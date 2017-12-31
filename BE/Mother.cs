using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Mother
    {
        //attributs
        private int teoudatZeout;
        private string surname;
        private string firstname;
        private int phoneNumber;
        private string adresse;
        private string adresseWanted;
        private int distanceMax;
        private bool[] daysNeeds;
        private int[,] houresNeeds;
        private string recomandations;

        //constructor
        public Mother(int teoudatZeout)
        {
            this.teoudatZeout = teoudatZeout;
            this.surname = "dupon";
            this.firstname = "marge";
            this.phoneNumber = 0000001;
            this.adresse ="philipe,jeru,israel";
        }

        //propreties
        public int TeoudatZeout { get => teoudatZeout; set => teoudatZeout = value; }
        public string Surname { get => surname; set => surname = value; }
        public string Firstname { get => firstname; set => firstname = value; }
        public int PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Adresse { get => adresse; set => adresse = value; }
        public string AdresseWanted { get => adresseWanted; set => adresseWanted = value; }
        public bool[] DaysNeeds { get => daysNeeds; set => daysNeeds = value; }
        public int[,] HouresNeeds { get => houresNeeds; set => houresNeeds = value; }
        public string Recomandations { get => recomandations; set => recomandations = value; }
        public int DistanceMax { get => distanceMax; set => distanceMax = value; }

        //to string 
        public override string ToString()
        {
            string mom = "the mom " + surname + " " + firstname + "\n teoudat Zeout : " + teoudatZeout
                        + "\n phone number : " + phoneNumber + "\n adresse : " + adresse
                        + "\n adresse wanted : " + adresseWanted + "\n days needs : " + daysNeeds
                        + "\n houres need : " + houresNeeds + "\n recomandations : " + recomandations;
                        
            return mom;
        }
    }
}
