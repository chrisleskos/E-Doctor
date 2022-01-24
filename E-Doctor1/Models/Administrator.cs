using E_Doctor1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErgasiaMVC.Models
{
    public class Admin : UserCred
    {
        public int user_id { get; set; }
        public String first_name { get; set; }
        public String last_name { get; set; }
        public String email { get; set; }
        public String salt { get; set; }

        public Admin() { }

        public Admin(int user_id, String username, String password, String salt, String first_name, String last_name, String email)
            : base (username, password)
        {
            this.user_id = user_id;
            this.salt = salt;
            this.first_name = first_name;
            this.last_name = last_name;
            this.email = email;
        }

        public Admin(String username, String password, String salt, String first_name, String last_name, String email) 
            : base(username, password)
        {
            this.salt = salt;
            this.first_name = first_name;
            this.last_name = last_name;
            this.email = email;
        }

        public int getUser_id()
        {
            return user_id;
        }

        public String getFirstname()
        {
            return first_name;
        }

        public String getLastname()
        {
            return last_name;
        }

        public String getEmail()
        {
            return email;
        }

        public String getSalt()
        {
            return salt;
        }

    }
}
