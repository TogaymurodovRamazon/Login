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
    /// Interaction logic for DiscountView.xaml
    /// </summary>
    public partial class DiscountView : Window
    {
        Menyu _menyu {  get; set; }
        public decimal summa {  get; set; }
        public decimal foiz {  get; set; }
        public decimal natija {  get; set; }
        
        public DiscountView()
        {
            InitializeComponent();
        }

        public void SetVariables(Menyu menyu, string Summa)
        {
            _menyu = menyu;
            summa_txb.Text = Summa;
            summa = decimal.Parse(Summa);
        }

        private void summa_txb_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void foiz_txb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (foiz_txb.Text.Length > 0)
            {
               
            }
        }

        private void natija_txb_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ok_btn_Click(object sender, RoutedEventArgs e)
        {
            if (natija < summa)
            {
                _menyu.SetDiscountSumma(natija.ToString());
                summa_txb.Text = foiz_txb.Text = natija_txb.Text = string.Empty;
                this.Close();
            }
            else
            {
                MessageBox.Show("Ortiqcha summa kiritildi!");
            }
        }

        private void bekorqilish_btn_Click(object sender, RoutedEventArgs e)
        {
            summa_txb.Text = foiz_txb.Text = natija_txb.Text = string.Empty;
            this.Close();
        }

        public void SetSum(decimal totalsum)
        {
            summa_txb.Text = totalsum.ToString();
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if(natija_txb.Text.Length>0 && natija_txb.IsFocused)
            {
                natija = decimal.Parse(natija_txb.Text);
                foiz = Math.Round(((summa-natija)/summa)*100 , 3);
                foiz_txb.Text=foiz.ToString();
            }
            if(foiz_txb.Text.Length>0 && foiz_txb.IsFocused)
            {
                foiz=decimal.Parse(foiz_txb.Text);
                natija = Math.Round(summa - summa *(foiz/ 100) , 3);
                natija_txb.Text=natija.ToString();
            }
        }
    }
}
