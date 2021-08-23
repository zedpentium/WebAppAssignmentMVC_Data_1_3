using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using WebAppAssignmentMVC_Data_1_3.Models;

namespace WebAppAssignmentMVC_Data_1_3.Controllers
{

    public class GameController : Controller
    {
        private int _gameRndNr;
        //const string SessionValueName = "_Value";

        public IActionResult GuessingGame() // get / HttpGet
        {
            ViewBag.Title = "Welcome to Guessing game";
            ViewBag.buttonView = "<input type = \"submit\" class=\"btn btn-primary\" name=\"btnSubmit\" value=\"Guess Number\">";

            Random gRnd = new Random();
            _gameRndNr = gRnd.Next(1,101); 

            HttpContext.Session.SetInt32("GameNr", _gameRndNr);

            return View();
        }

        [HttpPost]
        public IActionResult GuessingGame(Game createCheck) // set / HttpPost
        {
            Game newObj = new Game();
            bool isItWin = false;

            if (ModelState.IsValid)
            {
                //Game[] inAn = Game[3];
                string messageToView = newObj.CheckTheGuess(createCheck, (int)HttpContext.Session.GetInt32("GameNr"), out isItWin);

                if (isItWin)
                {
                    ViewBag.resultMessage = messageToView;
                    ViewBag.buttonView = "<input type = \"button\" class=\"btn btn-primary\" name=\"btnSubmit\" value=\"Play Again\" onClick = \"parent.location='/GuessingGame'\">";
                    //RedirectToAction
                    return View();
                } else
                {
                    
                    ViewBag.buttonView = "<input type = \"submit\" class=\"btn btn-primary\" name=\"btnSubmit\" value=\"Guess Number\">";
                }

                ViewBag.resultMessage = messageToView;

                return View();
            }

            return View(createCheck);
        }

    }

}
