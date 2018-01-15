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
            try
            {
                object myNanny = this.SurnamecomboBox.SelectedValue;
                if (myNanny == null)
                    throw new Exception("you must choice nanny !!");



            }
            catch
            {

            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //if ((long.Parse(this.teoudatZeoutTextBox.Text)) % 8 >= 1)
                //    nanny.TeoudatZeout = long.Parse(this.teoudatZeoutTextBox.Text);
                //else
                //    throw new Exception ("the teoudat zeout is not avaible");
                //nanny.Surname = this.surnameTextBox.Text;
                //nanny.Firstname = this.firstnameTextBox.Text;

                bl.AddNanny(nanny);
                nanny = new Nanny(1);
                nanny = (Nanny)NannyDetailsGrid.DataContext;
                MessageBox.Show("Congratulation you have add nanny !\n ID :" + nanny.TeoudatZeout + " \n Name : " + nanny.Surname + "  " + nanny.Firstname);

                //this.teoudatZeoutTextBox.ClearValue(TextBlock.TextProperty);
                //this.surnameTextBox.ClearValue(TextBlock.TextProperty);
                //this.firstnameTextBox.ClearValue(TextBlock.TextProperty);
            }
            catch (FormatException)
            {
                MessageBox.Show("check your input and try again");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
