using E_Doctor1.Models.DataManagement.DAO;
using E_Doctor1.Models.DataManagement.Factories;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErgasiaMVC.Models.DataManagement.Managers
{
    public class AppointmentManagement : IAppointmentManagement
    {

        AppointmentDAO appointmentDao;

        public AppointmentManagement()
        {
            appointmentDao = new AppointmentDAO();
        }

        public void changeAppointmentStatus(int appointment_id)
        {
            appointmentDao.openConn();
            appointmentDao.changeStatus(appointment_id);
            appointmentDao.closeConn();
        }

        public void createAppointment(Appointment appointment)
        {
            appointmentDao.openConn();
            appointmentDao.createAppointment(appointment);
            appointmentDao.closeConn();
        }

        public Appointment getAppointment(int appointment_id)
        {
            appointmentDao.openConn();
            NpgsqlDataReader reader = appointmentDao.getAppointment(appointment_id);

            if (reader.Read()) {
                Appointment appointment = AppointmentFactory.buildAppointment(reader);
                appointmentDao.closeConn();
                return appointment;
            }
            
            appointmentDao.closeConn();
            return null;
        }

        public List<Appointment> getAppointments(Patient patient)
        {
            List<Appointment> appointments = new List<Appointment>();

            appointmentDao.openConn();
            NpgsqlDataReader reader = appointmentDao.getAppointments(patient);

            while (reader.Read())
            {
                Appointment appointment = AppointmentFactory.buildAppointment(reader);
                appointments.Add(appointment);
            }

            appointmentDao.closeConn();

            return appointments;
        }

        public List<Appointment> getAppointments(Doctor doctor)
        {
            List<Appointment> appointments = new List<Appointment>();

            appointmentDao.openConn();
            NpgsqlDataReader reader = appointmentDao.getAppointments(doctor);

            while (reader.Read())
            {
                Appointment appointment = AppointmentFactory.buildAppointment(reader);
                appointments.Add(appointment);
            }

            appointmentDao.closeConn();

            return appointments;
        }
    }
}
