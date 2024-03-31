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
    /// Interaction logic for SettingPage.xaml
    /// </summary>
    public partial class SettingPage : UserControl
    {
        private MainWindow _window {  get; set; }
        private IUserService _userService { get; set; }
        private EmployeService _employeService { get; set; }
        public SettingPage()
        {
            InitializeComponent();
        }
        public void SetMainWindow(MainWindow window,IUserService userService,EmployeService employeService)
        {
            _window = window;
            _userService = userService;
            _employeService = employeService;
            employees_control.SetMainWindow(_employeService, _window, _userService);
        }

        private void employe_btn_Click(object sender, RoutedEventArgs e)
        {
            employees_control.SetMainWindow(_employeService, _window, _userService);
            employees_doc.Visibility = Visibility.Visible;
            language_doc.Visibility = Visibility.Collapsed;
        }

        private void language_btn_Click(object sender, RoutedEventArgs e)
        {
            language_doc.Visibility= Visibility.Visible;
            employees_doc.Visibility = Visibility.Collapsed;
        }
    }
}
