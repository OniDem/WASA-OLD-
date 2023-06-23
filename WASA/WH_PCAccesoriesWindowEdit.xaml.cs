using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using WASA.Models;
using WASA.Services;
using WASA.Сomplementary;

namespace WASA
{
    /// <summary>
    /// Логика взаимодействия для WH_PCAccesoriesWindowEdit.xaml
    /// </summary>
    public partial class WH_PCAccesoriesWindowEdit : Window
    {
        private static GlobalData globalSettings = new GlobalData();
        private readonly string PATH = globalSettings.GetDataPath("PCAccesories_Data.json");
        private readonly string TEMP_PATH = globalSettings.GetDataPath("Temp_Data.json");
        private BindingList<WareHouseModel> _wh_pcaccesoriesdata, _wh_tempdata;
        private FileIOServiceWH_PCAccesoriesEdit _fileIOServiceWH_PCAccesoriesEdit, _fileIOServiceWH_Temp;

        public WH_PCAccesoriesWindowEdit()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dgWH_Manipulate.ItemsSource = _wh_tempdata;
            dgWH_PCAccesories.ItemsSource = _wh_pcaccesoriesdata;
            _wh_pcaccesoriesdata.ListChanged += _wh_PCAccesories_DataEdit_ListChanged;
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            _fileIOServiceWH_PCAccesoriesEdit = new FileIOServiceWH_PCAccesoriesEdit(PATH);
            try
            {
                _wh_pcaccesoriesdata = _fileIOServiceWH_PCAccesoriesEdit.LoadDataWH_PCAccesoriesEdit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }


            _fileIOServiceWH_Temp = new FileIOServiceWH_PCAccesoriesEdit(TEMP_PATH);
            try
            {
                _wh_tempdata = _fileIOServiceWH_Temp.LoadDataWH_PCAccesoriesEdit();
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

        private void _wh_PCAccesories_DataEdit_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.ItemDeleted || e.ListChangedType == ListChangedType.ItemChanged)
            {
                try
                {
                    _fileIOServiceWH_PCAccesoriesEdit.SaveDataWH_PCAccesoriesEdit(sender);
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
            _fileIOServiceWH_Temp.Search(_wh_tempdata, _wh_pcaccesoriesdata);

        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            _fileIOServiceWH_Temp.Edit(_wh_pcaccesoriesdata, _wh_tempdata);
        }
    }
}
