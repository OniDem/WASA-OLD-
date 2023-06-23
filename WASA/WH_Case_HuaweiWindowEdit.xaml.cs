using System;
using System.ComponentModel;
using System.Windows;
using WASA.Models;
using WASA.Services;
using WASA.Сomplementary;

namespace WASA
{
    /// <summary>
    /// Логика взаимодействия для WH_Case_HuaweiWindowEdit.xaml
    /// </summary>
    public partial class WH_Case_HuaweiWindowEdit : Window
    {
        private static GlobalData globalSettings = new GlobalData();
        private readonly string PATH = globalSettings.GetDataPath("Case_Huawei_Data.json");
        private readonly string TEMP_PATH = globalSettings.GetDataPath("Temp_Data.json");
        private BindingList<WareHouseModel> _wh_casedata, _wh_tempdata;
        private FileIOServiceWH_CaseEdit _fileIOServiceWH_CaseEdit, _fileIOServiceWH_Temp;

        public WH_Case_HuaweiWindowEdit()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dgWH_Manipulate.ItemsSource = _wh_tempdata;
            dgWH_Case.ItemsSource = _wh_casedata;
            _wh_casedata.ListChanged += _wh_Case_Data_ListChanged;
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            _fileIOServiceWH_CaseEdit = new FileIOServiceWH_CaseEdit(PATH);
            try
            {
                _wh_casedata = _fileIOServiceWH_CaseEdit.LoadDataWH_Case();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }

            _fileIOServiceWH_Temp = new FileIOServiceWH_CaseEdit(TEMP_PATH);
            try
            {
                _wh_tempdata = _fileIOServiceWH_Temp.LoadDataWH_Case();
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

        private void _wh_Case_Data_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.ItemDeleted || e.ListChangedType == ListChangedType.ItemChanged)
            {
                try
                {
                    _fileIOServiceWH_CaseEdit.SaveDataWH_Case(sender);
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
            WH_Case_HuaweiWindow wH_Case_HuaweiWindow = new WH_Case_HuaweiWindow();
            wH_Case_HuaweiWindow.Show();
            Close();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            _fileIOServiceWH_Temp.Search(_wh_tempdata, _wh_casedata);

        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            _fileIOServiceWH_Temp.Edit(_wh_casedata, _wh_tempdata);
        }
    }
}
