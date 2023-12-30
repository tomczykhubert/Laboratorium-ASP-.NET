using Data;
using Data.Migrations;
using Laboratorium_3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorium_3.Controllers
{
    [Route("api/comments")]
    [ApiController]
    public class CommentApiController : ControllerBase
    {
        private readonly AppDbContext _context;
        public CommentApiController(AppDbContext context)
        {
            _context = context;
        }
        [Route("{id}")]
        public IActionResult GetCommentsByPostId(int id)
        {

            var comments = _context.Comments.Where(o => o.PostId == id).Select(o => new {id = o.CommentId, author = o.Author, content = o.Content, publicationDate = o.PublicationDate}).ToList();
            return comments.Count == 0 ? NotFound() : Ok(comments);
        }
    }
}