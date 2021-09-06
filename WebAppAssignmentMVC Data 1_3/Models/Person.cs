using System.ComponentModel.DataAnnotations;

namespace WebAppAssignmentMVC_Data_1_3.Models
{
    public class Person
    {

        private string _personName;
        private string _personPhoneNumber;
        private City _city;

        public Person()
        { }

        public Person(string personName, string personPhoneNumber, City personCity)
        {

            PersonName = personName;
            PersonPhoneNumber = personPhoneNumber;
            City = personCity;
        }

        [Key]
        public int PersonId { get; }


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

        public City City
        {
            get { return _city; }
            set { _city = value; }
        }

        public int CityForeignKey { get; set; }


    }
}
