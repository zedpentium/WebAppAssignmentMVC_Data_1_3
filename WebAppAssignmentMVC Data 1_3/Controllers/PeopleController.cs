using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppAssignmentMVC_Data_1_3.Models;

namespace WebAppAssignmentMVC_Data_1_3.Controllers
{
    public class PeopleController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Title = "Eric R Project";

            PeopleService peopleListView = new PeopleService();
            InMemoryPeopleRepo peopleList = new InMemoryPeopleRepo();

            if (peopleList.Read().Count == 0)
            {
                peopleList.CreateBasePersons();

            }

            return View(peopleListView.All());
        }

        [HttpPost]
        public IActionResult Index(PeopleViewModel viewModel)
        {
            PeopleService filterString = new PeopleService();

            viewModel = filterString.FindBy(viewModel);

            return View(viewModel);

        }

        /*[HttpPost]
        public IActionResult Index(CreatePersonViewModel createViewModel)
        {
            PeopleService peopleListView = new PeopleService();

            return View(createViewModel);

        }
        */

        /*public IActionResult CreatePerson() // set / HttpPost
        {
            return View("Index");
        }*/
        

        [HttpPost]
        public IActionResult CreatePerson(CreatePersonViewModel  personViewModel) // set / HttpPost
        {
            //try
            //{
                if (ModelState.IsValid)
                { 
                    PeopleService newPerson = new PeopleService();

                    newPerson.Add(personViewModel);

                ViewBag.Mess = "Person Added!";

                    return RedirectToAction("Index");
                }

            return RedirectToAction("index", personViewModel);
        }


        /*public IActionResult DeletePerson(int id) // set / HttpPost
        {
            PeopleService deleteById = new PeopleService();
            //InMemoryPeopleRepo deleteById = new InMemoryPeopleRepo();
            deleteById.Remove(id);

            return RedirectToAction(nameof(Home));
        }
        */
    }
}
