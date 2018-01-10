﻿using System;
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
    /// Interaction logic for NannyWindow.xaml
    /// </summary>
    public partial class NannyWindow : Window
    {
        Nanny nanny;
        IBL bl;
        public NannyWindow()
        {
            InitializeComponent();
            nanny = new Nanny(0);
            this.NannyDetailsGrid.DataContext = nanny;
            bl = Factory_BL.GetBL();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //if ((long.Parse(this.teoudatZeoutTextBox.Text)) % 8 >= 1)
                //    nanny.TeoudatZeout = long.Parse(this.teoudatZeoutTextBox.Text);
                //else
                //    throw new Exception ("the teoudat zeout is not avaible");
                //nanny.Surname = this.surnameTextBox.Text;
                //nanny.Firstname = this.firstnameTextBox.Text;

                bl.AddNanny(nanny);
                nanny = new Nanny(1);
                this.NannyDetailsGrid.DataContext = nanny;
                MessageBox.Show("Congratulation you have had nanny !");

                //this.teoudatZeoutTextBox.ClearValue(TextBlock.TextProperty);
                //this.surnameTextBox.ClearValue(TextBlock.TextProperty);
                //this.firstnameTextBox.ClearValue(TextBlock.TextProperty);
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
    }
}
