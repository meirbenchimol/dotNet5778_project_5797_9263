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
            Window NannyWindow = new NannyWindow();
            NannyWindow.Show();
        }

        private void UpdateNannyButton_Click(object sender, RoutedEventArgs e)
        {
            Window Update_Nanny = new Update_Nanny();
            Update_Nanny.Show();
        }

        private void AllDataButton_Click(object sender, RoutedEventArgs e)
        {
            Window Data = new Data();
            Data.Show();
        }

        private void AddMotherButton_Click(object sender, RoutedEventArgs e)
        {
            Window addMother = new AddMother();
            addMother.Show();
        }

        private void UpdateMother_Click(object sender, RoutedEventArgs e)
        {
            Window updateMother = new Update_Mother();
            updateMother.Show();
        }

        private void AddChildrenButton_Click(object sender, RoutedEventArgs e)
        {
            Window AddChildren = new Add_Child();
            AddChildren.Show();
        }

        private void UpdateChildrenButton_Click(object sender, RoutedEventArgs e)
        {
            Window UpdateChildren = new Update_child();
            UpdateChildren.ShowDialog();
        }

        private void AddContractButton_Click(object sender, RoutedEventArgs e)
        {
         
            Window AddContractwindow = new Add_Contract();
            AddContractwindow.ShowDialog();
        }

        private void UpdateContractButton_Click(object sender, RoutedEventArgs e)
        {
            Window UpdateContractWindow = new Update_Contract();
            UpdateContractWindow.ShowDialog();
        }
    }
}
