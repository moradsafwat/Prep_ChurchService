using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AvaMina.Models;
using AvaMina.Repositories;
using System;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

namespace AvaMina.Controllers
{
    [Authorize(Roles = "User")]
    public class PostController : Controller
    {
        private readonly ILogger<PostController> _logger;
        private readonly IPostRepository _post;

        public PostController(ILogger<PostController> logger,
            IPostRepository post)
        {
            _post = post;
            _logger = logger;
            
        }
        
        // GET: PostController
        public ActionResult Posts()
        {
            var posts = _post.List().OrderByDescending(x => x.CreateDate);
            return View(posts);
        }

        // GET: PostController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

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
            _post.Add(newPost);
            return RedirectToAction("Posts", "Post");

        }

        // GET: PostController/Edit/5
        public ActionResult EditPost(int id)
        {
            var post = _post.Find(id);
            return View(post);
        }

        // POST: PostController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int id, Post post)
        {
            post.CreateDate = DateTime.Now;
            _post.Update(id, post);
            return RedirectToAction("Posts", "Post");
        }

        // GET: PostController/Delete/5
        public ActionResult DeletePost(int id)
        {
            var post = _post.Find(id);
            return View(post);
        }

        // POST: PostController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id, Post post)
        {
            _post.Remove(post);
            return RedirectToAction("Posts", "Post");
        }
    }
}
