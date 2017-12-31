using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Nanny
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
        private int[,] hoursWorking;
        private bool hollydayTAMAT;
        private string recommandations;

        //constructor 
        public Nanny(int teoudatZeout)
        {
            this.teoudatZeout = teoudatZeout;
            this.surname = "X";
            this.firstname = "h";
            this.birthdate = DateTime.Today;
            this.phoneNumber = 0000;
            this.adresse = "gerard,jeru,israel";
            this.checkfloor = true;
            this.floor = 2;
            this.yearsExperiences = 3;
            this.maxChild = 10;
            this.minAge = 5;
            this.maxAge = 18;
            this.takePriceHoure = true;
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
        public int[,] HoursWorking { get => hoursWorking; set => hoursWorking = value; }
        public bool HollydayTAMAT { get => hollydayTAMAT; set => hollydayTAMAT = value; }
        public string Recommandations { get => recommandations; set => recommandations = value; }

        //to string
        public override string ToString()
        {
            string nanny = "the Nanny " + surname + " " + firstname
                + " \n teoudat Zeout :" + teoudatZeout + "\n birth date :" + birthdate
                + "\n phone number :" + phoneNumber + "\n adresse :" + adresse
                + "\n there are ascensor : " + checkfloor + " \n Floor : " + floor
                + "\n Years experiences : " + yearsExperiences + "\n Max children : " + maxChild
                + "\n max age : " + maxAge + "\n min age : " + minAge
                + "\n she take price par houres ? :" + takePriceHoure
                + "\n price houre : " + priceHoure + "\n price months : " + priceMonth
                + "\n days working : " + daysWorking + "\n houres wrking : " + hoursWorking
                + "\n hollyday TAMAT ? : " + hollydayTAMAT + "\recomandations : " + recommandations;

            return nanny;
        }

    }
}
