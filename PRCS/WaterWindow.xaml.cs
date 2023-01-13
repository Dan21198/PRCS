using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
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
    /// Interaction logic for WaterWindow.xaml
    /// </summary>
    public partial class WaterWindow : Window
    {
        public static ObservableCollection<Electricity> items { get; set; }

        double costOfelectricity = 97.76 ;

        public WaterWindow()
        {
            InitializeComponent();
            if (File.Exists("W.json") && new FileInfo("W.json").Length != 0)
            {
                string fileName = "W.json";
                string jsonString = File.ReadAllText(fileName);
                items = JsonSerializer.Deserialize<ObservableCollection<Electricity>>(jsonString)!;
                listView.ItemsSource = items;
                listView.Items.Refresh();
            }
            else
            {
                items = new ObservableCollection<Electricity>();
            }
        }

        private async void AdditionButton_Click(object sender, RoutedEventArgs e)
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

                string fileName = "W.json";
                using FileStream createStream = File.Create(fileName);
                await JsonSerializer.SerializeAsync(createStream, items);
                await createStream.DisposeAsync();

                listView.ItemsSource = items;
                listView.Items.Refresh();
            }
            catch (Exception ex)
            {

            }


        }
        private async void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var delete = listView.SelectedItems.Cast<Electricity>().FirstOrDefault();
                if (delete != null)
                {
                    ((ObservableCollection<Electricity>)listView.ItemsSource).Remove(delete);

                    string fileName = "W.json";
                    using FileStream createStream = File.Create(fileName);
                    await JsonSerializer.SerializeAsync(createStream, items);
                    await createStream.DisposeAsync();
                }
                listView.Items.Refresh();
            }
            catch
            {
            }
        }

        private async void UpdatenButton_Click(object sender, RoutedEventArgs e)
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

                    File.Delete("W.json");
                    string fileName = "W.json";
                    using FileStream createStream = File.Create(fileName);
                    await JsonSerializer.SerializeAsync(createStream, items);
                    await createStream.DisposeAsync();
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
            WaterGraphWindow waterGraph = new WaterGraphWindow();
            waterGraph.Show();
        }
    }
}
