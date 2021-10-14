using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;


namespace WebAppAssignmentMVC_Data_ER.Models
{
    public class Country
    {
        private string _countryName;

        public Country(string countryName)
        {
            CountryName = countryName;
        }


        public int CountryId { get; }


        public string CountryName
        {
            get { return _countryName; }
            set { _countryName = value; }
        }

        [JsonIgnore]
        public List<City> Cities { get; set; } // Navigation prop Cities(many) to Country(one) ER
    }
}
