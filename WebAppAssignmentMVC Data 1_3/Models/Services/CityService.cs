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


        public City Add(CreateCityViewModel cityViewModel)
        {
            City madeCity = _cityRepo.Create(cityViewModel.CityName);

            return madeCity;
        }

        public CityViewModel All()
        {
            CityViewModel ciViewMod = new CityViewModel() { CityListView = _cityRepo.Read() };  

            return ciViewMod;
        }

        public City Edit(int id, City person)
        {
            throw new NotImplementedException();
        }

        public CityViewModel FindBy(CityViewModel search)
        {
            search.CityListView.Clear();

            foreach (City item in _cityRepo.Read())
            {
                if (item.CityName.Contains(search.FilterString, StringComparison.OrdinalIgnoreCase))
                {

                    search.CityListView.Add(item);
                }
            }

            if (search.CityListView.Count == 0)
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
            City foundCity = _cityRepo.Read(id);

            return foundCity;
        }

        public bool Remove(int id)
        {
            City cityToDelete = _cityRepo.Read(id);
            bool success = _cityRepo.Delete(cityToDelete);

            return success;
        }

        public void CreateBaseCities()
        {
            _cityRepo.Create("Skövde");
            _cityRepo.Create("Trondheim");
            _cityRepo.Create("Kelontekemä");
            _cityRepo.Create("Eindhoven");
        }


    }
}
