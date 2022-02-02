using ErgasiaMVC.Models.DataManagement.DAO;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErgasiaMVC.Models.DataManagement.Managers
{
    public class DoctorAvailability : IDoctorAvailabilityManagement
    {

        public static readonly int PATHOLOGIST = 1;
        public static readonly int OPHTHALMOLOGIST = 2;
        public static readonly int ORTHOPEDIC = 3;

        DoctorAvailabilityDaoInterface  doctorAvailabilityDAO;

        DoctorAvailability()
        {
            doctorAvailabilityDAO = new DoctorAvailabilityDAO();
        }

        public void createAvailableDate(int day, TimeSpan starting_time, TimeSpan ending_time, Doctor doctor)
        {
            AvailableDate availableDate = new AvailableDate(day, starting_time, ending_time, doctor);
            doctorAvailabilityDAO.openConn();
            doctorAvailabilityDAO.createAvailableDate(availableDate);
            doctorAvailabilityDAO.closeConn();
        }

        public void deleteAvailableDate(int available_date_id)
        {
            doctorAvailabilityDAO.openConn();
            doctorAvailabilityDAO.deleteAvailableDate(available_date_id);
            doctorAvailabilityDAO.closeConn();
        }

        public void editAvailableDate(int available_date_id, int day, TimeSpan starting_time, TimeSpan ending_time, Doctor doctor)
        {
            AvailableDate availableDate = new AvailableDate(available_date_id, day, starting_time, ending_time, doctor);
            doctorAvailabilityDAO.openConn();
            doctorAvailabilityDAO.editAvailableDate(availableDate);
            doctorAvailabilityDAO.closeConn();
        }

        public AvailableDate getAvailableDate(int available_date_id)
        {
            doctorAvailabilityDAO.openConn();

            NpgsqlDataReader reader = doctorAvailabilityDAO.getAvailableDate(available_date_id);

            if (reader.Read())
            {
                doctorAvailabilityDAO.closeConn();
                return null;
            }

            doctorAvailabilityDAO.closeConn();
            return null;
        }

        public List<AvailableDate> getAvailableDates(int doctor_id)
        {
            throw new NotImplementedException();
        }

        public List<AvailableDate> getAvailableDates()
        {
            throw new NotImplementedException();
        }
    }
}
