using System.ComponentModel.DataAnnotations;


namespace WebAppAssignmentMVC_Data_1_3.Models
{
    public class Person
    {

        private int _personId;
        private string _personName;
        private string _personPhoneNumber;
        private string _personCity;


        public Person(string PersonName, string PersonPhoneNumber, string PersonCity)
        {
            //this.PersonId = PersonId;
            this.PersonName = PersonName;
            this.PersonPhoneNumber = PersonPhoneNumber;
            this.PersonCity = PersonCity;
        }

        [Key]
        public int PersonId
        {
            get { return _personId; }
            set { _personId = value; }
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

        public string PersonCity
        {
            get { return _personCity; }
            set {_personCity = value; }
        }
        

    }
}
