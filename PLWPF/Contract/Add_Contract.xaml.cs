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
using System.Threading;
using System.ComponentModel;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for Add_Contract.xaml
    /// </summary>
    public partial class Add_Contract : Window
    {
        IBL bl;
        Contract myContract;
        Nanny myNanny;
        Child myChildren;
        BackgroundWorker worker;
        Mother mom;
        public Add_Contract()
        {
            InitializeComponent();
            bl = Factory_BL.GetBL();
            myContract = new Contract(0, 0, 0);
            worker = new BackgroundWorker();
            worker.DoWork += Worker_DoWork;
            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
            this.ContractDedailGrid.DataContext = myContract;
            

            teoudatZeoutNannyComboBox.ItemsSource = bl.GetAllNanny(null);
            teoudatZeoutNannyComboBox.SelectedValuePath = "TeoudatZeout";
            teoudatZeoutNannyComboBox.DisplayMemberPath = "TeoudatZeout";

            teoudatZeoutChildComboBox.ItemsSource = bl.ChildWithoutNanny();
            teoudatZeoutChildComboBox.SelectedValuePath = "TeoudatZeout";
            teoudatZeoutChildComboBox.DisplayMemberPath = "TeoudatZeout";


            
            this.payementComboBox.ItemsSource = Enum.GetValues(typeof(BE.Payement));

        
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e )
        {
            if(e.Result!=null)
            {
                myContract.Distance = (int) e.Result;
                this.distanceTextBox.Text = e.Result.ToString();
            }
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e )
        {
            if (mom != null && myNanny != null)
            {
                e.Result = bl.CalculateDistance(mom.Adresse, myNanny.Adresse);
            }
        }

        private int GetSelectedIdNanny(object result)
        {
            //object result = this.teoudatZeoutNannyComboBox.SelectedValue;

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

        private void ValidNannyButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (GetSelectedIdNanny(this.teoudatZeoutNannyComboBox.SelectedValue)!=0)
                myNanny = bl.GetNanny(GetSelectedIdNanny(this.teoudatZeoutNannyComboBox.SelectedValue));

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

        private void ValidChildrenButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                myChildren = bl.GetChild(GetSelectedIdChild());
                myContract.TeoudatZeoutChild = myChildren.TeoudatZeout;


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

        private void CalculeDistanceButton_Click(object sender, RoutedEventArgs e)
        {
             mom = bl.GetMother(myChildren.TeoudatZeoutMom);

           if(worker.IsBusy!=true)
            {
                worker.RunWorkerAsync();
            }

        }

        private void HelpButton_Click(object sender, RoutedEventArgs e)
        {
            mom = bl.GetMother(myChildren.TeoudatZeoutMom);


            CorrespondNannyComboBox.ItemsSource = bl.CoordinationMother(mom);
            CorrespondNannyComboBox.SelectedValuePath = "TeoudatZeout";
            CorrespondNannyComboBox.DisplayMemberPath = "TeoudatZeout";

            PotentialNannyComboBox.ItemsSource = bl.LessPotentielNanny(mom);
            PotentialNannyComboBox.SelectedValuePath = "TeoudatZeout";
            PotentialNannyComboBox.DisplayMemberPath = "TeoudatZeout";

            AccessibleNannyComboBox.ItemsSource = bl.AccessibleNanny(mom);
            AccessibleNannyComboBox.SelectedValuePath = "TeoudatZeout";
            AccessibleNannyComboBox.DisplayMemberPath = "TeoudatZeout";

        }

        private void AddContractButton_Click(object sender, RoutedEventArgs e)
        {
            //if( myContract.TeoudatZeoutChild ==0)
            //     MessageBox.Show("You need selected children and valid him !");

            // if ( myContract.TeoudatZeoutNanny == 0)
            //     MessageBox.Show("You need selected Nanny and valid her !");
            myContract.MonthPrice = bl.PriceOfMonth(myContract);
            this.hourePriceTextBox.Text = myContract.HourePrice.ToString();
            this.monthPriceTextBox.Text = myContract.MonthPrice.ToString();


            bl.AddContract(myContract);

            
            //this.ContractDedailGrid.DataContext = myContract;
            MessageBox.Show("Congratulation !! \n You have add the contract n: " + myContract );
            this.Close();

        }
    }
}
