using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Doctor1.Models
{
    public class UserCred
    {
        public int user_id { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }


        public UserCred() { }

        public UserCred(String username, String password)
        {
            Username = username;
            Password = password;
        }

        public UserCred(String username)
        {
            Username = username;
        }

        public String getUsername()
        {
            return Username;
        }

        public String getPassword()
        {
            return Password;
        }

        public int getUser_id()
        {
            return user_id;
        }
    }
}