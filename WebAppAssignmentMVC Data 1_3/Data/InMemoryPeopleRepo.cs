using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppAssignmentMVC_Data_1_3.Models;

namespace WebAppAssignmentMVC_Data_1_3.Data
{
    public class InMemoryPeopleRepo : IPeopleRepo
    {
        private static readonly List<Person> _pList = new List<Person>();
        private static int _idCounter;

        
        public void CreateBasePersons()
        {
            /*InMemoryPeopleRepo pDataBase = new InMemoryPeopleRepo();
            pDataBase.Create("Eric Rönnhult", "0777 777777", "Tiesto");
            pDataBase.Create("Bosse Bus", "0777 777777", "Flen");
            pDataBase.Create("Kjell Kriminell", "0777 777777", "Burg");
            pDataBase.Create("Anders Rolle", "0777 777777", "Götet");
            */
        }

        public Person Create(string PersonName, string PersonPhoneNumber, City PersonCity)
        {
            /*

            //Person newPerson = new Person(_idCounter, PersonName, PersonPhoneNumber, PersonCity);
            Person newPerson = new Person(PersonName, PersonPhoneNumber, PersonCity); // removed _idCounter to run program
            _pList.Add(newPerson);

            _idCounter++;

            return newPerson;*/
            throw new NotImplementedException();
        }


        public List<Person> Read()
        {
            return _pList;
        }

        public Person Read(int id)
        {
            Person findPersonById = _pList.Find(idNr => idNr.PersonId == id);

            return findPersonById;
        }

        public Person Update(Person person)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Person person)
        {
            bool success = _pList.Remove(person);
            return success;
        }
    }
}
