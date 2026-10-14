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


            builder.Services.AddScoped<IPageRepository, PageRepository>();

            builder.Services.AddAuthentication(Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.AuthenticationScheme)
             .AddCookie(options =>
            {
              options.LoginPath = "/login";
            });
           
            
            builder.Services.AddCascadingAuthenticationState();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
            app.UseHttpsRedirection();

            app.UseAntiforgery();

            app.MapStaticAssets();
            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapPost("/api/login", async (HttpContext ctx, PublicCMS.Core.Repositories.IUserRepository userRepo) =>
            {
                var form = await ctx.Request.ReadFormAsync();
                string username = form["username"].ToString();
                string password = form["password"].ToString();

                // 1. Släpp alltid in Admin till admin-sidorna (som förut)
                if (username == "admin" && password == "1234")
                {
                    var adminClaims = new List<System.Security.Claims.Claim> {
            new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Name, "admin")
        };
                    var adminIdentity = new System.Security.Claims.ClaimsIdentity(adminClaims, "Cookies");
                    await Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.SignInAsync(ctx, "Cookies", new System.Security.Claims.ClaimsPrincipal(adminIdentity));
                    ctx.Response.Redirect("/admin/kategorier");
                    return;
                }

                // 2. Kolla databasen om en vanlig användare försöker logga in
                var user = userRepo.GetByUsername(username);
                if (user != null && user.PasswordHash == password)
                {
                    var userClaims = new List<System.Security.Claims.Claim> {
            new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Name, user.Username),
            new System.Security.Claims.Claim("ProfileImage", user.ProfileImageUrl ?? "") // Vi sparar bilden i ID-kortet!
        };
                    var userIdentity = new System.Security.Claims.ClaimsIdentity(userClaims, "Cookies");
                    await Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.SignInAsync(ctx, "Cookies", new System.Security.Claims.ClaimsPrincipal(userIdentity));

                    ctx.Response.Redirect("/"); // Skicka vanliga användare till startsidan
                    return;
                }

                // 3. Om fel lösenord eller om användaren inte finns
                ctx.Response.Redirect("/login");
            }).DisableAntiforgery();



            app.Run();
        }
    }
}
