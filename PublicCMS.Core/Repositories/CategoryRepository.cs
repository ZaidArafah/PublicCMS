using PublicCMS.Core.Data;
using PublicCMS.Core.Models;

namespace PublicCMS.Web.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public List<Category> GetAll()
        {
            return _context.Categories.ToList();
        }
    }
}