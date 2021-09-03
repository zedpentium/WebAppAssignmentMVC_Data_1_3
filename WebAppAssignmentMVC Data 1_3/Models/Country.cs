using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace WebAppAssignmentMVC_Data_1_3.Models
{
    public class Country
    {

        private int _countryId;
        private string _countryName;


        public List<City> Cities { get; set; }
        //public List<City> Countries { get; set; }


        public Country(string countryName)
        {
            CountryName = countryName;
        }

        [Key]
        public int CountryId
        {
            get { return _countryId; }
            //set { _countryId = value; }
        }

        public string CountryName
        {
            get { return _countryName; }
            set { _countryName = value; }
        }


    }
}
