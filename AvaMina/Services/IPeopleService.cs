using AvaMina.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvaMina.Services
{
    public interface IPeopleService
    {
        IEnumerable<Person> GetAll();
        int CountPeople();
        Person GetById(int id);
        Person Add(Person person);
        Person Delete(Person person);
        Person Update(int id, Person person);
        IEnumerable<Person> GetPeopleByname(string name);
        IEnumerable<Person> GetPeopleWithNameAndMonth(string name, int? month);
        IEnumerable<Person> GetPeopleWithEvent(int? selectedEventId);


    }
}
