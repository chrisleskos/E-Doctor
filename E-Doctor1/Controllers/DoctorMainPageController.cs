using ErgasiaMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ErgasiaMVC.Models.DataManagement.Managers;
using E_Doctor1.Models;
using ErgasiaMVC.Models.DataManagement.DAO;

namespace E_Doctor1.Controllers
{
    public class DoctorMainPageController : Controller
    {
        // GET: DoctorMainPage
        public ActionResult Index(Doctor doctor)
        {
            return View(doctor);
        }

        public ActionResult AddAvailableDate(int doctor_id, int day)
        {
            AvailableDate availableDate = new AvailableDate();

            AccountManagement account = new AccountManagement();
            availableDate.doctor = (Doctor)account.getUser(doctor_id, AccountDAO.DOCTORS_TABLE);
            availableDate.Day = day;

            return View(availableDate);
        }

        public ActionResult EditAvailableDate(int available_date_id)
        {
            DoctorAvailability doctorAvailability = new DoctorAvailability();
            AvailableDate availableDate = doctorAvailability.getAvailableDate(available_date_id);

            return View(availableDate);
        }

        [HttpPost]
        public ActionResult AddAvailableDate(AvailableDate availableDate, int starting_hours, int starting_minutes, int ending_hours, int ending_minutes)
        {
            DoctorAvailability doctorAvailability = new DoctorAvailability();
            availableDate.Starting_time = new TimeSpan(starting_hours, starting_minutes, 0);
            availableDate.Ending_time = new TimeSpan(ending_hours, ending_minutes, 0);
            doctorAvailability.createAvailableDate(availableDate);

            return RedirectToAction("AvailableDates", "DoctorMainPage", availableDate.doctor);
        }

        [HttpPost]
        public ActionResult EditAvailableDate(AvailableDate availableDate, int starting_hours, int starting_minutes, int ending_hours, int ending_minutes)
        {
            DoctorAvailability doctorAvailability = new DoctorAvailability();
            availableDate.Starting_time = new TimeSpan(starting_hours, starting_minutes, 0);
            availableDate.Ending_time = new TimeSpan(ending_hours, ending_minutes, 0);
            doctorAvailability.editAvailableDate(availableDate);

            return RedirectToAction("AvailableDates", "DoctorMainPage", availableDate.doctor);
        }

        public ActionResult DeleteAvailableDate(int available_date_id)
        {
            DoctorAvailability doctorAvailability = new DoctorAvailability();
            doctorAvailability.deleteAvailableDate(available_date_id);

            AvailableDate availableDate = doctorAvailability.getAvailableDate(available_date_id);
            
            return RedirectToAction("AvailableDates","DoctorMainPage", availableDate.doctor);
        }

        public ActionResult AvailableDates(Doctor doctor)
        {
            IDoctorAvailabilityManagement doctorAvailabilty = new DoctorAvailability();
            List<AvailableDate> availableDates = doctorAvailabilty.getAvailableDates(doctor.user_id);
            ListModel<AvailableDate> listModel = new ListModel<AvailableDate>(availableDates, doctor);

            return View(listModel);
        }

        public ActionResult ViewAppointmentsDoctor(Doctor doctor)
        {

            AppointmentManagement appointmentManagement = new AppointmentManagement();

            List<Appointment> appointments = appointmentManagement.getAppointments(doctor);
            ListModel<Appointment> listModel = new ListModel<Appointment>(appointments, doctor);

            return View(listModel);
        }
    }
}