using Microsoft.EntityFrameworkCore;
using AvaMina.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AvaMina.Data;

namespace AvaMina.Repositories
{
    public class EventRepository : Repository<Event>, IEventRepository
    {
        public EventRepository(ApplicationDbContext _db):base(_db)
        {

        }

        public IEnumerable<Event> GetEventWithPeople()
        {
            return db.Events.Include(p => p.People).ToList() ;
        }
    }
}
