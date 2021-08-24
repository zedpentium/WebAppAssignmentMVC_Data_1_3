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

        public IActionResult Home()
        {
            ViewBag.Title = "Home of Eric R People List Page";

            //PeopleService newPerson = new PeopleService();
            //newPerson.All();

            return View();
        }

        private int _gameRndNr;
        //const string SessionValueName = "_Value";

        /*public IActionResult Filtersearch() // get / HttpGet
        {
            ViewBag.Title = "Welcome to Guessing game";
            ViewBag.buttonView = "<input type = \"submit\" class=\"btn btn-primary\" name=\"btnSubmit\" value=\"Guess Number\">";

            Random gRnd = new Random();
            _gameRndNr = gRnd.Next(1, 101);

            HttpContext.Session.SetInt32("GameNr", _gameRndNr);

            return View();
        }*/

        /*[HttpPost]
        public IActionResult Filtersearch(Game createCheck) // set / HttpPost
        {
            Game newObj = new Game();
            bool isItWin = false;

            if (ModelState.IsValid)
            {
                //Game[] inAn = Game[3];
                string messageToView = newObj.CheckTheSearch(createCheck, (int)HttpContext.Session.GetInt32("GameNr"), out isItWin);

                if (isItWin)
                {
                    ViewBag.resultMessage = messageToView;
                    ViewBag.peoplelist = "<input type = \"button\" class=\"btn btn-primary\" name=\"btnSubmit\" value=\"Play Again\" onClick = \"parent.location='/GuessingGame'\">";
                    //RedirectToAction
                    return View();
                }
                else
                {

                    ViewBag.peoplelist = "<input type = \"submit\" class=\"btn btn-primary\" name=\"btnSubmit\" value=\"Guess Number\">";
                }

                ViewBag.peoplelist = messageToView;

                return View();
            }

            return View(createCheck);
        }*/





        [HttpPost]
        public IActionResult CreatePerson(Person createNewPerson) // set / HttpPost
        {
            //PeopleService newPerson = new PeopleService();
            //newPerson.Add(createNewPerson);

            return View();
        }




       /*     private List<People> GetPeopleList()
        {
            List<People> pList = new List<People>();
            pList.Add(new People { Name = "Tejas Trivedi", PhoneNr = "0777 777777", City = "Tiesto" });
            pList.Add(new People { Name = "Boose Bus", PhoneNr = "0777 777777", City = "Flen" });
            pList.Add(new People { Name = "Kjell Kriminell", PhoneNr = "0777 777777", City = "Burg" });
            return pList;
        }


        */

    }
}
