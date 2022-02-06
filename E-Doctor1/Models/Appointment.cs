using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErgasiaMVC.Models
{
    public class Appointment
    {
        public static int PENDING = 0;
        public static int CANCELLED = 1;

        public int appointment_id { get; set; }
        public DateTime scheduled_date { get; set; }
        public AvailableDate availableDate { get; set; }
        public Patient patient { get; set; }
        public int status { get; set; } // Pending, Cancelled, Done

        public Appointment(int appointment_id, DateTime scheduled_date, AvailableDate availableDate, Patient patient, int status)
        {
            this.appointment_id = appointment_id;
            this.scheduled_date = scheduled_date;
            this.availableDate = availableDate;
            this.patient = patient;
            this.status = status;
        }

        public Appointment(DateTime scheduled_date, AvailableDate availableDate, Patient patient, int status)
        {
            this.scheduled_date = scheduled_date;
            this.availableDate = availableDate;
            this.patient = patient;
            this.status = status;
        }

        public int getAppointment_id()
        {
            return appointment_id;
        }

        public DateTime getScheduled_date()
        {
            return scheduled_date;
        }

        public AvailableDate getAvailableDate()
        {
            return availableDate;
        }

        public Patient getPatient()
        {
            return patient;
        }

        public int getStatus()
        {
            return status;
        }
    }
}
