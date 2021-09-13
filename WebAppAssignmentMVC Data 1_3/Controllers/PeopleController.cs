using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppAssignmentMVC_Data_1_3.Models;
using WebAppAssignmentMVC_Data_1_3.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebAppAssignmentMVC_Data_1_3.Controllers
{
    public class PeopleController : Controller
    {

        // Now using DI and theese Constructors /ER

        private readonly IPeopleService _peopleService;
        private readonly ICityService _cityService;
        private readonly ICountryService _countryService;
        private readonly ILanguageService _languageService;

        public PeopleController(IPeopleService peopleService, ICityService cityService, ICountryService countryService, ILanguageService languageService)
        {
            _peopleService = peopleService;
            _cityService = cityService;
            _countryService = countryService;
            _languageService = languageService;
        }


        [HttpGet]
        public IActionResult Index()
        {
            PeopleViewModel peopleViewModel = CheckIfEmptyDBTables(); // Check if certain DB-Tables are empty. If yes, then add some.";

            CreatePersonViewModel citylist = new CreatePersonViewModel() { Cities = peopleViewModel.CityListView };

            ViewBag.Mess = TempData["Deletemess"];

            return View("Index", peopleViewModel);
        }

        [HttpPost]
        public IActionResult Index(PeopleViewModel peopleViewModel) //Find by model
        {
            //PeopleViewModel peopleViewModel2 = new PeopleViewModel();
            //peopleViewModel2 = peopleViewModel;
            peopleViewModel = _peopleService.FindBy(peopleViewModel);

            /*peopleViewModel2.PersonName = peopleViewModel.PersonName;
            peopleViewModel2.PersonPhoneNumber = peopleViewModel.PersonPhoneNumber;
            peopleViewModel2.CityListView = peopleViewModel.CityListView;*/

            return View("Index", peopleViewModel); 
        }


        [HttpPost]
        public IActionResult CreatePerson(CreatePersonViewModel createPersonViewModel) // set / HttpPost
        {


            PeopleViewModel peopleViewModel = new PeopleViewModel();

            List<City> cityL = _cityService.All().CityListView;
            createPersonViewModel.Cities = cityL;

            peopleViewModel.PersonName = createPersonViewModel.PersonName;
            peopleViewModel.PersonPhoneNumber = createPersonViewModel.PersonPhoneNumber;
            peopleViewModel.CityListView = cityL;


            if (ModelState.IsValid)
                {

                _peopleService.Add(createPersonViewModel);

                    ViewBag.Mess = "Person Added!";

                peopleViewModel.PeopleListView = _peopleService.All().PeopleListView;

                return View("Index", peopleViewModel);
                }

            peopleViewModel.PeopleListView = _peopleService.All().PeopleListView;

            return View("index", peopleViewModel);
        }

        [HttpPost]
        public IActionResult DeletePerson(int id)
        {
            _peopleService.Remove(id);

            TempData["Deletemess"] = "Person Deleted!";

            return RedirectToAction("Index");
        }


        // ---------------  Special Actions below ---------------
        [HttpPost]
        public IActionResult PersonDetails(int id)
        {
            Person personDetails = _peopleService.FindBy(id);

            return View("Details", personDetails);
        }


        [HttpPost]
        public IActionResult AddLanguageView(int id)
        {
            PersonLanguageViewModel personLanguageViewModel = new PersonLanguageViewModel()
            {
                LanguageListView = _languageService.All().LanguageListView,
                Person = _peopleService.FindBy(id)
            };

            personLanguageViewModel = GenerateSelectList(personLanguageViewModel);
            //personLanguageViewModel.LanguageListView = _languageService.All().LanguageListView;
            //personLanguageViewModel.Person = foundPerson;

            return View("AddLanguagesToPerson", personLanguageViewModel);
        }



        public IActionResult AddLanguageToPerson(PersonLanguageViewModel personLanguageViewModel)
        {
            Person person = _peopleService.FindBy(personLanguageViewModel.PersonId);

            personLanguageViewModel.LanguageListView = _languageService.All().LanguageListView;
            personLanguageViewModel.Person = person;

            personLanguageViewModel = GenerateSelectList(personLanguageViewModel);


            if (ModelState.IsValid)
            {
                bool success = _peopleService.AddLanguageToPerson(personLanguageViewModel);

                if (success) { ViewBag.Mess = "Languages added to Person!"; }
                else { ViewBag.Mess = "Error! Language did NOT get stored"; }

                return View("AddLanguagesToPerson", personLanguageViewModel);
            }

            return View("AddLanguagesToPerson", personLanguageViewModel);
        }



        // -------------- Normal Methods below -------------------

        public PeopleViewModel CheckIfEmptyDBTables()
        {
            PeopleViewModel peopleViewModel = new PeopleViewModel()
            {
                PeopleListView = _peopleService.All().PeopleListView,
                CityListView = _cityService.All().CityListView,
                CountryListView = _countryService.All().CountryListView,
                LanguageListView = _languageService.All().LanguageListView
            };

            if (peopleViewModel.LanguageListView.Count == 0 || peopleViewModel.LanguageListView == null)
            {
                _languageService.CreateBaseLanguages();
                ViewBag.BaseLanguageList = "Language-table was empty, added languages into it. ";
                peopleViewModel.LanguageListView = _languageService.All().LanguageListView;
            }

            if (peopleViewModel.CountryListView.Count == 0 || peopleViewModel.CountryListView == null)
            {
                _countryService.CreateBaseCountries();
                ViewBag.BaseCountryList = "Country-table was empty, added cities into it. ";
                peopleViewModel.CountryListView = _countryService.All().CountryListView;
            }

            if (peopleViewModel.CityListView.Count == 0 || peopleViewModel.CityListView == null)
            {
                _cityService.CreateBaseCities(peopleViewModel.CountryListView);
                ViewBag.BaseCityList = "City-table was empty, added cities into it, and a country per city. ";
                peopleViewModel.CityListView = _cityService.All().CityListView;
            }

            if (peopleViewModel.PeopleListView.Count == 0 || peopleViewModel.PeopleListView == null)
            {
                _peopleService.CreateBasePeople(peopleViewModel.CityListView);
                ViewBag.BasePersonList = "Person-table was empty, added peoples into it. ";
                peopleViewModel.PeopleListView = _peopleService.All().PeopleListView;
            }

            return peopleViewModel;

        }


        public PersonLanguageViewModel GenerateSelectList(PersonLanguageViewModel personLanguageViewModel)
        {
            List<Language> listPeronsLang = new List<Language>(); // list to add languages that a person might have allready
            List<SelectListItem> generatedList = new List<SelectListItem>();

            foreach (PersonLanguage language in personLanguageViewModel.Person.PersonLanguages.ToList())
            {
                listPeronsLang.Add(language.Language);
            }

            bool IsSelected; // to hold true or false for those languages a person might allready have

            foreach (Language languageItem in personLanguageViewModel.LanguageListView)
            {
                Language personLangID = listPeronsLang.Find(id => id.LanguageId == languageItem.LanguageId);

                if (personLangID != null) // IsSelected is True if equal, false if not equal
                { IsSelected = languageItem.LanguageId == personLangID.LanguageId; } 
                else { IsSelected = false; }

                SelectListItem selectList = new SelectListItem()
                {
                    Text = languageItem.LanguageName,
                    Value = languageItem.LanguageId.ToString(),
                    Selected = IsSelected
                };
                generatedList.Add(selectList);
            }
            personLanguageViewModel.LanguageSelectList = generatedList;

            return personLanguageViewModel;
        }




    }


}
