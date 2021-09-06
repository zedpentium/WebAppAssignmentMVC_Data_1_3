using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace WebAppAssignmentMVC_Data_1_3.Models
{
    public class Country
    {
        private string _countryName;


        public List<City> Cities { get; set; } // Navigation prop Cities(many) to Country(one) ER


        public Country(string countryName)
        {
            CountryName = countryName;
        }

        [Key]
        public int CountryId { get; }


        public string CountryName
        {
            get { return _countryName; }
            set { _countryName = value; }
        }


    }
}
