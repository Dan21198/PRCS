using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for GasWindow.xaml
    /// </summary>
    public partial class GasWindow : Window
    {
        public static ObservableCollection<Electricity> items { get; set; }

        double costOfelectricity = 11.84;

        public GasWindow()
        {
            InitializeComponent();
            items = new ObservableCollection<Electricity>();
        }

        private void AdditionButton_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                string dateInput = DataPicker.Text;
                var parsedDate = DateTime.Parse(dateInput);

                Electricity electricity = new Electricity(parsedDate, double.Parse(ValueTextBox.Text), CommentTextBox.Text, costOfelectricity);
                electricity.Value = double.Parse(ValueTextBox.Text);
                electricity.Time = parsedDate;
                electricity.Comment = CommentTextBox.Text;
                electricity.Cost = electricity.Value * costOfelectricity;

                items.Add(electricity);

                listView.ItemsSource = items;
                listView.Items.Refresh();
            }
            catch (Exception ex)
            {

            }


        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var delete = listView.SelectedItems.Cast<Electricity>().FirstOrDefault();
                if (delete != null)
                {
                    ((ObservableCollection<Electricity>)listView.ItemsSource).Remove(delete);
                }
                listView.Items.Refresh();
            }
            catch
            {
            }
        }

        private void UpdatenButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string dateInput = DataPicker.Text;
                var parsedDate = DateTime.Parse(dateInput);

                var update = listView.SelectedItems.Cast<Electricity>().FirstOrDefault();
                if (update != null)
                {
                    update.Value = double.Parse(ValueTextBox.Text);
                    update.Time = parsedDate;
                    update.Comment = CommentTextBox.Text;
                    update.Cost = update.Value * costOfelectricity;
                }
                listView.Items.Refresh();

            }
            catch
            {
            }

        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DateTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ValueTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ElGraphWindow elGraphWindow = new ElGraphWindow();
            elGraphWindow.Show();
        }
    }
}

