using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppAssignmentMVC_Data_1_3.Models;

namespace WebAppAssignmentMVC_Data_1_3.Controllers
{
    public class AjaxController : Controller
    {
        //All new PeopleService() is now replaced by DI via this Constructor, and using _peopleService instead /ER
        private readonly IPeopleService _peopleService;

        public AjaxController(IPeopleService peopleService)
        {
            _peopleService = peopleService;
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
            List<Person> peopleList = _peopleService.All().PeopleListView;

            return PartialView("_PeopleListPartial", peopleList);

        }

        [HttpPost]
        public IActionResult FindPersonById(int id)
        {
            //PeopleService filterString = new PeopleService();
            Person foundPerson = _peopleService.FindBy(id);

            if (foundPerson != null)
            {
                List<Person> addPerson = new List<Person>() { foundPerson };

                return PartialView("_PeopleListPartial", addPerson);
            }

            return StatusCode(404);

        }

        [HttpPost]
        public IActionResult DeletePersonById(int id)
        {
            //PeopleService filterString = new PeopleService();
            bool success = _peopleService.Remove(id);

            if (success)
            {
                return StatusCode(200);
            }

            return StatusCode(404);

        }



    }
}
