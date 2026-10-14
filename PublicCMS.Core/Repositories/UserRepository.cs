using PublicCMS.Core.Data;
using PublicCMS.Core.Models;
using PublicCMS.Core.Repositories;


namespace PublicCMS.Web.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(AppUser user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public AppUser GetByUsername(string username)
        {
            return _context.Users.FirstOrDefault(u => u.Username == username);
        }
    }
}