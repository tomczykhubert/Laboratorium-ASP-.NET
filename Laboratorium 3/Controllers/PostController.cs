using Laboratorium_3.Models;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Index()
        {
            return View(_postService.FindAll());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Post model)
        {
            model.Comments = new List<Comment>();
            model.PublicationDate = _dateTimeProvider.dateNow();
            if (ModelState.IsValid)
            {
                _postService.Add(model);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id) 
        {
            return View(_postService.FindById(id));

        }

        [HttpPost]
        public IActionResult Delete(Post model)
        {
            _postService.Delete(model.Id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update (int id)
        {
            return View(_postService.FindById(id));
        }

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
        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(_postService.FindById(id));

        }

        [HttpPost]
        public IActionResult Details(int postId, string author, string comment)
        {
            Post model = _postService.FindById(postId);
            if (model is null)
            {
                return Redirect(Request.Headers["Referer"].ToString());
            }
            model.Comments.Add(new Comment(){CommentId = model.Comments.Count + 1, Author = author, Content = comment, PublicationDate = _dateTimeProvider.dateNow()});
            if (ModelState.IsValid)
                _postService.Update(model);
            return View(_postService.FindById(model.Id));
        }
    }
}
