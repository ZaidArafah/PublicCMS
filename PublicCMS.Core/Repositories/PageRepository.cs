using PublicCMS.Core.Data;
using PublicCMS.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicCMS.Core.Repositories
{
    public class PageRepository : IPageRepository
    {
        private readonly AppDbContext _context;

        public PageRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Page> GetAll()
        {
            return _context.Pages.ToList();
        }

        public Page GetById(int id)
        {
            return _context.Pages.FirstOrDefault(p => p.Id == id);
        }

        public void Add(Page page)
        {
            _context.Pages.Add(page);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var page = _context.Pages.Find(id);
            if (page != null)
            {
                _context.Pages.Remove(page);
                _context.SaveChanges();
            }
        }


        public void Update(Page page)
        {
            _context.Pages.Update(page);
            _context.SaveChanges();
        }
    }
}
