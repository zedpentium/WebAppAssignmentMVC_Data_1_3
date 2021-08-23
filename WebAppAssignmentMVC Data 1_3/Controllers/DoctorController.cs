using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppAssignmentMVC_Data_1_3.Models;

namespace WebAppAssignmentMVC_Data_1_3.Controllers
{

    public class DoctorController : Controller
    {

        public IActionResult FeverCheck() // get / HttpGet
        {
            ViewBag.Title = "Check Temperature";
            return View();
        }

        [HttpPost]
        public IActionResult FeverCheck(Doctor createCheck ) // set / HttpPost
        {

            if (ModelState.IsValid)
            {
                ViewBag.resultMessage = Doctor.CheckFuncTheTemp(createCheck);
                return View();
            }

            return View(createCheck);
        }

    }

}
