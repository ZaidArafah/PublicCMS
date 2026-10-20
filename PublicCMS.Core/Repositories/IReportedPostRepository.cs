using PublicCMS.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicCMS.Core.Repositories
{
    public interface IReportedPostRepository
    {
        void AddReport(ReportedPost report);
        List<ReportedPost> GetAllReports();
        void DeleteReport(int id);
    }
}
