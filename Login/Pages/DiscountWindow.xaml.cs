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
using System.Windows.Shapes;

namespace Login.Pages
{
    /// <summary>
    /// Interaction logic for DiscountWindow.xaml
    /// </summary>
    public partial class DiscountWindow : Window
    {
        DiscountListController _discountListController { get; set; }
        IDiscountService _discountService { get; set; }
        IProductService _productService { get; set; }
        private List<ProductForSelect> forSelects { get; set; }=new List<ProductForSelect>();
        private DiscountDTO discountDTO { get; set; }
        private long selectedDiscountId { get; set; } = 0;
        public DiscountWindow()
        {
            InitializeComponent();
        }

        public void SetVariabl(DiscountListController discountListController, IDiscountService discountService,IProductService productService)
        {
            _discountListController = discountListController;
            _discountService = discountService;
            _productService = productService;
            GetAllProductsForDiscount1();
        }

        public async void GetAllProductsForDiscount1()
        {
            forSelects = await _productService.GetAllProductsForDiscount();
            if(forSelects != null && forSelects.Any())
            {
                discount_datagrid.ItemsSource = forSelects;
                discount_datagrid.Items.Refresh();
            }
        }
        private void Window_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private async void save_btn_Click(object sender, RoutedEventArgs e)
        {
            DiscountDTO discountDTO = new DiscountDTO();
            discountDTO.Title = title_txb.Text;
            discountDTO.Description= description_txb.Text;
            discountDTO.Amount=decimal.Parse(amount_txb.Text);
            discountDTO.AmountType = amount_type_combox.Text == "Percent" ?
                Data.Enum.DiscountType.Percent : amount_type_combox.Text == "Amount" ?
                Data.Enum.DiscountType.Amount : Data.Enum.DiscountType.Count;
            discountDTO.StarDate = star_date_datapicker.SelectedDate.Value;
            discountDTO.EndDate = end_date_datapicker.SelectedDate.Value;
            discountDTO.DiscountStatus=activ_checkbox.IsChecked==true? Data.Enum.DiscountStatus.Active :
                Data.Enum.DiscountStatus.Inactive;

            if (forSelects.Any(a => a.Select))
            {
                discountDTO.ProductsDTO = new List<ProductForSelect>();
                discountDTO.ProductsDTO.AddRange(forSelects.Where(a => a.Select));
            }
            else
            {
                MessageBox.Show("Products doesn't select for discount creating!");
                return;
            }
            if (selectedDiscountId > 0)
            {
                await _discountService.UpdateDiscount(selectedDiscountId, discountDTO);
            }
            else
            {
                await _discountService.CreateDiscount(discountDTO);
            }

           _discountListController.GetAllDiscounts();
            ClearForm();
            this.Close();
        }

        private void cansel_btn_Click(object sender, RoutedEventArgs e)
        {
            ClearForm();
            this.Close();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            if(checkBox?.DataContext is ProductForSelect productForDiscountDto)
            {
                productForDiscountDto.Select = true;
            }
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            if(checkBox?.DataContext is ProductForSelect productForDiscountDto)
            {
                productForDiscountDto.Select = false;
            }
        }

        private async void refresh_btn_Click(object sender, RoutedEventArgs e)
        {
            if (selectedDiscountId > 0)
            {
                forSelects = await _productService.GetProductsByIdsForDiscount(discountDTO.ProductsDTO.Select(a => a.Id).ToList());
            }
            else
            {
                forSelects = await _productService.GetAllProductsForDiscount();
            }
            if (forSelects != null && forSelects.Any())
            {
                discount_datagrid.ItemsSource = forSelects;
                discount_datagrid.Items.Refresh();
            }
        }

        private void ClearForm()
        {
            title_txb.Text =  description_txb.Text = amount_txb.Text = string.Empty;
            amount_type_combox.SelectedItem = amount_type_combox.Items[amount_type_combox.SelectedIndex];
            star_date_datapicker.SelectedDate = DateTime.Now;
            end_date_datapicker.SelectedDate = DateTime.Now;
            activ_checkbox.IsChecked = false;
        }
    }
}
