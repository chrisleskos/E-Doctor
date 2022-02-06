using ErgasiaMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Doctor1.Models.DataManagement.DAO
{
    interface AppointmentDaoInterface
    {
        Appointment getAppointment(int appointment_id);
        void createAppointment(Appointment appointment);
        List<Appointment> getAppointments(Patient patient);
        List<Appointment> getAppointments(Doctor doctor);
        void editAppointment(Appointment appointment);
    }
}
