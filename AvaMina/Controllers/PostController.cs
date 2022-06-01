using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AvaMina.Models;
using AvaMina.Repositories;
using System;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using AvaMina.Services;

namespace AvaMina.Controllers
{
    [Authorize(Roles = "User")]
    public class PostController : Controller
    {
        private readonly ILogger<PostController> _logger;
        private readonly IPostsService _postsService;

        public PostController(ILogger<PostController> logger,
            IPostsService postsService)
        {
            _postsService = postsService;
            _logger = logger;
            
        }
        
        // GET: PostController
        public ActionResult Posts()
        {
            return View(_postsService.GetAll());
        }

        // GET: PostController/Details/5
        //public ActionResult Details(int id)
        //{
        //   var post = _postsService.GetById(id);
        //    return View(post);
        //}

        // GET: PostController/Create
        public ActionResult CreatePost()
        {
            return View();
        }

        // POST: PostController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePost(Post newPost)
        {
            newPost.CreateDate = DateTime.Now;
            _postsService.Add(newPost);
            return RedirectToAction("Posts", "Post");

        }

        // GET: PostController/Edit/5
        public ActionResult EditPost(int id)
        {
            return View(_postsService.GetById(id));
        }

        // POST: PostController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int id, Post post)
        {
            post.CreateDate = DateTime.Now;
            _postsService.Update(id, post);
            return RedirectToAction("Posts", "Post");
        }

        // GET: PostController/Delete/5
        public ActionResult DeletePost(int id)
        {
            return View(_postsService.GetById(id));
        }

        // POST: PostController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id, Post post)
        {
            _postsService.Delete(post);
            return RedirectToAction("Posts", "Post");
        }
    }
}
