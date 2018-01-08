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
                    case 2:
                        AddMother();
                        break;
                    case 3:
                        AddChild();
                        break;
                    case 4:
                        AddContract();
                        break;
                    case 5:
                        DeleteNanny();
                        break;
                    case 7:
                        Detletechild();
                        break;
                    case 10:
                        UpdateMother();
                        break;
                    case 13:
                        PrintData();
                        break;
                    case 14:
                        choice = 0;
                        break;

                    default:
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

        static void AddNanny()
        {
            Console.WriteLine("what is teouadat zeout of nanny that you want add ?");
            int t = int.Parse(Console.ReadLine());
            Nanny n = new Nanny(t);
            try
            {
                bl.AddNanny(n);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        static void AddMother()
        {
            Console.WriteLine("what is teouadat zeout of mother that you want add ?");
            int t = int.Parse(Console.ReadLine());
            Mother n = new Mother (t);
            try
            {
                bl.AddMother(n);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        static void AddChild()
        {
            Console.WriteLine("what is teouadat zeout of child that you want add ?");
            int t = int.Parse(Console.ReadLine());
            Child n = new Child(t,0000);
            try
            {
                bl.AddChild(n);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        static void AddContract()
        {
            Console.WriteLine("what is number of contract that you want add ?");
            int t = int.Parse(Console.ReadLine());
            Contract n = new Contract(t,1,2);
            try
            {
                bl.AddContract(n);
            }
            catch (Exception e)
            {
                Console.WriteLine(" \n jjdjjd "+e.Message);
            }
        }
        static void DeleteNanny()
        {
            Console.WriteLine("what is teouadat zeout of nanny that you want delete ?");
            int t = int.Parse(Console.ReadLine());
            Nanny n = new Nanny(t);
            try
            {
                bl.DeleteNanny(n.TeoudatZeout);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        static void Detletechild()
        {
            Console.WriteLine("what is teouadat zeout of child that you want delet ?");
            int t = int.Parse(Console.ReadLine());
            try
            {
                bl.DeleteChild(t);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void UpdateMother()
        {
            Console.WriteLine("what is the teoudat zeout of the mom that you what chanhge ?");
            int t = int.Parse(Console.ReadLine());
            Mother m = new Mother(t);
            Console.WriteLine("what is the new name ?");
            string n = Console.ReadLine();
            m.Surname = n;

            try
            {
                bl.UpdateMother(m);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    
    
    }
}
