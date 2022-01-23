using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErgasiaMVC.Models.DataManagement.Managers
{
    interface IDoctorAvailabilityManagement
    {
        void createAvailableDate(String day, String time, Doctor doctor);
        void deleteAvailableDate(int available_date_id);
        AvailableDate getAvailableDate(int available_date_id);
        List<AvailableDate> getAvailableDates(int doctor_id);
        List<AvailableDate> getAvailableDates();
        void editAvailableDate(int available_date_id, String day, String time, Doctor doctor);
    }
}
