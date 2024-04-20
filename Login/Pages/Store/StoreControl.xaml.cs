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

namespace Login.Pages.Store
{
    /// <summary>
    /// Interaction logic for StoreControl.xaml
    /// </summary>
    public partial class StoreControl : UserControl
    {
        MainWindow _mainWindow {  get; set; }
        IProductService _productService { get; set; }
        public StoreControl()
        {
            InitializeComponent();
        }

        public void SetMainWindow(MainWindow mainWindow, IProductService productService)
        {
            _mainWindow = mainWindow;
            _productService = productService;
            products_control.SetMainWindow(this, _productService);
        }

        private void Mahsulot_btn_Click(object sender, RoutedEventArgs e)
        {
            products_doc.Visibility = Visibility.Visible;
            products_control.SetMainWindow(this, _productService);
        }

        private void Mah_Qabul_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Mah_Qaytarish_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Back_btn_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.Store_view.Visibility = Visibility.Collapsed;
            _mainWindow.Kassa_view.Visibility = Visibility.Visible;
        }

       
    }
}
