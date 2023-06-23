using System;
using System.ComponentModel;
using System.Windows;
using WASA.Models;
using WASA.Services;
using WASA.Сomplementary;

namespace WASA
{
    /// <summary>
    /// Логика взаимодействия для NewSell.xaml
    /// </summary>
    public partial class NewSell : Window
    {

        private static GlobalData globalSettings = new GlobalData();
        private BindingList<NewSellModel> _selldata;
        private FileIOServiceNewSell _fileIOServiceNewSell = new FileIOServiceNewSell();

        public NewSell()
        {
            InitializeComponent();
            _selldata = _fileIOServiceNewSell.LoadDataSell();
            dgsell.ItemsSource = _selldata;
            _selldata.ListChanged += _selldata_ListChanged;
            tb_Cash_Accouting.Text = _fileIOServiceNewSell.Cash_Accouting(_selldata);
            tb_Acquiring_Accouting.Text = _fileIOServiceNewSell.Acquiring_Accouting(_selldata);
            tb_All_Accouting.Text = _fileIOServiceNewSell.All_Accouting(_selldata);
            tb_Payments.Text = _fileIOServiceNewSell.Payments();
        }

       

        private void Window_Activated(object sender, EventArgs e)
        {
           
            
            

            ClockTimer clock = new ClockTimer(d => UserUI_Label_RealTime.Content = d.ToString("HH:mm:ss"));
            clock.Start();
            Title = "Смена №" + globalSettings.Day_Of_Year;
            UserUI_Label_Date.Content = globalSettings.Date;
            UserUI_Label_Day_Of_Week.Content = globalSettings.Day_Of_Week;
            
        }


        private void _selldata_ListChanged(object sender, ListChangedEventArgs e)
        {
            

            if (e.ListChangedType == ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.ItemDeleted || e.ListChangedType == ListChangedType.ItemChanged)
            {
                try
                {
                    _fileIOServiceNewSell.SaveDataSell(sender);
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
        private void CloseSell_Click(object sender, RoutedEventArgs e)
        {

            SuccefulCloseWindow succefulCloseWindow = new SuccefulCloseWindow();
            succefulCloseWindow.ShowDialog();

        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            NewSell newSell = new NewSell();
            newSell.Show();
            Close();
        }

        
    }

}
