// ***********************************************************************
// Assembly         : AnThinhPhat.Utilities
// Author           : tranthiencdsp@gmail.com
// Created          : 02-25-2016
//
// Last Modified By : tranthiencdsp@gmail.com
// Last Modified On : 02-18-2016
// ***********************************************************************
// <copyright file="AppCipher.cs" company="Atmel Corporation">
//     Copyright © Atmel 2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Configuration;
using System.IO;
using System.Security.Cryptography;
using System.Text;

/// <summary>
/// The Utilities namespace.
/// </summary>
namespace AnThinhPhat.Utilities
{
    /// <summary>
    /// Class AppCipher.
    /// </summary>
    public static class AppCipher
    {
        private static readonly byte[] iniVectorBytes = Encoding.ASCII.GetBytes("tu89geji340t89u2");
        // This constant is used to determine the key size of the encryption algorithm.
        private const int KEYSIZE = 256;
        private const int KILOBYTE = 8;
        const string KEY = "office";

        /// <summary>
        /// Encrypts the cipher.
        /// </summary>
        /// <param name="plainText">The plain text.</param>
        /// <param name="passPhrase">The pass phrase.</param>
        /// <returns></returns>
        public static string EncryptCipher(string plainText, string passPhrase = null)
        {
            if (passPhrase == null)
                passPhrase = GetKey();

            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            using (PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null))
            {
                byte[] keyBytes = password.GetBytes(KEYSIZE / KILOBYTE);
                using (RijndaelManaged symmetricKey = new RijndaelManaged())
                {
                    symmetricKey.Mode = CipherMode.CBC;
                    using (ICryptoTransform encrypt = symmetricKey.CreateEncryptor(keyBytes, iniVectorBytes))
                    {
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            using (CryptoStream encryptStream = new CryptoStream(memoryStream, encrypt, CryptoStreamMode.Write))
                            {
                                encryptStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                                encryptStream.FlushFinalBlock();
                                byte[] cipherTextBytes = memoryStream.ToArray();
                                return Convert.ToBase64String(cipherTextBytes);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Decrypts the cipher.
        /// </summary>
        /// <param name="cipherText">The cipher text.</param>
        /// <param name="passPhrase">The pass phrase.</param>
        /// <returns></returns>
        public static string DecryptCipher(string cipherText, string passPhrase = null)
        {
            if (passPhrase == null)
                passPhrase = GetKey();

            byte[] cipherTextBytes = Convert.FromBase64String(cipherText);
            using (PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null))
            {
                byte[] keyBytes = password.GetBytes(KEYSIZE / KILOBYTE);
                using (RijndaelManaged symmetricKey = new RijndaelManaged())
                {
                    symmetricKey.Mode = CipherMode.CBC;
                    using (ICryptoTransform decrypter = symmetricKey.CreateDecryptor(keyBytes, iniVectorBytes))
                    {
                        using (MemoryStream memoryStream = new MemoryStream(cipherTextBytes))
                        {
                            using (CryptoStream cryptStream = new CryptoStream(memoryStream, decrypter, CryptoStreamMode.Read))
                            {
                                byte[] plainTextBytes = new byte[cipherTextBytes.Length];
                                int decryptedByteCount = cryptStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                                return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Gets the key.
        /// </summary>
        /// <returns></returns>
        private static string GetKey()
        {
            System.Configuration.AppSettingsReader settingsReader = new AppSettingsReader();
            // Get the key from config file

            string key = (string)settingsReader.GetValue("KEY", typeof(String));
            if (String.IsNullOrEmpty(key))
                key = KEY;

            return key;
        }
    }
}