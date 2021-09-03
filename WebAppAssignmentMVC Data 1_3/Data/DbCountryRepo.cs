using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppAssignmentMVC_Data_1_3.Models;

namespace WebAppAssignmentMVC_Data_1_3.Data
{
    public class DbCountryRepo : ICountryRepo
    {
        private readonly PeopleDbContext _peopleListContext;

        public DbCountryRepo(PeopleDbContext peopleListContext)
        {
            _peopleListContext = peopleListContext;

        }

        public void CreateBaseCountries()
        {
            Create("Sweden");
            Create("Finland");
            Create("Norway");
            Create("Netherlands");
        }

       public Country Create(string countryName)
        {
            Country newCountry = new Country(countryName);

            _peopleListContext.Add(newCountry);
            _peopleListContext.SaveChanges();

            return newCountry;
        }

        
        public List<Country> Read()
        {
            List<Country> cList = _peopleListContext.Country.ToList();
            if (cList.Count == 0)
            {
                CreateBaseCountries();
                cList = _peopleListContext.Country.ToList();
            }

            return cList;
        }

        public Country Read(int id)
        {
            return _peopleListContext.Country.Find(id);
        }

        public Country Update(Country country)
        {
            _peopleListContext.Country.Update(country);
            _peopleListContext.SaveChanges();

            return country;
        }

        public bool Delete(Country country)
        {
            int nrStates;

            _peopleListContext.Country.Remove(country);
            nrStates = _peopleListContext.SaveChanges();

            if (nrStates == 1)
            {
                return true;
            }

            return false;
        }

    }
}
