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
        public IActionResult Index(CreatePersonViewModel viewModel)
        {
            //PeopleService filterString = new PeopleService();

            //viewModel = filterString.FindBy(viewModel);

            return View(viewModel);

        }*/


        /*public IActionResult CreatePerson() // set / HttpPost
        {
            CreatePersonViewModel returnView = new CreatePersonViewModel();

            return View("Home", returnView);
        }*/


        [HttpPost]
        public IActionResult CreatePerson(CreatePersonViewModel createNewPerson) // set / HttpPost
        {
            //try
            //{
                if (ModelState.IsValid)
                { 
                    PeopleService newPerson = new PeopleService();

                    newPerson.Add(createNewPerson);

                    return RedirectToAction("Index", createNewPerson);
                }

            return RedirectToAction("Index", createNewPerson);
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
