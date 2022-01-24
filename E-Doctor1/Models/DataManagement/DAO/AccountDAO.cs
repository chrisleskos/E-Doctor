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
        }

        public void openConn()
        {
            connection.Open();
        }

        public void closeConn()
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

        public void createAdmin(Admin admin)
        {

            String query = "WITH user_insert AS (" +
                "   INSERT INTO user_auth (user_password, salt) " +
                "   VALUES(@password, @salt) " +
                "   INSERT INTO administrators (id, username, first_name, last_name, email) " +
                "   VALUES ((SELECT user_id FROM user_insert), @username, @first_name, @last_name, @email)";

            NpgsqlCommand statement = new NpgsqlCommand(query, connection);

            statement.Parameters.AddWithValue("password", admin.getPassword());
            statement.Parameters.AddWithValue("salt", admin.getSalt());
            statement.Parameters.AddWithValue("username", admin.getUsername());
            statement.Parameters.AddWithValue("first_name", admin.getFirstname());
            statement.Parameters.AddWithValue("last_name", admin.getLastname());
            statement.Parameters.AddWithValue("email", admin.getEmail());

            statement.ExecuteNonQuery();

        }

        public void createDoctor(Doctor doctor)
        {

            String query = "WITH user_insert AS (" +
                "   INSERT INTO user_auth (user_password, salt) " +
                "   VALUES(@password, @salt) " +
                "   RETURNING user_id)" +
                "   INSERT INTO doctors (id, username, first_name, last_name, email, phone_number, amka, specialty) " +
                "   VALUES ((SELECT user_id FROM user_insert), @username, @first_name, @last_name, @email, @phone_number, @amka, @specialty)";



            NpgsqlCommand statement = new NpgsqlCommand(query, connection);


            statement.Parameters.AddWithValue("password", doctor.getPassword());
            statement.Parameters.AddWithValue("salt", doctor.getSalt());
            statement.Parameters.AddWithValue("username", doctor.getUsername());
            statement.Parameters.AddWithValue("first_name", doctor.getFirstname());
            statement.Parameters.AddWithValue("last_name", doctor.getLastname());
            statement.Parameters.AddWithValue("email", doctor.getEmail());
            statement.Parameters.AddWithValue("phone_number", doctor.getPhone_number());
            statement.Parameters.AddWithValue("amka", doctor.getAmka());
            statement.Parameters.AddWithValue("specialty", doctor.getSpecialty());

            statement.ExecuteNonQuery();

        }

        public void createPatient(Patient patient)
        {

            String query = "WITH user_insert AS (" +
                "   INSERT INTO user_auth (user_password, salt) " +
                "   VALUES(@password, @salt) " +
                "   RETURNING user_id)" +
                "   INSERT INTO patients (id, username, first_name, last_name, email, phone_number, amka) " +
                "   VALUES ((SELECT user_id FROM user_insert), @username, @first_name, @last_name, @email, @phone_number, @amka)";


            NpgsqlCommand statement = new NpgsqlCommand(query, connection);

            statement.Parameters.AddWithValue("password", patient.getPassword());
            statement.Parameters.AddWithValue("salt", patient.getSalt());
            statement.Parameters.AddWithValue("username", patient.getUsername());
            statement.Parameters.AddWithValue("first_name", patient.getFirstname());
            statement.Parameters.AddWithValue("last_name", patient.getLastname());
            statement.Parameters.AddWithValue("email", patient.getEmail());
            statement.Parameters.AddWithValue("phone_number", patient.getPhone_number());
            statement.Parameters.AddWithValue("amka", patient.getAmka());

            statement.ExecuteNonQuery();

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
