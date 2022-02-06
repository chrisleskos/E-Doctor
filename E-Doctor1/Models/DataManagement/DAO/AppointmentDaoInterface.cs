using ErgasiaMVC.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Doctor1.Models.DataManagement.DAO
{
    interface AppointmentDaoInterface
    {
        NpgsqlDataReader getAppointment(int appointment_id);
        void createAppointment(Appointment appointment);
        NpgsqlDataReader getAppointments(Patient patient);
        NpgsqlDataReader getAppointments(Doctor doctor);
        void changeStatus(int appointment_id);
        void editAppointment(Appointment appointment);
        void closeConn();
        void openConn();
    }
}
