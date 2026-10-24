using System;
using System.Collections.Generic;
using System.Text;

namespace PublicCMS.Core.Models
{
    public class Page
    {
        
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Bodytext { get; set; }
        public string ImageUrl { get; set; } = "";
        public string CssStyle { get; set; } = "";

        public bool IsPublished { get; set; } = true;

    }
}
