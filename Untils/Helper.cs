using System.Security.Cryptography;
using System.Text;

namespace Utils
{
    public static class Helper
    {
        public static string RandomString(int len)
        {
            Random random = new Random();
            string pattern = "qazwsxedcrfvnjimkotughyblp1234567890";
            char[] chars = new char[len];
            for (int i = 0; i < len; i++)
            {
                chars[i] = pattern[random.Next(pattern.Length)];
            }
            return string.Join(string.Empty, chars);
        }

        public static byte[] Hash(string plantext)
        {
            HashAlgorithm algorithm = HashAlgorithm.Create("SHA-512");
            return algorithm.ComputeHash(Encoding.ASCII.GetBytes(plantext));
        }
    }
}