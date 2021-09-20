using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppAssignmentMVC_Data_1_3.Models;
using WebAppAssignmentMVC_Data_1_3.Models.ViewModels;
using WebAppAssignmentMVC_Data_1_3.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace WebAppAssignmentMVC_Data_1_3.Controllers
{
    [Authorize]//(Roles = "RegisteredUser, User, Admin")]

    public class AjaxController : Controller
    {
        //All new PeopleService() is now replaced by DI via this Constructor, and using _peopleService instead /ER
        private readonly IPeopleService _peopleService;
        private readonly ICityService _cityService;
        private readonly ICountryService _countryService;
        private readonly ILanguageService _languageService;

        public AjaxController(IPeopleService peopleService, ICityService cityService, ICountryService countryService, ILanguageService languageService)
        {
            _peopleService = peopleService;
            _cityService = cityService;
            _countryService = countryService;
            _languageService = languageService;
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AllPeopleList()
        {
            PeopleViewModel peopleViewModel = new PeopleViewModel()
            {
                PeopleListView = _peopleService.All().PeopleListView,
                CityListView = _cityService.All().CityListView,
            };

            return PartialView("_PeopleListPartial", peopleViewModel);
        }

        [HttpPost]
        public IActionResult FindPersonById(int id)
        {
            PeopleViewModel peopleViewModel = new PeopleViewModel()
            {
                CityListView = _cityService.All().CityListView,
            };

            Person person = _peopleService.FindBy(id);

            if (person != null)
            {
                peopleViewModel.PeopleListView.Add(person);

                return PartialView("_PeopleListPartial", peopleViewModel);
            }

            return StatusCode(404);

        }

        [HttpPost]
        public IActionResult DeletePersonById(int id)
        {
            bool success = _peopleService.Remove(id);

            if (success)
            {
                return StatusCode(200);
            }

            return StatusCode(404);

        }



    }
}
