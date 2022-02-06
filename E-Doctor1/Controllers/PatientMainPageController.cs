using ErgasiaMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Doctor1.Controllers
{
    public class PatientMainPageController : Controller
    {
        // GET: PatientMainPage
        public ActionResult Index(Patient patient)
        {
            return View(patient);
        }

        public ActionResult SpecialtyChoice(Patient patient)
        {
            return View(patient);
        }

        public ActionResult ViewAppointmentsPatient()
        {
            return View();
        }


        public ActionResult AvailableDates(Patient patient)
        {
            return View();
        }

        public ActionResult AvailableTime()
        {
            return View();
        }
    }
}