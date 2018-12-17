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
using SweetsFactory.Classes.CMessage;
using SweetsFactory.Pages;
namespace SweetsFactory.Pages
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    /// 


    public partial class Login : Page
    {

        Message errorMesg = new Message();

        void ShowError(string text, TypesMessageEnumerstion type)
        {
            Messgae.Height = Double.NaN;
            ((Label)Messgae.Child).Content = text;
        }

        void HideError()
        {
            Messgae.Height = 0;
        }

        public Login()
        {
            InitializeComponent();

            errorMesg.onHideMessage += HideError;
            errorMesg.onShowMessage += ShowError;
        }

        void GoLogin(object obj, MouseButtonEventArgs e)
        {
            if (login.Text.Length == 0){ errorMesg.ShowMessage("Введіть логін!", 7000, TypesMessageEnumerstion.Ok); return; }
            else if (password.Password.Length == 0) { errorMesg.ShowMessage("Введіть пароль!", 7000, TypesMessageEnumerstion.Ok); return; }
            WorkPerson wp = VARS.factory.IsIssetUser(login.Text);
            if (wp == null) { errorMesg.ShowMessage("Не існує робітника з таким логіном!", 7000, TypesMessageEnumerstion.Ok); return; }
            else if (Security.GetCodePassword(password.Password) != wp.Password) { errorMesg.ShowMessage("Не вірний пароль!", 7000, TypesMessageEnumerstion.Ok); return; }
            VARS.currentUser = wp;
            VARS.CurrentPage = VARS.pages[(int)PegesEnumeration.AllowedLogin];
        }
    }

    
}
