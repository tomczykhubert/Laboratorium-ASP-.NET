using Data;
using Laboratorium_3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Laboratorium_3.Controllers
{
    [Route("api/posts")]
    [ApiController]
    public class PostApiController : ControllerBase
    {
        private readonly AppDbContext _context;
        public PostApiController(AppDbContext context)
        {
            _context = context;
        }

        [Route("{id}")]
        public IActionResult GetPostsByTag(int id)
        {

            var posts = _context.Posts.Where(o => o.TagId == id).Select(o => new {id = o.PostId, author = o.Author, content = o.Content, tagId = o.TagId, publicationDate = o.PublicationDate}).ToList();
            return posts.Count == 0 ? NotFound() : Ok(posts);
        }
    }
}
