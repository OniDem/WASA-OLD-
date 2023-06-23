﻿using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using WASA.Models;
using WASA.Services;
using WASA.Сomplementary;

namespace WASA
{
    /// <summary>
    /// Логика взаимодействия для WH_PCAccesoriesWindow.xaml
    /// </summary>
    public partial class WH_PCAccesoriesWindow : Window
    {
        private static GlobalData globalData = new GlobalData();
        private static FileIOService fileIOService = new FileIOService();
        private ObservableCollection<WareHouseModel> _warehouse_data = fileIOService.LoadObservableData(globalData.GetDataPath("PCAccesories_Data.json"));
        private BindingList<WareHouseModel> _tempdata = fileIOService.LoadTempData();
        
       
        public WH_PCAccesoriesWindow()
        {
            InitializeComponent();
            DataGridManipulate.ItemsSource = _tempdata;
            DataGridWareHouse.ItemsSource = _warehouse_data;
            ClockTimer clock = new ClockTimer(d => UserUI_Label_RealTime.Content = d.ToString("HH:mm:ss"));
            clock.Start();
            UserUI_Label_Date.Content = globalData.Date;
            UserUI_Label_Day_Of_Week.Content = globalData.Day_Of_Week;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            WH_MainWindow wareHouse = new WH_MainWindow();
            wareHouse.Show();
            Close();
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            WH_PCAccesoriesWindowEdit wH_PCAccesoriesWindowEdit = new WH_PCAccesoriesWindowEdit();
            wH_PCAccesoriesWindowEdit.Show();
            Close();
        }
        private void Search_Click(object sender, RoutedEventArgs e)
        {
            fileIOService.Search(_tempdata, _warehouse_data);

        }
    }
}
