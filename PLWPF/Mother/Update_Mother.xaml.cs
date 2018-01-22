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
    /// Interaction logic for Update_Mother.xaml
    /// </summary>
    public partial class Update_Mother : Window
    {
        IBL bl;
        Mother myMother;
        public Update_Mother()
        {
            InitializeComponent();
            bl = Factory_BL.GetBL();

            IdComboBox.ItemsSource = bl.GetAllMother(null);
            IdComboBox.SelectedValuePath = "TeoudatZeout";
            IdComboBox.DisplayMemberPath = "TeoudatZeout";

        }

        private int GetSelectedId()
        {
            object result = this.IdComboBox.SelectedValue;

            if (result == null)
                throw new Exception("you must choice Mother !!");
            return (int)result;
        }
        private void ValidMother_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                myMother = bl.GetMother(GetSelectedId());
                this.Planning.InsertDataFromObject(myMother.DaysNeeds, myMother.HouresNeeds);

                this.GridMotherDetail.DataContext = myMother;

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


        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                this.Planning.InsertDataInObject(myMother.DaysNeeds, myMother.HouresNeeds);

                bl.UpdateMother(myMother);

                System.Windows.MessageBox.Show("Congratulation you have update Mother !\n ID :" + myMother.TeoudatZeout + " \n Name : " + myMother.Surname + "  " + myMother.Firstname);
             
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
                
                bl.DeleteMother(myMother.TeoudatZeout);

                System.Windows.MessageBox.Show("Congratulation you have delete Mother !\n ID :" + myMother.TeoudatZeout + " \n Name : " + myMother.Surname + "  " + myMother.Firstname);
               
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
