using PublicCMS.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicCMS.Core.Repositories
{
    public interface IPageRepository
    {
        // hämta alla sidor
        List<Page> GetAll();

        // hämta en sida med id
        Page GetById(int id);

        // spara en ny sida
        void Add(Page page);
    }
}
