using System.Security.Cryptography;
using System.Text;
using CAD.Core.Shared.Interfaces;

namespace CAD.Core.Cryptography
{
    public class HashManager : IHashManager
    {
        private const int _saltSize = 16;

        public string Hash(string value, string salt)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] hashedValue = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(value + salt));
                return Convert.ToBase64String(hashedValue);
            }
        }

        public string CreateSalt()
        {
            byte[] saltBytes = RandomNumberGenerator.GetBytes(16);
            return Convert.ToBase64String(saltBytes);
        }
    }
}