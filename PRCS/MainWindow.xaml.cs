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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PRCS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void WaterButton_Click(object sender, RoutedEventArgs e)
        {
            WaterWindow waterWindow = new WaterWindow();
            waterWindow.Show();
        }

        private void ElectricityButton_Click(object sender, RoutedEventArgs e)
        {
            ElectricityWindow electricityWindow= new ElectricityWindow();
            electricityWindow.Show();
        }

        private void GasButton_Click(object sender, RoutedEventArgs e)
        {
            GasWindow gasWindow = new GasWindow();
            gasWindow.Show();
        }
    }
}
