using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Mother : IComparable
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
            this.adresse ="yafo,jerusalem,israel";
            adresseWanted = "uziel,jerusalem,israel";
            distanceMax = 20;
            daysNeeds = new bool[6];
            houresNeeds = new int[6, 2];
            recomandations = "  ";
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

        public int CompareTo(object obj)
        {
            Mother mother = obj as Mother;
            return this.teoudatZeout.CompareTo(mother.teoudatZeout);
        }

        //to string 
        public override string ToString()
        {
            string mom = "the mom " + surname + " " + firstname + "\n teoudat Zeout : " + teoudatZeout
                        + "\n phone number : " + phoneNumber + "\n adresse : " + adresse
                        + "\n adresse wanted : " + adresseWanted + "\n" +
                        "\n recomandations : " + recomandations;

            //for (int i = 0; i < 6; i++)
            //    mom += string.Format(i + " " + daysNeeds[i].ToString() + "\n");

            //for (int i = 0; i < 6; i++)
            //    mom += string.Format("Enter Hour: " + houresNeeds[i,0] + "Exit Hour: " + houresNeeds[i,1] + "\n");

            //return mom;

            //string mom = "";
            //Mother mother = new Mother(12);
            //foreach (var item in mother.GetType().GetProperties())
            //{
            //    mom += string.Format($"{item.Name} : {item.GetValue(mother, null)} \n");
            //}
            mom += "DayNeed :\n";
            for (int i = 0; i < 6; i++)
                mom += string.Format(i + " " + daysNeeds[i].ToString() + "\n");
            mom += "\nHoure need : \n";
            for (int i = 0; i < 6; i++)
                mom += string.Format("Enter Hour: " + houresNeeds[i, 0] + "Exit Hour: " + houresNeeds[i, 1] + "\n");

            return mom;
        }
    }
}
