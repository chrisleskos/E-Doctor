using ErgasiaMVC.Models;
using ErgasiaMVC.Models.DataManagement.DAO;
using ErgasiaMVC.Models.DataManagement.Exceptions;
using System;
using Npgsql;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErgasiaMVC.Models.DataManagement.Factories;
using ErgasiaMVC.Models.DataManagement.Utilities;
using System.Text;

namespace ErgasiaMVC.Models.DataManagement.Managers
{
    public class AccountManagement : IAccountManagement
    {

        AccountDaoInterface accountDao;

        public AccountManagement()
        {
            accountDao = new AccountDAO();
        }

        public object login(string username, string password)
        {
            try
            {
                NpgsqlDataReader dr = accountDao.getUser(username, AccountDAO.ADMINISTRATORS_TABLE);

                if (dr.Read())
                {
                    Admin user = UserFactory.buildAdmin(dr);
                    if (PasswordUtil.checkPasswords(password, user.getPassword(), user.getSalt()))
                        return user;
                    else
                        throw new WrongPasswordException();
                }

                dr = accountDao.getUser(username, AccountDAO.DOCTORS_TABLE);

                if (dr.Read())
                {
                    Doctor user = UserFactory.buildDoctor(dr);
                    if (PasswordUtil.checkPasswords(password, user.getPassword(), user.getSalt()))
                        return user;
                    else
                        throw new WrongPasswordException();
                }

                dr = accountDao.getUser(username, AccountDAO.PATIENTS_TABLE);

                if (dr.Read())
                {
                    Patient user = UserFactory.buildPatient(dr);
                    if (PasswordUtil.checkPasswords(password, user.getPassword(), user.getSalt()))
                        return user;
                    else
                        throw new WrongPasswordException();
                }


                throw new UserNotFoundException();


            }
            catch (Exception e)
            {
                Console.WriteLine("OOPS! THERE WA AN ERROR!");
                Console.WriteLine(e.Message);
            }
            

            return null;
        }

        public void register(string username, string password, string first_name, string last_name, string email)
        {
            if (usernameTaken(username))
                throw new UsernameAlreadyTaken();

            byte[] salt = PasswordUtil.generateSalt();

            password = PasswordUtil.generateHash(password, salt);
            

            Admin admin = new Admin(username, password, Encoding.ASCII.GetString(salt), first_name, last_name, email);

            try
            {
                this.accountDao.createAdmin(admin);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void register(string username, string password, string first_name, string last_name, string email, string phone_number, string amka, int specialty)
        {
            if (usernameTaken(username))
                throw new UsernameAlreadyTaken();

            byte[] salt = PasswordUtil.generateSalt();

            password = PasswordUtil.generateHash(password, salt);

            Doctor doctor = new Doctor(username, password, Encoding.ASCII.GetString(salt), first_name, last_name, email, amka, phone_number, specialty);

            try
            {
                this.accountDao.createDoctor(doctor);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void register(string username, string password, string first_name, string last_name, string email, string phone_number, string amka)
        {
            if (usernameTaken(username))
                throw new UsernameAlreadyTaken();

            byte[] salt = PasswordUtil.generateSalt();

            password = PasswordUtil.generateHash(password, salt);

            Patient patient = new Patient(username, password, Encoding.ASCII.GetString(salt), first_name, last_name, email, amka, phone_number);

            try
            {
                this.accountDao.createPatient(patient);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private bool usernameTaken(String username)
        {
            try
            {
                NpgsqlDataReader dr1 = accountDao.getUser(username, AccountDAO.ADMINISTRATORS_TABLE);
                NpgsqlDataReader dr2 = accountDao.getUser(username, AccountDAO.DOCTORS_TABLE);
                NpgsqlDataReader dr3 = accountDao.getUser(username, AccountDAO.PATIENTS_TABLE);

                return dr1.Read() || dr2.Read() || dr3.Read();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return false;
        }
    }
}
