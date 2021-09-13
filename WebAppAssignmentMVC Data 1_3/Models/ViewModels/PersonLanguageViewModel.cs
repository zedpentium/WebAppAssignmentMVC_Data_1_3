using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebAppAssignmentMVC_Data_1_3.Models
{

    public class PersonLanguageViewModel
    { 

        public List<Language> LanguageListView { get; set; }

        public Person Person { get; set; }

        public int PersonId { get; set; }


        public IEnumerable<SelectListItem> LanguageSelectList { get; set; }

        public IEnumerable<String> SelectedListBoxView { get; set; }

        
        public PersonLanguageViewModel()
        {
            //PersonLanguageViewModel personLanguageViewModel = new PersonLanguageViewModel();
            //PeopleListView = new List<Person>();
        }
        
    }
}
