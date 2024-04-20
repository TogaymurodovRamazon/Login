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
    /// Interaction logic for SelectPayment.xaml
    /// </summary>
    public partial class SelectPayment : Window
    {
        public SelectPayment()
        {
            InitializeComponent();
        }

        private void close_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
