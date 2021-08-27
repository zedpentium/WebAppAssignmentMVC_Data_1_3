using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppAssignmentMVC_Data_1_3.Models
{
    public class InMemoryPeopleRepo : IPeopleRepo
    {
        private static List<Person> _pList = new List<Person>();
        private static int _idCounter;


        public void CreateBasePersons()
        {
            InMemoryPeopleRepo pDataBase = new InMemoryPeopleRepo();
            pDataBase.Create("Tejas Trivedi", "0777 777777", "Tiesto");
            pDataBase.Create("Bosse Bus", "0777 777777", "Flen");
            pDataBase.Create("Kjell Kriminell", "0777 777777", "Burg");
        }

        public Person Create(string PersonName, string PersonPhoneNumber, string PersonCity)
        {
            Person newPerson = new Person(_idCounter, PersonName, PersonPhoneNumber, PersonCity);
            _pList.Add(newPerson);

            _idCounter++;

            return newPerson;
        }

        public bool Delete(Person person)
        {
            throw new NotImplementedException();
        }

        public List<Person> Read()
        {
            
            return _pList;
        }

        public Person Read(int id)
        {
            //Person foundObjIndex = Array.Find(_pList, id => id.PersonId == personId);
            throw new NotImplementedException();
        }

        public Person Update(Person person)
        {
            throw new NotImplementedException();
        }
    }
}
