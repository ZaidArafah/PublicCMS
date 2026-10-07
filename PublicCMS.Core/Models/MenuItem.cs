using System;
using System.Collections.Generic;
using System.Text;

namespace PublicCMS.Core.Models
{
    public class MenuItem
    {
        // id för menyval
        public int Id { get; set; }

        // namn på menyval som besökaren killar på
        public string Name { get; set; }

        // addressen till sidan som besökaren ska skickas till när hen klickar på menyvalet
        public string Url { get; set; }

        // sorteringsordning för menyvalet
        public string SortOrder { get; set; }
    }
}
