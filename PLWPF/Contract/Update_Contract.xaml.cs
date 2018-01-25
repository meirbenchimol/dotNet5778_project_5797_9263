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
using System.ComponentModel;


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
        Mother mom;
        BackgroundWorker worker;

        public Update_Contract()
        {
            InitializeComponent();
            bl = Factory_BL.GetBL();
            myContract = new Contract(0, 0, 0);
            worker = new BackgroundWorker();
            worker.DoWork += Worker_DoWork;
            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
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

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                myContract.Distance = (int)e.Result;
                this.distanceTextBox.Text = e.Result.ToString();
                
            }
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (mom != null && myNanny != null)
                e.Result = bl.CalculateDistance(mom.Adresse, myNanny.Adresse);
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
                myChild = bl.GetChild(myContract.TeoudatZeoutChild);
                myNanny = bl.GetNanny(myContract.TeoudatZeoutNanny);

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
            mom = bl.GetMother(myChild.TeoudatZeoutMom);

            if (worker.IsBusy != true)
            {
                worker.RunWorkerAsync();
            }

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
