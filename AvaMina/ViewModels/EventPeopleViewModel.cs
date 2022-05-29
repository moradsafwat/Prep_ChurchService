using AvaMina.Models;
using System.Collections.Generic;

namespace AvaMina.ViewModels
{
    public class EventPeopleViewModel
    {
        public IEnumerable<Event> Events { get; set; }
        public Event selectedEvent { get; set; }
        public List<PersonEventAttendanceViewModel> personEventAttendances { get; set; }
    }
}
