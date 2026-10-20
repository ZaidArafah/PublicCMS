using System;
using System.Collections.Generic;
using System.Text;

namespace PublicCMS.Core.Models
{
    public class ForumComment
    {
        public int Id { get; set; }

       public int ForumPostId { get; set; }

        public string Content { get; set; } = "";
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public string AuthorName { get; set; } = "";
        public string AuthorProfileImageUrl { get; set; } = "";
    }
}
