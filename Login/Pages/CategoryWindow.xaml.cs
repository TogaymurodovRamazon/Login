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
    /// Interaction logic for CategoryWindow.xaml
    /// </summary>
    public partial class CategoryWindow : Window
    {

        CategoryListController _categoryListController;
        ICategoryService _categoryService;
        IProductService _productService;
        private List<ProductForSelect> _productForSelects { get; set; } = new();
        private List<SelectDTO> parentCategories {  get; set; } = new();
        public CategoryWindow()
        {
            InitializeComponent();
        }

        public void SetVariables(CategoryListController categoryListController, ICategoryService categoryService, IProductService productService)
        {
            _categoryListController = categoryListController;
            _categoryService = categoryService;
            _productService = productService;
            GetAllProducts();
            GetParentCategoriess();
        }

        public async void GetAllProducts()
        {
            if (!_productForSelects.Any())
            {
                _productForSelects = await _productService.GetAllProductsForDiscount();

            }
            category_datagrid.ItemsSource = _productForSelects;
            category_datagrid.Items.Refresh();
        }

        public async void GetParentCategoriess()
        {
            parentCategories = await _categoryService.GetCategoriesForSelect();
            if (parentCategories.Any())
            {
                parent_category_combox.ItemsSource = parentCategories.Select(a=>a.Name);
                parent_category_combox.Items.Refresh();
            }
        }
        private void refresh_btn_Click(object sender, RoutedEventArgs e)
        {
            GetAllProducts();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            if(checkBox?.DataContext is ProductForSelect productfordiscountDTO)
            {
                productfordiscountDTO.Select = true;
            }
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            if(checkBox?.DataContext is ProductForSelect productfordiscountDTO)
            {
                productfordiscountDTO.Select = false;
            }
        }

        private  void cansel_btn_Click(object sender, RoutedEventArgs e)
        {
           this.Close();
        }

        private async void save_btn_Click(object sender, RoutedEventArgs e)
        {
            CategoryDTO categoryDTO = new CategoryDTO();
            categoryDTO.Title = name_txb.Text;
            categoryDTO.Description = description_txb.Text;
            categoryDTO.ParentId = parentCategories.Any() ? parentCategories[parent_category_combox.SelectedIndex].Id : null;
            categoryDTO.Products = _productForSelects.Any() ? _productForSelects.Where(a => a.Select).ToList() : new();
            if(_productForSelects.Any())
            {
                categoryDTO.Products = new List<ProductForSelect>();
                categoryDTO.Products.AddRange(_productForSelects.Where(a => a.Select));
            }
            else
            {
                MessageBox.Show("Products doesn't select for discount creating!");
            }
            await _categoryService.CreateProductCategory(categoryDTO);
            _categoryListController.GetAllCategory();
            ClearForm();
            this.Close();
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void ClearForm()
        {
            name_txb.Text = description_txb.Text = string.Empty;
            _productForSelects = null;
            parentCategories = null;
            category_datagrid.ItemsSource = null;
            parent_category_combox.ItemsSource = null;
            _productForSelects = new();
            parentCategories = new();
        }
    }
}
