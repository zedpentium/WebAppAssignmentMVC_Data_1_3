﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebAppAssignmentMVC_Data_1_3.Models
{

    public class PeopleViewModel : CreatePersonViewModel
    { 
        public List<Person> PeopleListView { get; set; }
        public List<City> CityListView { get; set; }
        // public List<Country> CountryListView { get; set; } // not used atm


        public string FilterString { get; set; }

        public string SearchResultEmpty { get; set; }


        
        public PeopleViewModel()
        {
            PeopleListView = new List<Person>();
        }

    }
}