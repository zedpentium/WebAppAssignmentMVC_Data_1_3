using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppAssignmentMVC_Data_1_3.Models
{
    public class PeopleService : IPeopleService
    {
        //All new InMemoryPeopleRepo() is now replaced by DI via this Constructor, and using _peopleRepo instead /ER
        private readonly IPeopleRepo _peopleRepo;

        public PeopleService(IPeopleRepo peopleRepo)
        {
            _peopleRepo = peopleRepo;
        }


        public Person Add(CreatePersonViewModel person)
        {
            //InMemoryPeopleRepo createAndStorePerson = new InMemoryPeopleRepo();
            Person madePerson = _peopleRepo.Create(person.PersonName, person.PersonPhoneNumber, person.PersonCity);

            return madePerson;
        }

        public PeopleViewModel All()
        {
            //InMemoryPeopleRepo pRepoList = new InMemoryPeopleRepo(); 
            
            PeopleViewModel pViewMod = new PeopleViewModel() { PeopleListView = _peopleRepo.Read() };  

            return pViewMod;
        }

        public Person Edit(int id, Person person)
        {
            throw new NotImplementedException();
        }

        public PeopleViewModel FindBy(PeopleViewModel search)
        {
            //InMemoryPeopleRepo loadListForSearch = new InMemoryPeopleRepo();

            search.PeopleListView.Clear();

            foreach (Person item in _peopleRepo.Read())
            {
                if (item.PersonName.Contains(search.FilterString, StringComparison.OrdinalIgnoreCase) || item.PersonCity.Contains(search.FilterString, StringComparison.OrdinalIgnoreCase))
                {

                    search.PeopleListView.Add(item);
                }
            }

            if (search.PeopleListView.Count == 0)
            {
                search.SearchResultEmpty = $"No Person or City could be found, matching \"{search.FilterString}\" ";
            } else
            {
                search.SearchResultEmpty = "";
            }

            return search;

        }

        public Person FindBy(int id)
        {
            //InMemoryPeopleRepo findPersonById = new InMemoryPeopleRepo();
            Person foundPerson = _peopleRepo.Read(id);

            return foundPerson;
        }

        public bool Remove(int id)
        {
            //InMemoryPeopleRepo deletePersonFromRepo = new InMemoryPeopleRepo();
            Person personToDelete = _peopleRepo.Read(id);
            bool success = _peopleRepo.Delete(personToDelete);

            return success;
        }
    }
}
