using AvaMina.Models;
using AvaMina.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvaMina.Services
{
    public class PeopleService : IPeopleService
    {
        private readonly IPersonRepository _person;

        public PeopleService(IPersonRepository person)
        {
            _person = person;
        }

        public IEnumerable<Person> GetAll()
        {
            return _person.List();
        }

        public Person GetById(int id)
        {
            return _person.Find(id);
        }
        public Person Add(Person person)
        {
            _person.Add(person);
            return person;
        }

        public Person Delete(Person person)
        {
            _person.Remove(person);
            return person;
        }

        

        public Person Update(int id, Person person)
        {
            _person.Update(id, person);
            return person;
        }

        public int CountPeople()
        {
            return _person.CountPeople();

        }

        public IEnumerable<Person> GetPeopleByname(string name)
        {
            return _person.GetPeopleWithName(name);
        }

        public IEnumerable<Person> GetPeopleWithNameAndMonth(string name, int? month)
        {
            return _person.GetPeopleWithNameAndMonth(name, month);
        }

        public IEnumerable<Person> GetPeopleWithEvent(int? selectedEventId)
        {
            throw new NotImplementedException();
        }
    }
}
