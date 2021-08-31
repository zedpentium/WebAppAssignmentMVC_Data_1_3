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
        [ValidateAntiForgeryToken]
        public IActionResult FindPersonById(string id)
        {
            PeopleService filterString = new PeopleService();
            Person foundPerson = filterString.FindBy(2);//(Convert.ToInt32(id));

            if (foundPerson != null)
            {
                List<Person> addPerson = new List<Person>() { foundPerson };

                return PartialView("_PeopleListPartial", addPerson);
            }

            return PartialView("_PeopleListPartial");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePersonById(string id)
        {
            PeopleService filterString = new PeopleService();
            bool isItDone = filterString.Remove(Convert.ToInt32(id));

            /*if (!isItDone)
            {
                List<Person> addPerson = new List<Person>();
                addPerson.Add(foundPerson);
                return PartialView("_PeopleListPartial", addPerson);
            }*/

            return Ok(); //PartialView("_PeopleListPartial");

        }



    }
}
