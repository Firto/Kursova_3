using System.Security.Cryptography;
namespace SweetsFactory.Classes.CSecurity
{
    static class Security
    {
        public static string GetCodePassword(string s) // Шифрування паролю
        {
            byte[] bytes = System.Text.Encoding.ASCII.GetBytes(s);
            MD5CryptoServiceProvider CSP = new MD5CryptoServiceProvider();
            byte[] byteHash = CSP.ComputeHash(bytes);
            string hash = string.Empty;
            foreach (byte b in byteHash)
                hash += string.Format("{0:x2}", b);
            return hash;
        }
    }
}
