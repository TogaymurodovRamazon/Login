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

namespace Login.Windows
{
    /// <summary>
    /// Interaction logic for SettingView.xaml
    /// </summary>
    public partial class SettingView : UserControl
    {
        MainWindow _mainWindow {  get; set; }
        public SettingView()
        {
            InitializeComponent();
        }

        public void SetMainWindow(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
        } 

        private void qaytish_btn_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.Setting_View.Visibility = Visibility.Collapsed;
            _mainWindow.Kassa_view.Visibility = Visibility.Visible;
        }
    }
}
