using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErgasiaMVC.Models.DataManagement.Utilities
{
    public class DatabaseUtil
    {
        public static NpgsqlConnection conn = null;

        public static NpgsqlConnection getConnection(String database)
        {
            String username = "postgres";
            String password = "Ch10280613";
            String host = "localhost";
            String port = "5432";


            try
            {
                if (conn == null)
                {
                    String connString = "Host=" + host + ";Port=" + port + ";Username=" + username + ";Password="+ password + ";Database=" + database + ";";
                    conn = new NpgsqlConnection(connString);
                    Console.WriteLine("First initialization");
                }
                else
                {
                    Console.WriteLine("Already initiated");
                }

                return conn;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }
    }
}
