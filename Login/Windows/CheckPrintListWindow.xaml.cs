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
using System.Windows.Shapes;

namespace Login.Windows
{
    /// <summary>
    /// Interaction logic for CheckPrintListWindow.xaml
    /// </summary>
    public partial class CheckPrintListWindow : UserControl
    {

        private List<CheckPrintingDTO> checkPrintingDTOs = new List<CheckPrintingDTO>();
        CheckPrintingDTO printingDTO {  get; set; }
        SettingPage _settingPage { get; set; }

        private ICheckPrintService _checkPrintService { get; set; }

        MainWindow _mainWindow { get; set; }
        public CheckPrintListWindow()
        {
            InitializeComponent();
        }

        // bu windowku UserControl emasku, Window bunaqa ishlatilmaydiku
        // oyna window settingisga chaqiriladiku xatomi shu
        //siz yozgandek chaqirilmaydida

        public async void SetAllVaribles(MainWindow mainWindow ,ICheckPrintService checkPrintService,SettingPage settingPage)
        {
            _mainWindow = mainWindow;
            _checkPrintService = checkPrintService;
            _settingPage = settingPage;
            await GetAllCheckPrint();
        }

        public async Task GetAllCheckPrint()
        {
            checkPrintingDTOs =await _checkPrintService.GetAllCheckPrint();
            if(checkPrintingDTOs != null && checkPrintingDTOs.Any())
            {
                checkprint_datagrid.ItemsSource= checkPrintingDTOs;
            }
        }

        private void checkprint_datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            printingDTO = checkprint_datagrid.SelectedItem as CheckPrintingDTO;
        }

        private void checkprint_datagrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(printingDTO != null)
            {
                CheckPrintWindow checkPrintWindow = new CheckPrintWindow();
                checkPrintWindow.SettVariables(this, _checkPrintService);
                checkPrintWindow.SetCheckPrint(printingDTO.Id, true);
                checkPrintWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Select any CheckPrintingData!");
            }
        }

        private void create_btn_Click(object sender, RoutedEventArgs e)
        {
            CheckPrintWindow checkPrintWindow=new CheckPrintWindow();
            checkPrintWindow.SettVariables(this, _checkPrintService);
            checkPrintWindow.ShowDialog();
        }

        private void edit_btn_Click(object sender, RoutedEventArgs e)
        {
            if(printingDTO != null)
            {
                CheckPrintWindow checkPrintWindow=new CheckPrintWindow();
                checkPrintWindow.SettVariables(this, _checkPrintService);
                checkPrintWindow.SetCheckPrint(printingDTO.Id);
                checkPrintWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Select any CheckPrintingData!");

            }
        }

        private async void delete_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(printingDTO != null)
                {
                    var resalt = MessageBox.Show("Do you want delete this checkPrint", "WARNING",
                        MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if(resalt == MessageBoxResult.Yes)
                    {
                        await _checkPrintService.DeleteCheckPrint(printingDTO.Id);
                        await GetAllCheckPrint();

                    }
                }
                else
                {
                    MessageBox.Show("Select any CheckPrintingData!");
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
