using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppAssignmentMVC_Data_1_3.Models
{
    public interface ICityService
    {
        City Add(CreateCityViewModel person);

        CityViewModel All();

        CityViewModel FindBy(CityViewModel search);

        City FindBy(int id);

        City Edit(int id, City person);

        bool Remove(int id);

        void CreateBaseCities(List<Country> countries);

    }
}
