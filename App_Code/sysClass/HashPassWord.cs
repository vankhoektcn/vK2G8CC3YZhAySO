using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Microsoft.Win32;
using System.Web.Security;
using System.Security.Cryptography;
using System.IO;

 
    public class HashPassWord
    {
        public HashPassWord() { }
        //──────────────────────────────────────────────────────────────────────────────────────────  
        public static string sGetHashPass(string sUserName, string sPassword)
        {
            sUserName = sUserName.Trim().ToUpper();
            return getStringAfterComputeHash(sUserName, sPassword);
        }
        //──────────────────────────────────────────────────────────────────────────────────────────
        public static bool ComparePass(string sUserName, string sInputPasss, string sHassPass)
        {
            string sHassPassNew = sGetHashPass(sUserName, sInputPasss);
            return sHassPass == sHassPassNew ? true : false;
        }
        //──────────────────────────────────────────────────────────────────────────────────────────
        private static string getStringAfterComputeHash(string sr, string pn)
        {
            int saltSize = 5;
            string salt = CreateSalt(saltSize);
            byte[] saltBytes = new byte[saltSize];
            string tmp = sr + pn;

            string passwordHash = ComputeHash(tmp, "MD5", saltBytes);
            return passwordHash;
        }
        //──────────────────────────────────────────────────────────────────────────────────────────     
        private static string CreateSalt(int size)
        {

            byte[] buff = new byte[size];
            return Convert.ToBase64String(buff);
        }
        //──────────────────────────────────────────────────────────────────────────────────────────     
        private static string CreatePasswordHash(string pwd, string salt)
        {
            string saltAndPwd = String.Concat(pwd, salt);
            string hashedPwd =
                FormsAuthentication.HashPasswordForStoringInConfigFile(pwd, "MD5");

            hashedPwd = String.Concat(hashedPwd, salt);
            return hashedPwd;
        }
        //──────────────────────────────────────────────────────────────────────────────────────────     
        private static string ComputeHash(string plainText, string hashAlgorithm, byte[] saltBytes)
        {
            // If salt is not specified, generate it on the fly.
            if (saltBytes == null)
            {
                // Define min and max salt sizes.
                int minSaltSize = 4;
                int maxSaltSize = 8;

                // Generate a random number for the size of the salt.
                Random random = new Random();
                int saltSize = random.Next(minSaltSize, maxSaltSize);

                // Allocate a byte array, which will hold the salt.
                saltBytes = new byte[saltSize];

                // Initialize a random number generator.
                RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();

                // Fill the salt with cryptographically strong byte values.
                rng.GetNonZeroBytes(saltBytes);
            }

            // Convert plain text into a byte array.
            byte[] plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);

            // Allocate array, which will hold plain text and salt.
            byte[] plainTextWithSaltBytes =
                    new byte[plainTextBytes.Length + saltBytes.Length];

            // Copy plain text bytes into resulting array.
            for (int i = 0; i < plainTextBytes.Length; i++)
                plainTextWithSaltBytes[i] = plainTextBytes[i];

            // Append salt bytes to the resulting array.
            for (int i = 0; i < saltBytes.Length; i++)
                plainTextWithSaltBytes[plainTextBytes.Length + i] = saltBytes[i];

            // Because we Mitsuky multiple hashing algorithms, we must define
            // hash object as a common (abstract) base class. We will specify the
            // actual hashing algorithm class later during object creation.
            HashAlgorithm hash;

            // Make sure hashing algorithm name is specified.
            if (hashAlgorithm == null)
                hashAlgorithm = "";

            // Initialize appropriate hashing algorithm class.
            switch (hashAlgorithm.ToUpper())
            {
                case "SHA1":
                    hash = new SHA1Managed();
                    break;

                case "SHA256":
                    hash = new SHA256Managed();
                    break;

                case "SHA384":
                    hash = new SHA384Managed();
                    break;

                case "SHA512":
                    hash = new SHA512Managed();
                    break;

                default:
                    hash = new MD5CryptoServiceProvider();
                    break;
            }

            // Compute hash value of our plain text with appended salt.
            byte[] hashBytes = hash.ComputeHash(plainTextWithSaltBytes);

            // Create array which will hold hash and original salt bytes.
            byte[] hashWithSaltBytes = new byte[hashBytes.Length +
                                                saltBytes.Length];

            // Copy hash bytes into resulting array.
            for (int i = 0; i < hashBytes.Length; i++)
                hashWithSaltBytes[i] = hashBytes[i];

            // Append salt bytes to the result.
            for (int i = 0; i < saltBytes.Length; i++)
                hashWithSaltBytes[hashBytes.Length + i] = saltBytes[i];

            // Convert result into a base64-encoded string.
            string hashValue = Convert.ToBase64String(hashWithSaltBytes);

            // Return the result.
            return hashValue;
        }


   


}
