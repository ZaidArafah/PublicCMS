using PublicCMS.Core.Data;
using PublicCMS.Core.Models;
using PublicCMS.Web.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicCMS.Core.Repositories
{
    public class ForumPostRepository : IForumPostRepository
    {
        private readonly AppDbContext _context;

        public ForumPostRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(ForumPost post)
        {
            _context.ForumPosts.Add(post);
            _context.SaveChanges();
        }

        public ForumPost GetById(int id)
        {
            return _context.ForumPosts.FirstOrDefault(p => p.Id == id);
        }

        public List<ForumPost> GetPostsByCategory(int categoryId)
        {
            return _context.ForumPosts
                .Where(p => p.CategoryId == categoryId).ToList()
                .OrderByDescending(p => p.CreatedAt)
                .ToList();
        }


        public void Delete(int id)
        {
            var post= _context.ForumPosts.Find(id);
            if (post != null)
            {
                _context.ForumPosts.Remove(post);
                _context.SaveChanges();
            }
        }

        public void Update(ForumPost post)
        {
            _context.ForumPosts.Update(post);
            _context.SaveChanges();
        }

        public List<ForumPost> GetByCategoryId(int categoryId)
        {
            return _context.ForumPosts
                .Where(p => p.CategoryId == categoryId)
                .OrderByDescending(p => p.CreatedAt)
                .ToList();
        }
    }
}
