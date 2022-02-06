using E_Doctor1.Models;
using ErgasiaMVC.Models;
using ErgasiaMVC.Models.DataManagement.DAO;
using ErgasiaMVC.Models.DataManagement.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Doctor1.Controllers
{
    public class PatientMainPageController : Controller
    {
        public object AppointmentManager { get; private set; }

        // GET: PatientMainPage
        public ActionResult Index(Patient patient)
        {
            return View(patient);
        }

        public ActionResult SpecialtyChoice(Patient patient)
        {
            return View(patient);
        }

        public ActionResult ViewAppointmentsPatient(Patient patient)
        {
            AppointmentManagement appointmentManagement = new AppointmentManagement();

            List<Appointment> appointments = appointmentManagement.getAppointments(patient);
            ListModel<Appointment> listModel = new ListModel<Appointment>(appointments, patient);

            return View(listModel);
        }

        public ActionResult AvailableDates(int patient_id, int specialty)
        {
            DoctorAvailability doctorAvailability = new DoctorAvailability();
            List<AvailableDate> availableDates = doctorAvailability.getSpecialtyAvailableDates(specialty);

            AccountManagement accountManagement = new AccountManagement();
            Patient patient = (Patient)accountManagement.getUser(patient_id, AccountDAO.PATIENTS_TABLE);

            ListModel<AvailableDate> listModel = new ListModel<AvailableDate>(availableDates, patient);
            if (specialty == 1)
                listModel.data = "ΠΑΘΟΛΟΓΟ";
            else if (specialty == 2)
                listModel.data = "ΟΦΘΑΛΜΙΑΤΡΟ";
            else
                listModel.data = "ΟΡΘΟΠΕΔΙΚΟ";

            return View(listModel);
        }

        public ActionResult AvailableTime(int available_date_id, int patient_id, string date)
        {
            DoctorAvailability doctorAvailability = new DoctorAvailability();
            AvailableDate availableDate = doctorAvailability.getAvailableDate(available_date_id);

            AccountManagement accountManagement = new AccountManagement();
            Patient patient = (Patient)accountManagement.getUser(patient_id, AccountDAO.PATIENTS_TABLE);

            DateTime scheduled_date = DateTime.Parse(date);

            Appointment appointment = new Appointment(scheduled_date, availableDate, patient, Appointment.PENDING);

            return View(appointment);
        }

        [HttpPost]
        public ActionResult AddAppointment(int available_date_id, int patient_id, string scheduled_date, int hour, int minute)
        {
            DoctorAvailability doctorAvailability = new DoctorAvailability();
            AvailableDate availableDate = doctorAvailability.getAvailableDate(available_date_id);

            AccountManagement accountManagement = new AccountManagement();
            Patient patient = (Patient)accountManagement.getUser(patient_id, AccountDAO.PATIENTS_TABLE);

            DateTime date = DateTime.Parse(scheduled_date);

            date = date.AddHours(hour);
            date = date.AddMinutes(minute);

            Appointment appointment = new Appointment(date, availableDate, patient, Appointment.PENDING);

            AppointmentManagement appointmentManagement = new AppointmentManagement();

            appointmentManagement.createAppointment(appointment);

            return RedirectToAction("Index", "PatientMainPage", patient);
        }

        [HttpPost]
        public ActionResult CancelAppointment(int appointment_id)
        {
            AppointmentManagement appointmentManager = new AppointmentManagement();

            Appointment appointment = appointmentManager.getAppointment(appointment_id);

            appointmentManager.changeAppointmentStatus(appointment_id);

            return RedirectToAction("ViewAppointmentsPatient", "PatientMainPage", appointment.patient);
        }

    }
}