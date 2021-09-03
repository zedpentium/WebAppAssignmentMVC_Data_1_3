using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppAssignmentMVC_Data_1_3.Models;

namespace WebAppAssignmentMVC_Data_1_3.Data
{
    public class DbPeopleRepo : IPeopleRepo
    {
        private readonly PeopleDbContext _peopleListContext;

        public DbPeopleRepo(PeopleDbContext peopleListContext)
        {
            _peopleListContext = peopleListContext;

        }

        public void CreateBasePersons()
        {
            Create("Eric Rönnhult", "0777 777777", "Tiesto");
            Create("Bosse Bus", "0777 777777", "Flen");
            Create("Kjell Kriminell", "0777 777777", "Burg");
            Create("Anders Rolle", "0777 777777", "Götet");
            /*_peopleListContext.Add(new Person() { PersonName = "Eric Rönnhult", PersonPhoneNumber = "0777 777777", PersonCity = "Tiesto" });
            _peopleListContext.Add(new Person() { PersonName = "Bosse Bus", PersonPhoneNumber = "0777 777777", PersonCity = "Flen" });
            _peopleListContext.Add(new Person() { PersonName = "Kjell Kriminell", PersonPhoneNumber = "0777 777777", PersonCity = "Burg" });
            _peopleListContext.Add(new Person() { PersonName = "Anders Rolle", PersonPhoneNumber = "0777 777777", PersonCity = "Götet" });
            */
        }

       public Person Create(string PersonName, string PersonPhoneNumber, string PersonCity)
        {
            Person newPerson = new Person(PersonName, PersonPhoneNumber, PersonCity);

            _peopleListContext.Add(newPerson);
            _peopleListContext.SaveChanges();

            return newPerson;
        }

        
        public List<Person> Read()
        {
            List<Person> pList = _peopleListContext.People.ToList();
            if (pList.Count == 0)
            {
                CreateBasePersons();
                pList = _peopleListContext.People.ToList();
            }

            return pList;
        }

        public Person Read(int id)
        {
            return _peopleListContext.People.Find(id);
        }

        public Person Update(Person person)
        {
            _peopleListContext.People.Update(person);
            _peopleListContext.SaveChanges();

            return person;
        }

        public bool Delete(Person person)
        {
            int nrStates;

            _peopleListContext.People.Remove(person);
            nrStates = _peopleListContext.SaveChanges();

            if (nrStates == 1)
            {
                return true;
            }

            return false;


        }

    }
}
