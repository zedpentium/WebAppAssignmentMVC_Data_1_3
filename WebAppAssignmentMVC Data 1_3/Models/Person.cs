using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppAssignmentMVC_Data_1_3.Models
{
    public class Person
    {
        private readonly int _personId;
        private string _personName;
        private string _personPhoneNumber;
        private string _personCity;


        public Person(int id, string pName, string pPhonenumber, string pCity)
        {
            this._personId = id;
            PersonName = pName;
            PersonPhoneNumber = pPhonenumber;
            PersonCity = pCity;
        }

        public int PersonId
        {
            get { return _personId; }
        }

        public string PersonName
        {
            get { return _personName; }
            set
            { _personName = value; }
        }


        public string PersonPhoneNumber
        {
            get { return _personPhoneNumber; }
            set
            { _personPhoneNumber = value; }
        }

        public string PersonCity
        {
            get { return _personCity; }
            set
            {_personCity = value; }
        }
        

    }
}
