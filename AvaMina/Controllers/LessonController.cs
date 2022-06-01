using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AvaMina.Models;
using AvaMina.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using AvaMina.Services;

namespace AvaMina.Controllers
{
    [Authorize(Roles = "User")]
    public class LessonController : Controller
    {
        private readonly ILogger<LessonController> _logger;
        private readonly ILessonsService _lessonsService;

        public LessonController(ILogger<LessonController> logger, ILessonsService lessonsService)
        {
            _logger = logger;
            _lessonsService = lessonsService;
        }

        // GET: LessonController
        public ActionResult Lessons()
        {
            return View(_lessonsService.GetAll());
        }

        // GET: LessonController/Details/5
        public ActionResult DetailsLesson(int id)
        {
            return View(_lessonsService.GetById(id));
        }

        // GET: LessonController/Create
        public ActionResult CreateLesson()
        {
            return View();
        }

        // POST: LessonController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateLesson(Lesson  lesson)
        {
            _lessonsService.Add(lesson);
            return RedirectToAction("Lessons", "Lesson");
        }

        // GET: LessonController/Edit/5
        public ActionResult EditLesson(int id)
        {
            return View(_lessonsService.GetById(id));
        }

        // POST: LessonController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditLesson(int id, Lesson lesson)
        {
            _lessonsService.Update(id, lesson);
            return RedirectToAction("Lessons", "Lesson");
        }

        // GET: LessonController/Delete/5
        public ActionResult RemoveLesson(int id)
        {
            return View(_lessonsService.GetById(id));
        }

        // POST: LessonController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveLesson(Lesson lesson)
        {
            _lessonsService.Delete(lesson);
            return RedirectToAction("Lessons", "Lesson");
        }
    }
}
