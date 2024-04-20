using Login.Common.DTO;
using Login.Service;
using Login.Windows;
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

namespace Login.Pages
{
    /// <summary>
    /// Interaction logic for ClientWindow.xaml
    /// </summary>
    public partial class ClientWindow : Window
    {
        ClientListController _clientListController { get; set; }
        IClientService _clientService { get; set; }
        long ClientId { get; set; } = 0;
        bool isDisabled { get; set; }=false;
        public ClientWindow()
        {
            InitializeComponent();
        }
        public void SetVariables(ClientListController clientListController, IClientService clientService)
        {
            _clientListController = clientListController;
            _clientService = clientService;
        }

        private async void Ok_btn_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    CheckPrintingDTO newPrintDTO = new CheckPrintingDTO()
            //    {
            //        Header = header_tbx.Text,
            //        Footer = footer_tbx.Text,
            //        Printer = printer_tbx.Text,
            //        Tara = tara_tbx.Text,
            //        TIN = tin_tbx.Text

            //    };
            //    if (checkPrintId == 0)
            //    {
            //        await _checkPrintService.CreateCheckPrint(newPrintDTO);
            //    }
            //    else
            //    {
            //        await _checkPrintService.UpdateCheckPrint(checkPrintId, newPrintDTO);
            //    }
            //    await _checkPrintListWindow.GetAllCheckPrint();
            //    ClearCheck();
            //    this.Close();

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            try
            {
                ClinetDTO clinetDTO = new ClinetDTO()
                {
                    FirstName = firstname_tbx.Text,
                    LastName = lastname_tbx.Text,
                    FatherName = fathername_tbx.Text,
                    BornDate = borndate_picker.SelectedDate.Value,
                    PhoneNumber = phonenumber_tbx.Text,
                    Addres = addres_tbx.Text,
                };
                if (ClientId == 0)
                {
                    await _clientService.CreateClient(clinetDTO);

                }
                else
                {
                    await _clientService.UpdateClient(ClientId, clinetDTO);
                }
                //await _clientListController
                ClearClient();
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
        public void ClearClient()
        {
            firstname_tbx.Text = "";
            lastname_tbx.Text = "";
            fathername_tbx.Text = "";
            borndate_picker.Text = "";
            phonenumber_tbx.Text = "";
            addres_tbx.Text = "";
        }
        public async void SetClient(long Id, bool isView = false)
        {
            if (Id > 0)
            {
                DisableForm(isView);
                ClientId= Id;
                var clint = await _clientService.GetAllById(Id);
                if(clint != null)
                {
                    firstname_tbx.Text = clint.FirstName;
                    lastname_tbx.Text= clint.LastName;
                    fathername_tbx.Text=clint.FatherName;
                    borndate_picker.SelectedDate = clint.BornDate;
                    phonenumber_tbx.Text = clint.PhoneNumber;
                    addres_tbx.Text = clint.Addres;
                }
            }
        }
        public void DisableForm(bool isReadOnly)
        {
            firstname_tbx.IsReadOnly = isReadOnly;
            lastname_tbx.IsReadOnly= isReadOnly;
            fathername_tbx.IsReadOnly=isReadOnly;
            borndate_picker.IsEnabled=isReadOnly;
            phonenumber_tbx.IsReadOnly=isReadOnly;
            addres_tbx.IsReadOnly=isReadOnly;
            Ok_btn.Visibility = isReadOnly ? Visibility.Hidden : Visibility.Visible;

        }
    }
}
