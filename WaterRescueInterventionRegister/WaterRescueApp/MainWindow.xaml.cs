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
using WaterRescueDBConversion;

namespace WaterRescueApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Lifeguard> Lifeguards { get; set; } = DataFromDB.GetLifeguards();
        public List<Report> Reports { get; set; } = DataFromDB.GetReports();
        public List<Intervention> Interventions { get; set; } = DataFromDB.GetInterventions();
        public List<Role> Roles { get; set; } = DataFromDB.GetRoles();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void DataButtonLifeguards_Click(object sender, RoutedEventArgs e)
        {
            DataGridReports.Visibility = Visibility.Hidden;
            DataGridInterventions.Visibility = Visibility.Hidden;
            DataGridLifeguard.Visibility = Visibility.Visible;
        }

        private void DataButtonReports_Click(object sender, RoutedEventArgs e)
        {
            DataGridLifeguard.Visibility = Visibility.Hidden;
            DataGridInterventions.Visibility = Visibility.Hidden;
            DataGridReports.Visibility = Visibility.Visible;
        }

        private void DataButtonInterventions_Click(object sender, RoutedEventArgs e)
        {
            DataGridReports.Visibility = Visibility.Hidden;
            DataGridLifeguard.Visibility = Visibility.Hidden;
            DataGridInterventions.Visibility = Visibility.Visible;
        }

        private void LifeguardWindowButton_Click(object sender, RoutedEventArgs e)
        {
            ManageLifeguards manageLifeguards = new ManageLifeguards();
            manageLifeguards.ShowDialog();
            Refresh();
        }

        private void ReportWindowButton_Click(object sender, RoutedEventArgs e)
        {
            ManageReports manageReports = new ManageReports();
            manageReports.ShowDialog();
            Refresh();
        }

        private void InterventionWindowButton_Click(object sender, RoutedEventArgs e)
        {
            ManageInterventions manageInterventions = new ManageInterventions();
            manageInterventions.ShowDialog();
            Refresh();
        }

        public void Refresh()
        {
            DataGridLifeguard.ItemsSource = null;
            DataGridReports.ItemsSource = null;
            DataGridInterventions.ItemsSource = null;
            Lifeguards = DataFromDB.GetLifeguards();
            Reports = DataFromDB.GetReports();
            Interventions = DataFromDB.GetInterventions();
            DataGridLifeguard.ItemsSource = Lifeguards;
            DataGridReports.ItemsSource = Reports;
            DataGridInterventions.ItemsSource = Interventions;
        }
    }
}
        /*
public void Refresh()
{
categoryDataGrid.ItemsSource = null;
Pacjenci = Data.GetPacjents();
categoryDataGrid.ItemsSource = Pacjenci;

WypisDataGrid.ItemsSource = null;
Wypisy = Data.GetWypis();
WypisDataGrid.ItemsSource = Wypisy;

RozpoznanieDataGrid.ItemsSource = null;
Rozpoznania = Data.GetRozpoznianie();
RozpoznanieDataGrid.ItemsSource = Rozpoznania;
}
*/

