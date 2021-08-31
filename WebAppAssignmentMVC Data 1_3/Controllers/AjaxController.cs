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

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AllPeopleList()
        {
            PeopleService checkListView = new PeopleService();
            List<Person> peopleList = checkListView.All().PeopleListView;

            return PartialView("_PeopleListPartial", peopleList);

        }

        [HttpPost]
        public IActionResult FindPersonById(int id)
        {
            PeopleService filterString = new PeopleService();
            Person foundPerson = filterString.FindBy(id);

            if (foundPerson != null)
            {
                List<Person> addPerson = new List<Person>() { foundPerson };

                return PartialView("_PeopleListPartial", addPerson);
            }

            return StatusCode(404);//PartialView("_PeopleListPartial");

        }

        [HttpPost]
        public IActionResult DeletePersonById(int id)
        {
            PeopleService filterString = new PeopleService();
            bool success = filterString.Remove(id);

            if (success)
            {
                return StatusCode(200);
            }

            return StatusCode(404);

        }



    }
}
