﻿using Login.Common.DTO;
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
using System.Windows.Shapes;

namespace Login.Pages
{
    /// <summary>
    /// Interaction logic for UserCreateForm.xaml
    /// </summary>
    public partial class UserCreateForm : Window
    {
        UserListController _userListController {  get; set; }
        EmployeService _employeService { get; set; }
        long employeId { get; set; } = 0;

        bool isDisabled { get; set; }= false;

        public UserCreateForm()
        {
            InitializeComponent();
        }
        
        public void SetVariables(UserListController userListController, EmployeService employeService)
        {
            _userListController = userListController;
            _employeService = employeService;
        }

        public async void SetEmployeeDate(long Id, bool isView=false)
        {
            if (Id > 0)
            {
                DisableForm(isView);
                employeId = Id;
                var employe = await _employeService.GetEmployeeById(Id);
                if(employe != null)
                {
                    jobtitle_txt.Text = employe.JobTitle;
                    enrollnumber_txt.Text = employe.EnrollNumber.ToString();
                   
                    employerole_combo.SelectedItem = employe.EmployeRole == Data.Enum.EmployePole.Cashier ?
                        employerole_combo.Items[0] : employerole_combo.Items[1];

                    username_txt.Text = employe.UserName;
                    password_txt.Text = employe.Password;
                    pin_txt.Text = employe.PIN;

                    firstname_txt.Text = employe.FirstName;
                    lastname_txt.Text = employe.LastName;
                    fathername_txt.Text= employe.FatherName;
                    borndate_picter.SelectedDate = employe.BornDate;
                    hiredate_picter.SelectedDate = employe.HireDate;
                    address_txt.Text = employe.Addres;
                    phonenumber_txt.Text = employe.PhoneNumber;
                }
            }
        }

        private async void save_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                EmployeeDTO newEmployee = new EmployeeDTO()
                {
                    // employe
                    JobTitle = jobtitle_txt.Text,
                    EnrollNumber = long.Parse(enrollnumber_txt.Text),
                    HireDate = hiredate_picter.SelectedDate.Value,
                    EmployeRole = employerole_combo.SelectedValue == employerole_combo.Items[0] ?
                    Data.Enum.EmployePole.Cashier : Data.Enum.EmployePole.Admin,
                    // username
                    UserName = employerole_combo.SelectedItem == employerole_combo.Items[1] ? username_txt.Text : "",
                    Password = employerole_combo.SelectedItem== employerole_combo.Items[1] ? password_txt.Text :"",
                    PIN = pin_txt.Text,

                    //person
                    FirstName=firstname_txt.Text,
                    LastName=lastname_txt.Text,
                    FatherName=fathername_txt.Text,
                    BornDate=borndate_picter.SelectedDate.Value,
                    PhoneNumber=phonenumber_txt.Text,
                    Addres=address_txt.Text,
                };
                if (employeId == 0)
                {
                    await _employeService.CreateEmployee(newEmployee);
                }
                else
                {
                    await _employeService.UpdateEmployee(employeId, newEmployee);
                }
                await _userListController.GetAllUsers();
                ClearnForm();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void DisableForm(bool isReadonly)
        {
            jobtitle_txt.IsEnabled= !isReadonly;
            enrollnumber_txt.IsEnabled= !isReadonly;
            employerole_combo.IsEnabled= !isReadonly;
            hiredate_picter.IsEnabled= !isReadonly;
            username_txt.IsEnabled = !isReadonly;
            firstname_txt.IsEnabled= !isReadonly;
            lastname_txt.IsEnabled = !isReadonly;
            fathername_txt.IsEnabled= !isReadonly;
            address_txt.IsEnabled = !isReadonly;
            phonenumber_txt.IsEnabled= !isReadonly;
            password_txt.IsEnabled = !isReadonly;
            pin_txt.IsEnabled= !isReadonly;
            borndate_picter.IsEnabled = !isReadonly;
            save_btn.Visibility = isReadonly ? Visibility.Hidden : Visibility.Visible;
        }


        public void ClearnForm()
        {
            jobtitle_txt.Text = "";
            enrollnumber_txt.Text = "";
            hiredate_picter.SelectedDate = DateTime.Today;
            employerole_combo.SelectedItem = employerole_combo.Items[0];

            username_txt.Text = "";
            password_txt.Text = "";
            pin_txt.Text = "";

            firstname_txt.Text = "";
            lastname_txt.Text = "";
            fathername_txt.Text = "";
            borndate_picter.SelectedDate = DateTime.Today;
            address_txt.Text = "";
            phonenumber_txt.Text = "";
        }

        private void cansel_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
