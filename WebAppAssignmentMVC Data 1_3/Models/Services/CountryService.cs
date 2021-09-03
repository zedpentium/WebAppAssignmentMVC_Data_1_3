using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppAssignmentMVC_Data_1_3.Models
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepo _countryRepo;

        public CountryService(ICountryRepo countryRepo)
        {
            _countryRepo = countryRepo;
        }


        public Country Add(CreateCountryViewModel country)
        {
            //InMemoryPeopleRepo createAndStorePerson = new InMemoryPeopleRepo();
            Country madeCountry = _countryRepo.Create(country.CountryName);

            return madeCountry;
        }

        public CountryViewModel All()
        {
            //InMemoryPeopleRepo pRepoList = new InMemoryPeopleRepo(); 

            CountryViewModel pViewMod = new CountryViewModel() { PeopleListView = _peopleRepo.Read() };  

            return pViewMod;
        }

        public Country Edit(int id, Country person)
        {
            throw new NotImplementedException();
        }

        public CountryViewModel FindBy(CountryViewModel search)
        {
            //InMemoryPeopleRepo loadListForSearch = new InMemoryPeopleRepo();

            search.PeopleListView.Clear();

            foreach (Country item in _peopleRepo.Read())
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

        public Country FindBy(int id)
        {
            //InMemoryPeopleRepo findPersonById = new InMemoryPeopleRepo();
            Person foundPerson = _peopleRepo.Read(id);

            return foundPerson;
        }

        public bool Remove(int id)
        {
            //InMemoryPeopleRepo deletePersonFromRepo = new InMemoryPeopleRepo();
            Country personToDelete = _peopleRepo.Read(id);
            bool success = _peopleRepo.Delete(personToDelete);

            return success;
        }
    }
}
