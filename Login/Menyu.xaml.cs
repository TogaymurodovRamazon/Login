using Login.Common.DTO;
using Login.Service;
using Login.Windows;
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
    /// Interaction logic for Menyu.xaml
    /// </summary>
    public partial class Menyu : UserControl
    {
        MainWindow _mainWindow { get; set; }
        IProductService _productService {  get; set; }
        private ProductForSearchDTO selectedProduct {  get; set; }

        private List<ProductForSearchDTO> Products=new List<ProductForSearchDTO>();
        private List<ProductForKassaDTO> ProductCash=new List<ProductForKassaDTO>();

        private ProductForKassaDTO selectedKassaProduct { get; set; }
        public Menyu()
        {
            InitializeComponent();
        }
        public void SetMainWindow(MainWindow mainWindow ,IProductService productService)
        {
            _mainWindow = mainWindow;
           _productService = productService;
        }

        private async void searchcombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (searchcombo.SelectedIndex >= 0)
            {
                selectedProduct = Products[searchcombo.SelectedIndex];

                if (selectedProduct != null)
                {
                    AddProductTable(selectedProduct.Id);
                }
            }
        }

         private async void AddProductTable(long productId)
        {
            var product=await _productService.GetProductById(productId);
            if (product.Amount>1)
            {
                if(ProductCash.Any(a=>a.Id == product.Id))
                {
                    ProductCash.Where(a => a.Id == product.Id).ToList().ForEach(a =>
                    {
                        a.Quantity++;
                        a.TotalPrice = a.Quantity * a.Price;
                    });
                }
                else
                {
                    ProductCash.Add(new ProductForKassaDTO()
                    {
                        Index=ProductCash.Count + 1,
                        Id=product.Id,
                        Name=product.Name,
                        Barcode=product.Barcode,
                        Price=product.Price,
                        Quantity=1,
                        TotalPrice=product.Price
                       
                    });
                }
                datagridview.ItemsSource=ProductCash;
                datagridview.Items.Refresh();
                all_lebl.Content = ProductCash.Sum(x => x.TotalPrice);
            }
            else
            {
                MessageBox.Show("Mahsulot yetarli emas!");
            }
        }   


        private void searchcombo_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private async void barCode_tbx_KeyUp(object sender, KeyEventArgs e)
        {
            if (searchcombo.Text.Length > 2)
            {
                Products= await _productService.GetProductForSearche(searchcombo.Text);
                searchcombo.ItemsSource = Products.Select(a => a.Name);
            }
            else if (searchcombo.Text.Length == 0)
            {
                searchcombo.ItemsSource= null;
                searchcombo.Items.Refresh();
            }
        }

        private void selected_payment_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void edit_btn_Click(object sender, RoutedEventArgs e)
        {
            selectedKassaProduct = datagridview.SelectedItem as ProductForKassaDTO;
            if(selectedKassaProduct != null)
            {
                var prod= await _productService.GetProductById(selectedKassaProduct.Id);
                EditWindow editWindow = new EditWindow();
                editWindow.SetMainWindow(this ,prod.Amount, selectedKassaProduct.Quantity);
                editWindow.ShowDialog();
                
            }
        }

        private void kategori_btn_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void TizChiq_btn_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.Login_view.Visibility = Visibility.Visible;
            _mainWindow.Menyu_view.Visibility = Visibility.Collapsed;
            ClearCash();
        }

        private void qosh_btn_Click(object sender, RoutedEventArgs e)
        {
            var prod = datagridview.SelectedItem as ProductForKassaDTO;
            if(prod != null)
            {
                AddProductTable(prod.Id);
            }
        }

        private void clint_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void clint_card_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ayirish_btn_Click(object sender, RoutedEventArgs e)
        {
            var prod = datagridview.SelectedItem as ProductForKassaDTO;
            if(prod !=null && prod.Quantity > 1)
            {
                ProductCash.Where(z => z.Id == prod.Id).ToList().ForEach(z =>
                {
                    z.Quantity--;
                    z.TotalPrice = z.Quantity * z.Price;
                });
            }
            else if(prod != null && prod.Quantity==1) 
            {
                ProductCash.Remove(prod);
            }
            datagridview.ItemsSource = ProductCash;
            datagridview.Items.Refresh();
            all_lebl.Content = ProductCash.Sum(a => a.TotalPrice);
        }

        private void return_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void chegirma_btn_Click(object sender, RoutedEventArgs e)
        {
            if (ProductCash.Any())
            {
                 DiscountView discountView = new DiscountView();
                 discountView.SetVariables(this, ProductCash.Sum(a=>a.TotalPrice).ToString());
                 discountView.ShowDialog();
            }
            else
            {
                MessageBox.Show("Mahsulot tanlanmagan!");
            }
           
        }

        private void ClearCash()
        {
            Products.Clear();
            ProductCash.Clear();
            datagridview.ItemsSource = null;
            searchcombo.ItemsSource = null;
            all_lebl.Content = string.Empty;
            final_sum_lbl.Content = string.Empty;
        }

        public void ChangeQuantityProduct(decimal quantity)
        {
            ProductCash.Where(a => a.Id == selectedKassaProduct.Id).ToList().ForEach(a =>
            {
                a.Quantity = quantity;
                a.TotalPrice = a.Quantity * a.Price;
            });
            datagridview.ItemsSource = ProductCash;
            datagridview.Items.Refresh();
            all_lebl.Content=ProductCash.Sum(a => a.TotalPrice);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        public void SetDiscountSumma (string summa)
        {
            final_sum_lbl.Content= summa;
        }
    }
}
