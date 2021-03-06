﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Child
    {
        //attributs
        private int teoudatZeout;
        private int teoudatZeoutMom;
        private string firstname;
        private DateTime birthday;
        private Gender genderChild; 
        private bool specialNeed;
        private string specialNeeds;

        //constructor
        public Child () { }
        public Child(int teoudatZeout, int teoudatZeoutMom)
        {
            this.teoudatZeout = teoudatZeout;
            this.teoudatZeoutMom = teoudatZeoutMom;
            firstname = "firstname";
            birthday = new DateTime (2017,03,23);
            genderChild = Gender.Boy;
            specialNeed = false;
            specialNeeds = "  ";
        }

        //properties
        public int TeoudatZeout { get => teoudatZeout; set => teoudatZeout = value; }
        public int TeoudatZeoutMom { get => teoudatZeoutMom; set => teoudatZeoutMom = value; }
        public string Firstname { get => firstname; set => firstname = value; }
        public DateTime Birthday { get => birthday; set => birthday = value; }
        public bool SpecialNeed { get => specialNeed; set => specialNeed = value; }
        public string SpecialNeeds { get => specialNeeds; set => specialNeeds = value; }
        public Gender GenderChild { get => genderChild; set => genderChild = value; }

        //to string 
        public override string ToString()
        {
            string children = "########################################################################\n"
                            + "########################################################################\n"
                            + "######### The children : " + firstname
                            + " ########### \n teoudat Zeout : " + teoudatZeout
                            + "\n teoudat Zeout'mom : " + teoudatZeoutMom
                            + "\n nirthday : " + birthday
                            + "\n gender : " + genderChild
                            + "\n he have speciales need ?" + specialNeed
                            + " who are : " + specialNeeds
                            + "***********************************************************************";

            return children;
        }
    }
}
