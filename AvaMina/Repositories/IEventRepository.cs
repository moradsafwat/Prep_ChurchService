using AvaMina.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvaMina.Repositories
{
    public interface IEventRepository : IRepository<Event>
    {
        IEnumerable<Event> GetEventWithPeople();
    }
}
