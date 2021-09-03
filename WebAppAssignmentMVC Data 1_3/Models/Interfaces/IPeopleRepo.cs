using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppAssignmentMVC_Data_1_3.Models
{
    public interface IPeopleRepo
    {
        Person Create(string personName, string personPhoneNumber, string personCity);


        List<Person> Read();


        Person Read(int id);


        Person Update(Person person);


        bool Delete(Person person);
    }
}
