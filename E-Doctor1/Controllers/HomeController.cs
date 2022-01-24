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
            return View(new UserCred());
        }


        [HttpPost]
        public ActionResult Index(UserCred userCred)
        {

            AccountManagement accountManagement = new AccountManagement();

            try
            {
                if (ModelState.IsValid)
                {
                    object user = accountManagement.login(userCred.Username, userCred.Password);

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
                return RedirectToAction("Index", "Home");
            }
            catch (WrongPasswordException e)
            {
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Index", "Home");
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