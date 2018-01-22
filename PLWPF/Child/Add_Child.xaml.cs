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
    /// Interaction logic for Add_Child.xaml
    /// </summary>
    public partial class Add_Child : Window
    {
        IBL bl;
        Child myChild;
        public Add_Child()
        {
            InitializeComponent();
            bl = Factory_BL.GetBL();
            myChild = new Child(0, 11133333);
            this.ChidrenDetailGrid.DataContext = myChild;


            IdMomComboBox.ItemsSource = bl.GetAllMother(null);
            IdMomComboBox.SelectedValuePath = "TeoudatZeout";
            IdMomComboBox.DisplayMemberPath = "TeoudatZeout";

            this.genderChildComboBox.ItemsSource = Enum.GetValues(typeof(BE.Gender));




        }
        private int GetSelectedId()
        {
            object result = this.IdMomComboBox.SelectedValue;

            if (result == null)
                throw new Exception("you must choice Mother !!");
            return (int)result;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource childViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("childViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // childViewSource.Source = [generic data source]
        }

        private void AddChildButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((int.Parse(this.teoudatZeoutTextBox.Text)) / 10000000 >= 1)
                    myChild.TeoudatZeout = int.Parse(this.teoudatZeoutTextBox.Text);
                else
                    throw new Exception("the teoudat zeout is not avaible");

                myChild.TeoudatZeoutMom = GetSelectedId();
                bl.AddChild(myChild);

                MessageBox.Show("Congratulation you have add Children !\n ID :" + myChild.TeoudatZeout + " \n Mother'ID :  " + myChild.TeoudatZeoutMom + " \n Name :  " + myChild.Firstname);
                //myChild = new Child(0, 11133333);
                //ChidrenDetailGrid.DataContext = myChild;
                this.Close();

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
