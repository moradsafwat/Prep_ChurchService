using AvaMina.Models;
using AvaMina.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvaMina.Services
{
    public class EventsService : IEventsService
    {
        private readonly IEventRepository _event;
        public EventsService(IEventRepository eveent)
        {
            _event = eveent;
        }

        public Event Add(Event eveent)
        {
            _event.Add(eveent);
            return eveent;
        }

        public Event Delete(Event eveent)
        {
            _event.Remove(eveent);
            return eveent;
        }

        public IEnumerable<Event> GetAll()
        {
            return _event.List().OrderByDescending(x => x.Date);
        }

        public Event GetById(int id)
        {
            return _event.Find(id);
        }

        public Event Update(int id, Event eveent)
        {
            _event.Update(id, eveent);
            return eveent;
        }
    }
}
