using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Doctor1.Models
{
    public class UserCred
    {
        String Username { get; set; }
        String Password { get; set; }

        public UserCred(String username, String password)
        {
            Username = username;
            Password = password;
        }

        public String getUsername()
        {
            return Username;
        }

        public String getPassword()
        {
            return Password;
        }
    }
}