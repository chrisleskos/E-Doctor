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

        public void createAppointment(Appointment appointment)
        {
            throw new NotImplementedException();
        }

        public void editAppointment(Appointment appointment)
        {
            throw new NotImplementedException();
        }

        public Appointment getAppointment(int appointment_id)
        {
            throw new NotImplementedException();
        }

        public List<Appointment> getAppointments(Patient patient)
        {
            throw new NotImplementedException();
        }

        public List<Appointment> getAppointments(Doctor doctor)
        {
            throw new NotImplementedException();
        }
    }
}