using ErgasiaMVC.Models;
using ErgasiaMVC.Models.DataManagement.Factories;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Doctor1.Models.DataManagement.Factories
{
    public class AppointmentFactory
    {
        public static Appointment buildAppointment(NpgsqlDataReader reader)
        {

            int appointment_id = reader.GetInt32(reader.GetOrdinal("appointment_id"));
            DateTime scheduled_date = reader.GetDateTime(reader.GetOrdinal("scheduled_date"));
            int status = reader.GetInt32(reader.GetOrdinal("status"));
            AvailableDate availableDate = AvailableDateFactory.buildAvailableDate(reader);

            int patient_id = reader.GetInt32(reader.GetOrdinal("patient_id"));
            string username = reader.GetString(11);
            string first_name = reader.GetString(12);
            string last_name = reader.GetString(13);
            string email = reader.GetString(14);
            string phone_number = reader.GetString(15);
            string amka = reader.GetString(16);

            Patient patient = new Patient(patient_id,username, first_name, last_name, email, amka, phone_number);

            return new Appointment(appointment_id, scheduled_date, availableDate, patient, status);
        }
    }
}