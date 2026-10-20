using System;
using System.Collections.Generic;
using System.Text;

namespace PublicCMS.Core.Models
{
    public class ForumPost
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public string Title { get; set; } = "";
        public string Content { get; set; } = "";

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public string AuthorName { get; set; } = "";
        public string AuthorProfileImageUrl { get; set; } = "";

        public int Likes { get; set; } = 0;

        public string? ImageUrl { get; set; } = null;
    }
}
