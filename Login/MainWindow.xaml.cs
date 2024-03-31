﻿using Login.Data;
using Login.Data.Models;
using Login.IRepository;
using Login.Service;
using System.Text;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private readonly IUserService userService;
        private readonly IGenericRepository<User> genericRepository;
        private readonly AppDBContext appDBContext;
        private readonly EmployeService employeService;

        public MainWindow(IUserService userService , 
            IGenericRepository<User> genericRepository , 
            AppDBContext appDBContext,
            EmployeService employeService)
        {
            InitializeComponent();

            this.appDBContext = appDBContext;
            this.employeService = employeService;
            this.userService = userService;
            this.genericRepository = genericRepository;

            Asosiy_Page.SetMainWindow(this);
            Login_Page.SetMainWindow(this, userService);
            PinKod_Page.SetMainWindow(this,userService);
            Menyu_Page.SetMainWindow(this);
            Kassa_Page.SetMainWindow(this);
            Setting_Page.SetMainWindow(this, userService, employeService);
            Xodim_Control.SetMainWindow(this);
            employee_control.SetMainWindow(employeService, this, userService);
        }

    }
}