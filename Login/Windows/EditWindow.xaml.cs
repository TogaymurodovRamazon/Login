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
    /// Interaction logic for EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
       private decimal _totalAmount {  get; set; }
       Menyu _menyu { get; set; }

        public EditWindow()
        {
            InitializeComponent();
        }

        public void SetMainWindow(Menyu menyu ,decimal totalAmount, decimal amount)
        {
            umumiy_soni_lbl.Content = totalAmount.ToString();
            soni_btn.Text=amount.ToString();
            _totalAmount = totalAmount;
            _menyu = menyu;
        }

        private void Edit_btn_Click(object sender, RoutedEventArgs e)
        {
            if (soni_btn.Text.Length > 0)
            {
                if (decimal.Parse(soni_btn.Text) <= _totalAmount)
                {
                    _menyu.ChangeQuantityProduct(decimal.Parse(soni_btn.Text));
                    this.Close();
                }
            }
           
        }

        private void Close_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void soni_btn_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (soni_btn.Text.Length > 0)
            {
                if (decimal.Parse(soni_btn.Text) > _totalAmount)
                {
                  soni_btn.Text = soni_btn.Text.Substring(0, soni_btn.Text.Length - 1);
                }
                
            }
        }
    }
}
