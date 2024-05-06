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

namespace Login.Pages
{
    /// <summary>
    /// Interaction logic for CategoryListController.xaml
    /// </summary>
    public partial class CategoryListController : UserControl
    {
        private SettingPage _settingPage {  set; get; }
        private IProductService _productService { set; get; }
        private ICategoryService _categoryService { set; get; }
        private List<CategoryDTO> _categories { set; get; }=new List<CategoryDTO>();
        public CategoryListController()
        {
            InitializeComponent();
        }

        public void SetVariabls(SettingPage settingPage, IProductService productService, ICategoryService categoryService)
        {
            _settingPage = settingPage;
            _productService = productService;
            _categoryService = categoryService;
            if (!_categories.Any())
            {
                GetAllCategory();
            }
        }

        public async void GetAllCategory()
        {
            _categories = await _categoryService.GetAllProductCategorys();
            if (_categories.Any())
            {
                category_datagrid.ItemsSource = _categories;
                category_datagrid.Items.Refresh();
            }
        }

        private void category_datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void category_datagrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void edit_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void delete_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void create_btn_Click(object sender, RoutedEventArgs e)
        {
            CategoryWindow categoryWindow = new CategoryWindow();
            categoryWindow.SetVariables(this, _categoryService, _productService);
            categoryWindow.GetAllProducts();
            categoryWindow.GetParentCategoriess();
            categoryWindow.ShowDialog();
        }
    }
}
