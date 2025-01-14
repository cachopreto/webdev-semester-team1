using System.Security.Cryptography;
using System.Text;
using BCrypt.Net;

namespace StarterKit.Utils
{
    public static class EncryptionHelper
    {
        private const int WORK_FACTOR = 11;

        public static string EncryptPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, workFactor: WORK_FACTOR);
        }

        public static bool VerifyPassword(string password, string hashedPassword)
        {
            try
            {
                return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
            }
            catch (BCrypt.Net.SaltParseException)
            {
                // If the stored hash is in an invalid format, encrypt the provided password
                // and compare with the stored password directly
                // This handles the case where passwords in the database might not be properly hashed
                return password == hashedPassword;
            }
        }
    }
}
