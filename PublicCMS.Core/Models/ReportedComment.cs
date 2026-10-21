using System;
using System.Collections.Generic;
using System.Text;

namespace PublicCMS.Core.Models
{
    public class ReportedComment
    {
        public int Id { get; set; }
        public int CommentId { get; set; }
        public string Reason { get; set; } = "";
        public string ReportedBy { get; set; } = "";
        public DateTime ReportedAt { get; set; } = DateTime.Now;
    }
}
