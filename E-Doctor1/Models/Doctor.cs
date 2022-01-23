﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ErgasiaMVC.Models
{
    public class Doctor : Patient
    {
        public int specialty { get; set; }

        public Doctor(int user_id, String username, String password, String salt, String first_name, String last_name, String email, String amka, String phone_number, int specialty) 
            : base(user_id, username, password, salt, first_name, last_name, email, phone_number, amka)
        {
            this.specialty = specialty;
        }

        public Doctor(String username, String password, String salt, String first_name, String last_name, String email, String amka, String phone_number, int specialty) 
            : base(username, password, salt, first_name, last_name, email, phone_number, amka)
        {
            this.specialty = specialty;
        }

        public int getSpecialty()
        {
            return specialty;
        }
    }
}