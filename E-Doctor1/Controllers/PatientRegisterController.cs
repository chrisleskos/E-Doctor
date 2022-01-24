using ErgasiaMVC.Models;
using ErgasiaMVC.Models.DataManagement.Exceptions;
using ErgasiaMVC.Models.DataManagement.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Doctor1.Controllers
{
    public class PatientRegisterController : Controller
    {
        // GET: PatientRegister
        public ActionResult Index()
        {
            return View(new Patient());
        }

        [HttpPost]
        public ActionResult Index(Patient patient)
        {
            AccountManagement accountManagement = new AccountManagement();
            try
            {

                accountManagement.register(patient.Username, patient.Password, patient.first_name, patient.last_name, patient.email, patient.phone_number, patient.amka);
            } catch (UsernameAlreadyTaken e)
            {
                return Content(e.Message);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}