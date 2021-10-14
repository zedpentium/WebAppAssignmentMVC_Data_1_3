using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using WebAppAssignmentMVC_Data_ER.Models;
using WebAppAssignmentMVC_Data_ER.Models.ViewModels;
using WebAppAssignmentMVC_Data_ER.Models.Interfaces;
using System.Text.Json;
using System.Collections;
using Newtonsoft.Json;

namespace WebAppAssignmentMVC_Data_ER.Controllers
{
    [Authorize]
    public class ReactController : Controller
    {

        // Now using DI and theese Constructors /ER

        private readonly IPeopleService _peopleService;
        private readonly ICityService _cityService;
        private readonly ICountryService _countryService;
        private readonly ILanguageService _languageService;

        private static List<Person> _listOfPersons;


        public ReactController(IPeopleService peopleService, ICityService cityService, ICountryService countryService, ILanguageService languageService)
        {
            _peopleService = peopleService;
            _cityService = cityService;
            _countryService = countryService;
            _languageService = languageService;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Index()
        {
            return View("Index");
        }



        [Authorize]
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







        [Authorize(Roles = "Admin, User")]
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

        [Authorize(Roles = "Admin, User")]
        [HttpPost]
        public IActionResult DeletePerson(int id)
        {
            bool success = _peopleService.Remove(id);

            if (success)
            {
                return new OkResult();
            }

            return new NotFoundResult();
        }



        [Authorize(Roles = "Admin, User")]
        [HttpPost]
        public IActionResult AddLanguageView(int id)
        {
            PersonLanguageViewModel personLanguageViewModel = new PersonLanguageViewModel()
            {
                LanguageListView = _languageService.All().LanguageListView,
                Person = _peopleService.FindBy(id)
            };

            //personLanguageViewModel = GenerateSelectList(personLanguageViewModel);
            //personLanguageViewModel.LanguageListView = _languageService.All().LanguageListView;
            //personLanguageViewModel.Person = foundPerson;

            return View("AddLanguagesToPerson", personLanguageViewModel);
        }


        [Authorize(Roles = "Admin, User")]
        public IActionResult AddLanguageToPerson(PersonLanguageViewModel personLanguageViewModel)
        {
            Person person = _peopleService.FindBy(personLanguageViewModel.PersonId);

            personLanguageViewModel.LanguageListView = _languageService.All().LanguageListView;
            personLanguageViewModel.Person = person;

            //personLanguageViewModel = GenerateSelectList(personLanguageViewModel);


            if (ModelState.IsValid)
            {
                bool success = _peopleService.AddLanguageToPerson(personLanguageViewModel);

                if (success) { ViewBag.Mess = "Languages added to Person!"; }
                else { ViewBag.Mess = "Error! Language did NOT get stored"; }

                return View("AddLanguagesToPerson", personLanguageViewModel);
            }

            return View("AddLanguagesToPerson", personLanguageViewModel);
        }


        public IActionResult AccessDenied()
        {
            return View();
        }


        // -------------   Reactjs Json route ----------------------
        [Route("Reactjson")] // Building Personlist to Json API
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult PersonsList()
        {
            _listOfPersons = _peopleService.All().PeopleListView;
            return Json(_listOfPersons);
        }

    }

}
