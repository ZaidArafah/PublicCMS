using System;
using System.Collections.Generic;
using System.Text;

namespace PublicCMS.Core.Models
{
    public class Page
    {
        
        public int Id { get; set; }

        // för sidan rubrik
        public string Title { get; set; }

        // huvudtexten på sidan
        public string Bodytext { get; set; }

        // URL till bild som visas på sidan
        public string ImageUrl { get; set; }

        // CSS-stil för sidan
        public string CssStyle { get; set; }

    }
}
