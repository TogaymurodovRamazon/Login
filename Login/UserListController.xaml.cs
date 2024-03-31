using Login.Common.DTO;
using Login.Data.Models;
using Login.Pages;
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
        private List<EmployeeDTO> employeeDTOs = new List<EmployeeDTO>();
        

        MainWindow _mainWindow { get; set; }
        IUserService _userService { get; set; }
        private EmployeService _employeService { get; set; }
        EmployeeDTO selectedUser { get; set; }

        public UserListController()
        {
            InitializeComponent();
        }
        
        public async void SetMainWindow(EmployeService employeService,
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
            employeeDTOs = await _employeService.GetAllEmployee();
            if (employeeDTOs != null && employeeDTOs.Any())
            {
                users_datagrid.ItemsSource = employeeDTOs;
            }
        }

        private async void create_btn_Click(object sender, RoutedEventArgs e)
        {
           UserCreateForm userCreateForm = new UserCreateForm();
            userCreateForm.SetVariables(this, _employeService);
            userCreateForm.ShowDialog();
        }

        private void edit_btn_Click(object sender, RoutedEventArgs e)
        {
            if(selectedUser != null)
            {
                UserCreateForm userCreateForm = new UserCreateForm();
                userCreateForm.SetVariables(this, _employeService);
                userCreateForm.SetEmployeeDate(selectedUser.Id);
                userCreateForm.ShowDialog();
            }
        }

        private async void delete_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(selectedUser != null)
                {
                    await _employeService.DeleteEmployee(selectedUser.Id);
                    await GetAllUsers();
                }
               
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void users_datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedUser = users_datagrid.SelectedItem as EmployeeDTO;
        }
    }
}
