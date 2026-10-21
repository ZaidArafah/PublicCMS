using Microsoft.EntityFrameworkCore;
using PublicCMS.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicCMS.Core.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Page> Pages { get; set; }

        public DbSet<MenuItem> MenuItems { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<AppUser> Users { get; set; }

        public DbSet<ForumPost> ForumPosts { get; set; }

        public DbSet<ForumComment> ForumComments { get; set; }

        public DbSet<PrivateMessage> PrivateMessages { get; set; }

        public DbSet<ReportedPost> ReportedPosts { get; set; }

        public DbSet<ReportedComment> ReportedComments { get; set; }
    }
}
 