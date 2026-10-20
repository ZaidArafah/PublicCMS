using PublicCMS.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicCMS.Web.Repositories
{
    public interface IForumPostRepository
    {
        void Add (ForumPost post);
        List<ForumPost> GetPostsByCategory(int categoryId);

        ForumPost GetById(int id);

        void Delete(int id);

        void Update(ForumPost post);
        List<ForumPost> GetByCategoryId(int categoryId);
    }
}
