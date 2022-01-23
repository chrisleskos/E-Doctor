﻿using ErgasiaMVC.Models.DataManagement.DAO;
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

        public void createAvailableDate(string day, string time, Doctor doctor)
        {
            AvailableDate availableDate = new AvailableDate(day, time, doctor);
            doctorAvailabilityDAO.createAvailableDate(availableDate);
        }

        public void deleteAvailableDate(int available_date_id)
        {
            throw new NotImplementedException();
        }

        public void editAvailableDate(int available_date_id, string day, string time, Doctor doctor)
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