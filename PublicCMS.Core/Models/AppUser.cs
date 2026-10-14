using System;
using System.Collections.Generic;
using System.Text;

namespace PublicCMS.Core.Models
{
    public class AppUser
    {
        public int Id { get; set; }

        public string Username { get; set; } = "";

        public string PasswordHash { get; set; } = "";

        public string ProfileImageUrl { get; set; } = "";
    }
}
