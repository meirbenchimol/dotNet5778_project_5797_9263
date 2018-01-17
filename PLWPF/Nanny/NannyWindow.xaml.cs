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

       

        private void AddButton_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((int.Parse(this.teoudatZeoutTextBox.Text)) / 10000000 >= 1)
                    nanny.TeoudatZeout = int.Parse(this.teoudatZeoutTextBox.Text);
                else
                    throw new Exception("the teoudat zeout is not avaible");
                //nanny.Surname = this.surnameTextBox.Text;
                //nanny.Firstname = this.firstnameTextBox.Text;

                bl.AddNanny(nanny);
                
                MessageBox.Show("Congratulation you have add nanny !\n ID :"+nanny.TeoudatZeout+" \n Name : "+nanny.Surname+"  "+nanny.Firstname);
                nanny = new Nanny(0);
                NannyDetailsGrid.DataContext=nanny;
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

        private void changeImageButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog f = new Microsoft.Win32.OpenFileDialog();
            f.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
            if (f.ShowDialog() == true)
            {
                this.NannyImage.Source = new BitmapImage(new Uri(f.FileName));

            }
        }

    }
}