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
    /// Interaction logic for AddMother.xaml
    /// </summary>
    public partial class AddMother : Window
    {
        IBL bl;
        Mother myMother;
        public AddMother()
        {
            InitializeComponent();
            myMother = new Mother(0);
            this.MotherDetailGrid.DataContext = myMother;
            bl = Factory_BL.GetBL();

        }

     

        private void AddMotherButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((int.Parse(this.teoudatZeoutTextBox.Text)) / 10000000 >= 1)
                    myMother.TeoudatZeout = int.Parse(this.teoudatZeoutTextBox.Text);
                else
                    throw new Exception("the teoudat zeout is not avaible");
                this.Planning.InsertDataInObject(myMother.DaysNeeds, myMother.HouresNeeds);

                bl.AddMother(myMother);

                System.Windows.MessageBox.Show("Congratulation you have add Mother !\n " + myMother);
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
