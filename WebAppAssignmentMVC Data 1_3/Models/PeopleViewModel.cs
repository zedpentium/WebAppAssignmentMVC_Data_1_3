using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppAssignmentMVC_Data_1_3.Models
{

    public class PeopleViewModel
    { 
        public List<Person> PeopleListView { get; set; }

        public string FilterString { get; set; }


        //public string btnFilter { get; set; }

        public string PersonName { get; set; }
        public string PersonPhoneNumber { get; set; }
        public string PersonCity { get; set; }
        //public string btnCreate { get; set; }

        public PeopleViewModel()
        {
            PeopleListView = new List<Person>();
        }



    }
}
