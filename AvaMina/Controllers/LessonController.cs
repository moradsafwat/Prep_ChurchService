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

namespace AvaMina.Controllers
{
    [Authorize(Roles = "User")]
    public class LessonController : Controller
    {
        private readonly ILogger<LessonController> _logger;
        private readonly ILessonRepository _lesson;
        public LessonController(ILogger<LessonController> logger, ILessonRepository lesson)
        {
            _lesson = lesson;
            _logger = logger;
        }
        // GET: LessonController
        public ActionResult Lessons()
        {
            var lessons = _lesson.List().OrderBy(d =>d.Date);
            return View(lessons);
        }

        // GET: LessonController/Details/5
        public ActionResult DetailsLesson(int id)
        {
            var lesson = _lesson.Find(id);
            return View(lesson);
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
            _lesson.Add(lesson);
            return RedirectToAction("Lessons", "Lesson");
        }

        // GET: LessonController/Edit/5
        public ActionResult EditLesson(int id)
        {
            var lesson = _lesson.Find(id);
            return View(lesson);
        }

        // POST: LessonController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditLesson(int id, Lesson lesson)
        {
            _lesson.Update(id, lesson);
            return RedirectToAction("Lessons", "Lesson");
        }

        // GET: LessonController/Delete/5
        public ActionResult RemoveLesson(int id)
        {
            var lesson = _lesson.Find(id);
            return View(lesson);
        }

        // POST: LessonController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveLesson(Lesson lesson)
        {
            _lesson.Remove(lesson);
            return RedirectToAction("Lessons", "Lesson");
        }
    }
}
