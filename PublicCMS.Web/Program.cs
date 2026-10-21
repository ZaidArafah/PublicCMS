using Microsoft.EntityFrameworkCore;
using PublicCMS.Core.Data;
using PublicCMS.Core.Repositories;
using PublicCMS.Web.Components;
using PublicCMS.Web.Repositories;

namespace PublicCMS.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            // det tilläggs för att kunna använda Entity Framework Core med SQL Server
            builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddControllers();

            builder.Services.AddScoped<IPageRepository, PageRepository>();

            builder.Services.AddScoped<IForumPostRepository, ForumPostRepository>();

            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

            builder.Services.AddScoped<IPrivateMessageRepository, PrivateMessageRepository>();

            builder.Services.AddScoped<IReportedPostRepository, ReportedPostRepository>();

            builder.Services.AddScoped<IReportedCommentRepository, ReportedCommentRepository>();

            builder.Services.AddAuthentication(Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.AuthenticationScheme)
             .AddCookie(options =>
            {
                options.LoginPath = "/login";
            });


            builder.Services.AddScoped<IForumCommentRepository, ForumCommentRepository>();

            builder.Services.AddCascadingAuthenticationState();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
               
                app.UseHsts();
            }

            app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
            app.UseHttpsRedirection();

            app.UseAntiforgery();

            app.UseStaticFiles();

            app.MapStaticAssets();
            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.MapPost("/api/login", async (HttpContext ctx, PublicCMS.Core.Repositories.IUserRepository userRepo)  =>
            {
                var form = await ctx.Request.ReadFormAsync();
                string username = form["username"].ToString();
                string password = form["password"].ToString();

                //  Släpp in den inbyggda Admin till admin-sidorna
                if (username == "admin" && password == "1234")
                {
                    var adminClaims = new List<System.Security.Claims.Claim> {
            new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Name, "admin"),
            new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Role, "Admin") // Ger admin-rättigheter
        };
                    var adminIdentity = new System.Security.Claims.ClaimsIdentity(adminClaims, "Cookies");
                    await Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.SignInAsync(ctx, "Cookies", new System.Security.Claims.ClaimsPrincipal(adminIdentity));

                    ctx.Response.Redirect("/admin/kategorier");
                    return;
                }

                // Kolla databasen om en vanlig användare eller databas-admin försöker logga in
                var user = userRepo.GetByUsername(username);
                if (user != null && user.PasswordHash == password)
                {
                    var userClaims = new List<System.Security.Claims.Claim> {
            new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Name, user.Username),
            new System.Security.Claims.Claim("ProfileImage", user.ProfileImageUrl ?? "")
        };

                    // ge dem administratörsrättigheter till admin-sidorna om de är admin
                    if (user.Username.ToLower() == "admin")
                    {
                        userClaims.Add(new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Role, "Admin"));
                    }

                    var userIdentity = new System.Security.Claims.ClaimsIdentity(userClaims, "Cookies");
                    await Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.SignInAsync(ctx, "Cookies", new System.Security.Claims.ClaimsPrincipal(userIdentity));

                    ctx.Response.Redirect("/"); 
                    return;
                }

                ctx.Response.Redirect("/login?error=true");
            }).DisableAntiforgery();

            app.MapGet("/api/logout", async (HttpContext ctx) =>
            {
                await Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.SignOutAsync(ctx, "Cookies");
                ctx.Response.Redirect("/");
            });


            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<PublicCMS.Core.Data.AppDbContext>();
                dbContext.Database.Migrate();
            }

            app.MapGet("/api/inlagg/{postId}/komplett", (int postId, IForumPostRepository postRepo, IForumCommentRepository commentRepo) =>
            {
                // 1. Hämta alla inlägg och hitta det som matchar vårt ID
                var inlagg = postRepo.GetById(postId);

                if (inlagg == null)
                {
                    return Results.NotFound(new { message = "Inlägget hittades inte." });
                }

                // 2. Hämta kommentarerna och filtrera fram de som tillhör just detta inlägg
                // OrderByDescending sorterar dem så att den nyaste kommentaren hamnar överst!
                var kommentarer = commentRepo.GetCommentsByPost(postId)
                                             .OrderByDescending(c => c.CreatedAt)
                                             .ToList();

                // 3. Baka ihop inlägget och kommentarerna till ett gemensamt paket
                var komplettResultat = new
                {
                    Inlagg = inlagg,
                    Kommentarer = kommentarer
                };

                return Results.Ok(komplettResultat);
            });


            app.Run();

        }
    }
}
