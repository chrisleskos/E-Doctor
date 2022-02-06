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
            throw new NotImplementedException();
        }

        public NpgsqlDataReader getAppointments(Patient patient)
        {
            throw new NotImplementedException();
        }

        public NpgsqlDataReader getAppointments(Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public void changeStatus(int appointment_id)
        {
            throw new NotImplementedException();
        }
    }
}