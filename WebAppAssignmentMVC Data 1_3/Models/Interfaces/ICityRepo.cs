using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppAssignmentMVC_Data_1_3.Models
{
    public interface ICityRepo
    {
        City Create(string cityName, Country country);


        List<City> Read();


        City Read(int id);


        City Update(City city);


        bool Delete(City city);

    }
}
