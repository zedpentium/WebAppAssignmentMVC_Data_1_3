using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppAssignmentMVC_Data_1_3.Models;

namespace WebAppAssignmentMVC_Data_1_3.Controllers
{
    public class CountryController : Controller
    {
        //All new PeopleService() is now replaced by DI via this Constructor, and using _peopleService instead /ER
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AllPeopleList()
        {
            //PeopleService checkListView = new PeopleService();
            List<Country> countryList = _countryService.All().CountryListView;

            return PartialView("_CountryListPartial", countryList);

        }

        [HttpPost]
        public IActionResult FindCountryById(int id)
        {
            //PeopleService filterString = new PeopleService();
            Country foundCountry = _countryService.FindBy(id);

            if (foundCountry != null)
            {
                List<Country> addCountry = new List<Country>() { foundCountry };

                return PartialView("_PeopleListPartial", addCountry);
            }

            return StatusCode(404);

        }

        [HttpPost]
        public IActionResult DeleteCountryById(int id)
        {
            //PeopleService filterString = new PeopleService();
            bool success = _countryService.Remove(id);

            if (success)
            {
                return StatusCode(200);
            }

            return StatusCode(404);

        }



    }
}
