using Login.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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

namespace Login.Pages
{
    /// <summary>
    /// Interaction logic for DiscountListController.xaml
    /// </summary>
    public partial class DiscountListController : UserControl
    {
       SettingPage _settingPage {  get; set; }
        IDiscountService _discountService { get; set; }
        IProductService _productService { get; set; }
        
        public DiscountListController()
        {
            InitializeComponent();
        }
        public void SetVariables(SettingPage settingPage, IDiscountService discountService,IProductService productService)
        {
            _settingPage = settingPage;
            _discountService = discountService;
            _productService = productService;
        }

        public async void GetAllDiscounts()
        {
            var discount = await _discountService.GetAllDiscount();
            if (discount.Any())
            {
                discount_datagrid.ItemsSource= discount;
                discount_datagrid.Items.Refresh();
            }

        }
        private void create_btn_Click(object sender, RoutedEventArgs e)
        {
            DiscountWindow discountWindow = new DiscountWindow();
            discountWindow.SetVariabl(this, _discountService, _productService);
            discountWindow.GetAllProductsForDiscount1();
            discountWindow.ShowDialog();
        }

        private void edit_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void delete_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void discount_datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void discount_datagrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
