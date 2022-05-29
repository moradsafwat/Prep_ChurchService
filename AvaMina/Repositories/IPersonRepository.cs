using AvaMina.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvaMina.Repositories
{
    public interface IPersonRepository : IRepository<Person>
    {
        IEnumerable<Person> GetPeopleThatHasBirthDayInMonth(int month);
        IEnumerable<Person> GetPeopleWithNameAndMonth(string name, int? month);
        IEnumerable<Person> GetCountPeople();
        int CountPeople();
        IEnumerable<Person> GetPeopleWithName(string name);
        IEnumerable<Person> GetPeopleWithEvent(int eventId);
        IEnumerable<Person> GetNameWithId();
    }
}
