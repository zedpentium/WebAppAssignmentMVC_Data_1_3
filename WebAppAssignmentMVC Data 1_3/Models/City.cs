using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAppAssignmentMVC_Data_1_3.Models
{
    public class City
    {

        private int _cityId;
        private string _cityName;

        public List<Person> People { get; set; }
        //public List<Country> Countries { get; set; }



        public City(string cityName)
        {
            this.CityName = cityName;
        }

        [Key]
        public int CityId
        {
            get { return _cityId; }
            //set { _cityId = value; }
        }

        public string CityName
        {
            get { return _cityName; }
            set { _cityName = value; }
        }

    }
}
