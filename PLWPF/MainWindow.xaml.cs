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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BE;
using BL;

namespace PLWPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static IBL bl;
        public MainWindow()
        {
            bl = Factory_BL.GetBL();
            InitializeComponent(); 
        }

        private void AddNannyButton_Click(object sender, RoutedEventArgs e)
        {
            Window Add_Nanny = new Add_Nanny();
            Add_Nanny.Show();
        }

        private void UpdateNannyButton_Click(object sender, RoutedEventArgs e)
        {
            Window Update_Nanny = new Update_Nanny();
            Update_Nanny.Show();
        }

        private void DeleteNannyButton_Click(object sender, RoutedEventArgs e)
        {
            Window Delete_Nanny = new Delete_Nanny();
            Delete_Nanny.Show();
        }
    }
}
