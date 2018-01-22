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
using Xceed.Wpf.Toolkit;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for PlanningUserControl.xaml
    /// </summary>
    public partial class PlanningUserControl : UserControl
    {
        public Label[] LabelDay;
        public CheckBox[] CheckBoxDay { get; set; }
        public TimePicker[] TimePicketBeginHours { get; set; }

        public TimePicker[] TimePicketEndHours { get; set; }
        private string[] shortDaysStrings;

        public bool[] CheckedDays { get; set; }
        public DateTime[,] PlanningAgendas { get; set; }


        public PlanningUserControl()
        {
            InitializeComponent();
            LabelDay = new Label[6];
            CheckBoxDay = new CheckBox[6];
            TimePicketBeginHours = new TimePicker[6];
            TimePicketEndHours = new TimePicker[6];
            //shortDaysStrings= new string[] {"S", "M", "Tu", "W", "Th", "F"};
            shortDaysStrings = new string[] { DayOfWeek.Sunday.ToString(), DayOfWeek.Monday.ToString(), DayOfWeek.Tuesday.ToString(), DayOfWeek.Wednesday.ToString(), DayOfWeek.Thursday.ToString(), DayOfWeek.Friday.ToString() };


            for (int i = 0; i < 6; i++)
            {

                //Label Day
                LabelDay[i] = new Label() { Content = shortDaysStrings[i], Name = shortDaysStrings[i] + "Label" };
                this.Container.Children.Add(LabelDay[i]);
                Grid.SetRow(LabelDay[i], 0);
                Grid.SetColumn(LabelDay[i], i);

                //CheckBoxDay
                CheckBoxDay[i] = new CheckBox() { Name = shortDaysStrings[i] + "CheckBox" };
                this.Container.Children.Add(CheckBoxDay[i]);
                Grid.SetColumn(CheckBoxDay[i], i);
                Grid.SetRow(CheckBoxDay[i], 1);
                //BeginHours
                TimePicketBeginHours[i] = new TimePicker() { Name = shortDaysStrings[i] + "BeginHoursTimePicker" };
                this.Container.Children.Add(TimePicketBeginHours[i]);
                Grid.SetColumn(TimePicketBeginHours[i], i);
                Grid.SetRow(TimePicketBeginHours[i], 3);
                //EndHours
                TimePicketEndHours[i] = new TimePicker() { Name = shortDaysStrings[i] + "EndHoursTimePicker" };
                this.Container.Children.Add(TimePicketEndHours[i]);
                Grid.SetColumn(TimePicketEndHours[i], i);
                Grid.SetRow(TimePicketEndHours[i], 5);

                //Binding from Checkbox
                Binding enableBinding = new Binding();
                enableBinding.Source = CheckBoxDay[i];
                enableBinding.Path = new PropertyPath("IsChecked");
                TimePicketBeginHours[i].SetBinding(TimePicker.IsEnabledProperty, enableBinding);
                TimePicketEndHours[i].SetBinding(TimePicker.IsEnabledProperty, enableBinding);


            }
        }


        

        //Insert data in Object
        public void InsertDataInObject(bool[] CheckedDay, DateTime[,] AgendaHours)
        {
            for (int i = 0; i < 6; i++)
            {
                if (this.CheckBoxDay[i].IsChecked == null)
                    this.CheckBoxDay[i].IsChecked = false;
                if (this.TimePicketBeginHours[i].Value == null)
                    this.TimePicketBeginHours[i].Value = DateTime.MinValue;
                if (this.TimePicketEndHours[i].Value == null)
                    this.TimePicketEndHours[i].Value = DateTime.MinValue;

                CheckedDay[i] = (bool)this.CheckBoxDay[i].IsChecked;
                AgendaHours[i,0] = (DateTime)this.TimePicketBeginHours[i].Value;
                AgendaHours[i,1] = (DateTime)this.TimePicketEndHours[i].Value;
            }
        }
        //Insert data in Object
        public void InsertDataFromObject(bool[] CheckedDay, DateTime[,] AgendaHours)
        {
            for (int i = 0; i < 6; i++)
            {
                
                this.CheckBoxDay[i].IsChecked = CheckedDay[i];
                this.TimePicketBeginHours[i].Value = AgendaHours[i,0];
                this.TimePicketEndHours[i].Value = AgendaHours[i,1];
            }
        }



    }
}
