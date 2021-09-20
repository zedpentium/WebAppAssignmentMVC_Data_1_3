using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppAssignmentMVC_Data_1_3.Models;
using WebAppAssignmentMVC_Data_1_3.Models.Interfaces;

namespace WebAppAssignmentMVC_Data_1_3.Data
{
    public class DbCityRepo : ICityRepo
    {
        private readonly PeopleDbContext _cityListContext;

        public DbCityRepo(PeopleDbContext cityListContext)
        {
            _cityListContext = cityListContext;

        }

        public DbCityRepo()
        {
        }

 
        public City Create(string cityName, Country country)
        {
            City newCity = new City(cityName, country);

            _cityListContext.Add(newCity);
            _cityListContext.SaveChanges();

            return newCity;
        }


        public List<City> Read()
        {
            List<City> cList = _cityListContext.Cities
                .Include(c => c.Country)
                .ToList();

            return cList;
        }

        public City Read(int id)
        {
            City cList = _cityListContext.Cities
                .Where(c => c.CityId == id)
                .Include(c => c.Country)
                .FirstOrDefault();

            return cList;
        }

        public City Update(City city)
        {
            _cityListContext.Cities.Update(city);
            _cityListContext.SaveChanges();

            return city;
        }

        public bool Delete(City city)
        {
            int nrStates;

            _cityListContext.Cities.Remove(city);
            nrStates = _cityListContext.SaveChanges();

            if (nrStates >= 1)
            {
                return true;
            }

            return false;


        }

    }
}
