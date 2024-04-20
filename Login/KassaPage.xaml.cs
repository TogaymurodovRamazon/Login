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
    /// Interaction logic for KassaPage.xaml
    /// </summary>
    public partial class KassaPage : UserControl
    {
        MainWindow _mainWindow {  get; set; }
        public KassaPage()
        {
            InitializeComponent();
        }

        public void SetMainWindow(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
        }

        private void log_btn_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.Kassa_view.Visibility = Visibility.Collapsed;
            _mainWindow.Login_view.Visibility = Visibility.Visible;
        }

        private void sozlama_btn_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.Kassa_view.Visibility = Visibility.Collapsed;
            _mainWindow.Setting_view.Visibility = Visibility.Visible;
        }

        private void kassa_btn_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.Kassa_view.Visibility= Visibility.Collapsed;
            _mainWindow.Menyu_view.Visibility = Visibility.Visible;
        }

        private void store_btn_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.Kassa_view.Visibility= Visibility.Collapsed;
            _mainWindow.Store_view.Visibility = Visibility.Visible;
        }

        private void malumot_btn_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.Kassa_view.Visibility=Visibility.Collapsed;
            _mainWindow.Setting_View.Visibility= Visibility.Visible;
        }
    }
}
