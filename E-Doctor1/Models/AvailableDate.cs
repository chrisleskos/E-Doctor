using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErgasiaMVC.Models
{
    public class AvailableDate
    {
        private int available_date_id;
        private String day;
        private String time;
        private Doctor doctor;

        public AvailableDate(int available_date_id, String day, String time, Doctor doctor)
        {
            this.available_date_id = available_date_id;
            this.day = day;
            this.time = time;
            this.doctor = doctor;
        }

        public AvailableDate(String day, String time, Doctor doctor)
        {
            this.day = day;
            this.time = time;
            this.doctor = doctor;
        }

        public int getAvailable_date_id()
        {
            return available_date_id;
        }

        public String getDay()
        {
            return day;
        }

        public String getTime()
        {
            return time;
        }

        public Doctor getDoctor()
        {
            return doctor;
        }
    }
}
