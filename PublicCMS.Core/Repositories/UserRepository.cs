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

        public List<AppUser> GetAll()
        {
            return _context.Users.ToList();
        }

        public void Delete(int id)
        {
           var user = _context.Users.Find(id); // Leta upp användaren med rätt ID
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }
    }
}