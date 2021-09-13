using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAppAssignmentMVC_Data_1_3.Models
{
    public class Language
    {
        private int _languageId;
        private string _languageName;

        public Language()
        { }

        public Language(string languageName)
        {
            LanguageName = languageName;
        }

        /*public Language(string languageName, List<Person> people)
        {
            LanguageName = languageName;
            People = people;

        }
        */

        public int LanguageId
        {
            get { return _languageId; }
            set { _languageId = value; }
        }


        public string LanguageName
        {
            get { return _languageName; }
            set { _languageName = value; }
        }

        //public List<Person> People { get; set; }  // commented out to get many-to-many to work in EF Core  /ER

        public ICollection<PersonLanguage> PeopleLink { get; set; } // Join table-navigation-relation EF Core Specific with no lazy loading /ER

    }
}
