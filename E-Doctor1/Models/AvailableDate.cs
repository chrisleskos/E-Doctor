using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErgasiaMVC.Models
{
    public class AvailableDate
    {
        private int Id { get; set; }
        private DayOfWeek Day { get; set; }
        private TimeSpan Starting_time { get; set; }
        private TimeSpan Ending_time { get; set; }
        private Doctor doctor { get; set; }

        public AvailableDate(int available_date_id, DayOfWeek day, TimeSpan starting_time, TimeSpan ending_time, Doctor doctor)
        {
            this.Id = available_date_id;
            this.Day = day;
            this.Starting_time = starting_time;
            this.Ending_time = ending_time;
            this.doctor = doctor;
        }

        public AvailableDate(DayOfWeek day, TimeSpan starting_time, TimeSpan ending_time, Doctor doctor)
        {
            this.Day = day;
            this.Starting_time = starting_time;
            this.Ending_time = ending_time;
            this.doctor = doctor;
        }

        public int getId()
        {
            return Id;
        }

        public DayOfWeek getDay()
        {
            return Day;
        }

        public TimeSpan getStartingTime()
        {
            return Starting_time;
        }

        public TimeSpan getEndingTime()
        {
            return Ending_time;
        }

        public Doctor getDoctor()
        {
            return doctor;
        }
    }
}
