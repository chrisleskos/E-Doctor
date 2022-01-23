using System;
using Npgsql;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErgasiaMVC.Models.DataManagement.Utilities;

namespace ErgasiaMVC.Models.DataManagement.DAO
{
    public class AccountDAO : AccountDaoInterface
    {

        public static readonly int ADMINISTRATORS_TABLE = 1;
        public static readonly int DOCTORS_TABLE = 2;
        public static readonly int PATIENTS_TABLE = 3;

        private NpgsqlConnection connection;

        public AccountDAO()
        {
            this.connection = DatabaseUtil.getConnection("appointments_management");
            connection.Open();
        }

        ~AccountDAO()
        {
            connection.Close();
        }

        public NpgsqlDataReader getUser(string username, int table_index)
        {
            String table = "";

            if (table_index == ADMINISTRATORS_TABLE)
                table = "administrators";
            else if (table_index == DOCTORS_TABLE)
                table = "doctors";
            else if (table_index == PATIENTS_TABLE)
                table = "patients";


            String query = "SELECT * FROM user_auth as ua " +
                    "INNER JOIN " + table + " as b " +
                    "ON ua.user_id = b.id " +
                    "WHERE username = @username";


            NpgsqlCommand statement = new NpgsqlCommand(query, connection);

            statement.Parameters.AddWithValue("username", username);

            return statement.ExecuteReader();
        }

        private void createUser(String password, String salt)
        {
            String query = "INSERT INTO user_auth (user_password, salt) VALUES(@password, @salt) ";

            NpgsqlCommand statement = new NpgsqlCommand(query, connection);

            statement.Parameters.AddWithValue("password", password);
            statement.Parameters.AddWithValue("salt", salt);

            statement.ExecuteReader();
        }

        private void deleteFalseGeneratedUser(Exception exc)
        {

            String query = "DELETE FROM user_auth WHERE user_id = (SELECT currval(pg_get_serial_sequence('user_auth','user_id')))";

            try {
                NpgsqlCommand statement = new NpgsqlCommand(query, connection);
                statement.ExecuteReader();
                Console.WriteLine("Deleted user");
                throw exc;
            } catch (Exception e) {
                Console.WriteLine(e.Message);
            }

        }

        public void createAdmin(Admin admin)
        {
            createUser(admin.getPassword(), admin.getSalt());

            String query = "INSERT INTO administrators (id, username, first_name, last_name, email) " +
                    "VALUES ((SELECT currval(pg_get_serial_sequence('user_auth','user_id'))), @username, @first_name, @last_name, @email)";
            try
            {
                NpgsqlCommand statement = new NpgsqlCommand(query, connection);

                statement.Parameters.AddWithValue("username", admin.getUsername());
                statement.Parameters.AddWithValue("first_name", admin.getFirstname());
                statement.Parameters.AddWithValue("last_name", admin.getLastname());
                statement.Parameters.AddWithValue("email", admin.getEmail());

                statement.ExecuteReader();
            }
            catch (Exception e)
            {
                deleteFalseGeneratedUser(e);
            }
        }

        public void createDoctor(Doctor doctor)
        {
            createUser(doctor.getPassword(), doctor.getSalt());

            String query = "INSERT INTO doctors (id, username, first_name, last_name, email, phone_number, amka, specialty) " +
                    "VALUES ((SELECT currval(pg_get_serial_sequence('user_auth','user_id'))), @username, @first_name, @last_name, @email, @phone_number, @amka, @specialty)";

            try
            {
                NpgsqlCommand statement = new NpgsqlCommand(query, connection);

                statement.Parameters.AddWithValue("username", doctor.getUsername());
                statement.Parameters.AddWithValue("first_name", doctor.getFirstname());
                statement.Parameters.AddWithValue("last_name", doctor.getLastname());
                statement.Parameters.AddWithValue("email", doctor.getEmail());
                statement.Parameters.AddWithValue("phone_number", doctor.getPhone_number());
                statement.Parameters.AddWithValue("amka", doctor.getAmka());
                statement.Parameters.AddWithValue("specialty", doctor.getSpecialty());

                statement.ExecuteReader();
            }
            catch (Exception e)
            {
                deleteFalseGeneratedUser(e);
            }
        }

        public void createPatient(Patient patient)
        {
            createUser(patient.getPassword(), patient.getSalt());

            String query = "INSERT INTO patients (id, username, first_name, last_name, email, phone_number, amka) " +
                    "VALUES ((SELECT currval(pg_get_serial_sequence('user_auth','user_id'))), @username, @first_name, @last_name, @email, @phone_number, @amka)";

            try
            {
                NpgsqlCommand statement = new NpgsqlCommand(query, connection);

                statement.Parameters.AddWithValue("username", patient.getUsername());
                statement.Parameters.AddWithValue("first_name", patient.getFirstname());
                statement.Parameters.AddWithValue("last_name", patient.getLastname());
                statement.Parameters.AddWithValue("email", patient.getEmail());
                statement.Parameters.AddWithValue("phone_number", patient.getPhone_number());
                statement.Parameters.AddWithValue("amka", patient.getAmka());

                statement.ExecuteReader();
            }
            catch (Exception e)
            {
                deleteFalseGeneratedUser(e);
            }
        }

        public void editUser(Admin admin)
        {
            throw new NotImplementedException();
        }

        public void editUser(Patient patient)
        {
            throw new NotImplementedException();
        }

        public void editUser(Doctor doctor)
        {
            throw new NotImplementedException();
        }

    }
}
