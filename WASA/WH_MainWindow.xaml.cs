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

namespace WASA
{
    /// <summary>
    /// Логика взаимодействия для WH_MainWindow.xaml
    /// </summary>
    public partial class WH_MainWindow : Window
    {
        public WH_MainWindow()
        {
            InitializeComponent();
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void WH_Case_Click(object sender, RoutedEventArgs e)
        {
            WH_Case_ChoiceWindow wH_Case_ChoiceWindow = new WH_Case_ChoiceWindow();
            wH_Case_ChoiceWindow.Show();
            Close();
        }

        private void WH_Headphones_Click(object sender, RoutedEventArgs e)
        {
            WH_HeadphonesWindow wH_HeadphonesWindow = new WH_HeadphonesWindow();
            wH_HeadphonesWindow.Show();
            Close();
        }

        private void WH_Storage_Click(object sender, RoutedEventArgs e)
        {
            WH_StorageWindow wH_StorageWindow = new WH_StorageWindow();
            wH_StorageWindow.Show();
            Close();
        }

        private void WH_Charge_Click(object sender, RoutedEventArgs e)
        {
            WH_ChargeWindow wh_ChargeWindow = new WH_ChargeWindow();
            wh_ChargeWindow.Show();
            Close();
        }

        private void WH_Audio_Click(object sender, RoutedEventArgs e)
        {
            WH_AudioWindow wH_AudioWindow = new WH_AudioWindow();
            wH_AudioWindow.Show();
            Close();
        }

        private void WH_Accesories_Click(object sender, RoutedEventArgs e)
        {
            WH_AccesoriesWindow wh_AccesoriesWindow = new WH_AccesoriesWindow();
            wh_AccesoriesWindow.Show();
            Close();
        }

        private void WH_PCAccesories_Click(object sender, RoutedEventArgs e)
        {
            WH_PCAccesoriesWindow wH_PCAccesoriesWindow = new WH_PCAccesoriesWindow();
            wH_PCAccesoriesWindow.Show();
            Close();
        }

        private void Cable_Click(object sender, RoutedEventArgs e)
        {
            WH_CableWindow wH_CableWindow = new WH_CableWindow();
            wH_CableWindow.Show();
            Close();
        }

        private void WH_Adapter_Click(object sender, RoutedEventArgs e)
        {
            WH_AdapterWindow wH_AdapterWindow = new WH_AdapterWindow();
            wH_AdapterWindow.Show();
            Close();
        }

        private void CarHolder_Click(object sender, RoutedEventArgs e)
        {
            WH_CarHolderWindow wH_CarHolderWindow = new WH_CarHolderWindow();
            wH_CarHolderWindow.Show();
            Close();
        }

        private void Battery_Click(object sender, RoutedEventArgs e)
        {
            WH_BatteryWindow wH_BatteryWindow = new WH_BatteryWindow();
            wH_BatteryWindow.Show();
            Close();
        }
    }
}
