using System;
using System.Collections.Generic;
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
using SweetsFactory.VVARS;
using SweetsFactory.Classes.CMessage;

namespace SweetsFactory.Pages.EditWorker
{
    /// <summary>
    /// Interaction logic for EditEmail.xaml
    /// </summary>
    public partial class EditEmail : Page
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

        public void OnChangeCrrentLoginFrame()
        {
            if (VARS.CurrentLoginPage == this)
            {
                if (VARS.currentUser == null) VARS.CurrentLoginPage = null;
                else
                {
                    HideError();
                    newEmail.Text = "";
                };
            }
        }

        public EditEmail()
        {
            InitializeComponent();
            VARS.onChangeCurrentLoginPage += OnChangeCrrentLoginFrame;
            errorMesg.onHideMessage += HideError;
            errorMesg.onShowMessage += ShowError;
        }



        private void GoZmina(object sender, MouseButtonEventArgs e)
        {
            /*
               if (login.Text.Length == 0){ ShowError("Введіть логін!"); return; }
             else if (password.Password.Length == 0) { ShowError("Введіть пароль!"); return; }
             WorkPerson wp = VARS.factory.IsIssetUser(login.Text);
             if (wp == null) { ShowError("Не існує робітника з таким логіном!"); return; }
             else if (Security.GetCodePassword(password.Password) != wp.Password) { ShowError("Не вірний пароль!"); return; }
             VARS.currentUser = wp;
             VARS.CurrentPage = VARS.pages[(int)PegesEnumeration.AllowedLogin];
              */

            if (newEmail.Text.Length == 0) { errorMesg.ShowMessage("Введіть новий емейл!", 7000, TypesMessageEnumerstion.Ok); return; }
            if (newEmail.Text == VARS.currentUser.Email) { errorMesg.ShowMessage("Потрібен НОВИЙ емейл!", 7000, TypesMessageEnumerstion.Ok); return; }
            VARS.currentUser.UserName = newEmail.Text;
            VARS.CurrentLoginPage = null;
            VARS.globalMessage.ShowMessage("Емейл успішно змінений!", 7000, Classes.CMessage.TypesMessageEnumerstion.Ok);
        }

        private void bback(object sender, MouseButtonEventArgs e)
        {
            VARS.CurrentLoginPage = null;
        }
    }
}
