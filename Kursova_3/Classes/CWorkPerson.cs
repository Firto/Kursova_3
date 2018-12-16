using SweetsFactory.Classes.CSNL;
using SweetsFactory.Classes.CBirthdayDate;
using SweetsFactory.Classes.CPosada;
using SweetsFactory.Classes.CSecurity;
namespace SweetsFactory.Classes.CWorkPerson
{
    public class WorkPerson
    {
        public SNL FName { get; set; } // ПІБ
        public BDate Birthday { get; set; } // Дата народження
        public byte Age { get; set; } // вік
        public Posada Posada; // посада
        string password; // зашифрований пароль
        public string Password { get => password; set {
                password = Security.GetCodePassword(value);
            } }
        public string UserName { get; set; } // логин
        public string Email { get; set; } // Емейл
        public bool ActivatedEmail { get; set; } = false; // Активация Емайла
    }
}
