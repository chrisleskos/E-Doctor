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
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SpecialtyChoice()
        {
            return View();
        }

        public ActionResult ViewAppointmentsPatient()
        {
            return View();
        }


        public ActionResult AvailableDates()
        {
            return View();
        }

        public ActionResult AvailableTime()
        {
            return View();
        }
    }
}