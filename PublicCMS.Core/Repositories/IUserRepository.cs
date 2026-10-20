using PublicCMS.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicCMS.Core.Repositories
{
    public interface IUserRepository
    {
        void Add(AppUser user);
        AppUser GetByUsername(string username);

        List<AppUser> GetAll();

        void Delete(int id);
    }
}
