using System.Security.Cryptography;
using System.Text;
using BCrypt.Net;

namespace StarterKit.Utils
{
    public static class EncryptionHelper
    {
        public static string EncryptPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public static bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}
