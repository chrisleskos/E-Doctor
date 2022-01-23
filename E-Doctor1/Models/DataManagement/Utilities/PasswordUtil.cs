using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ErgasiaMVC.Models.DataManagement.Utilities
{
    public class PasswordUtil
    {
        public static String generateHash(string data, byte[] salt)
        {
            HashAlgorithm algo = new SHA256Managed();

            byte[] plainText = Encoding.ASCII.GetBytes(data);

            byte[] plainTextWithSaltBytes =
              new byte[plainText.Length + salt.Length];

            for (int i = 0; i < plainText.Length; i++)
            {
                plainTextWithSaltBytes[i] = plainText[i];
            }
            for (int i = 0; i < salt.Length; i++)
            {
                plainTextWithSaltBytes[plainText.Length + i] = salt[i];
            }

            return algo.ComputeHash(plainTextWithSaltBytes).ToString();
        }

        public static bool checkPasswords(String givenPassword, String storedPassword, String storedSalt)
        {
            String givenHashedPassword = generateHash(givenPassword, Encoding.ASCII.GetBytes(storedSalt));
            return givenHashedPassword.Equals(storedPassword);
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

