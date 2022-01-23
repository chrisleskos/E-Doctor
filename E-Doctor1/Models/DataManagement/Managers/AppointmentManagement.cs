using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErgasiaMVC.Models.DataManagement.Managers
{
    public class AppointmentManagement : IAppointmentManagement
    {
        public void changeAppointmentStatus(Appointment appointment)
        {
            throw new NotImplementedException();
        }

        public void createAppointment(Appointment appointment)
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
