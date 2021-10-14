using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppAssignmentMVC_Data_ER.Models.ViewModels;

namespace WebAppAssignmentMVC_Data_ER.Models.Interfaces
{
    public interface IPeopleService
    {
        Person Add(CreatePersonViewModel person);

        public bool AddLanguageToPerson(PersonLanguageViewModel personLanguageViewModel);

        PeopleViewModel All();

        PeopleViewModel FindBy(PeopleViewModel search);

        Person FindBy(int id);

        Person Edit(int id, Person person);

        bool Remove(int id);

        void CreateBasePeople(List<City> cList);
    }
}
