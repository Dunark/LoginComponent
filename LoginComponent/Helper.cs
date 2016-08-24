using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace LoginComponent
{
    static class Helper
    {
        public static void chkEmail(string email)
        { }
        public static void chkPassword(string password)
        {
            if (password == null)
                throw new Exception("Password is null");
            if (password.Length < 6)
                throw new Exception("Password is too short");
        }

        public static string HashPassword(string password)
        {
            return GetStringSha256Hash(password);
        }
        internal static string GetStringSha256Hash(string text)
        {
            var sha = new SHA256Managed();

            byte[] textData = Encoding.UTF8.GetBytes(text);
            byte[] hash = sha.ComputeHash(textData);
            return BitConverter.ToString(hash).Replace("-", String.Empty);
        }
    }
}
