using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Nanny : IComparable
    {
        //attributs
        private int teoudatZeout;
        private string surname;
        private string firstname;
        private DateTime birthdate;
        private int phoneNumber ;
        private string adresse;
        private bool checkfloor;
        private int floor;
        private int yearsExperiences;
        private int maxChild;
        private int minAge;
        private int maxAge;
        private bool takePriceHoure;
        private int priceHoure;
        private int priceMonth;
        private bool[] daysWorking;
        private DateTime[,] hoursWorking;
        private bool hollydayTAMAT;
        private string recommandations;
        //private string imageSource;

        //constructor 
        public Nanny ()
        { }
        public Nanny(int teoudatZeout)
        {
            //imageSource = (@"Empty image");
            this.teoudatZeout = teoudatZeout;
            this.surname = "surname";
            this.firstname = "firstname";
            this.birthdate = new DateTime (1950,01,01);
            this.phoneNumber = 0000000000;
            this.adresse = "street,city,country";
            this.checkfloor = false;
            this.floor = 0;
            this.yearsExperiences = 0;
            this.maxChild = 10;
            this.minAge = 0;
            this.maxAge = 0;
            this.takePriceHoure = false;
            priceHoure = 0;
            priceMonth = 0;
            daysWorking = new bool[6];
            hoursWorking = new DateTime[6, 2];
            hollydayTAMAT = true;
            recommandations = "  ";
        }
        
        //propreties
        public int TeoudatZeout { get => teoudatZeout; set => teoudatZeout = value; }
        public string Surname { get => surname; set => surname = value; }
        public string Firstname { get => firstname; set => firstname = value; }
        public DateTime Birthdate { get => birthdate; set => birthdate = value; }
        public int PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Adresse { get => adresse; set => adresse = value; }
        public bool Checkfloor { get => checkfloor; set => checkfloor = value; }
        public int Floor { get => floor; set => floor = value; }
        public int YearsExperiences { get => yearsExperiences; set => yearsExperiences = value; }
        public int MaxChild { get => maxChild; set => maxChild = value; }
        public int MinAge { get => minAge; set => minAge = value; }
        public int MaxAge { get => maxAge; set => maxAge = value; }
        public bool TakeHoureprice { get => takePriceHoure; set => takePriceHoure = value; }
        public int PriceHoure { get => priceHoure; set => priceHoure = value; }
        public int PriceMonth { get => priceMonth; set => priceMonth = value; }
        public bool[] DaysWorking { get => daysWorking; set => daysWorking = value; }
        public DateTime[,] HoursWorking { get => hoursWorking; set => hoursWorking = value; }
        public bool HollydayTAMAT { get => hollydayTAMAT; set => hollydayTAMAT = value; }
        public string Recommandations { get => recommandations; set => recommandations = value; }
        //public string ImageSource { get => imageSource; set => imageSource = value; }

        public int CompareTo(object obj)
        {
            Nanny nanny = obj as Nanny;
            return this.teoudatZeout.CompareTo(nanny.teoudatZeout);
        }


        //to string
        public override string ToString()
        {
            string nan = "############################################################################"
                + "############################################################################"
                + "\n ########## The Nanny : " + surname + " " + firstname
                +" ##########"
                + " \n ID :   " + teoudatZeout
                + "\n Birth date :   " + birthdate
                + "\n Phone number :   " + phoneNumber
                + "\n Adresse :" + adresse
                + "\n There are ascensor :   " + checkfloor
                + " \n Floor :   " + floor
                + "\n Years experiences :   " + yearsExperiences
                + "\n Max children :   " + maxChild
                + "\n Age max :   " + maxAge + "\n min age : " + minAge
                + "\n She take price par houres ?   :   " + takePriceHoure
                + "\n Price for one houre :   " + priceHoure
                + "\n Price for one months :   " + priceMonth

                + "\n She have the hollyday TAMAT ?   : " + hollydayTAMAT
                + "\recomandations :   " + recommandations
                + "\n";

            //string nan = "";
            //Nanny nanny = new Nanny (11);
            //foreach (var item in nanny.GetType().GetProperties())
            //{
            //    nan += string.Format($"{item.Name} : {item.GetValue(nanny, null)} \n");
            //}

            nan += "+++++++ Day Working :  ++++++\n";
            for (int i = 0; i < 6; i++)
                nan += string.Format( "***Day "+ (DayOfWeek)i + "-> she work ? :   " + daysWorking[i].ToString() + "\n ---Hour Beguin : " + hoursWorking[i, 0] + " --- Hour Finish : " + hoursWorking[i, 1] + "\n");
           
            nan += "********************************************************************\n" +
                "********************************************************************\n" +
                "********************************************************************\n";

            return nan;
        }

    }
}
