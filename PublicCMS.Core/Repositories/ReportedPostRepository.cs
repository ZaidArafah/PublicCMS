using PublicCMS.Core.Data;
using PublicCMS.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicCMS.Core.Repositories
{
    public class ReportedPostRepository : IReportedPostRepository
    {
        private readonly AppDbContext _context;

        public ReportedPostRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AddReport(ReportedPost report)
        {
            _context.ReportedPosts.Add(report);
            _context.SaveChanges();
        }

        public List<ReportedPost> GetAllReports()
        {
            // Hämtar alla anmälningar, nyaste först
            return _context.ReportedPosts.OrderByDescending(r => r.ReportedAt).ToList();
        }

        public void DeleteReport(int id)
        {
            var report = _context.ReportedPosts.Find(id);
            if (report != null)
            {
                _context.ReportedPosts.Remove(report);
                _context.SaveChanges();
            }
        }
    }
}