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
    /// Interaction logic for Add_Contract.xaml
    /// </summary>
    public partial class Add_Contract : Window
    {
        IBL bl;
        Contract myContract;
        public Add_Contract()
        {
            InitializeComponent();
            bl = Factory_BL.GetBL();

            teoudatZeoutNannyComboBox.ItemsSource = bl.GetAllNanny(null);
            teoudatZeoutNannyComboBox.SelectedValuePath = "TeoudatZeout";
            teoudatZeoutNannyComboBox.DisplayMemberPath = "TeoudatZeout";

            teoudatZeoutChildComboBox.ItemsSource = bl.ChildWithoutNanny();
            teoudatZeoutChildComboBox.SelectedValuePath = "TeoudatZeout";
            teoudatZeoutChildComboBox.DisplayMemberPath = "TeoudatZeout";

            this.payementComboBox.ItemsSource = Enum.GetValues(typeof(BE.Payement));

        
        }
        private int GetSelectedIdnanny()
        {
            object result = this.teoudatZeoutNannyComboBox.SelectedValue;

            if (result == null)
                throw new Exception("you must choice Mother !!");
            return (int)result;
        }
        private int GetSelectedIdCHILD()
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

        }

        private void ValidChildrenButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CalculeDistanceButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
