﻿using restapp.Model;
using System.Net;
using System.Reflection;

namespace restapp.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private volatile int count;

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
            
        }

        public List<Person> FindAll()
        {
            List<Person> persons = new List<Person>();
            for (int i = 0; i < 8; i++)
            {
                Person person = MockPerson(i);
                persons.Add(person);
            }
            return persons;
        }

        public Person FindById(long id)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirtName = "Leandro",
                LastName = "Costa",
                Address = "Uberlândia - Minas Gerais - Brasil",
                Gender= "Male"
            };
        }

        public Person Update(Person person)
        {
            return person;
        }
        private Person MockPerson(int i)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirtName = "Nome da pessoa" + i,
                LastName = "Último nome"+i,
                Address = "Cidade e Estado que reside" + i,
                Gender = (i % 2 == 0) ? "Male" : "Female"
            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }
    }
}
