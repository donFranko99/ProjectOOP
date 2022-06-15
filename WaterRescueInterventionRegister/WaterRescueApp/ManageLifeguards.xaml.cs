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
using WaterRescueDBConversion;

namespace WaterRescueApp
{
    /// <summary>
    /// Interaction logic for ManageLifeguards.xaml
    /// </summary>
    public partial class ManageLifeguards : Window
    {
        public ManageLifeguards()
        {
            InitializeComponent();
        }

        private void AddLifeguardButton_Click(object sender, RoutedEventArgs e)
        {
            InputData.AddLifeguard(InputName.Text,InputSurname.Text,InputPhonenumber.Text,InputRole.Text);
            this.Close();
        }

        private void LifeguardList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void IDRemoveComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void IDRemoveComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> tmp = new List<string>();
            using (var db = new WaterRescueContext())
            {
                foreach (Lifeguard lg in db.Lifeguards)
                {
                    tmp.Add(lg.ID.ToString());
                }
            }
            IDRemoveComboBox.ItemsSource = tmp;
        }

        private void RemoveLifeguardButton_Click(object sender, RoutedEventArgs e)
        {
            InputData.RemoveLifeguard(Int32.Parse(IDRemoveComboBox.SelectedItem.ToString()));
            this.Close();
        }
    }
}
