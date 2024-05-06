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
        private ICheckPrintService _checkPrintService { get; set; }

        private IProductService _productService { get; set; }
        private ICategoryService _categoryService { get; set; }
        private IDiscountService _discountService { get; set; }
        public SettingPage()
        {
            InitializeComponent();
        }
        public void SetMainWindow(MainWindow window,IUserService userService,EmployeService employeService, 
            ICheckPrintService checkPrintService,IProductService productService,ICategoryService categoryService,IDiscountService discountService)
        {
            _window = window;
            _userService = userService;
            _employeService = employeService;
            _checkPrintService = checkPrintService;
            _discountService = discountService;
            _categoryService = categoryService;
            _productService = productService;

            employees_control.SetMainWindow(_employeService, _window, _userService);
            cheksozlama_control.SetAllVaribles(_window,_checkPrintService,this);
            chegirmaberish_controller.SetVariables(this, _discountService, _productService);
           
          
        }

        private void employe_btn_Click(object sender, RoutedEventArgs e)
        {
            employees_control.SetMainWindow(_employeService, _window, _userService);
            employees_doc.Visibility = Visibility.Visible;
            language_doc.Visibility = Visibility.Collapsed;
            checksoz_doc.Visibility = Visibility.Collapsed;
            chegirmaberish_doc.Visibility = Visibility.Collapsed;
            category_doc.Visibility = Visibility.Collapsed;

        }

        private void language_btn_Click(object sender, RoutedEventArgs e)
        {

            language_doc.Visibility = Visibility.Visible;
            employees_doc.Visibility = Visibility.Collapsed;
            checksoz_doc.Visibility= Visibility.Collapsed;
            chegirmaberish_doc.Visibility=Visibility.Collapsed;
            mijoz_doc.Visibility=Visibility.Collapsed;
            category_doc.Visibility = Visibility.Collapsed;
        }
        
        private void Kichik_Katta_Click(object sender, RoutedEventArgs e)
        {
            if (Setting_grid.ColumnDefinitions.First().MaxWidth == 40)
            {
                Setting_grid.ColumnDefinitions.First().MaxWidth = 200;
            }
            else
            {
                Setting_grid.ColumnDefinitions.First().MaxWidth = 40;
            }
        }

        private void qaytish_btn_Click(object sender, RoutedEventArgs e)
        {
            _window.Setting_view.Visibility = Visibility.Collapsed;
            _window.Kassa_view.Visibility = Visibility.Visible;
        }

        private void cheksozlamasi_btn_Click(object sender, RoutedEventArgs e)
        {
            checksoz_doc.Visibility = Visibility.Visible;
            employees_doc.Visibility = Visibility.Collapsed;
            language_doc.Visibility = Visibility.Collapsed;
            chegirmaberish_doc.Visibility = Visibility.Collapsed;
            mijoz_doc.Visibility = Visibility.Collapsed;
            category_doc.Visibility = Visibility.Collapsed;
        }

        private void mijoz_btn_Click(object sender, RoutedEventArgs e)
        {
           mijoz_doc.Visibility = Visibility.Visible;
           employees_doc.Visibility = Visibility.Collapsed;
           language_doc.Visibility = Visibility.Collapsed;
           chegirmaberish_doc.Visibility = Visibility.Collapsed;
            checksoz_doc.Visibility = Visibility.Collapsed;
            category_doc.Visibility = Visibility.Collapsed;
        }
        private void chegirmaberish_btn_Click(object sender, RoutedEventArgs e)
        {
            
            chegirmaberish_doc.Visibility = Visibility.Visible;
            employees_doc.Visibility = Visibility.Collapsed;
            language_doc.Visibility = Visibility.Collapsed;
            checksoz_doc.Visibility = Visibility.Collapsed;
            mijoz_doc.Visibility= Visibility.Collapsed;
            category_doc.Visibility = Visibility.Collapsed;
        }

        private void category_btn_Click(object sender, RoutedEventArgs e)
        {
             category_control.SetVariabls(this, _productService, _categoryService);
            category_control.GetAllCategory();
           
            category_doc.Visibility = Visibility.Visible;
            employees_doc.Visibility = Visibility.Collapsed;
            language_doc.Visibility = Visibility.Collapsed;
            checksoz_doc.Visibility = Visibility.Collapsed;
            mijoz_doc.Visibility = Visibility.Collapsed;
            chegirmaberish_doc.Visibility = Visibility.Collapsed;
        }

        // xodimlar oynasiga o'xshagan bo'ladi product oynalari ham, xodimlar oynasini productga moslashtirib turing, jadvallarini ustunlarini o'zgartirib
        // til oynasi UI yasalgandi backenti yozish kerakmasmi hozircha kerak emas men oynani o'zi bog'lab qo'ymoqchi edim xolos 
        // sozlamalarnikiga o'xshatib/ sozlamalardagi tilni bosganda chiqadigan qilmoqchimisiz ha shuni bossa language oynasi ochiladigan, men qilganman man yozgan kodga qarang  , xodimlarnikiga o'xshaydi u ham
        // // hozir qarab turing aka 
        // bo'ldi endi ishlashi kerak ha shu ochilmay yotgandida/ bu yerda ham local ishlatgansizda pa ha tushundim aka rahmat sizgaOK
        // Savol bo'lsa yana yozarsiz hop
    }
}
