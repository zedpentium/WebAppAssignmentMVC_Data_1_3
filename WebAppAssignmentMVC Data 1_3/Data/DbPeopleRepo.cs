using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppAssignmentMVC_Data_1_3.Models;

namespace WebAppAssignmentMVC_Data_1_3.Data
{
    public class DbPeopleRepo : IPeopleRepo
    {
        private readonly PeopleDbContext _peopleListContext;

        public DbPeopleRepo(PeopleDbContext peopleListContext)
        {
            _peopleListContext = peopleListContext;

        }


        public Person Create(string personName, string personPhoneNumber, City city)
        {
            Person newPerson = new Person(personName, personPhoneNumber, city);

            _peopleListContext.Add(newPerson);
            _peopleListContext.SaveChanges();

            return newPerson;
        }

        public bool AddLanguageToPerson(PersonLanguageViewModel personLanguageViewModel)
        {
            int nrStates;

            Person updatePersonLang = updatePersonLang = _peopleListContext.People // load person with languages
                .Where(c => c.PersonId == personLanguageViewModel.PersonId)
                .Include(f => f.PersonLanguages).ThenInclude(g => g.Language)
                .First();

            List<PersonLanguage> dbLangList = _peopleListContext.PersonLanguages.ToList();
            List<PersonLanguage> foundLang = new List<PersonLanguage>();

            foreach (string id in personLanguageViewModel.SelectedListBoxView)
            {
                foundLang.Add(dbLangList.Find(la => la.LanguageId == Convert.ToInt32(id)));
            }

            //_peopleListContext.PersonLanguages.Add(foundLang);


            /*    Another TESTkod part JUST to test someting different then before.. but no. no sulution.
             *    
            // I will add two books to one library
            var language1 = new Language();
            var language2 = new Language();

            // I create the library 
            var lib = new Person();

            // I create two Library2Book which I need them 
            // To map between the books and the library
            var l2pers1 = new PersonLanguage();
            var l2pers2 = new PersonLanguage();

            // Mapping the first book to the library.
            // Changed b2lib2.Library to b2lib1.Library
            l2pers1.Language = language1;
            l2pers1.Person = lib;

            // I map the second book to the library.
            l2pers2.Language = language2;
            l2pers2.Person = lib;

            // Linking the books (Library2Book table) to the library
            lib.PersonLanguages.Add(l2pers1);
            lib.PersonLanguages.Add(l2pers2);

            // Adding the data to the DbContext.
            _peopleListContext.People.Add(lib);

            _peopleListContext.Languages.Add(language1);
            _peopleListContext.Languages.Add(language2);

            // Save the changes and everything should be working!
            _peopleListContext.SaveChanges();*/


            nrStates =_peopleListContext.SaveChanges();

            if (nrStates > 0)
            {
                return true;
            }

            return false;
        }
        


        public List<Person> Read()
        {
            List<Person> pList = _peopleListContext.People
                .Include(d => d.City)
                .Include(e => e.City.Country)
                .Include(f => f.PersonLanguages).ThenInclude(g => g.Language)
                .ToList();

            return pList;
        }

        public Person Read(int id)
        {
            Person person = _peopleListContext.People
                .Where(c => c.PersonId == id)
                .Include(d => d.City)
                .Include(e => e.City.Country)
                .Include(f => f.PersonLanguages).ThenInclude(g => g.Language)
                .FirstOrDefault();

            return person;
        }

        public Person Update(Person person)
        {
            _peopleListContext.People.Update(person);
            _peopleListContext.SaveChanges();

            return person;
        }

        public bool Delete(Person person)
        {
            int nrStates;

            _peopleListContext.People.Remove(person);
            nrStates = _peopleListContext.SaveChanges();

            if (nrStates > 0)
            {
                return true;
            }

            return false;


        }

    }
}
