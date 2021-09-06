using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppAssignmentMVC_Data_1_3.Models;
using WebAppAssignmentMVC_Data_1_3.Data;
using Microsoft.Extensions.DependencyInjection;

namespace WebAppAssignmentMVC_Data_1_3.Controllers
{
    public class PeopleController : Controller
    {

        // Now using DI and theese Constructors /ER

        private readonly IPeopleService _peopleService;
        private readonly ICityService _cityService;
        private readonly ICountryService _countryService;

        public PeopleController(IPeopleService peopleService, ICityService cityService, ICountryService countryService)
        {
            _peopleService = peopleService;
            _cityService = cityService;
            _countryService = countryService;
        }

        /*public PeopleController(ICityService cityService)
        {
            _cityService = cityService;
        }*/


        public PartialViewResult PersonList()
        {
            return PartialView("_PeopleListPartial");
        }


        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Title = "Eric R Project. This view will generate cities and persons if database is blank";

            PeopleViewModel peopleViewModel = new PeopleViewModel()
            { 
                PeopleListView = _peopleService.All().PeopleListView,
                CityListView = _cityService.All().CityListView,
            };


            /*if (peopleViewModel.CountryListView.Count == 0 || peopleViewModel.CountryListView == null) // commented out coz not using country atm
            {
                _countryService.CreateBaseCountries();  // to generate 4 persons in Repo
                ViewBag.BaseCountryList = "Database was empty, added cities into it.";
                peopleViewModel.CountryListView = _countryService.All().CountryListView;
            }*/

            if (peopleViewModel.CityListView.Count == 0 || peopleViewModel.CityListView == null)
            {
                _cityService.CreateBaseCities();  // to generate 4 persons in Repo
                ViewBag.BaseCityList = "Database was empty, added cities into it.";
                peopleViewModel.CityListView = _cityService.All().CityListView;
            }

            if (peopleViewModel.PeopleListView.Count == 0 || peopleViewModel.PeopleListView == null)
            {
                _peopleService.CreateBasePeople(peopleViewModel.CityListView);  // to generate 4 persons in Repo
                ViewBag.BasePersonList = "Database was empty, added peoples into it.";
                peopleViewModel.PeopleListView = _peopleService.All().PeopleListView;
            }

            return View(peopleViewModel);
        }

        [HttpPost]
        public IActionResult Index(PeopleViewModel viewModel)
        {
            PeopleViewModel peopleViewModel = new PeopleViewModel()
            { 
                PeopleListView = _peopleService.FindBy(viewModel).PeopleListView,
                CityListView = _cityService.All().CityListView,
            };

                return View(peopleViewModel); 
        }


        [HttpPost]
        public IActionResult CreatePerson(CreatePersonViewModel personViewModel) // set / HttpPost
        {

            var newModel = new PeopleViewModel();

            if (ModelState.IsValid)
                {

                newModel.PersonName = personViewModel.PersonName;
                newModel.PersonPhoneNumber = personViewModel.PersonPhoneNumber;
                newModel.PersonCity = personViewModel.PersonCity;

                newModel.PeopleListView = _peopleService.All().PeopleListView;


                _peopleService.Add(personViewModel);

                    ViewBag.Mess = "Person Added!";

                    return View("Index", newModel);
                }

            newModel.PersonName = personViewModel.PersonName;
            newModel.PersonPhoneNumber = personViewModel.PersonPhoneNumber;
            newModel.PersonCity = personViewModel.PersonCity;

            newModel.PeopleListView = _peopleService.All().PeopleListView;

            return View("index", newModel);
        }


        public IActionResult DeletePerson(int id)
        {
            //PeopleService deleteById = new PeopleService();
            _peopleService.Remove(id);

            return RedirectToAction("Index");
        }


    }


}
