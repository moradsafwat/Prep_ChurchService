using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AvaMina.Models;
using AvaMina.Repositories;
using AvaMina.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace AvaMina.Controllers
{
    [Authorize(Roles = "User")]
    public class EventController : Controller
    {
        private readonly ILogger<EventController> _logger;
        private readonly IEventRepository _event;
        private readonly IPersonRepository _person;

        public EventController(ILogger<EventController> logger,
            IEventRepository ev,
            IPersonRepository person)
        {
            _logger = logger;
            _event = ev;
            _person = person;
        }
        public IActionResult CreateEvent()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateEvent(Event eveent)
        {
            _event.Add(eveent);
            return RedirectToAction("EventAttendance", "Event");
        }

        public IActionResult EditEvent(int id)
        {
            var item = _event.Find(id);
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditEvent(int id, Event eveent)
        {
            _event.Update(id, eveent);
            return RedirectToAction("EventAttendance", "Event");
        }

        public ActionResult DeleteEvent(int id)
        {
            return View(_event.Find(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteEvent(Event eveent)
        {
             _event.Remove(eveent);
            return RedirectToAction("EventAttendance","Event");
        }

        public IActionResult EventAttendance(int? selectedEventId)
        {
            EventPeopleViewModel vm = new EventPeopleViewModel()
            {
                Events = _event.List().OrderByDescending(x => x.Date)
            };
            if (selectedEventId != null)
            {
                vm.personEventAttendances = _person.GetPeopleWithEvent(selectedEventId.Value)
                    // Mapping IEnumerable<Person> to IEnumerable<PersonEventAttendanceViewModel>
                    .Select(x => new PersonEventAttendanceViewModel
                    {
                        Person = x,
                        currentIsAttendent = x.Events.Any(),
                        previousIsAttendent = x.Events.Any()
                    }).ToList();
                vm.selectedEvent = vm.Events.FirstOrDefault(x => x.Id == selectedEventId);

                ViewBag.Current = vm.personEventAttendances.Count(c => c.currentIsAttendent);
                ViewBag.Previous = vm.personEventAttendances.Count(c => !c.previousIsAttendent);
            }
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EventAttendance(EventPeopleViewModel eventPeopleViewModel)
        {
            // Create EventPerson Model
            //جبنا كل الاطفال عشان نقدر نحفظها في الداتا 
            //بنجيب الايفينت اللي هيتضاف / اللي هيتشال من الاطفال
            // بلف علي كل الاطفال و نشوف الحالة بتاعته حاضر / غائب و تم تغيرها 
            //لو حاضر بضيفه لليست الايفنتات بتاعة الطفل 
            //لو لم يحضر بيتشال منهم 

            var personsToBeUpdated = _person.GetPeopleWithEvent(eventPeopleViewModel.selectedEvent.Id);
            var currentEvent = _event.Find(eventPeopleViewModel.selectedEvent.Id);
            Person person;
            IList<Person> updatedPersons = new List<Person>();
            foreach (var eventPerson in eventPeopleViewModel.personEventAttendances)
            {
                if (eventPerson.currentIsAttendent != eventPerson.previousIsAttendent)
                {
                    person = personsToBeUpdated.FirstOrDefault(x => x.Id == eventPerson.Person.Id);
                    if (eventPerson.currentIsAttendent)
                        person.Events.Add(currentEvent);
                    else
                        person.Events.Remove(currentEvent);
                    updatedPersons.Add(person);
                    //_person.Update(person.Id, person);
                }
            }
            if (updatedPersons.Any())
            {
                _person.UpdateRange(updatedPersons);
            }
            //return RedirectToAction("EventAttendance", new { selectedEventId = eventPeopleViewModel.selectedEvent.Id });
            return RedirectToAction("EventAttendance", "Event");
            //return RedirectToAction("People", "People");

        }
    }
}
