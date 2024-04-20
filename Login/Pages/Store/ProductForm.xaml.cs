using Login.Common.DTO;
using Login.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Login.Pages.Store
{
    /// <summary>
    /// Interaction logic for ProductForm.xaml
    /// </summary>
    public partial class ProductForm : Window
    {
        IProductService _productService {  get; set; }
        StoreControl _storeControl {  get; set; }
        ProductsControl _productsControl { get; set; }
        private long productId {  get; set; }
        public ProductForm()
        {
            InitializeComponent();
        }

        public void SetMainWindow(IProductService productService, StoreControl storeControl, ProductsControl productsControl)
        {
            _productService = productService;
            _storeControl = storeControl;
            _productsControl = productsControl;
        }

        

        private async void save_btn_Click(object sender, RoutedEventArgs e)
        {
            var res = new ProductDTO()
            {
                Name = name_txt.Text,
                Barcode = barcode_txt.Text,
                ActualPrice = int.Parse(actualprice_txt.Text),
                Amount = int.Parse(amount_txt.Text),
                Price = int.Parse(price_txt.Text),
                PriceOfPiece = int.Parse(priceOfPiece_txt.Text),
                Selected = tag_checkbox.IsChecked.Value,
            };
            if (productId == 0)
            {
                await _productService.CreateProduct(res);
            }
            else
            {
                await _productService.UpdateProduct(productId, res);
            }
            _storeControl.products_control.GetAllProducts();
            this.Close();

        }

        private void cansel_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

      
        private void NumericValidator(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9^.]");
            e.Handled = regex.IsMatch(e.Text);
        }

        public void ClearForm()
        {
            name_txt.Text = barcode_txt.Text = actualprice_txt.Text =
                amount_txt.Text = amountInPackage_txt.Text = price_txt.Text =
                priceOfPiece_txt.Text = "";
            tag_checkbox.IsChecked= false;
        }

        public async void FillForm(long Id, bool IsVisible = false)
        {
            var prop = await _productService.GetProductById(Id);
            if(prop != null)
            {
                productId = Id;
                name_txt.Text = prop.Name;
                barcode_txt.Text = prop.Barcode;
                actualprice_txt.Text = prop.ActualPrice.ToString();
                amount_txt.Text = prop.Amount.ToString();
                amountInPackage_txt.Text = prop.AmountInPackage.ToString();
                price_txt.Text = prop.Price.ToString();
                priceOfPiece_txt.Text = prop.PriceOfPiece.ToString();
                tag_checkbox.IsChecked = prop.Selected;

            }
        }
    }
}
