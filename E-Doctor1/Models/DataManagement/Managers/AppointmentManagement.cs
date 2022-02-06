using E_Doctor1.Models.DataManagement.DAO;
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
