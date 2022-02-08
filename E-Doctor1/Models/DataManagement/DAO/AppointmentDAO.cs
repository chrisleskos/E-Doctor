using ErgasiaMVC.Models;
using ErgasiaMVC.Models.DataManagement.Utilities;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Doctor1.Models.DataManagement.DAO
{
    public class AppointmentDAO : AppointmentDaoInterface
    {

        private NpgsqlConnection connection;

        public AppointmentDAO()
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

        public void createAppointment(Appointment appointment)
        {
            String query = "INSERT INTO appointments(patient_id, available_appointment_id, scheduled_date, status) " +
                "VALUES (@patient_id, @available_appointment_id, @scheduled_date, @status)";

            NpgsqlCommand statement = new NpgsqlCommand(query, connection);

            statement.Parameters.AddWithValue("patient_id", appointment.patient.user_id);
            statement.Parameters.AddWithValue("available_appointment_id", appointment.availableDate.Id);
            statement.Parameters.AddWithValue("scheduled_date", appointment.scheduled_date);
            statement.Parameters.AddWithValue("status", appointment.status);

            statement.ExecuteNonQuery();
        }

        public void editAppointment(Appointment appointment)
        {
            throw new NotImplementedException();
        }

        public NpgsqlDataReader getAppointment(int appointment_id)
        {
            string query = "Select * FROM appointments as a INNER JOIN weekly_available_appointments as waa ON waa.available_appointment_id = a.available_appointment_id INNER JOIN doctors as d ON d.id = doctor_id INNER JOIN patients as p ON patient_id = p.id " +
                " WHERE appointment_id = @id ";

            NpgsqlCommand statement = new NpgsqlCommand(query, connection);
            statement.Parameters.AddWithValue("id", appointment_id);

            return statement.ExecuteReader();
        }

        public NpgsqlDataReader getAppointments(Patient patient)
        {
            string query = "SELECT * FROM appointments as a INNER JOIN weekly_available_appointments as waa ON waa.available_appointment_id = a.available_appointment_id INNER JOIN doctors as d ON d.id = doctor_id INNER JOIN patients as p ON patient_id = p.id" +
                " WHERE patient_id = @patient_id ORDER BY scheduled_date DESC";

            NpgsqlCommand statement = new NpgsqlCommand(query, connection);
            statement.Parameters.AddWithValue("patient_id", patient.user_id);

            return statement.ExecuteReader();
        }

        public NpgsqlDataReader getAppointments(Doctor doctor)
        {
            string query = "SELECT * FROM appointments as a INNER JOIN weekly_available_appointments as waa ON waa.available_appointment_id = a.available_appointment_id INNER JOIN patients as p ON patient_id = p.id INNER JOIN doctors as d ON d.id = doctor_id " +
                " WHERE doctor_id = @doctor_id AND DATE(scheduled_date) >= CURRENT_DATE ORDER BY scheduled_date";

            NpgsqlCommand statement = new NpgsqlCommand(query, connection);
            statement.Parameters.AddWithValue("doctor_id", doctor.user_id);

            return statement.ExecuteReader();
        }

        public void changeStatus(int appointment_id)
        {
            string query = "UPDATE appointments SET status = 1" +
                 " WHERE appointment_id = @appointment_id";

            NpgsqlCommand statement = new NpgsqlCommand(query, connection);
            statement.Parameters.AddWithValue("appointment_id", appointment_id);

            statement.ExecuteNonQuery();
        }
    }
}