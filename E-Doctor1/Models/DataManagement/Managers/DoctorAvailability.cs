using E_Doctor1.Models.DataManagement.Factories;
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

        public DoctorAvailability()
        {
            doctorAvailabilityDAO = new DoctorAvailabilityDAO();
        }

        public void createAvailableDate(AvailableDate availableDate)
        {
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

        public void editAvailableDate(AvailableDate availableDate)
        {
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
            List<AvailableDate> dates = new List<AvailableDate>();

            doctorAvailabilityDAO.openConn();
            NpgsqlDataReader reader = doctorAvailabilityDAO.getAvailableDates(doctor_id);

            while (reader.Read())
            {
                AvailableDate availableDate = AvailableDateFactory.buildAvailableDate(reader);
                dates.Add(availableDate);
            }

            doctorAvailabilityDAO.closeConn();

            return dates;
        }

        public List<AvailableDate> getAvailableDates()
        {
            throw new NotImplementedException();
        }
    }
}
