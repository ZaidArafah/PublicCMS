using Microsoft.AspNetCore.Mvc;
using PublicCMS.Core.Repositories;
using PublicCMS.Web.Repositories;
using System.Linq;

namespace PublicCMS.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForumApiController : ControllerBase
    {
        private readonly IForumPostRepository _postRepo;

        public ForumApiController(IForumPostRepository postRepo)
        {
            _postRepo = postRepo;
        }

        [HttpGet("diskussion/{categoryId}")]
        public IActionResult GetPostsForDiscussion(int categoryId)
        {
            var posts = _postRepo.GetByCategoryId(categoryId);

            if (posts == null || !posts.Any())
            {
                return NotFound("Inga inlägg hittades för denna diskussion.");
            }
            return Ok(posts);
        }
    }
}