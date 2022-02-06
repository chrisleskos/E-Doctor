using ErgasiaMVC.Models;
using ErgasiaMVC.Models.DataManagement.Factories;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Doctor1.Models.DataManagement.Factories
{
    public class AvailableDateFactory
    {
        public static AvailableDate buildAvailableDate(NpgsqlDataReader reader)
        {
            int available_date_id = reader.GetInt32(reader.GetOrdinal("available_appointment_id"));
            TimeSpan starting_time = reader.GetTimeSpan(reader.GetOrdinal("starting_time"));
            TimeSpan ending_time = reader.GetTimeSpan(reader.GetOrdinal("ending_time"));
            int day = reader.GetInt32(reader.GetOrdinal("day_of_week"));

            int doctor_id = reader.GetInt32(reader.GetOrdinal("id"));
            string username = reader.GetString(reader.GetOrdinal("username"));
            string first_name = reader.GetString(reader.GetOrdinal("first_name"));
            string last_name = reader.GetString(reader.GetOrdinal("last_name"));
            string email = reader.GetString(reader.GetOrdinal("email"));
            string phone_number = reader.GetString(reader.GetOrdinal("phone_number"));
            string amka = reader.GetString(reader.GetOrdinal("amka"));
            int specialty = reader.GetInt32(reader.GetOrdinal("specialty"));

            Doctor doctor = new Doctor(doctor_id, username, first_name, last_name, email, phone_number, amka, specialty);

            return new AvailableDate(available_date_id, day, starting_time, ending_time, doctor);


        }
    }
}