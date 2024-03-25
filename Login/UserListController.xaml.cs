using Login.Common.DTO;
using Login.Data.Models;
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
    /// Interaction logic for UserListController.xaml
    /// </summary>
    public partial class UserListController : UserControl
    {
        List<UserDTO> users = new List<UserDTO>();

        MainWindow _mainWindow { get; set; }
        IUserService _userService { get; set; }
        EmployeService _employeService { get; set; }

        public UserListController()
        {
            InitializeComponent();
        }
        
        public async void SetAllVariables(EmployeService employeService,
                                          MainWindow mainWindow, 
                                          IUserService userService)
        {
            _mainWindow = mainWindow;
            _userService = userService;
            _employeService = employeService;
            await GetAllUsers();
        }

        public async Task GetAllUsers()
        {
            users=await _userService.GetAllUsers();
            if (users != null && users.Any())
            {
                users_datagrid.ItemsSource = users;
            }
        }

        private async void create_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                EmployeCreateDTO newEmploye = new EmployeCreateDTO()
                {
                    //employee details
                    JobTitle = "DeveloperIT",
                    EnrollNumber = 12312345,
                    HireDate = DateTime.Now,
                    EmployeRole = Data.Enum.EmployePole.Manager,

                    //user details
                    UserName = "Valijon",
                    Password = "valibek",
                    PIN = "56789",

                    //person details
                    FirstName = "Solijon",
                    LastName = "Aminov",
                    FatherName = "Qori o'g'li",
                    BornDate = new DateTime(2010, 11, 01),
                    Addres = "Toshkent",
                    PhoneNumber = "904418556",

                };

                await _employeService.CreateEmploye(newEmploye);
                await GetAllUsers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void edit_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void delete_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void users_datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
