using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppAssignmentMVC_Data_1_3.Models.ViewModels;

namespace WebAppAssignmentMVC_Data_1_3.Models.Interfaces
{
    public interface ICityService
    {
        City Add(string cityName, Country country);

        CityViewModel All();

        CityViewModel FindBy(CityViewModel search);

        City FindBy(int id);

        City Edit(int id, City person);

        bool Remove(int id);

        void CreateBaseCities(List<Country> countries);

    }
}
