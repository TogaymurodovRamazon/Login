using Login.Common.DTO;
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
    /// Interaction logic for ProductsControl.xaml
    /// </summary>
    public partial class ProductsControl : UserControl
    {
        StoreControl _storeControl {  get; set; }
        IProductService _productService { get; set; }
        ProductDTO selectedProduct { get; set; }
        public ProductsControl()
        {
            InitializeComponent();
        }

        public void SetMainWindow(StoreControl storeControl, IProductService productService)
        {
            _storeControl = storeControl;
            _productService = productService;
        }

        public async void GetAllProducts()
        {
            var products = await _productService.GetAllProducts();
            products_datagrid.ItemsSource= products;
            products_datagrid.Items.Refresh();
        }

        private void create_btn_Click(object sender, RoutedEventArgs e)
        {
            ProductForm productForm = new ProductForm();
            productForm.SetMainWindow( _productService , _storeControl, this);
            productForm.ShowDialog();
        }

        private void product_datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedProduct = products_datagrid.SelectedItem as ProductDTO;
        }

        private void products_datagrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(selectedProduct != null)
            {
                if(selectedProduct != null)
                {
                    ProductForm productForm = new ProductForm();
                    productForm.SetMainWindow(_productService , _storeControl, this);
                    productForm.FillForm(selectedProduct.Id, true);
                    productForm.ShowDialog();
                }
            }
        }

        private void edit_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(selectedProduct != null)
                {
                    ProductForm productForm = new ProductForm();
                    productForm.SetMainWindow(_productService , _storeControl, this);
                    productForm.FillForm(selectedProduct.Id);
                    productForm.ShowDialog();
                }
                else
                {
                   MessageBox.Show("Please select any product!");
                }
            }
            catch(Exception exseption)
            {
                MessageBox.Show(exseption.Message);
            }
        }

        private async void delete_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(selectedProduct != null )
                {
                    await _productService.DeleteProduct(selectedProduct.Id);
                    GetAllProducts();
                }
                else
                {
                    MessageBox.Show("Please select any product!");
                }
            }
            catch(Exception exsep)
            {
                MessageBox.Show(exsep.Message);
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            GetAllProducts();
        }
    }
}
