using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Timers;
using SweetsFactory.VVARS;
using SweetsFactory.Classes.CWorkPerson;
using SweetsFactory.Classes.CSecurity;
using SweetsFactory.Pages;
namespace SweetsFactory.Pages
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    /// 


    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();

            // ((Label)Messgae.Child).Content
        }

        bool ShowError(string text) {
            Messgae.Height = Double.NaN;
            ((Label)Messgae.Child).Content = text;
            return false;
        }

        void GoLogin(object obj, MouseButtonEventArgs e)
        {
            if (login.Text.Length == 0){ ShowError("Введіть логін!"); return; }
            else if (password.Password.Length == 0) { ShowError("Введіть пароль!"); return; }
            WorkPerson wp = VARS.factory.IsIssetUser(login.Text);
            if (wp == null) { ShowError("Не існує робітника з таким логіном!"); return; }
            else if (Security.GetCodePassword(password.Password) != wp.Password) { ShowError("Не вірний пароль!"); return; }
            VARS.currentUser = wp;
            VARS.CurrentPage = VARS.pages[(int)PegesEnumeration.AllowedLogin];
        }
    }

    
}
