using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MED_X
{
    internal class Password
    {
        public string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public bool VerifyHashedPassword(string hashedPassword, string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                string hashOfInput = HashPassword(password);

                StringComparer comparer = StringComparer.OrdinalIgnoreCase;
                if (0 == comparer.Compare(hashOfInput, hashedPassword))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
