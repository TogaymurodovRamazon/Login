using Login.Data;
using Login.Data.Models;
using Login.IRepository;
using Login.Service;
using System.Text;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private readonly IUserService userService;
        private readonly IGenericRepository<User> genericRepository;
        private readonly AppDBContext appDBContext;
        public MainWindow(IUserService userService , IGenericRepository<User> genericRepository , AppDBContext appDBContext)
        {
            InitializeComponent();

            this.appDBContext = appDBContext;
            this.userService = userService;
            this.genericRepository = genericRepository;

            Asosiy_Page.SetMainWindow(this);
            Login_Page.SetMainWindow(this);
            PinKod_Page.SetMainWindow(this);
            Menyu_Page.SetMainWindow(this);
            Kassa_Page.SetMainWindow(this);
            Setting_Page.SetMainWindow(this);
            
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Asosiysi_view.Visibility = Visibility.Visible;
        }
    }
}