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

        public PartialViewResult PersonList()
        {
            return PartialView("_PeopleListPartial");
        }


        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Title = "Eric R Project";

            PeopleService checkListView = new PeopleService();
            PeopleViewModel peopleList = new PeopleViewModel();

            InMemoryPeopleRepo makeBaseList = new InMemoryPeopleRepo(); // to generate 4 persons in Repo

            peopleList.PeopleListView = checkListView.All().PeopleListView;

            if (peopleList.PeopleListView.Count == 0 || peopleList.PeopleListView == null)
            {
                makeBaseList.CreateBasePersons();
            }

            return View(peopleList);
        }

        [HttpPost]
        public IActionResult Index(PeopleViewModel viewModel)
        {
            PeopleService filterString = new PeopleService();

            viewModel = filterString.FindBy(viewModel);
                return View(viewModel); 
        }


        [HttpPost]
        public IActionResult CreatePerson(CreatePersonViewModel personViewModel) // set / HttpPost
        {

            var newModel = new PeopleViewModel();
            PeopleService repoList = new PeopleService();

            if (ModelState.IsValid)
                {

                newModel.PersonName = personViewModel.PersonName;
                newModel.PersonPhoneNumber = personViewModel.PersonPhoneNumber;
                newModel.PersonCity = personViewModel.PersonCity;

                newModel.PeopleListView = repoList.All().PeopleListView;


                repoList.Add(personViewModel);

                    ViewBag.Mess = "Person Added!";

                    return View("Index", newModel);
                }

            newModel.PersonName = personViewModel.PersonName;
            newModel.PersonPhoneNumber = personViewModel.PersonPhoneNumber;
            newModel.PersonCity = personViewModel.PersonCity;

            newModel.PeopleListView = repoList.All().PeopleListView;

            return View("index", newModel);
        }


        public IActionResult DeletePerson(int id)
        {
            PeopleService deleteById = new PeopleService();
            deleteById.Remove(id);

            return RedirectToAction("Index");
        }
        
    }
}
