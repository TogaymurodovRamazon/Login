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

namespace Login
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : UserControl
    {
        MainWindow _mainWindow { get; set; }
        public LoginPage()
        {
            InitializeComponent();
            
        }

        public void SetMainWindow(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
        }
        private void Cansel_btn_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.Login_view.Visibility = Visibility.Collapsed;
            _mainWindow.Asosiysi_view.Visibility = Visibility.Visible;
        }
    }
}
