using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErgasiaMVC.Models.DataManagement.DAO
{
    interface AccountDaoInterface
    {
        void createAdmin(Admin admin);// throws Exception;
        void createDoctor(Doctor doctor);// throws Exception;
        void createPatient(Patient patient);// throws Exception;
        NpgsqlDataReader getUser(String username, int table_index);// throws SQLException;
        NpgsqlDataReader getUser(int id, int table_index);
        void editUser(Admin admin);
        void editUser(Patient patient);
        void editUser(Doctor doctor);

        void closeConn();
        void openConn();
    }
}
