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
using SweetsFactory.Pages;
using SweetsFactory.VVARS;
using SweetsFactory.Classes.CSecurity;

namespace SweetsFactory.Pages.EditWorker
{
    /// <summary>
    /// Interaction logic for EditPassword.xaml
    /// </summary>
    public partial class EditPassword : Page
    {

        bool ShowError(string text)
        {
            Messgae.Height = Double.NaN;
            ((Label)Messgae.Child).Content = text;
            return false;
        }

        public void OnChangeCrrentFrame()
        {
            if (VARS.CurrentPage == this)
            {
                if (VARS.currentUser == null) VARS.CurrentPage = VARS.pages[(int)PegesEnumeration.Login];
                else
                {
                    
                };
            }
        }

        public EditPassword()
        {
            InitializeComponent();

            VARS.onChangeCurrentPage += OnChangeCrrentFrame;
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

            if (lastPass.Password.Length == 0) { ShowError("Введіть старий пароль!"); return; }
            if (newPass.Password.Length == 0) { ShowError("Введіть новий пароль!"); return; }
            if (Security.GetCodePassword(lastPass.Password) != VARS.currentUser.Password) { ShowError("Не вірний старий пароль!"); return; }
            VARS.currentUser.Password = newPass.Password;
        }

        private void bback(object sender, MouseButtonEventArgs e)
        {
            VARS.CurrentLoginPage = null;
        }
    }
}
