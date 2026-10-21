using PublicCMS.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicCMS.Core.Repositories
{
    public interface IReportedCommentRepository 
    {
        void Add(ReportedComment report);

        List<ReportedComment> GetAll();
        void Delete(int id);
    }
}
