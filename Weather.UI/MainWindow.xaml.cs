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
using Weather.Classes;
using Weather.Classes.Models;

namespace Weather.UI {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        WeathRepository weatherRepo = new WeathRepository();
        LocRepository locationRepo = new LocRepository();

        public MainWindow() {
            InitializeComponent();
            comboBoxLocations.ItemsSource = locationRepo.Locations;
        }

        private void comboBoxLocations_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            var location = comboBoxLocations.SelectedItem as Location;

            listBoxWeather.ItemsSource = location != null ? weatherRepo.GetWeatherForLocation(location.Id) : null;
        }
    }
}
