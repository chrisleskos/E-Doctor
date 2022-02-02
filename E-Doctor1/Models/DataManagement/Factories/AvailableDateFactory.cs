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
            try
            {
                int available_date_id = reader.GetInt32(reader.GetOrdinal("available_date_id"));
                TimeSpan starting_time = reader.GetTimeSpan(reader.GetOrdinal("starting_time"));
                TimeSpan ending_time = reader.GetTimeSpan(reader.GetOrdinal("ending_time"));
                int day = reader.GetInt32(reader.GetOrdinal("day"));

                Doctor doctor = new Doctor();

                doctor.user_id = reader.GetInt32(reader.GetOrdinal("doctor_id"));
                doctor.Username = reader.GetString(reader.GetOrdinal("username"));
                doctor.first_name = reader.GetString(reader.GetOrdinal("first_name"));
                doctor.last_name = reader.GetString(reader.GetOrdinal("last_name"));
                doctor.email = reader.GetString(reader.GetOrdinal("email"));
                doctor.phone_number = reader.GetString(reader.GetOrdinal("phone_number"));
                doctor.amka = reader.GetString(reader.GetOrdinal("amka"));
                doctor.specialty = reader.GetInt32(reader.GetOrdinal("specialty"));

                return new AvailableDate(available_date_id, day, starting_time, ending_time, doctor);

            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return null;
        }
    }
}