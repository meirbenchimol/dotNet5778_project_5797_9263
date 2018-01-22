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
    /// Interaction logic for Update_Contract.xaml
    /// </summary>
    public partial class Update_Contract : Window
    {
        IBL bl;
        Contract myContract;
        Nanny myNanny;
        Child myChild;
        public Update_Contract()
        {
            InitializeComponent();
            bl = Factory_BL.GetBL();
            myContract = new Contract(0, 0, 0);

            this.ContractDetailGrid.DataContext = myContract;

            contractNumberComboBox.ItemsSource = bl.GetAllContract(null);
            contractNumberComboBox.SelectedValuePath = "ContractNumber";
            contractNumberComboBox.DisplayMemberPath = "ContractNumber";

            teoudatZeoutNannyComboBox.ItemsSource = bl.GetAllNanny(null);
            teoudatZeoutNannyComboBox.SelectedValuePath = "TeoudatZeout";
            teoudatZeoutNannyComboBox.DisplayMemberPath = "TeoudatZeout";

            teoudatZeoutChildComboBox.ItemsSource = bl.ChildWithoutNanny();
            teoudatZeoutChildComboBox.SelectedValuePath = "TeoudatZeout";
            teoudatZeoutChildComboBox.DisplayMemberPath = "TeoudatZeout";

            this.payementComboBox.ItemsSource = Enum.GetValues(typeof(BE.Payement));
        }

        private int GetSelectedContractNumber()
        {
            object result = this.contractNumberComboBox.SelectedValue;

            if (result == null)
                throw new Exception("you must choice Mother !!");
            return (int)result;
        }
        private int GetSelectedIdNanny()
        {
            object result = this.teoudatZeoutNannyComboBox.SelectedValue;

            if (result == null)
                throw new Exception("you must choice Mother !!");
            return (int)result;
        }
        private int GetSelectedIdChild()
        {
            object result = this.teoudatZeoutChildComboBox.SelectedValue;

            if (result == null)
                throw new Exception("you must choice Mother !!");
            return (int)result;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource contractViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("contractViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // contractViewSource.Source = [generic data source]
        }

        private void ValidContractbutton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                myContract = bl.GetContract(GetSelectedContractNumber());

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

        private void ValidChildrenButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                myChild = bl.GetChild(GetSelectedIdChild());
                myContract.TeoudatZeoutChild = myChild.TeoudatZeout;

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

        private void ValidNannyButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                myNanny = bl.GetNanny(GetSelectedIdNanny());
                myContract.TeoudatZeoutNanny = myNanny.TeoudatZeout;

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

        private void RecalculeDistanceButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            
            bl.UpdateContract(myContract);
            
            MessageBox.Show("Congratulation !! \n You have update the contract n: " + myContract);
            this.Close();

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

            bl.DeleteContract(myContract.ContractNumber);
            MessageBox.Show("Congratulation !! \n You have add the contract n: " + myContract);
            this.Close();
        }
    }
}
