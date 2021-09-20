using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppAssignmentMVC_Data_1_3.Models.ViewModels;

namespace WebAppAssignmentMVC_Data_1_3.Models.Interfaces
{
    public interface IPeopleRepo
    {
        Person Create(string personName, string personPhoneNumber, City city);


        public bool AddLanguageToPerson(PersonLanguageViewModel personLanguageViewModel);


        List<Person> Read();


        Person Read(int id);


        Person Update(Person person);


        bool Delete(Person person);
    }
}
