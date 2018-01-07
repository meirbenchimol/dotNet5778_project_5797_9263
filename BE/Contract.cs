using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Contract
    {
        //attributs
        private int contractNumber;
        private int teoudatZeoutNanny;
        private int teoudatZeoutChild;
        private bool knowMeet;
        private double distance;
        private bool signature;
        private int hourePrice;
        private int monthPrice;
        private Payement payement;
        private DateTime dateBeguin;
        private DateTime dateFinish;

        //constructor
        public Contract(int contractNumber, int teoudatZeoutNanny, int teoudatZeoutChild)
        {
            this.contractNumber = contractNumber;
            this.teoudatZeoutNanny = teoudatZeoutNanny;
            this.teoudatZeoutChild = teoudatZeoutChild;
            this.knowMeet = true;
            distance = 14;
            signature = false;
            hourePrice = 35;
            monthPrice = 1500;
            payement = Payement.Mensuel;
            dateBeguin = new DateTime(2017, 10, 12);
            dateFinish = new DateTime(2018, 10, 12);
        }

        //properties
        public int ContractNumber { get => contractNumber; set => contractNumber = value; }
        public int TeoudatZeoutNanny { get => teoudatZeoutNanny; set => teoudatZeoutNanny = value; }
        public int TeoudatZeoutChild { get => teoudatZeoutChild; set => teoudatZeoutChild = value; }
        public bool KnowMeet { get => knowMeet; set => knowMeet = value; }
        public bool Signature { get => signature; set => signature = value; }
        public int HourePrice { get => hourePrice; set => hourePrice = value; }
        public int MonthPrice { get => monthPrice; set => monthPrice = value; }
        public Payement Payement { get => payement; set => payement = value; }
        public DateTime DateBeguin { get => dateBeguin; set => dateBeguin = value; }
        public DateTime DateFinish { get => dateFinish; set => dateFinish = value; }
        public double Distance { get => distance; set => distance = value; }

        //to string
        public override string ToString()
        {
            string contract = " The contract n°:" + contractNumber
                              + "\n Teoudat Zeout'Nanny: " + teoudatZeoutNanny
                              + "\n Teoudat Zeout Children: " + teoudatZeoutChild
                              + "\n had the first meeting ?: " + knowMeet
                              + "\n had sign ?: " + signature + "\n houres'price:" + hourePrice
                              + "\n months'price : " + monthPrice + "\n payemment par :" + payement
                              + "\n the contract begin: " + dateBeguin + " and finish : " + dateFinish;
            return contract;
        }
    }
}
