using System.Security.Cryptography;
using System.Text;

namespace EXERCICE3.Services
{
    public class GetUserInfoService : IGetUserInfoService
    {
        public static byte[] GetHash(string inputString)
        {
            using (HashAlgorithm algorithm = SHA256.Create())
                return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        public  string GetPasswordHash(string password)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(password))
                sb.Append(b.ToString("X2"));
            return sb.ToString();
        }

        public string GetUserName(string name)
        {
            return name.ToUpper();
        }
    }
}
