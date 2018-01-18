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
    /// Interaction logic for Update_child.xaml
    /// </summary>
    public partial class Update_child : Window
    {
        IBL bl;
        Child myChild;
        public Update_child()
        {
            InitializeComponent();

            bl = Factory_BL.GetBL();

            teoudatZeoutComboBox.ItemsSource = bl.GetAllChild(null);
            teoudatZeoutComboBox.SelectedValuePath = "TeoudatZeout";
            teoudatZeoutComboBox.DisplayMemberPath = "TeoudatZeout";

            IdMomComboBox.ItemsSource = bl.GetAllMother(null);
            IdMomComboBox.SelectedValuePath = "TeoudatZeout";
            IdMomComboBox.DisplayMemberPath = "TeoudatZeout";

            this.genderChildComboBox.ItemsSource = Enum.GetValues(typeof(BE.Gender));


        }

        private int GetSelectedId()
        {
            object result = this.teoudatZeoutComboBox.SelectedValue;

            if (result == null)
                throw new Exception("you must choice Mother !!");
            return (int)result;
        }
        private int GetSelectedIdmom()
        {
            object result = this.IdMomComboBox.SelectedValue;

            if (result == null)
                throw new Exception("you must choice Mother !!");
            return (int)result;
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                myChild = bl.GetChild(GetSelectedId());
                this.ChildrenDetailGrid.DataContext = myChild;

                myChild.TeoudatZeoutMom = GetSelectedIdmom();


                bl.UpdateChild(myChild);

                MessageBox.Show("Congratulation you have update Children !\n ID :" + myChild.TeoudatZeout +"\n Mother'ID : "+myChild.TeoudatZeoutMom+ " \n Name : " + myChild.Firstname );
                myChild = new Child(0, 11133333);
                ChildrenDetailGrid.DataContext = myChild;
                
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

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                myChild = bl.GetChild(GetSelectedId());
                this.ChildrenDetailGrid.DataContext = myChild;

                myChild.TeoudatZeoutMom = GetSelectedIdmom();


                bl.DeleteChild(myChild.TeoudatZeout);

                MessageBox.Show("Congratulation you have delete Children !\n ID :" + myChild.TeoudatZeout + "\n Mother'ID : " + myChild.TeoudatZeoutMom + " \n Name : " + myChild.Firstname);
                //myChild = new Child(0, 11133333);
                ChildrenDetailGrid.DataContext = null;

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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource childViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("childViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // childViewSource.Source = [generic data source]
        }
    }
}
