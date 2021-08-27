using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppAssignmentMVC_Data_1_3.Models
{
    public class PeopleService : IPeopleService
    {
        public Person Add(CreatePersonViewModel person)
        {
            InMemoryPeopleRepo createAndStorePerson = new InMemoryPeopleRepo();
            Person madePerson = createAndStorePerson.Create(person.PersonName, person.PersonPhoneNumber, person.PersonCity);

            return madePerson;
        }

        public PeopleViewModel All()
        {
            PeopleViewModel pViewMod = new PeopleViewModel();
            
            InMemoryPeopleRepo pRepoList = new InMemoryPeopleRepo();

            pViewMod.PeopleListView = pRepoList.Read();

            return pViewMod;
        }

        public Person Edit(int id, Person person)
        {
            


            throw new NotImplementedException();
        }

        public PeopleViewModel FindBy(PeopleViewModel search)
        {
            InMemoryPeopleRepo loadListForSearch = new InMemoryPeopleRepo();

            foreach (Person item in loadListForSearch.Read())
            {
                if (item.PersonName.Contains(search.FilterString, StringComparison.OrdinalIgnoreCase) || item.PersonCity.Contains(search.FilterString, StringComparison.OrdinalIgnoreCase))
                {

                    search.PeopleListView.Add(item);
                }
            }

            if (search.PeopleListView.Count == 0)
            {
                Person tempEmtpyListMessage = new Person(0, "No Person or City could be found", "", "");
                search.PeopleListView.Add(tempEmtpyListMessage);
            }

            return search;

        }

        public Person FindBy(int id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            //InMemoryPeopleRepo createAndStorePerson = new InMemoryPeopleRepo();
            //Person madePerson = createAndStorePerson.Delete(person.PersonName, person.PersonPhoneNumber, person.PersonCity);

            throw new NotImplementedException();
        }
    }
}
