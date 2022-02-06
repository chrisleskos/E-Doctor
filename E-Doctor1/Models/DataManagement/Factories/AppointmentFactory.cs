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
            Patient patient = UserFactory.buildPatient(reader);


            return new Appointment(appointment_id, scheduled_date, availableDate, patient, status);
        }
    }
}