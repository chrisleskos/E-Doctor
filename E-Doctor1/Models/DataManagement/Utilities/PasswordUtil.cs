﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ErgasiaMVC.Models.DataManagement.Utilities
{
    public class PasswordUtil
    {
        public static String generateHash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                return ByteToString(bytes);
            }
        }

        public static bool checkPasswords(String givenPassword, String storedPassword, String storedSalt)
        {
            String givenHashedPassword = generateHash(givenPassword + storedSalt);
            return givenHashedPassword.Equals(storedPassword);
        }

        public static string ByteToString(byte[] bytes)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }

            return builder.ToString();
        }

        public static byte[] generateSalt()
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] salt = new byte[20];
            rng.GetBytes(salt);

            return salt;
        }

    }
}

