using PublicCMS.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicCMS.Core.Repositories
{
    public interface IPageRepository
    {
        List<Page> GetAll();
        Page GetById(int id);
        void Add(Page page);

        void Delete(int id);
        void Update(Page editPage);
    }
}
