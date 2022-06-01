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
    public class PeopleController : Controller
    {
        private readonly ILogger<PostController> _logger;
        private readonly IPeopleService _peopleService;

        public PeopleController(ILogger<PostController> logger, IPeopleService peopleService)
        {
            _logger = logger;
            _peopleService = peopleService;
        }

        // GET: PersonController
        public ActionResult People(string name)
        {
            ViewBag.CountPeople = _peopleService.CountPeople();
            var people = _peopleService.GetAll();
            
            if (string.IsNullOrWhiteSpace(name))
                return View(people);
            var PeopleGet = _peopleService.GetPeopleByname(name);
                return View(PeopleGet);
        }

        // GET: PersonController/Details/5
        public ActionResult DetailsPerson(int id)
        {
            return View(_peopleService.GetById(id));
        }

        // GET: PersonController/Create
        public ActionResult CreatePerson()
        {
            return View();
        }

        // POST: PersonController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePerson(Person person)
        {
            if (!ModelState.IsValid)
                return View();
            _peopleService.Add(person);
            return RedirectToAction("People", "People");
        }

        // GET: PersonController/Edit/5
        public ActionResult EditPerson(int id)
        {
            return View(_peopleService.GetById(id));
        }

        // POST: PersonController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPerson(int id, Person person)
        {
            _peopleService.Update(id, person);
            return RedirectToAction("people", "people");
        }

        // GET: PersonController/Delete/5
        public ActionResult RemovePerson(int id)
        {
            return View(_peopleService.GetById(id));
        }

        // POST: PersonController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RemovePerson(Person person)
        {
            _peopleService.Delete(person);
            return RedirectToAction("People","People");
        }

        public ActionResult DOB(string name, int? month)
        {
            //var list = _person.GetPersonEventAttendanceByEventIdAndPersonArea("3", 1);
            //var list = _event.GetEventAttendancesByPersonArea();

            var people = _peopleService.GetAll();
            if (month == null && string.IsNullOrWhiteSpace(name))
                return View(people);
            //var birthPeople = _person.GetPeopleThatHasBirthDayInMonth(month.Value);
            var birthPeople = _peopleService.GetPeopleWithNameAndMonth(name, month);
            return View(birthPeople);
        }

    }
}
