using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Doctor1.Controllers
{
    public class DoctorMainPageController : Controller
    {
        // GET: DoctorMainPage
        public ActionResult Index()
        {
            return View();
        }
    }
}