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

namespace Login.Pages.Components
{
    /// <summary>
    /// Interaction logic for CategoriesForKassaControl.xaml
    /// </summary>
    public partial class CategoriesForKassaControl : UserControl
    {
        private Menyu _menyu {  get; set; }
        private ICategoryService _categoryService {  get; set; }

        public List<SelectDTO> categoryList=new List<SelectDTO>();
        private long curretCategoryId = 0; 
        public CategoriesForKassaControl()
        {
            InitializeComponent();
        }
        public void SetVariables(Menyu menyu, ICategoryService categoryService)
        {
            _menyu = menyu;
            _categoryService = categoryService;
        }
        public async void GetChildCategoies(long? parentId)
        {
            categoryList = await _categoryService.GetCategoriesForSelect(parentId);
            if(categoryList != null && categoryList.Any())
                GetAllCategories();
        }

        public void GetAllCategories()
        {
            main_wrap.Visibility = Visibility.Visible;
            main_wrap.Children.Clear();
            foreach (var category in categoryList)
            {
                CategoryItemControl itemControl = new CategoryItemControl();
                itemControl.Tag = category.Id;
                itemControl.SetVariables(_categoryService, this);
                itemControl.SetCategoryName(category.Name);
                itemControl.Margin = new Thickness(5, 5, 5, 5);
                main_wrap.Children.Add(itemControl);
            }
        }

        public async void GetCategoryProducts(long categotyId)
        {
            curretCategoryId = categotyId;
            products_panel.Visibility= Visibility.Visible;
            main_wrap.Visibility = Visibility.Collapsed;
            var category = await _categoryService.GetById(categotyId);
            if( category != null && category.Products.Any())
            {
                products_datagrid.ItemsSource = category.Products;
                products_datagrid.Items.Refresh();
            }
        }

        private void refresh_btn_Click(object sender, RoutedEventArgs e)
        {
            if(curretCategoryId > 0)
            {
                GetCategoryProducts(curretCategoryId);
            }
        }

        private void products_datagrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var select = products_datagrid.SelectedItem as ProductForSelect;
            _menyu.AddProductToCash(select.Id);
            _menyu.menyu_box.Visibility = Visibility.Visible;
            _menyu.category_doc.Visibility = Visibility.Collapsed;

            products_panel.Visibility = Visibility.Collapsed;
            categoryList = new List<SelectDTO>();
        }
    }
}
