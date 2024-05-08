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
    /// Interaction logic for CategoryItemControl.xaml
    /// </summary>
    public partial class CategoryItemControl : UserControl
    {
        private ICategoryService _categoryService {  get; set; }
        private CategoriesForKassaControl _categoriesForKassaControl { get; set; }
        public CategoryItemControl()
        {
            InitializeComponent();
        }

        public void SetVariables(ICategoryService categoryService, CategoriesForKassaControl categoriesForKassaControl)
        {
            _categoryService = categoryService;
            _categoriesForKassaControl= categoriesForKassaControl;
        }

        public void SetCategoryName(string name)
        {
            name_txt.Text = name;
        }
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var category = _categoriesForKassaControl.categoryList.FirstOrDefault(a => a.Id == long.Parse(this.Tag.ToString()));
                var hasChild = await _categoryService.HasChildCategory(category.Id);
                if (hasChild)
                {
                    _categoriesForKassaControl.GetChildCategoies(category.Id);

                }
                else
                {
                    _categoriesForKassaControl.GetCategoryProducts(category.Id);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
