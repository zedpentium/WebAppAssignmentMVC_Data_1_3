using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppAssignmentMVC_Data_1_3.Models.ViewModels;

namespace WebAppAssignmentMVC_Data_1_3.Models.Interfaces
{
    public interface ICountryService
    {
        Country Add(CreateCountryViewModel country);

        CountryViewModel All();

        CountryViewModel FindBy(CountryViewModel search);

        Country FindBy(int id);

        Country Edit(int id, Country country);

        bool Remove(int id);

        void CreateBaseCountries();
    }
}
