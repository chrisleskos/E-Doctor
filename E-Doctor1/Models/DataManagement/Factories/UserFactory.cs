using System;
using Npgsql;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErgasiaMVC.Models.DataManagement.Factories
{
    public class UserFactory
    {
        public static Admin buildAdmin(NpgsqlDataReader dr)
        {
            try
            {
                int user_id = dr.GetInt32(dr.GetOrdinal("user_id"));
                String password = dr.GetString(dr.GetOrdinal("user_password"));
                String salt = dr.GetString(dr.GetOrdinal("salt"));
                String username = dr.GetString(dr.GetOrdinal("username"));
                String first_name = dr.GetString(dr.GetOrdinal("first_name"));
                String last_name = dr.GetString(dr.GetOrdinal("last_name"));
                String email = dr.GetString(dr.GetOrdinal("email"));

                return new Admin(user_id, username, password, salt, first_name, last_name, email);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return null;
        }

        public static Doctor buildDoctor(NpgsqlDataReader dr)
        {
            try
            {
                int user_id = dr.GetInt32(dr.GetOrdinal("user_id"));
                String password = dr.GetString(dr.GetOrdinal("user_password"));
                String salt = dr.GetString(dr.GetOrdinal("salt"));
                String username = dr.GetString(dr.GetOrdinal("username"));
                String first_name = dr.GetString(dr.GetOrdinal("first_name"));
                String last_name = dr.GetString(dr.GetOrdinal("last_name"));
                String email = dr.GetString(dr.GetOrdinal("email"));
                String phone_number = dr.GetString(dr.GetOrdinal("phone_number"));
                String amka = dr.GetString(dr.GetOrdinal("amka"));
                int specialty = dr.GetInt32(dr.GetOrdinal("specialty"));

                return new Doctor(user_id, username, password, salt, first_name, last_name, email, phone_number, amka, specialty);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return null;
        }

        public static Patient buildPatient(NpgsqlDataReader dr)
        {
            try
            {
                int user_id = dr.GetInt32(dr.GetOrdinal("user_id"));
                String password = dr.GetString(dr.GetOrdinal("user_password"));
                String salt = dr.GetString(dr.GetOrdinal("salt"));
                String username = dr.GetString(dr.GetOrdinal("username"));
                String first_name = dr.GetString(dr.GetOrdinal("first_name"));
                String last_name = dr.GetString(dr.GetOrdinal("last_name"));
                String email = dr.GetString(dr.GetOrdinal("email"));
                String phone_number = dr.GetString(dr.GetOrdinal("phone_number"));
                String amka = dr.GetString(dr.GetOrdinal("amka"));

                return new Patient(user_id, username, password, salt, first_name, last_name, email, phone_number, amka);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return null;
        }
    }
}
