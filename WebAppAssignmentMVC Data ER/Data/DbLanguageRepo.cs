using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppAssignmentMVC_Data_ER.Models;
using WebAppAssignmentMVC_Data_ER.Models.Interfaces;

namespace WebAppAssignmentMVC_Data_ER.Data
{
    public class DbLanguageRepo : ILanguageRepo
    {
        private readonly PeopleDbContext _languageListContext;

        public DbLanguageRepo(PeopleDbContext languageListContext)
        {
            _languageListContext = languageListContext;

        }

        public DbLanguageRepo()
        {
        }

 
        public Language Create(string languageName)
        {
            Language newLanguage = new Language(languageName);

            _languageListContext.Add(newLanguage);
            _languageListContext.SaveChanges();

            return newLanguage;
        }


        public List<Language> Read()
        {
            List<Language> langList = _languageListContext.Languages.ToList();

            return langList;
        }

        public Language Read(int id)
        {
            return _languageListContext.Languages.Find(id);
        }

        public Language Update(Language language)
        {
            _languageListContext.Languages.Update(language);
            _languageListContext.SaveChanges();

            return language;
        }

        public bool Delete(Language language)
        {
            int nrStates;

            _languageListContext.Languages.Remove(language);
            nrStates = _languageListContext.SaveChanges();

            if (nrStates >= 1)
            {
                return true;
            }

            return false;


        }

    }
}
