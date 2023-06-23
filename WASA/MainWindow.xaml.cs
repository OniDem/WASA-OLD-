
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WASA
{
    
    public partial class MainWindow : Window
    {


        public MainWindow()
        {
            InitializeComponent();
        }
        
        

        private void NewSell_Click(object sender, RoutedEventArgs e)
        {
            NewSell newSell = new NewSell();
            newSell.Show();
            Close();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void WareHouse_Click(object sender, RoutedEventArgs e)
        {
            WH_MainWindow wH_mainWindow  = new WH_MainWindow();
            wH_mainWindow.Show();
            Close();
        }

        private void Defect_Click(object sender, RoutedEventArgs e)
        {
            DefectWindow defectWindow = new DefectWindow();
            defectWindow.Show();
            Close();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
