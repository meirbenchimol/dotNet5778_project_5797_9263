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
    /// Logique d'interaction pour Add_Nanny.xaml
    /// </summary>
    public partial class Add_Nanny : Window
    {
        Nanny nanny;
        IBL bl;

        public Add_Nanny()
        {
            nanny = new Nanny(0);
            bl = Factory_BL.GetBL();
            InitializeComponent();
          //  this.nannyListView_Copy.DataContext = nanny;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource nannyViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("nannyViewSource")));
            // Charger les données en définissant la propriété CollectionViewSource.Source :
            // nannyViewSource.Source = [source de données générique]

        }


        private void AddNannybutton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void nannyDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
