﻿using System;
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


        public Person(int id, string name, string number, string city)
        {
            this._personId = id;
            PersonName = name;
            PersonPhoneNumber = number;
            PersonCity = city;
        }

        public int PersonId
        {
            get { return _personId; }
        }

        public string PersonName
        {
            get { return _personName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("The in-value are Null/Empty or whitespace. Will not be stored.");
                }

                _personName = value;
            }
        }


        public string PersonPhoneNumber
        {
            get { return _personPhoneNumber; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("The in-value are Null/Empty or whitespace. Will not be stored.");
                }

                _personPhoneNumber = value;
            }
        }

        public string PersonCity
        {
            get { return _personCity; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("The in-value are Null/Empty or whitespace. Will not be stored.");
                }

                _personCity = value;
            }
        }
        

    }
}
