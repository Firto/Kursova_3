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

namespace SweetsFactory
{
    public partial class MainWindow : Window
    {
        public void OnChangeCrrentFrame() {
            MainFrm.Content = VARS.CurrentPage;
        }

        public MainWindow()
        {
            InitializeComponent();
            VARS.onChangeCurrentPage = OnChangeCrrentFrame;
            VARS.onChangeCurrentPage();
        }

    }
}
