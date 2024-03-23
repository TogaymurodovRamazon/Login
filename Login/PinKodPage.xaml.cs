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
    /// Interaction logic for PinKodPage.xaml
    /// </summary>
    public partial class PinKodPage : UserControl
    {
        MainWindow _mainWindow { get; set; }
        public PinKodPage()
        {
            InitializeComponent();
        }

        public void SetMainWindow(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
        }

        private void Cancel_btn_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.PinKod_view.Visibility = Visibility.Collapsed;
            _mainWindow.Asosiysi_view.Visibility = Visibility.Visible;
            _mainWindow.Login_view.Visibility = Visibility.Collapsed;
        }

        private void Btn_Raqam(object sender, RoutedEventArgs e)
        {
            Button button=sender as Button;
            Raqam_pasbox.Password = Raqam_pasbox.Password.ToString() + button.Content.ToString();
           
        }

        private void Qayt_btn(object sender, RoutedEventArgs e)
        {
            if(Raqam_pasbox.Password !=null && Raqam_pasbox.Password != "")
                Raqam_pasbox.Password = Raqam_pasbox.Password.Substring(0,Raqam_pasbox.Password.Length-1);
        }

        private void Raqam_pasbox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (Raqam_pasbox.Password.Length == 4)
            {
               

            }
            else
            {
                return;
            }
        }
    }
}
