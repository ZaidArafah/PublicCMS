using PublicCMS.Core.Data;
using PublicCMS.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicCMS.Core.Repositories
{
    public class ReportedCommentRepository : IReportedCommentRepository
    {
        private readonly AppDbContext _context;

        public ReportedCommentRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(ReportedComment report)
        {
            _context.ReportedComments.Add(report);
            _context.SaveChanges();
        }
        public List<ReportedComment> GetAll()
        {
            return _context.ReportedComments.ToList();
        }

        public void Delete(int id)
        {
            var report = _context.ReportedComments.FirstOrDefault(r => r.Id == id);
            if (report != null)
            {
                _context.ReportedComments.Remove(report);
                _context.SaveChanges();
            }
        }
    }
}
