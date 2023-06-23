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
    /// Логика взаимодействия для WH_Choice_CaseWindow.xaml
    /// </summary>
    public partial class WH_Case_ChoiceWindow : Window
    {
        public WH_Case_ChoiceWindow()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            WH_MainWindow wareHouse = new WH_MainWindow();
            wareHouse.Show();
            Close();
        }

        private void Samsung_Click(object sender, RoutedEventArgs e)
        {
            WH_Case_SamsungWindow wH_Case_SamsungWindow = new WH_Case_SamsungWindow();
            wH_Case_SamsungWindow.Show();
            Close();
        }

        private void Huawei_Click(object sender, RoutedEventArgs e)
        {
            WH_Case_HuaweiWindow wH_Case_HuaweiWindow = new WH_Case_HuaweiWindow();
            wH_Case_HuaweiWindow.Show();
            Close();
        }

        private void Xiaomi_Click(object sender, RoutedEventArgs e)
        {
            WH_Case_XiaomiWindow wH_Case_XiaomiWindow = new WH_Case_XiaomiWindow();
            wH_Case_XiaomiWindow.Show();
            Close();
        }

        private void IPhone_Click(object sender, RoutedEventArgs e)
        {
            WH_Case_IPhoneWindow wH_Case_IPhoneWindow = new WH_Case_IPhoneWindow();
            wH_Case_IPhoneWindow.Show();
            Close();
        }

        private void Realme_Click(object sender, RoutedEventArgs e)
        {
            WH_Case_RealmeWindow wH_Case_RealmeWindow = new WH_Case_RealmeWindow();
            wH_Case_RealmeWindow.Show();
            Close();
        }
    }
}
