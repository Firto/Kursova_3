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
using SweetsFactory.Pages;
using SweetsFactory.Classes.CPermission;

namespace SweetsFactory.Pages
{

    public partial class AllovedLogin : Page
    {

        Permission currentPermission;

        public void OnChangeCrrentFrame()
        {
            if (VARS.CurrentPage == this) {
                if (VARS.currentUser == null) VARS.CurrentPage = VARS.pages[(int)PegesEnumeration.Login];
                else {
                    currentPermission = VARS.currentUser.Posada.perm;
                    UpdatePathPermissions();
                    UpdateButtonsPermissons();
                };
            }
        }

        public void OnChangeCrrentLoginFrame()
        {
            frmMain.Content = VARS.CurrentLoginPage;
        }

        public AllovedLogin()
        {
            InitializeComponent();
            VARS.onChangeCurrentPage += OnChangeCrrentFrame;
            VARS.onChangeCurrentLoginPage += OnChangeCrrentLoginFrame;
        }

        public Permission bbc(Permission scur) {
            Permission cat = scur.FatherPermission != null ? bbc(scur.FatherPermission) : null;
            if (scur.FatherPermission != null)
            {
                PathPermissions.Children.Add(new Label { Content = " > ", Style = (Style)this.FindResource("Path_Lbl") });
            }

            PathPermissions.Children.Add(new Label { Content = scur.Tittle, Style = (Style)this.FindResource("Path_Lbl") });

            return cat;
        }

        public void UpdatePathPermissions()
        {
            PathPermissions.Children.Clear();
            bbc(currentPermission);
        }

        public void OnClickToFunctions(object obj, MouseButtonEventArgs e) {
            int id = currentPermission.ChildPermissions.IndexOf((Permission)((Border)obj).Tag);
            if (currentPermission.ChildPermissions[id].ChildPermissions != null)
            {
                currentPermission = currentPermission.ChildPermissions[id];
                UpdatePathPermissions();
                UpdateButtonsPermissons();
            }
            else {
                switch (currentPermission.ChildPermissions[id].IDFunc) {
                    case 1:
                        VARS.CurrentLoginPage = VARS.loginPages[(int)Pages.PegesLoginEnumeration.NewPassword];
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                }
            }
        }

        public void UpdateButtonsPermissons() {
            Perms.Children.Clear();
            for (int i = 0; i < currentPermission.ChildPermissions.Count; i++)
            {
                Perms.Children.Add(new Border {
                    Style = (Style)this.FindResource("BprderButFort"),
                    Tag = currentPermission.ChildPermissions[i],
                    
                    Child = new Label {
                        Content = currentPermission.ChildPermissions[i].Tittle + (currentPermission.ChildPermissions[i].ChildPermissions != null ? " > " : ""),
                        Style = (Style)this.FindResource("ButtonFort")
                    }
                });

                ((Border)Perms.Children[Perms.Children.Count - 1]).MouseUp += OnClickToFunctions;
            }
        }
    }
}
