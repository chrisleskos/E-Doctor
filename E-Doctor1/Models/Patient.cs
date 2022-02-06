using System;
using System.Collections.Generic;
using System.Text;

namespace ErgasiaMVC.Models
{
    public class Patient : Admin
    {
        public String phone_number { get; set; }
        public String amka { get; set; }


        public Patient() { }
        public Patient(int user_id, String username, String password, String salt, String first_name, String last_name, String email, String amka, String phone_number) : base(user_id, username, password, salt, first_name, last_name, email)
        {
            this.phone_number = phone_number;
            this.amka = amka;
        }

        public Patient(String username, String password, String salt, String first_name, String last_name, String email, String amka, String phone_number) : base(username, password, salt, first_name, last_name, email)
        {
            this.phone_number = phone_number;
            this.amka = amka;
        }
        public Patient(int user_id, String username, String first_name, String last_name, String email, String amka, String phone_number)
            : base(user_id, username, first_name, last_name, email)
        {
            this.phone_number = phone_number;
            this.amka = amka;
        }

        public String getPhone_number()
        {
            return phone_number;
        }

        public String getAmka()
        {
            return amka;
        }
    }
}
