﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace WebAppAssignmentMVC_Data_ER.Models
{
    public class City
    {
        private string _cityName;

        public City()
        { }

        public City(string cityName, Country country)
        {
            CityName = cityName;
            Country = country;
        }


        public int CityId { get; }


        public string CityName
        {
            get { return _cityName; }
            set { _cityName = value; }
        }

        public int CountryId { get; set; }

        [JsonIgnore]
        public List<Person> People { get; set; } // Navigation prop

        public Country Country { get; set; } // Navigation prop Country(one) to Cities(many)

        //public List<Country> Countries { get; set; }

    }
}