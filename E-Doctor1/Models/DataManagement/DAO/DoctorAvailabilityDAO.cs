using ErgasiaMVC.Models.DataManagement.Utilities;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErgasiaMVC.Models.DataManagement.DAO
{
    public class DoctorAvailabilityDAO : DoctorAvailabilityDaoInterface
    {
        private NpgsqlConnection connection;

        public DoctorAvailabilityDAO()
        {
            connection = DatabaseUtil.getConnection("appointments_management");
        }

        public void openConn()
        {
            connection.Open();
        }

        public void closeConn()
        {
            connection.Close();
        }

        public void createAvailableDate(AvailableDate available_date)
        {
            String query = "INSERT INTO weekly_available_appointments(day, starting_time, ending_time, doctor_id) " +
                "VALUES (@day, @starting_time, @ending_time, @doctor_id)";

            NpgsqlCommand statement = new NpgsqlCommand(query, connection);

            statement.Parameters.AddWithValue("day", available_date.getDay());
            statement.Parameters.AddWithValue("starting_time", available_date.getStartingTime());
            statement.Parameters.AddWithValue("ending_time", available_date.getEndingTime());
            statement.Parameters.AddWithValue("doctor_id", available_date.getDoctor().getUser_id());

            statement.ExecuteNonQuery();
        }

        public void deleteAvailableDate(int available_date_id)
        {
            throw new NotImplementedException();
        }

        public void editAvailableDate(AvailableDate available_date)
        {
            string query = "UPDATE weekly_available_appointments SET day = @day, stating_time = @starting_time, ending_time = @ending_time" +
                "   WHERE available_date_id = @available_date_id";

            NpgsqlCommand statement = new NpgsqlCommand(query, connection);

            statement.Parameters.AddWithValue("day", available_date.getDay());
            statement.Parameters.AddWithValue("starting_time", available_date.getStartingTime());
            statement.Parameters.AddWithValue("ending_time", available_date.getEndingTime());

            statement.ExecuteNonQuery();
        }

        public NpgsqlDataReader getAvailableDate(int available_date_id)
        {
            string query = "SELECT * FROM weekly_available_appointments WHERE available_date_id = @available_date_id";

            NpgsqlCommand statement = new NpgsqlCommand(query, connection);
            statement.Parameters.AddWithValue("available_date_id", available_date_id);

            return statement.ExecuteReader();
        }

        public NpgsqlDataReader getAvailableDates(int doctor_id)
        {
            string query = "SELECT * FROM weekly_available_appointments WHERE doctor_id = @doctor_id";

            NpgsqlCommand statement = new NpgsqlCommand(query, connection);
            statement.Parameters.AddWithValue("doctor_id", doctor_id);

            return statement.ExecuteReader();
        }

        public NpgsqlDataReader getAvailableDates()
        {
            string query = "SELECT * FROM weekly_available_appointments";

            NpgsqlCommand statement = new NpgsqlCommand(query, connection);
            
            return statement.ExecuteReader();
        }
    }
}
