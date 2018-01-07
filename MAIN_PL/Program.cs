using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;
using BE;

namespace MAIN_PL
{
   class Program
    {
        
        static BL_imp bl;
        static void Main(string[] args)
        {
            bl = new BL_imp();

            int choice = 0;
            do
            {
                Console.WriteLine("-------------------------");
                Console.WriteLine("welcome \n What is your choice ?" +
                    "\n\t 1_Add Nanny" +
                    "\n\t 2_add Mother" +
                    "\n\t 3_add child" +
                    "\n\t 4_add contract" +
                    "\n\t 5_delete nanny" +
                    "\n\t 6_delete mother" +
                    "\n\t 7_delete children" +
                    "\n\t 8_delete contract" +
                    "\n\t 9_uptdate nanny" +
                    "\n\t 10_update mother" +
                    "\n\t 11_update children" +
                    "\n\t 12_update contract" +
                    "\n\t 13_see all data " +
                    "\n\t 14_exit\n\n");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AddNanny();
                        break;
                    case 13:
                        PrintData();
                        break;
                    case 14:
                        choice = 0;
                        break;

                    case (default):
                        break;
                }
            } while (choice != 0);
        }

        private static void PrintData()
        {
            Console.WriteLine("\n Nanny list : \n");
            IEnumerable<Nanny> nannyData = bl.GetAllNanny(null);
            foreach (Nanny item in nannyData)
            {
                Console.WriteLine(item + "\n");
            }

            Console.WriteLine("\n Mother list : \n");
            IEnumerable<Mother> motherdata = bl.GetAllMother(null);
            foreach (Mother item in motherdata)
            {
                Console.WriteLine(item + "\n");
            }

            Console.WriteLine("\n Children List : \n ");
            IEnumerable<Child> childData = bl.GetAllChild(null);
            foreach (Child item in childData )
            {
                Console.WriteLine(item +"\n");
            }

            Console.WriteLine("\n Contract List : \n ");
            IEnumerable<Contract> contractData = bl.GetAllContract(null);
            foreach ( Contract item in contractData)
            {
                Console.WriteLine(item + "\n");
            }
        }

        public AddNanny()
        {

        }
    }
}
