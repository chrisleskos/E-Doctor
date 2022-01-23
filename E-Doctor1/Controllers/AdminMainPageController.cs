using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Doctor1.Controllers
{
    public class AdminMainPageController : Controller
    {
        // GET: AdminMainPage
        public ActionResult Index()
        {
            return View();
        }

        //register

        public ActionResult PatientRegister()
        {
            return RedirectToAction("PatientRegister", "Index");

        }

    }
}