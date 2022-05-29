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
    public class PeopleController : Controller
    {
        private readonly ILogger<PostController> _logger;
        private readonly IPersonRepository _person;
        public PeopleController(IPersonRepository person,
            ILogger<PostController> logger )
        {
            _person = person;
            _logger = logger;
        }
        // GET: PersonController
        public ActionResult People(string name)
        {
            ViewBag.CountPeople = _person.CountPeople();
            var people = _person.List();
            
            if (string.IsNullOrWhiteSpace(name))
                return View(people);
            var PeopleGet = _person.GetPeopleWithName(name);
                return View(PeopleGet);
        }

        // GET: PersonController/Details/5
        public ActionResult DetailsPerson(int id)
        {
            var person = _person.Find(id);
            return View(person);
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
            _person.Add(person);
            return RedirectToAction("People", "People");
        }

        // GET: PersonController/Edit/5
        public ActionResult EditPerson(int id)
        {
            var person = _person.Find(id);
            return View(person);
        }

        // POST: PersonController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPerson(int id, Person person)
        {
            _person.Update(id, person);
            return RedirectToAction("people", "people");
        }

        // GET: PersonController/Delete/5
        public ActionResult RemovePerson(int id)
        {
            var person = _person.Find(id);
            return View(person);
        }

        // POST: PersonController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RemovePerson(Person person)
        {
            _person.Remove(person);
            return RedirectToAction("People","People");
        }

        public ActionResult DOB(string name, int? month)
        {
            //var list = _person.GetPersonEventAttendanceByEventIdAndPersonArea("3", 1);
            //var list = _event.GetEventAttendancesByPersonArea();

            var people = _person.List();
            if (month == null && string.IsNullOrWhiteSpace(name))
                return View(people);
            //var birthPeople = _person.GetPeopleThatHasBirthDayInMonth(month.Value);
            var birthPeople = _person.GetPeopleWithNameAndMonth(name, month);
            return View(birthPeople);
        }

    }
}
