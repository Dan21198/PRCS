using LiveCharts.Wpf;
using LiveCharts;
using System;
using System.Collections;
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

namespace PRCS
{
    /// <summary>
    /// Interaction logic for WaterGraphWindow.xaml
    /// </summary>
    public partial class WaterGraphWindow : Window
    {
        private ArrayList graphValues = new ArrayList();
        public WaterGraphWindow()
        {
            InitializeComponent();
            DrawGraphs();
        }

        public void DrawGraphs()
        {
            foreach (var tmp in WaterWindow.items)
            {
                graphValues.Add(tmp.Value);
            }

            ColumnSeries mySeries = new ColumnSeries
            {

                Values = new ChartValues<double>()
            };


            for (int i = 0; i < graphValues.Count; i++)
            {
                mySeries.Values.Add((double)graphValues[i]);
            }

            myChart.Series.Add(mySeries);

        }

        private void myChart_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
