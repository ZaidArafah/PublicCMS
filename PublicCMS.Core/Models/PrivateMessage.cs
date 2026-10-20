using System;
using System.Collections.Generic;
using System.Text;

namespace PublicCMS.Core.Models
{
    public class PrivateMessage
    {
        public int Id {get; set;}
        
        public string SenderName {get; set;}= string.Empty;
        public string ReceiverName {get; set;}= string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime SentAt { get; set; } = DateTime.Now;

    }
}
