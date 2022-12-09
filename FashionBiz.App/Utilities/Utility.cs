using System.Text;
using System.Security.Cryptography;

namespace FashionBiz.App.Utilities
{
    public class Utility
    {
        public static string HashPassword(string password)
        {
            string result;
            SHA1Managed sha1 = new SHA1Managed();
            byte[] hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(password));
            StringBuilder sb = new StringBuilder(hash.Length * 2);
            foreach (byte b in hash)
            {
                sb.Append(b.ToString("x2"));
            }
            result = sb.ToString();
            return result;
        }
    }
}
