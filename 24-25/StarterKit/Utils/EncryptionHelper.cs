using System.Security.Cryptography;
using System.Text;


// namespace StarterKit.Utils
// {
//     public static class EncryptionHelper
//     {
//         public static string EncryptPassword(string password)
//         {
//             using (SHA256 sha256 = SHA256.Create())
//             {
//                 byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
//                 StringBuilder builder = new StringBuilder();
//                 foreach (byte b in bytes)
//                 {
//                     builder.Append(b.ToString("x2")); // Convert byte to hex
//                 }
//                 return builder.ToString(); // Return hex string
//             }
//         }
//     }
// }

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
