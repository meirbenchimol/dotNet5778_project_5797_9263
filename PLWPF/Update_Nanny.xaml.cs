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
using BE;
using BL;

namespace PLWPF
{
    /// <summary>
    /// Logique d'interaction pour Update_Nanny.xaml
    /// </summary>
    public partial class Update_Nanny : Window
    {
        IBL bl;
        public Update_Nanny()
        {
            InitializeComponent();
            bl = Factory_BL.GetBL();

            SurnamecomboBox.ItemsSource = bl.GetAllNanny(null);
            SurnamecomboBox.SelectedValuePath = "TeoudatZeout";
            SurnamecomboBox.DisplayMemberPath = "Surname";

            FirstnameComboBox.ItemsSource = bl.GetAllNanny(null);
            FirstnameComboBox.SelectedValuePath = "TeoudatZeout";
            FirstnameComboBox.DisplayMemberPath = "Firstname";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource nannyViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("nannyViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // nannyViewSource.Source = [generic data source]
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
