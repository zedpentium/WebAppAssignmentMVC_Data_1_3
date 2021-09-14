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

            Person updatePersonLang = _peopleListContext.People // load person with languages
                .Where(c => c.PersonId == personLanguageViewModel.PersonId)
                .Include(f => f.PersonLanguages)
                .ThenInclude(g => g.Language)
                .First();



            List<Language> dbLangList = _peopleListContext.Languages.ToList();

            //List<PersonLanguage> dbLangList = _peopleListContext.Languages.ToList();

            //List<PersonLanguage> foundLang = new List<PersonLanguage>();
            //List<Language> foundLang = new List<Language>();
            Language foundLang = new Language();

            /*int placeHold = 0;
            PersonLanguage foundLang = new PersonLanguage(personLanguageViewModel.PersonId, placeHold);
            List<PersonLanguage> listAddLang = new List<PersonLanguage>();*/



            //PersonLanguage personLanguage = new PersonLanguage(personLanguageViewModel.PersonId, placeHold);


            foreach (string id in personLanguageViewModel.SelectedListBoxView) // SelectedListBoxView has the list of choosen languages IdNr as string
            {
                foundLang = dbLangList.Find(la => la.LanguageId == Convert.ToInt32(id));

                //foundLang.Add(dbLangList.Find(la => la.LanguageId == Convert.ToInt32(id)));

                //foundLang.Add(PersonLanguage Convert.ToInt32(id));

                /*placeHold = Convert.ToInt32(id);
                listAddLang.Add(foundLang);*/

                /*foreach (var item in foundLang)
                {

                }*/
                /*using (var context = new _peopleListContext())
                {
                    // loads the book by it's ISBN
                    var book = context.Books
                        .Single(p => p.ISBN == "123456");

                    // Do changes
                    book.Price = 30;

                    // Save changes
                    context.SaveChanges();
                }*/

                updatePersonLang.PersonLanguages = new List<PersonLanguage>()
                {
                new PersonLanguage
                {
                    Language = foundLang
                }
                };

                /*updatePersonLang = new Person
                {
                PersonLanguages = foundLang
                };*/
            }


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
