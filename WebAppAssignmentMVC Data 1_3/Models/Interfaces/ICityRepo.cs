using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppAssignmentMVC_Data_1_3.Models
{
    public interface ICityRepo
    {
        City Create(string cityName);


        List<City> Read();


        City Read(int id);


        City Update(City person);


        bool Delete(City person);
    }
}
