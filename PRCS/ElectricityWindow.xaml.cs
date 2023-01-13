using LiveCharts;
using LiveCharts.Wpf;
using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Reflection.Metadata;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace PRCS
{
    /// <summary>
    /// Interaction logic for ElectricityWindow.xaml
    /// </summary>
    public partial class ElectricityWindow : Window
    {
        public static ObservableCollection<Electricity> items { get; set; }

        double costOfelectricity = 6.979;

        public ElectricityWindow()
        {
            InitializeComponent();
            items = new ObservableCollection<Electricity>();
        }

        private void AdditionButton_Click(object sender, RoutedEventArgs e)
        {

            try {
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
            catch(Exception ex)
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
            catch { 
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
