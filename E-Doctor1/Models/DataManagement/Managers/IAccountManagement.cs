using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErgasiaMVC.Models.DataManagement.Managers
{
    interface IAccountManagement
    {
        void register(String username, String password, String first_name, String last_name, String email); // admin
        void register(String username, String password, String first_name, String last_name, String email, String phone_number, String amka, int specialty); // doctor
        void register(String username, String password, String first_name, String last_name, String email, String phone_number, String amka); // patient
        Object login(String username, String password);
    }
}
