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
    /// Interaction logic for AddMother.xaml
    /// </summary>
    public partial class AddMother : Window
    {
        IBL bl;
        Mother myMother;
        public AddMother()
        {
            InitializeComponent();
            Mother myMother = new Mother(0);
            this.MotherDetailGrid.DataContext = myMother;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource motherViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("motherViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // motherViewSource.Source = [generic data source]
        }

        private void AddMotherButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
