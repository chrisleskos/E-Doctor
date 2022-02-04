using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErgasiaMVC.Models.DataManagement.Managers
{
    interface IDoctorAvailabilityManagement
    {
        void createAvailableDate(AvailableDate availableDate);
        void deleteAvailableDate(int available_date_id);
        AvailableDate getAvailableDate(int available_date_id);
        List<AvailableDate> getAvailableDates(int doctor_id);
        List<AvailableDate> getAvailableDates();
        void editAvailableDate(AvailableDate availableDate);
    }
}
