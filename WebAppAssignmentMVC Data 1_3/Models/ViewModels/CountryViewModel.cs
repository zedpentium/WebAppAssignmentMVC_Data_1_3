using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebAppAssignmentMVC_Data_1_3.Models.ViewModels
{

    public class CountryViewModel : CreateCountryViewModel
    { 
        public List<Country> CountryListView { get; set; }


        public string FilterString { get; set; }

        public string SearchResultEmpty { get; set; }


        
        public CountryViewModel()
        {
            CountryListView = new List<Country>();
        }
        
    }
}
