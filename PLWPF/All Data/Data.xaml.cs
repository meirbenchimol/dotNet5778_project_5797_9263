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
                ShowAllNanny sn = new ShowAllNanny();
                sn.Source = bl.GetAllNanny(null);

                this.page.Content = sn;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

              
        
    }
}
