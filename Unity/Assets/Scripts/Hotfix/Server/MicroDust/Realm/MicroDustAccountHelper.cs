using System.Security.Cryptography;
using System.Text;

namespace ET.Server
{
    public static class MicroDustAccountHelper
    {
        public static string GenerateSalt()
        {
            byte[] salt = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }
            var result = Encoding.UTF8.GetString(salt);
            return result;
        }

        public static string HashPassword(string password, string salt)
        {
            var bytePassword = Encoding.UTF8.GetBytes(password);
            var byteSalt = Encoding.UTF8.GetBytes(salt);
            var hash = new byte[64];
            using (var pbkdf2 = new Rfc2898DeriveBytes(bytePassword, byteSalt, 10000, HashAlgorithmName.SHA512))
            {
                hash = pbkdf2.GetBytes(64);
            }
            var result = Encoding.UTF8.GetString(hash);
            return result;
        }
    }
}
