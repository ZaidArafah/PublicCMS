using PublicCMS.Core.Models;

namespace PublicCMS.Web.Repositories
{
    public interface ICategoryRepository
    {
        void Add(Category category);
        List<Category> GetAll();
    }
}