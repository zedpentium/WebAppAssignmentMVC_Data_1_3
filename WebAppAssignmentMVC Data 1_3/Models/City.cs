using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAppAssignmentMVC_Data_1_3.Models
{
    public class City
    {
        private string _cityName;

        public List<Person> People { get; set; } // Navigation prop


        public City()
        { }

        public City(string cityName)
        {
            this.CityName = cityName;
        }

        [Key]
        public int CityId { get; }


        public string CityName
        {
            get { return _cityName; }
            set { _cityName = value; }
        }

        //public int ForeignKey_CountryId { get; } // ForeignKey for Country.CountryID
        //public Country Country { get; set; } // Navigation prop Country(one) to Cities(many)

    }
}
