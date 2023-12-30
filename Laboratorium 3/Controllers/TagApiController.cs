using Data;
using Laboratorium_3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorium_3.Controllers
{
    [Route("api/tags")]
    [ApiController]
    public class TagApiController : ControllerBase
    {
        private readonly AppDbContext _context;
        public TagApiController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult GetAllTags()
        {
            var tags = _context.Tags.Select(o => new {id = o.TagId, tagName = o.TagName}).ToList();
            return Ok(tags);
        }
    }
}