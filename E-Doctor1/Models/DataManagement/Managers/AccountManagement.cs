﻿using ErgasiaMVC.Models;
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
            accountDao.openConn();
            NpgsqlDataReader dr = accountDao.getUser(username, AccountDAO.ADMINISTRATORS_TABLE);

            if (dr.Read())
            {
                Admin user = UserFactory.buildAdmin(dr);
                accountDao.closeConn();
                if (PasswordUtil.checkPasswords(password, user.getPassword(), user.getSalt()))
                    return user;
                else
                {
                    throw new WrongPasswordException();
                }
            }
            accountDao.closeConn();

            accountDao.openConn();

            dr = accountDao.getUser(username, AccountDAO.DOCTORS_TABLE);

            if (dr.Read())
            {
                Doctor user = UserFactory.buildDoctor(dr);
                accountDao.closeConn();
                if (PasswordUtil.checkPasswords(password, user.getPassword(), user.getSalt()))
                    return user;
                else
                    throw new WrongPasswordException();
            }

            accountDao.closeConn();

            accountDao.openConn();

            dr = accountDao.getUser(username, AccountDAO.PATIENTS_TABLE);

            if (dr.Read())
            {
                Patient user = UserFactory.buildPatient(dr);
                accountDao.closeConn();
                if (PasswordUtil.checkPasswords(password, user.getPassword(), user.getSalt()))
                    return user;
                else
                    throw new WrongPasswordException();
            }

            accountDao.closeConn();

            throw new UserNotFoundException();

        }

        public void register(string username, string password, string first_name, string last_name, string email)
        {
            if (usernameTaken(username))
            {
                accountDao.closeConn();
                throw new UsernameAlreadyTaken();
            }
            else
            {
                accountDao.closeConn();
            }

            byte[] salt = PasswordUtil.generateSalt();

            password = PasswordUtil.generateHash(password + PasswordUtil.ByteToString(salt));
            

            Admin admin = new Admin(username, password, PasswordUtil.ByteToString(salt), first_name, last_name, email);

            accountDao.openConn();

            try
            {
                this.accountDao.createAdmin(admin);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            accountDao.closeConn();
        }

        public void register(string username, string password, string first_name, string last_name, string email, string phone_number, string amka, int specialty)
        {
            if (usernameTaken(username))
            {
                throw new UsernameAlreadyTaken();
            }

            byte[] salt = PasswordUtil.generateSalt();

            password = PasswordUtil.generateHash(password + PasswordUtil.ByteToString(salt));

            Doctor doctor = new Doctor(username, password, PasswordUtil.ByteToString(salt), first_name, last_name, email, amka, phone_number, specialty);

            accountDao.openConn();

            try
            {
                this.accountDao.createDoctor(doctor);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            accountDao.closeConn();
        }

        public string register(string username, string password, string first_name, string last_name, string email, string phone_number, string amka)
        {
            if (usernameTaken(username))
            {
                accountDao.closeConn();
                throw new UsernameAlreadyTaken();
            }
            else
            {
                accountDao.closeConn();
            }

            byte[] salt = PasswordUtil.generateSalt();

            password = PasswordUtil.generateHash(password + PasswordUtil.ByteToString(salt));

            Patient patient = new Patient(username, password, PasswordUtil.ByteToString(salt), first_name, last_name, email, amka, phone_number);

            accountDao.openConn();

            try
            {
                this.accountDao.createPatient(patient);
            }
            catch (Exception e)
            {
                return e.Message;
            }

            accountDao.closeConn();

            return username + "  " + password + "  " + PasswordUtil.ByteToString(salt) + "  " + first_name + "  " + last_name + "  " + email + "  " + amka + "  " + phone_number;
        }

        private bool usernameTaken(String username)
        {
            
            try
            {
                accountDao.openConn();
                NpgsqlDataReader dr1 = accountDao.getUser(username, AccountDAO.ADMINISTRATORS_TABLE);
                bool firstResult = dr1.Read();
                accountDao.closeConn();

                accountDao.openConn();
                NpgsqlDataReader dr2 = accountDao.getUser(username, AccountDAO.DOCTORS_TABLE);
                bool secondResult = dr2.Read();
                accountDao.closeConn();

                accountDao.openConn();
                NpgsqlDataReader dr3 = accountDao.getUser(username, AccountDAO.PATIENTS_TABLE);
                bool thirdResult = dr3.Read();
                accountDao.closeConn();

                return firstResult || secondResult || thirdResult;
            }
            catch (Exception e)
            {
                accountDao.closeConn();
                Console.WriteLine(e.Message);
            }

            return false;
        }

        public object getUser(int id, int table_index)
        {
            accountDao.openConn();
            NpgsqlDataReader reader = accountDao.getUser(id, table_index);

            if (!reader.Read())
                return null;

            if (table_index == AccountDAO.ADMINISTRATORS_TABLE)
            {
                Admin user = UserFactory.buildAdmin(reader);
                accountDao.closeConn();
                return user;
            } else if (table_index == AccountDAO.DOCTORS_TABLE)
            {
                Doctor user = UserFactory.buildDoctor(reader);
                accountDao.closeConn();
                return user;
            } else if (table_index == AccountDAO.PATIENTS_TABLE)
            {
                Patient user = UserFactory.buildPatient(reader);
                accountDao.closeConn();
                return user;
            }

            accountDao.closeConn();
            return null;
        }


    }
}
