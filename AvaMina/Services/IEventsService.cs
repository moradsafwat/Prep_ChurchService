using AvaMina.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvaMina.Services
{
    public interface IEventsService
    {
        IEnumerable<Event> GetAll();
        Event GetById(int id);
        Event Add(Event eveent);
        Event Delete(Event eveent);
        Event Update(int id, Event eveent);
    }
}
