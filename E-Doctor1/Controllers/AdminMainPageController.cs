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
            return View(new Patient());
        }

        [HttpPost]
        public ActionResult PatientRegister(Patient patient)
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

            return RedirectToAction("Index", "AdminMainPage");
            
        }


        public ActionResult DoctorRegister()
        {
            return View(new Doctor());
        }

        [HttpPost]

        public ActionResult DoctorRegister(Doctor doctor)
        {
            AccountManagement accountManagement = new AccountManagement();
            try
            {
                accountManagement.register(doctor.Username, doctor.Password, doctor.first_name, doctor.last_name, doctor.email, doctor.phone_number, doctor.amka, doctor.specialty);
            }
            catch (UsernameAlreadyTaken e)
            {
                return Content(e.Message);
            }

            return RedirectToAction("DoctorRegister", "AdminMainPage");
        }

    }
}