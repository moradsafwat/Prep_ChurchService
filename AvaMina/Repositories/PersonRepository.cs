using Microsoft.EntityFrameworkCore;
using AvaMina.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AvaMina.Data;

namespace AvaMina.Repositories
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(ApplicationDbContext _db) : base(_db)
        {
        }

        public IEnumerable<Person> GetCountPeople()
        {
            return db.People.ToList<Person>();
        }

        public IEnumerable<Person> GetPeopleThatHasBirthDayInMonth(int month)
        {
            return db.People.Where(x => x.DateOfBirth.Date.Month == month).ToList();
        }

        public IEnumerable<Person> GetPeopleWithNameAndMonth(string name, int? month)
        {
            return db.People.Where(x => x.DateOfBirth.Date.Month == month || x.FirstName.Contains(name)).ToList();
        }
        public IEnumerable<Person> GetPeopleWithName(string name)
        {
            return db.People.Where(n => n.FirstName.Contains(name)).ToList();
        }

        public IEnumerable<Person> GetPeopleWithEvent(int eventId) {
            // Join with event person
            return db.People.Include(x => x.Events.Where(x => x.Id == eventId)).ToList();
        }

        public int CountPeople()
        {
            return db.People.Count();
        }
        public IEnumerable<Person> GetNameWithId()
        {
            return db.People.ToList();
        }
    }
}
