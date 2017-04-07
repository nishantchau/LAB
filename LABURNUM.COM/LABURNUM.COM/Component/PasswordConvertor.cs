using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace LABURNUM.COM.Component
{
    public class PasswordConvertor
    {
        /// <summary>
        /// Convert Password To Md5 Type Password
        /// </summary>
        /// <param name="password"> Password Provided By User</param>
        /// <returns>Md5 Type Password</returns>
        public string Password(string password)
        {
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
            byte[] hashedBytes;

            //Create A UTF8Encoding Object We Will Use To Convert Our Password String To A Byte Array
            UTF8Encoding encoder = new UTF8Encoding();

            //Encrypt The Password And Store It In The HashedBytes Byte Array
            hashedBytes = md5Hasher.ComputeHash(encoder.GetBytes(password));
            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < hashedBytes.Length; i++)
            {
                sBuilder.Append(hashedBytes[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
    }
}