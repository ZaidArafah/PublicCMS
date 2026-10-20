using PublicCMS.Core.Models;
using PublicCMS.Core.Data;
using PublicCMS.Web.Repositories;

namespace PublicCMS.Web.Repositories
{
    public class ForumCommentRepository : IForumCommentRepository
    {
        private readonly AppDbContext _context;

       

        public ForumCommentRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(ForumComment comment)
        {
            _context.ForumComments.Add(comment);
            _context.SaveChanges();
        }

        public List<ForumComment> GetCommentsByPost(int postId)
        {
            return _context.ForumComments
                           .Where(c => c.ForumPostId == postId)
                           .OrderBy(c => c.CreatedAt)
                           .ToList();
        }
    }
}