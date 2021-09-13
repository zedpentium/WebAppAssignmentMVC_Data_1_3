using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAppAssignmentMVC_Data_1_3.Models
{
    public class Person
    {

        private string _personName;
        private string _personPhoneNumber;


        public Person()
        { }

       /* public Person(List<PersonLanguage> languages)
        {
            Languages = languages;
        }*/

        public Person(string personName, string personPhoneNumber, City city)
        {

            PersonName = personName;
            PersonPhoneNumber = personPhoneNumber;
            City = city;
        }



        public int PersonId { get; set; }


        public string PersonName
        {
            get { return _personName; }
            set { _personName = value; }
        }


        public string PersonPhoneNumber
        {
            get { return _personPhoneNumber; }
            set { _personPhoneNumber = value; }
        }

        public int CityId { get; set; }

        public City City { get; set; }

        //public List<Language> Languages { get; set; } // commented out to get many-to-many to work in EF Core  /ER

        public List<PersonLanguage> PersonLanguages { get; set; } = new List<PersonLanguage>();// Join table-navigation-relation EF Core Specific with no lazy loading /ER


    }
}
