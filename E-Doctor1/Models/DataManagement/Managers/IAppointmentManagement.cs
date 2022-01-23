using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErgasiaMVC.Models.DataManagement.Managers
{
    interface IAppointmentManagement
    {
        void createAppointment(Appointment appointment);
        void changeAppointmentStatus(Appointment appointment);
        Appointment getAppointment(int appointment_id);
        List<Appointment> getAppointments(Patient patient);
        List<Appointment> getAppointments(Doctor doctor);
    }
}
