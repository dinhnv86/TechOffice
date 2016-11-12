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

namespace AnThinhPhat.Utilities
{
    /// <summary>
    ///     Class AppCipher.
    /// </summary>
    public static class AppCipher
    {
        // This constant is used to determine the key size of the encryption algorithm.
        private const int KEYSIZE = 256;
        private const int KILOBYTE = 8;
        private const string KEY = "office";
        private static readonly byte[] iniVectorBytes = Encoding.ASCII.GetBytes("tu89geji340t89u2");

        /// <summary>
        ///     Encrypts the cipher.
        /// </summary>
        /// <param name="plainText">The plain text.</param>
        /// <param name="passPhrase">The pass phrase.</param>
        /// <returns></returns>
        public static string EncryptCipher(string plainText, string passPhrase = null)
        {
            if (passPhrase == null)
                passPhrase = GetKey();

            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            using (var password = new PasswordDeriveBytes(passPhrase, null))
            {
                var keyBytes = password.GetBytes(KEYSIZE/KILOBYTE);
                using (var symmetricKey = new RijndaelManaged())
                {
                    symmetricKey.Mode = CipherMode.CBC;
                    using (var encrypt = symmetricKey.CreateEncryptor(keyBytes, iniVectorBytes))
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            using (var encryptStream = new CryptoStream(memoryStream, encrypt, CryptoStreamMode.Write))
                            {
                                encryptStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                                encryptStream.FlushFinalBlock();
                                var cipherTextBytes = memoryStream.ToArray();
                                return Convert.ToBase64String(cipherTextBytes);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        ///     Decrypts the cipher.
        /// </summary>
        /// <param name="cipherText">The cipher text.</param>
        /// <param name="passPhrase">The pass phrase.</param>
        /// <returns></returns>
        public static string DecryptCipher(string cipherText, string passPhrase = null)
        {
            if (passPhrase == null)
                passPhrase = GetKey();

            var cipherTextBytes = Convert.FromBase64String(cipherText);
            using (var password = new PasswordDeriveBytes(passPhrase, null))
            {
                var keyBytes = password.GetBytes(KEYSIZE/KILOBYTE);
                using (var symmetricKey = new RijndaelManaged())
                {
                    symmetricKey.Mode = CipherMode.CBC;
                    using (var decrypter = symmetricKey.CreateDecryptor(keyBytes, iniVectorBytes))
                    {
                        using (var memoryStream = new MemoryStream(cipherTextBytes))
                        {
                            using (var cryptStream = new CryptoStream(memoryStream, decrypter, CryptoStreamMode.Read))
                            {
                                var plainTextBytes = new byte[cipherTextBytes.Length];
                                var decryptedByteCount = cryptStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                                return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        ///     Gets the key.
        /// </summary>
        /// <returns></returns>
        private static string GetKey()
        {
            var settingsReader = new AppSettingsReader();
            // Get the key from config file

            var key = (string) settingsReader.GetValue("KEY", typeof (string));
            if (string.IsNullOrEmpty(key))
                key = KEY;

            return key;
        }
    }
}