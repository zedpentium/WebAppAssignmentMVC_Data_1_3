using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebAppAssignmentMVC_Data_ER.Models.ViewModels
{

    public class LanguageViewModel : CreateLanguageViewModel
    { 
        public List<Language> LanguageListView { get; set; }


        public string FilterString { get; set; }

        public string SearchResultEmpty { get; set; }


        public LanguageViewModel()
        {
            LanguageListView = new List<Language>();
        }

    }
}
