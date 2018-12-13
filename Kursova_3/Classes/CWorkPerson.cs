using SweetsFactory.Classes.CSNL;
using SweetsFactory.Classes.CBirthdayDate;
using SweetsFactory.Classes.CPosada;
using System.Security.Cryptography;
namespace SweetsFactory.Classes.CWorkPerson
{
    public class WorkPerson
    {
        static string GetHashString(string s) // Шифрування паролю
        {
            byte[] bytes = System.Text.Encoding.ASCII.GetBytes(s);
            MD5CryptoServiceProvider CSP = new MD5CryptoServiceProvider();
            byte[] byteHash = CSP.ComputeHash(bytes);
            string hash = string.Empty;
            foreach (byte b in byteHash)
                hash += string.Format("{0:x2}", b);
            return hash;
        }

        public SNL FName { get; set; } // ПІБ
        public BDate Birthday { get; set; } // Дата народження
        public byte Age { get; set; } // вік
        public Posada Posada; // посада
        string password; // зашифрований пароль
        public string Password { get => password; set {
                password = GetHashString(value);
            } }
        public string UserName { get; set; } // логин
        public string Email { get; set; } // Емейл
        public bool ActivatedEmail { get; set; } = false; // Активация Емайла
    }
}
