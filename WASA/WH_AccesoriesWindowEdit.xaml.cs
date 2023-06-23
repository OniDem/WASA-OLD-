using System;
using System.ComponentModel;
using System.Windows;
using WASA.Models;
using WASA.Services;
using WASA.Сomplementary;

namespace WASA
{
    /// <summary>
    /// Логика взаимодействия для WH_AccesoriesWindowEdit.xaml
    /// </summary>
    public partial class WH_AccesoriesWindowEdit : Window
    {
        private static GlobalData globalSettings = new GlobalData();
        private readonly string PATH = globalSettings.GetDataPath("Accesories_Data.json");
        private readonly string TEMP_PATH = globalSettings.GetDataPath("Temp_Data.json");
        private BindingList<WareHouseModel> _wh_accesoriesdata, _wh_tempdata;
        //private FileIOServiceAccesoriesEdit _fileIOServiceWH_AccesoriesEdit, _fileIOServiceWH_Temp;
        
        public WH_AccesoriesWindowEdit()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dgWH_Manipulate.ItemsSource = _wh_tempdata;
            dgWH_Accesories.ItemsSource = _wh_accesoriesdata;
            _wh_accesoriesdata.ListChanged += _wh_Accesories_Data_ListChanged;
        }

        private void Window_Activated(object sender, EventArgs e)
        {/*
            _fileIOServiceWH_AccesoriesEdit = new FileIOServiceAccesoriesEdit(PATH);
            try
            {
                _wh_accesoriesdata = _fileIOServiceWH_AccesoriesEdit.LoadDataWH_Accesories();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }

            _fileIOServiceWH_Temp = new FileIOServiceAccesoriesEdit(TEMP_PATH);
            try
            {
                _wh_tempdata = _fileIOServiceWH_Temp.LoadDataWH_Accesories();
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
            */
        }

        private void _wh_Accesories_Data_ListChanged(object sender, ListChangedEventArgs e)
        {/*
            if (e.ListChangedType == ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.ItemDeleted || e.ListChangedType == ListChangedType.ItemChanged)
            {
                try
                {
                    _fileIOServiceWH_AccesoriesEdit.SaveDataWH_Accesories(sender);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Close();
                }
            }*/
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            WH_MainWindow wareHouse = new WH_MainWindow();
            wareHouse.Show();
            Close();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            //_fileIOServiceWH_Temp.Search(_wh_tempdata, _wh_accesoriesdata);

        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            //_fileIOServiceWH_Temp.Edit(_wh_accesoriesdata, _wh_tempdata);
        }
    }
}
