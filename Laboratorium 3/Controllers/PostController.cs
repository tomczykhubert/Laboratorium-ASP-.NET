using Laboratorium_3.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Reflection;
using System.Text.Json;

namespace Laboratorium_3.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        private readonly IDateTimeProvider _dateTimeProvider;

        public PostController(IPostService postService, IDateTimeProvider dateTimeProvider)
        {
            _postService = postService;
            _dateTimeProvider = dateTimeProvider;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View(_postService.FindAll());
        }
        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public IActionResult Create(Post model)
        {
            model.PublicationDate = _dateTimeProvider.dateNow();
            if (ModelState.IsValid)
            {
                _postService.Add(model);
                return RedirectToAction("Index");
            }
            return View();
        }
        [Authorize(Roles = "admin")]
        [HttpGet]
        public IActionResult Delete(int id) 
        {
            return View(_postService.FindById(id));

        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult Delete(Post model)
        {
            _postService.Delete(model.Id);
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "admin")]
        [HttpGet]
        public IActionResult Update (int id)
        {
            return View(_postService.FindById(id));
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult Update(Post model)
        {
            if (ModelState.IsValid)
            {
                _postService.Update(model);
                return RedirectToAction("Index");
            }
            return View();
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(_postService.FindById(id));
        }
        [Authorize]
        [HttpPost]
        public IActionResult AddComment(int postId, string author, string content)
        {
            Comment comment = new Comment() { CommentId = _postService.GetCommentId(), Author = author, Content = content, PostId = postId, PublicationDate = _dateTimeProvider.dateNow() };
            _postService.AddComment(comment);
            return Redirect(Request.Headers["Referer"]);
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult DeleteComment(int commentId)
        {
            Console.WriteLine(commentId);
            _postService.DeleteComment(commentId);
            return Redirect(Request.Headers["Referer"]);
        }
    }
}
