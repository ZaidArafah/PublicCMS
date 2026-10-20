using PublicCMS.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicCMS.Core.Repositories
{
    public interface IPrivateMessageRepository
    {
        void SendMessage(PrivateMessage message);
        List<PrivateMessage> GetMessagesForUser(string username);
    }
}
