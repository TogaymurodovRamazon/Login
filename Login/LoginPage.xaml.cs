using Login.Service;
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
       private MainWindow _mainWindow { get; set; }
       private IUserService _userService { get; set; }

        public LoginPage()
        {
            InitializeComponent();
            
        }

        public void SetMainWindow(MainWindow mainWindow, IUserService userservice)
        {
            _mainWindow = mainWindow;
            _userService = userservice;

        }
        private void Cansel_btn_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.Login_view.Visibility = Visibility.Collapsed;
            _mainWindow.Asosiysi_view.Visibility = Visibility.Visible;
        }

        private async void Kirish_btn_Click(object sender, RoutedEventArgs e)
        {


            //if (txtlogin.Text == "ramazon00" && txtpassword.Password == "12345")
            //{
            //    _mainWindow.Login_view.Visibility = Visibility.Collapsed;
            //    _mainWindow.Menyu_view.Visibility = Visibility.Visible;
            //}
            //else
            //{
            //    MessageBox.Show("Username yoki parol xato");
            //    txtlogin.Text = "";
            //    txtpassword.Password = "";
            //}


            //var data = _userService.LoginByUserName(txtlogin.Text, txtpassword.Password);
            //if (data == null) throw new Exception("Bazada malumot yoq");
            //if (data.Result == true && txtpassword.Password != "" && txtlogin.Text != "")
            //{
            //    _mainWindow.Login_view.Visibility = Visibility.Hidden;
            //    _mainWindow.Menyu_view.Visibility = Visibility.Visible;
            //}
            //else
            //{
            //    MessageBox.Show("Username yoki Parol xato");
            //}
            if(txtlogin.Text.Length==0 || txtpassword.Password.Length == 0)
            {
                MessageBox.Show("Plese fill login and password");
            }
            else
            {
                var res = await _userService.LoginByUserName(txtlogin.Text, txtpassword.Password);
                if (res)
                {
                    _mainWindow.Kassa_view.Visibility = Visibility.Visible;
                    _mainWindow.Login_view.Visibility = Visibility.Collapsed;
                    MessageBox.Show("Welcom to my Point of Sales");
                    txtlogin.Text=txtpassword.Password="";
                }
                else
                {
                    MessageBox.Show("Username or Password incorrect!");
                }
            }
        }
    }
}
