using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErgasiaMVC.Models.DataManagement.DAO
{
    interface DoctorAvailabilityDaoInterface
    {
        void createAvailableDate(AvailableDate available_date);
        void deleteAvailableDate(int available_date_id);
        NpgsqlDataReader getAvailableDate(int available_date_id);
        NpgsqlDataReader getAvailableDates(int doctor_id);
        NpgsqlDataReader getAvailableDates();
        void editAvailableDate(AvailableDate available_date);
        NpgsqlDataReader getSpecialtyAvailableDates(int specialty);
        void closeConn();
        void openConn();
    }
}
