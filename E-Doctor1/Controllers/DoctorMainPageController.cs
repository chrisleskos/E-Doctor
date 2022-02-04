using ErgasiaMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ErgasiaMVC.Models.DataManagement.Managers;
using E_Doctor1.Models;

namespace E_Doctor1.Controllers
{
    public class DoctorMainPageController : Controller
    {
        // GET: DoctorMainPage
        public ActionResult Index(Doctor doctor)
        {
            return View(doctor);
        }

        public ActionResult AddAvailableDate(Doctor doctor, string day)
        {
            AvailableDate availableDate = new AvailableDate();
            availableDate.doctor = doctor;
            availableDate.Day = Int32.Parse(day);

            return View(availableDate);
        }

        [HttpPost]
        public ActionResult AddAvailableDate(AvailableDate availableDate)
        {
            DoctorAvailability doctorAvailability = new DoctorAvailability();
            doctorAvailability.createAvailableDate(availableDate);

            return View();
        }

        public ActionResult AvailableDates(Doctor doctor)
        {
            IDoctorAvailabilityManagement doctorAvailabilty = new DoctorAvailability();
            List<AvailableDate> availableDates = doctorAvailabilty.getAvailableDates(doctor.user_id);
            
            return View(availableDates);
        }

        public ActionResult ViewAppointmentsDoctor()
        {
            return View();
        }
    }
}