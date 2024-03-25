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
    /// Interaction logic for XodimControl.xaml
    /// </summary>
    public partial class XodimControl : UserControl
    {
        MainWindow _window {  get; set; }
        public XodimControl()
        {
            InitializeComponent();
        }
        public void SetMainWindow(MainWindow window)
        {
            _window = window;
        }
    }
}
