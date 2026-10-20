using System;
using System.Collections.Generic;
using System.Text;

namespace PublicCMS.Core.Models
{
    public class ReportedPost
    {
        public int Id { get; set; }

        public int ForumPostId { get; set; }

        public string ReportedBy { get; set; } = string.Empty;
        public string Reason { get; set; } = string.Empty;
        public DateTime ReportedAt { get; set; } = DateTime.Now;
    }
}
