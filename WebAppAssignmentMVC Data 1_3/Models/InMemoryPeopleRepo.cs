using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebAppAssignmentMVC_Data_1_3.Models
{
    public class InMemoryPeopleRepo : IPeopleRepo
    {
        private static List<Person> _pList;
        private static int _idCounter;


        public Person Create(string pName, string pPhonenumber, string pCity)
        {
            throw new NotImplementedException();
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
