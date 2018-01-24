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
    /// Interaction logic for Data.xaml
    /// </summary>
    public partial class Data : Window
    {
        IBL bl;
        public Data()
        {
            InitializeComponent();
            bl = Factory_BL.GetBL();
        }

        private void ShowNannyButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ShowData sn = new ShowData();
                sn.Source = bl.GetAllNanny(null);

                this.page.Content = sn;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ShowMotherButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ShowData sn = new ShowData();
                sn.Source = bl.GetAllMother(null);

                this.page.Content = sn;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ShowChildrenButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ShowData sn = new ShowData();
                sn.Source = bl.GetAllChild(null);

                this.page.Content = sn;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ShowAllContracts_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ShowData sn = new ShowData();
                sn.Source = bl.GetAllContract(null);

                this.page.Content = sn;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Grouping1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool minimun = false;
                GroupeNannyByAgeAccept min = new GroupeNannyByAgeAccept();
                min.Source = bl.Grouping_Nanny(minimun);


                this.page.Content = min;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Grouping1bis_Click(object sender, RoutedEventArgs e)
        {
            try 
            {
                bool maximun = true;
                GroupeNannyByAgeAccept max = new GroupeNannyByAgeAccept();
                max.Source = bl.Grouping_Nanny( maximun );
                   

                this.page.Content = max;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Grouping2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                GroupingContractByDistance gd = new GroupingContractByDistance();
                gd.Source = bl.Grouping_Contract();


                this.page.Content = gd;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
