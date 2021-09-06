using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebAppAssignmentMVC_Data_1_3.Models
{

    public class CityViewModel
    { 
        public List<City> CityListView { get; set; }


        public string FilterString { get; set; }

        public string SearchResultEmpty { get; set; }


        
        public CityViewModel()
        {
            CityListView = new List<City>();
        }

    }
}
