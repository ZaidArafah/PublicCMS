using PublicCMS.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicCMS.Core.Repositories
{
    public interface IPageRepository
    {
        // hämta alla sidor
        List<Page> GetAllPages();

        // hämta en sida med id
        Page GetById(int id);

        // spara en ny sida
        void AddPage(Page page);
    }
}
