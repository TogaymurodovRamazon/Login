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
    /// Interaction logic for GibritPayWindow.xaml
    /// </summary>
    public partial class GibritPayWindow : Window
    {
        public GibritPayWindow()
        {
            InitializeComponent();
        }

        private void close_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void tolovqilish_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void plastik_txb_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void naqt_txb_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void qatim_txb_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void summa_txb_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
