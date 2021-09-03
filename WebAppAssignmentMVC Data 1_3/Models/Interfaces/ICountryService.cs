using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppAssignmentMVC_Data_1_3;

namespace WebAppAssignmentMVC_Data_1_3.Models
{
    public interface ICountryService
    {
        Country Add(CreateCountryViewModel person);

        CountryViewModel All();

        CountryViewModel FindBy(CountryViewModel search);

        Country FindBy(int id);

        Country Edit(int id, Country person);

        bool Remove(int id);
    }
}
