using E_Doctor1.Models;
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
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

       /* [HttpPost]*/
        [ValidateAntiForgeryToken]
        public ActionResult Login(string username, string password)
        {
            AccountManagement accountManagement = new AccountManagement();
            try
            {
                if (ModelState.IsValid)
                {
                    object user = accountManagement.login(username, password);
                    if (user.GetType() == typeof(Admin))
                    {
                        return RedirectToAction("Index", "AdminMainPage");

                    }
                    else if (user.GetType() == typeof(Patient))
                    {
                        return RedirectToAction("Index", "PatientMainPage");
                    }
                    else if (user.GetType() == typeof(Doctor))
                    {
                        return RedirectToAction("Index", "DoctorMainPage" );
                    }
                }

            }
            catch (UserNotFoundException e)
            {
                Console.WriteLine(e.Message);
                ModelState.AddModelError("", "Invalid Credentials");


            }
            catch (WrongPasswordException e)
            {
                Console.WriteLine(e.Message);
                ModelState.AddModelError("", "Invalid Credentials");


            }
            return View();
        }



        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}