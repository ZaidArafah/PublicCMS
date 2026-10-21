using PublicCMS.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicCMS.Web.Repositories
{
    public interface IForumCommentRepository
    {
        void Add(ForumComment comment);
        List<ForumComment> GetCommentsByPost(int postId);

        void Delete(int id);

    }
}
