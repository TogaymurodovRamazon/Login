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
    /// Interaction logic for CheckPrintWindow.xaml
    /// </summary>
    public partial class CheckPrintWindow : Window
    {
        CheckPrintListWindow _checkPrintListWindow { get; set; }
        ICheckPrintService _checkPrintService { get; set; }

        long checkPrintId { get; set; } = 0;
        bool isDisabled { get; set; }=false;

        public CheckPrintWindow()
        {
            InitializeComponent();
        }

        public void SettVariables(CheckPrintListWindow checkPrintListWindow, ICheckPrintService checkPrintService)
        {
            _checkPrintListWindow = checkPrintListWindow;
            _checkPrintService = checkPrintService;
        }

        private async void Ok_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CheckPrintingDTO newPrintDTO = new CheckPrintingDTO()
                {
                    Header = header_tbx.Text,
                    Footer = footer_tbx.Text,
                    Printer =printer_tbx.Text,
                    Tara = tara_tbx.Text,
                    TIN = tin_tbx.Text

                };
                if(checkPrintId == 0)
                {
                    await _checkPrintService.CreateCheckPrint(newPrintDTO);
                }
                else
                {
                    await _checkPrintService.UpdateCheckPrint(checkPrintId, newPrintDTO);
                }
                await _checkPrintListWindow.GetAllCheckPrint();
                ClearCheck();
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cansel_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void ClearCheck()
        {
            header_tbx.Text = "";
            footer_tbx.Text = "";
            printer_tbx.Text = "";
            tara_tbx.Text = "";
            tin_tbx.Text = "";
        }

        public void DisableForm(bool isReadOnly)
        {
            header_tbx.IsReadOnly = isReadOnly;
            footer_tbx.IsReadOnly=isReadOnly;
            printer_tbx.IsReadOnly=isReadOnly;
            tara_tbx.IsReadOnly=isReadOnly;
            tin_tbx.IsReadOnly=isReadOnly;
            Ok_btn.Visibility=  isReadOnly ? Visibility.Hidden : Visibility.Visible;
        }

        public async void SetCheckPrint(long Id, bool isView=false)
        {
            if(Id > 0)
            {
                DisableForm(isView);
                checkPrintId=Id;
                var printing = await _checkPrintService.GetAllCheckPrintById(Id);
                if(printing != null)
                {
                    header_tbx.Text = printing.Header;
                    footer_tbx.Text = printing.Footer;
                    printer_tbx.Text= printing.Printer;
                    tara_tbx.Text = printing.Tara;
                    tin_tbx.Text = printing.TIN;
                }
            }
        }
    }
}
