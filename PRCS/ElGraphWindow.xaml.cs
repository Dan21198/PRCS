using LiveCharts.Wpf;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
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
using System.Collections.ObjectModel;
using System.Collections;

namespace PRCS
{
    /// <summary>
    /// Interaction logic for ElGraphWindow.xaml
    /// </summary>
    public partial class ElGraphWindow : Window
    {
        private ArrayList graphValues = new ArrayList();
        public ElGraphWindow()
        {
            InitializeComponent();
            DrawGraphs();
        }
        public void DrawGraphs()
        {
            foreach (var tmp in ElectricityWindow.items)
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

        private void ElGraphWindow_Load(object sender, EventArgs e)
        {
            
        }
    }
}
