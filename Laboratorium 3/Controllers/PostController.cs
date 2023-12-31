﻿using Laboratorium_3.Models;
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
        public IActionResult Index(int tagId = 0)
        {
            ViewBag.TagId = tagId;
            if (tagId == 0)
                return View(_postService.FindAll());
            else
                return View(_postService.FindByTag(tagId));
        }

        [AllowAnonymous]

        public IActionResult PagedIndex(int tagId = 0, int page = 1, int size = 2)
        {
            List<Post> list = new List<Post>();
            if (tagId == 0)
                list = _postService.FindAll();
            else
                list = _postService.FindByTag(tagId);
            ViewBag.TagId = tagId;
            PagingList<Post> pagingList = _postService.FindPage(page, size, list);
            return View(pagingList);
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
                return RedirectToAction("PagedIndex");
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
            return RedirectToAction("PagedIndex");
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
                return RedirectToAction("PagedIndex");
            }
            return View();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Details(int id)
        {
            var model = _postService.FindById(id);
            return model is null ? NotFound() : View(model);
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddComment(int postId, string author, string content)
        {
            Comment comment = new Comment() { Author = author, Content = content, PostId = postId, PublicationDate = _dateTimeProvider.dateNow() };
            var posts = _postService.FindAll();
            foreach (var post in posts)
            {
                if(post.Id == postId)
                {
                    _postService.AddComment(comment);
                    return RedirectToAction("Details", new { id = postId });
                }
            }
            return RedirectToAction("PagedIndex");
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult DeleteComment(int commentId)
        {
            _postService.DeleteComment(commentId);
            return Redirect(Request.Headers["Referer"]);
        }
    }
}
