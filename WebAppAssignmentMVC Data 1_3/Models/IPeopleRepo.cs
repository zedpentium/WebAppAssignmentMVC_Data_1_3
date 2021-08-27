using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppAssignmentMVC_Data_1_3.Models
{
    interface IPeopleRepo
    {


        public Person Create(string PersonName, string PersonPhoneNumber, string PersonCity);


        public List<Person> Read();


        public Person Read(int id);


        public Person Update(Person person);


        public bool Delete(Person person);


    }
}
