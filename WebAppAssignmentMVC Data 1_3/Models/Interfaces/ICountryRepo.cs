using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppAssignmentMVC_Data_1_3.Models
{
    public interface ICountryRepo
    {
        Country Create(string countryName);


        List<Country> Read();


        Country Read(int id);


        Country Update(Country person);


        bool Delete(Country person);
    }
}
