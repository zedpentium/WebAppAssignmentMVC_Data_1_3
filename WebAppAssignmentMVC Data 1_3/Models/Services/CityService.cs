using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppAssignmentMVC_Data_1_3;

namespace WebAppAssignmentMVC_Data_1_3.Models
{
    public class CityService : ICityService
    {
        //All new InMemoryPeopleRepo() is now replaced by DI via this Constructor, and using _peopleRepo instead /ER
        private readonly ICityRepo _cityRepo;

        public CityService(ICityRepo cityRepo)
        {
            _cityRepo = cityRepo;
        }


        public City Add(CreateCityViewModel person)
        {
            //InMemoryPeopleRepo createAndStorePerson = new InMemoryPeopleRepo();
            City madePerson = _cityRepo.Create(person.PersonName, person.PersonPhoneNumber, person.PersonCity);

            return madePerson;
        }

        public CityViewModel All()
        {
            //InMemoryPeopleRepo pRepoList = new InMemoryPeopleRepo(); 

            CityViewModel pViewMod = new CityViewModel() { PeopleListView = _cityRepo.Read() };  

            return pViewMod;
        }

        public City Edit(int id, City person)
        {
            throw new NotImplementedException();
        }

        public CityViewModel FindBy(CityViewModel search)
        {
            //InMemoryPeopleRepo loadListForSearch = new InMemoryPeopleRepo();

            search.PeopleListView.Clear();

            foreach (City item in _cityRepo.Read())
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

        public City FindBy(int id)
        {
            //InMemoryPeopleRepo findPersonById = new InMemoryPeopleRepo();
            City foundPerson = _cityRepo.Read(id);

            return foundPerson;
        }

        public bool Remove(int id)
        {
            //InMemoryPeopleRepo deletePersonFromRepo = new InMemoryPeopleRepo();
            City personToDelete = _cityRepo.Read(id);
            bool success = _cityRepo.Delete(personToDelete);

            return success;
        }
    }
}
