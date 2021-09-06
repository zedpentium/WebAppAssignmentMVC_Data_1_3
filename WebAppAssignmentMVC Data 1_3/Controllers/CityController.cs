using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppAssignmentMVC_Data_1_3.Models;

namespace WebAppAssignmentMVC_Data_1_3.Controllers
{
    public class CityController : Controller
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AllCityList()
        {
            //PeopleService checkListView = new PeopleService();
            List<City> cityList = _cityService.All().CityListView;

            return PartialView("_CityListPartial", cityList);

        }

        [HttpPost]
        public IActionResult FindCityById(int id)
        {
            //PeopleService filterString = new PeopleService();
            City foundCity = _cityService.FindBy(id);

            if (foundCity != null)
            {
                List<City> addCity = new List<City>() { foundCity };

                return PartialView("_CityListPartial", addCity);
            }

            return StatusCode(404);

        }

        [HttpPost]
        public IActionResult DeleteCityById(int id)
        {
            //PeopleService filterString = new PeopleService();
            bool success = _cityService.Remove(id);

            if (success)
            {
                return StatusCode(200);
            }

            return StatusCode(404);

        }



    }
} // ER Code
