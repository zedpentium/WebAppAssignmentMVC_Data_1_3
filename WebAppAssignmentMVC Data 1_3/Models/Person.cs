using System.ComponentModel.DataAnnotations;

namespace WebAppAssignmentMVC_Data_1_3.Models
{
    public class Person
    {

        private int _personId;
        private string _personName;
        private string _personPhoneNumber;
        private City _personCity;
        //private class _personCity(int CityId, string CityName);


        public Person(string personName, string personPhoneNumber, City personCity)
        {
            //this.PersonId = PersonId;
            PersonName = personName;
            PersonPhoneNumber = personPhoneNumber;
            PersonCity = personCity;
        }

        [Key]
        public int PersonId
        {
            get { return _personId; }
            //set { _personId = value; }
        }

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

        public City PersonCity
        {
            get { return _personCity; }
            set {_personCity = value; }
        }
        

    }
}
