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
                        return RedirectToAction("Index", "AdminMainPage", user);
                    }
                    else if (user.GetType() == typeof(Patient))
                    {
                        return RedirectToAction("Index", "PatientMainPage", user);
                    }
                    else if (user.GetType() == typeof(Doctor))
                    {
                        return RedirectToAction("Index", "DoctorMainPage", user);
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


        public ActionResult Register()
        {
            return View(new Patient());
        }

        [HttpPost]
        public ActionResult Register(Patient patient)
        {
            AccountManagement accountManagement = new AccountManagement();
            try
            {

                accountManagement.register(patient.Username, patient.Password, patient.first_name, patient.last_name, patient.email, patient.phone_number, patient.amka);
            }
            catch (UsernameAlreadyTaken e)
            {
                return Content(e.Message);
            }

            return RedirectToAction("Index", "Home");
        }

    }
}