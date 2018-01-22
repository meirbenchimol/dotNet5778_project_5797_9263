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
using Xceed.Wpf.Toolkit;

namespace PLWPF
{
    /// <summary>
    /// Logique d'interaction pour Update_Nanny.xaml
    /// </summary>
    public partial class Update_Nanny : Window
    {
        IBL bl;
        Nanny myNanny;
        public Update_Nanny()
        {
            InitializeComponent();
            bl = Factory_BL.GetBL();

            IdComboBox.ItemsSource = bl.GetAllNanny(null);
            IdComboBox.SelectedValuePath = "TeoudatZeout";
            IdComboBox.DisplayMemberPath = "TeoudatZeout";




        }
        private void ValidNanny_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                myNanny = bl.GetNanny(GetSelectedId());
                this.Planning.InsertDataFromObject(myNanny.DaysWorking, myNanny.HoursWorking);

                this.NannyDetailsGrid.DataContext = myNanny;

            }
            catch (FormatException)
            {
                System.Windows.MessageBox.Show("check your input and try again");
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource nannyViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("nannyViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // nannyViewSource.Source = [generic data source]
        }

        private int GetSelectedId()
        {
            object result = this.IdComboBox.SelectedValue;

            if (result == null)
                throw new Exception("you must choice nanny !!");
            return (int)result;
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                this.Planning.InsertDataInObject(myNanny.DaysWorking, myNanny.HoursWorking);

                bl.UpdateNanny(myNanny);
                System.Windows.MessageBox.Show("Congratulation you have update nanny !\n ID :" + myNanny.TeoudatZeout + " \n Name : " + myNanny.Surname + "  " + myNanny.Firstname);
                this.Close();

            }
            catch (FormatException)
            {
                System.Windows.MessageBox.Show("check your input and try again");
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                

                bl.DeleteNanny(myNanny.TeoudatZeout);
                System.Windows.MessageBox.Show("Congratulation you have delete nanny !\n ID :" + myNanny.TeoudatZeout + " \n Name : " + myNanny.Surname + "  " + myNanny.Firstname);
                this.Close();
                
                
            }
            catch (FormatException)
            {
                System.Windows.MessageBox.Show("check your input and try again");
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }

       
    }
}
