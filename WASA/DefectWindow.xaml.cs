using System;
using System.ComponentModel;
using System.Windows;
using WASA.Models;
using WASA.Services;
using WASA.Сomplementary;

namespace WASA
{
    /// <summary>
    /// Логика взаимодействия для DefectWindow.xaml
    /// </summary>
    public partial class DefectWindow : Window
    {
        private static GlobalData globalSettings = new GlobalData();
        private BindingList<DefectModel> _defectdata;
        private FileIOServiceDefect _fileIOServicedefect;

        public DefectWindow()
        {
            InitializeComponent();
        }
        

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dgdefect.ItemsSource = _defectdata;
            _defectdata.ListChanged += _defectdata_ListChanged;
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            string PATH = globalSettings.GetPath("defect_data.json");
            _fileIOServicedefect = new FileIOServiceDefect(PATH);
            try
            {
                _defectdata = _fileIOServicedefect.LoadDataDefect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            ClockTimer clock = new ClockTimer(d => UserUI_Label_RealTime.Content = d.ToString("HH:mm:ss"));
            clock.Start();
            UserUI_Label_Date.Content = globalSettings.Date;
            UserUI_Label_Day_Of_Week.Content = globalSettings.Day_Of_Week;

        }


        private void _defectdata_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.ItemDeleted || e.ListChangedType == ListChangedType.ItemChanged)
            {
                try
                {
                    _fileIOServicedefect.SaveDataDefect(sender);
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
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void YouSure_Click(object sender, RoutedEventArgs e)
        {
            string PATH = globalSettings.GetPath("defect_data.json");
            _fileIOServicedefect = new FileIOServiceDefect(PATH);
            _fileIOServicedefect.DeleteDataDefect();
            DefectWindow defectWindow = new DefectWindow();
            defectWindow.Show();
            Close();
        }
    }
}
