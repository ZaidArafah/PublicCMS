using PublicCMS.Core.Data;
using PublicCMS.Core.Models;
using PublicCMS.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace PublicCMS.Web.Repositories
{
    public class PrivateMessageRepository : IPrivateMessageRepository
    {
        private readonly AppDbContext _context;

        public PrivateMessageRepository(AppDbContext context)
        {
            _context = context;
        }

        public void SendMessage(PrivateMessage message)
        {
            _context.PrivateMessages.Add(message);
            _context.SaveChanges();
        }

        public List<PrivateMessage> GetMessagesForUser(string username)
        {
            // Hämtar alla meddelanden som har skickats TILL användaren
            return _context.PrivateMessages
                .Where(m => m.ReceiverName == username)
                .OrderByDescending(m => m.SentAt)
                .ToList();
        }
    }
}