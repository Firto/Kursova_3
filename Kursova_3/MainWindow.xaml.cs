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
using SweetsFactory.VVARS;
using SweetsFactory.Classes.CMessage;

namespace SweetsFactory
{
    public partial class MainWindow : Window
    {
        void OnChangeCrrentFrame()
        {
            MainFrm.Content = VARS.CurrentPage;
        }

        public MainWindow()
        {
            InitializeComponent();
            VARS.onChangeCurrentPage += OnChangeCrrentFrame;
            OnChangeCrrentFrame();
            VARS.mainWnd = this;
            VARS.globalMessage.onShowMessage += ShowMessage;
            VARS.globalMessage.onHideMessage += HideMessage;
        }

        void ShowMessage(string str, TypesMessageEnumerstion type)
        {
            HeightPoleForMessage.Height = new GridLength(50, GridUnitType.Pixel);
            PoleForMessage.Content = str;
        }
        void HideMessage()
        {
            HeightPoleForMessage.Height = new GridLength(0, GridUnitType.Pixel);
        }


    }
}
