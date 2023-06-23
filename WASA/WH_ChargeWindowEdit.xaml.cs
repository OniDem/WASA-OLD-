using System;
using System.ComponentModel;
using System.Windows;
using WASA.Models;
using WASA.Services;
using WASA.Сomplementary;

namespace WASA
{
    /// <summary>
    /// Логика взаимодействия для WH_ChargeWindowEdit.xaml
    /// </summary>
    public partial class WH_ChargeWindowEdit : Window
    {
        private static GlobalData globalSettings = new GlobalData();
        private readonly string PATH = globalSettings.GetDataPath("Charge_Data.json");
        private readonly string TEMP_PATH = globalSettings.GetDataPath("Temp_Data.json");
        private BindingList<WareHouseModel> _wh_chargedata, _wh_tempdata;
        private FileIOServiceWH_ChargeEdit _fileIOServiceWH_ChargeEdit, _fileIOServiceWH_Temp;
        

        public WH_ChargeWindowEdit()
        {
            InitializeComponent();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dgWH_Manipulate.ItemsSource = _wh_tempdata;
            dgWH_Charge.ItemsSource = _wh_chargedata;
            _wh_chargedata.ListChanged += _wh_Charge_DataEdit_ListChanged;
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            _fileIOServiceWH_ChargeEdit = new FileIOServiceWH_ChargeEdit(PATH);
            try
            {
                _wh_chargedata = _fileIOServiceWH_ChargeEdit.LoadDataWH_ChargeEdit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }

            _fileIOServiceWH_Temp = new FileIOServiceWH_ChargeEdit(TEMP_PATH);
            try
            {
                _wh_tempdata = _fileIOServiceWH_Temp.LoadDataWH_ChargeEdit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }

            ClockTimer clock = new ClockTimer(d => UserUI_Label_RealTime.Content = d.ToString("HH:mm:ss"));
            clock.Start();
            UserUI_Label_Date.Content = globalSettings.Date;
            UserUI_Label_Day_Of_Week.Content = globalSettings.Day_Of_Week;

        }

        private void _wh_Charge_DataEdit_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.ItemDeleted || e.ListChangedType == ListChangedType.ItemChanged)
            {
                try
                {
                    _fileIOServiceWH_ChargeEdit.SaveDataWH_ChargeEdit(sender);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Close();
                }
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            WH_MainWindow wareHouse = new WH_MainWindow();
            wareHouse.Show();
            Close();
        }
        private void Search_Click(object sender, RoutedEventArgs e)
        {
            _fileIOServiceWH_Temp.Search(_wh_tempdata, _wh_chargedata);

        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            _fileIOServiceWH_Temp.Edit(_wh_chargedata, _wh_tempdata);
        }
    }
}
