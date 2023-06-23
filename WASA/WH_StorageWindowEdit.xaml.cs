using System;
using System.ComponentModel;
using System.Windows;
using WASA.Models;
using WASA.Services;
using WASA.Сomplementary;

namespace WASA
{
    /// <summary>
    /// Логика взаимодействия для Wh_StorageWindowEdit.xaml
    /// </summary>
    public partial class Wh_StorageWindowEdit : Window
    {
        private static GlobalData globalSettings = new GlobalData();
        private readonly string PATH = globalSettings.GetDataPath("Storage_Data.json");
        private readonly string TEMP_PATH = globalSettings.GetDataPath("Temp_Data.json");
        private BindingList<WareHouseModel> _wh_storagedata, _wh_tempdata;
        private FileIOServiceWH_StorageEdit _fIleIOServiceWH_StorageEdit, _fileIOServiceWH_Temp;
        

        public Wh_StorageWindowEdit()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        { 

            dgWH_Manipulate.ItemsSource = _wh_tempdata;
            dgWH_Storage.ItemsSource = _wh_storagedata;
            _wh_storagedata.ListChanged += _wh_Storage_DataEdit_ListChanged;
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            _fIleIOServiceWH_StorageEdit = new FileIOServiceWH_StorageEdit(PATH);
            try
            {
                _wh_storagedata = _fIleIOServiceWH_StorageEdit.LoadDataWH_Storage();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }

            _fileIOServiceWH_Temp = new FileIOServiceWH_StorageEdit(TEMP_PATH);
            try
            {
                _wh_tempdata = _fileIOServiceWH_Temp.LoadDataWH_Storage();
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

        private void _wh_Storage_DataEdit_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.ItemDeleted || e.ListChangedType == ListChangedType.ItemChanged)
            {
                try
                {
                    _fIleIOServiceWH_StorageEdit.SaveDataWH_Storage(sender);
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
            _fileIOServiceWH_Temp.Search(_wh_tempdata, _wh_storagedata);

        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            _fileIOServiceWH_Temp.Edit(_wh_tempdata, _wh_storagedata);
        }
    }
}
