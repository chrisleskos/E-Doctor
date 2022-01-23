using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErgasiaMVC.Models
{
    public class Appointment
    {
        private int appointment_id;
        //private Date scheduled_date;
        private AvailableDate availableDate;
        private Patient patient;
        private Doctor doctor;
        private int status; // Pending, Cancelled, Done

        public Appointment(int appointment_id, /*Date scheduled_date*/ AvailableDate availableDate, Patient patient, Doctor doctor, int status)
        {
            this.appointment_id = appointment_id;
            //this.scheduled_date = scheduled_date;
            this.availableDate = availableDate;
            this.patient = patient;
            this.doctor = doctor;
            this.status = status;
        }

        public int getAppointment_id()
        {
            return appointment_id;
        }

        /*public Date getScheduled_date()
        {
            return scheduled_date;
        }*/

        public AvailableDate getAvailableDate()
        {
            return availableDate;
        }

        public Patient getPatient()
        {
            return patient;
        }

        public Doctor getDoctor()
        {
            return doctor;
        }

        public int getStatus()
        {
            return status;
        }
    }
}
