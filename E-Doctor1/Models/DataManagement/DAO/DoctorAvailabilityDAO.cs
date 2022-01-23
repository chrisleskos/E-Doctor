using ErgasiaMVC.Models.DataManagement.Utilities;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErgasiaMVC.Models.DataManagement.DAO
{
    public class DoctorAvailabilityDAO : DoctorAvailabilityDaoInterface
    {
        private NpgsqlConnection connection;

        public DoctorAvailabilityDAO()
        {
            connection = DatabaseUtil.getConnection("appointments_management");
            connection.Open();
        }

        ~DoctorAvailabilityDAO()
        {
            connection.Close();
        }

        public void createAvailableDate(AvailableDate available_date)
        {
            String query = "INSERT INTO weekly_available_appointments() VALUES ()";
        }

        public void deleteAvailableDate(int available_date_id)
        {
            throw new NotImplementedException();
        }

        public void editAvailableDate(AvailableDate available_date)
        {
            throw new NotImplementedException();
        }

        public AvailableDate getAvailableDate(int available_date_id)
        {
            throw new NotImplementedException();
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
