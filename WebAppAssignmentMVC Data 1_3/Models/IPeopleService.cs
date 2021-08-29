using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppAssignmentMVC_Data_1_3.Models
{
    interface IPeopleService
    {
        public Person Add(CreatePersonViewModel person);

        public PeopleViewModel All();

        public PeopleViewModel FindBy(PeopleViewModel search);

        public Person FindBy(int id);

        public Person Edit(int id, Person person);

        public bool Remove(int id);
    }
}
