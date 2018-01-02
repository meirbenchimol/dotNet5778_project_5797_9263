using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;
using GoogleMapsApi;
using GoogleMapsAPI;
using Newtonsoft.Json;
using GoogleMapsApi.Entities.Directions.Request;
using GoogleMapsApi.Entities.Directions.Response;

namespace BL
{
    internal class BL_imp : IBL
    {
        DAL.Idal dal;

        //contructor 
        public BL_imp()
        {
            dal = DAL.FactoryDal.GetDal();
            Initialisation();
        }
        public void Initialisation()
        {
            this.AddNanny(new Nanny(1111111) { Surname ="dupon",Firstname ="Marge",Birthdate= new DateTime (1992,12,21) });
            this.AddNanny(new Nanny(222222) { Surname = "ben", Firstname = "sarah", Birthdate = new DateTime(1990, 08, 03) });
            this.AddMother(new Mother(11133) { Surname = "levi", Firstname = "debo", Adresse = "hapisga,jerusalem,israel" });
        }
        
        #region Nanny
        public void AddNanny ( Nanny nanny)
        {
            if (Age(nanny.Birthdate) < 18)
                throw new Exception("the nanny is too young");
            dal.AddNanny(nanny);
        }
        public bool DeleteNanny (int teoudatZeout)
        {
            return dal.DeleteNanny(teoudatZeout);
        }
        public void UpdateNanny (Nanny nanny)
        {
            if (Age(nanny.Birthdate) < 18)
                throw new Exception("tha nanny can't have less 18 years olds !");
            dal.UpdateNanny(nanny);
        }
        public Nanny GetNanny ( int teoudatZeout)
        {
            return dal.GetNanny(teoudatZeout);
        }
        public IEnumerable<Nanny> GetAllNanny (Func <Nanny,bool> predicate=null)
        {
            return dal.GetAllNanny(predicate);
        }
        #endregion

        #region Mother

        public void AddMother(Mother mother)
        {
            dal.AddMother(mother);
        }
        public bool DeleteMother(int teoudatZeout)
        {
            return dal.DeleteMother(teoudatZeout);
        }
        public void UpdateMother(Mother mother)
        {
            dal.UpdateMother(mother);
        }
        public Mother GetMother(int teoudatZeout)
        {
            return dal.GetMother(teoudatZeout);
        }
        public IEnumerable<Mother> GetAllMother(Func<Mother, bool> predicate = null)
        {
            return dal.GetAllMother(predicate);
        }

        #endregion

        #region Children
        public void AddChild(Child child)
        {
            if (AgeMonths(child.Birthday) < 3)
                throw new Exception("this children is too young for take it !");
            
            dal.AddChild(child);
        }
        public bool DeleteChild(int teoudatZeout)
        {
            return dal.DeleteChild(teoudatZeout);
        }
        public void UpdateChild(Child child)
        {
            if (AgeMonths(child.Birthday) < 3)
                throw new Exception("this children is too young for take it !");
            dal.UpdateChild(child);
        }
        public Child GetChild(int teoudatZeout)
        {
            return dal.GetChild(teoudatZeout);
        }
        public IEnumerable<Child> GetAllChild(Func<Child, bool> predicate = null)
        {
            return dal.GetAllChild(predicate);
        }
        #endregion

        #region Contract 

        public void AddContract(Contract contract)
        {
            Nanny myNanny = GetNanny(contract.TeoudatZeoutNanny);
            if (!CapacityOSignature(myNanny, contract)&& myNanny==null)
                throw new Exception("you can do this conctract because this nanny have signed the max children she can !");

            contract.MonthPrice = PriceOfMonth(contract);


            dal.AddContract(contract);
        }
        public bool DeleteContract(int contractNumber)
        {


            return dal.DeleteContract(contractNumber);
        }
        public void UpdateContract(Contract contract)
        {
            dal.UpdateContract(contract);
        }
        public Contract GetContract(int contractnumber)
        {
            return dal.GetContract(contractnumber);
        }
        public IEnumerable<Contract> GetAllContract(Func<Contract, bool> predicate = null)
        {
            return dal.GetAllContract(predicate);
        }
        #endregion


        #region Methods
        public int Age(DateTime birthdate)
        {
            var today = DateTime.Today;
            // Calculate the age.
            var age = today.Year - birthdate.Year;
            // Go back to the year the person was born in case of a leap year
            if (birthdate > today.AddYears(-age)) age--;
            return age;
        }
        public int AgeMonths (DateTime birthdate)
        {
            var today = DateTime.Today;
            var ageYears = today.Year - birthdate.Year;
            var ageMonth = today.Month - birthdate.Month;
            return ageYears * 12 + ageMonth;
        }
        public bool CapacityOSignature (Nanny nanny , Contract contract)
        {
            bool capacity = false;
            int count = 0; //conteur for number of children than nanny have
            Nanny myNanny = dal.GetNanny(contract.TeoudatZeoutNanny);
            IEnumerable<Contract> cn = dal.GetAllContract(x=> x.TeoudatZeoutNanny==contract.TeoudatZeoutNanny);
            foreach ( Contract item in cn )
            {
                if (item.Signature == true)// if in the list of the contract with the same nanny there are signature 
                    count++;
            }
            if (count < nanny.MaxChild) // check if the nnay can accept an other contract 
                capacity = true;
            return capacity;
        }
        public int PriceOfMonth (Contract contract)
        {
            int count = 0; //number of children'brother 
            Child children = dal.GetChild(contract.TeoudatZeoutChild);//get the child of contract
            Nanny nannychildren = dal.GetNanny(contract.TeoudatZeoutNanny);//get the nanny of contract
            Mother childMother = dal.GetMother(children.TeoudatZeoutMom);//Get the mother of the children
            IEnumerable<Child> BrotherList = dal.GetAllChild(x => x.TeoudatZeoutMom == childMother.TeoudatZeout);
            //list of all children with the same mom

            foreach (Child item in BrotherList)// checking if the brother have the same nanny
            {
                if (item.TeoudatZeout == nannychildren.TeoudatZeout)
                    count++;
            }

            if (contract.Payement == Payement.Horraire)// checkink if the payement is to houres ?
            {
                //if the payement is to houre we need the number of houre par semain and there are 4 week in the month
                contract.MonthPrice =(4 * TotalHouresWorkingWeek(childMother.HouresNeeds) * nannychildren.PriceHoure * ((100 - count * 2) / 100));
            }
            else
                contract.MonthPrice = nannychildren.PriceMonth * (100 - count * 2) / 100;

            return contract.MonthPrice ;
        }

        public int TotalHouresWorkingWeek (int [,]matrcice/*in the matrice there are to  the first line the hour begin to woork
            and to the second line the hour to stôp to work*/ )
        {
            int houresWorking = 0;// total of hours in the week where 
            for (int i =0; i<6; i++)
            {
                houresWorking += matrcice[1, i]-matrcice [0,i];
            }
            return houresWorking;
        }

        public int HouresAverageDay(int[,] matrice, bool[] aray)
        {
            int houresWorking = 0;// total of hours in the week where 
            int daysWorking = 0;
            for (int i = 0; i < 6; i++)
            {
                if (aray[i] == true)
                    daysWorking++;
                houresWorking += matrice[1, i] - matrice[0, i];
            }
            return houresWorking / daysWorking;
        }
        
        // method for calcul the distance between 2 adresse 
        public static int CalculateDistance(string source, string dest)
        {
            var drivingDirectonRequest = new DirectionsRequest
            {
                TravelMode = TravelMode.Walking,
                Origin = source,
                Destination = dest,
            };
            DirectionsResponse drivingDirections = GoogleMaps.Directions.Query(drivingDirectonRequest);
            Route route = drivingDirections.Routes.First();
            Leg leg = route.Legs.First();
            return leg.Distance.Value;
        }

        //method for calculate all nanny she can be good for the mom
        public IEnumerable<Nanny> CoordinationMother(Mother mother)
        {
            Mother myMother = dal.GetMother(mother.TeoudatZeout);
            List<Nanny> potentialNanny = new List<Nanny>();// list for the nanny who correspond to the mother
            IEnumerable<Nanny> NannyList = dal.GetAllNanny(null);// take the list of all nanny 
            foreach ( Nanny item in NannyList)
            {
                // check if the day'working of the nanny is the same that day looking for mom
                int problem1 = 6;//all days are not compatible
                for (int i =0; i<6; i++)
                {
                    if (myMother.DaysNeeds[i] == item.DaysWorking[i])
                        problem1--;
                }
                // check if the houres if good for mom and nanny
                int problem2 = 6;
                for (int i=0; i<6;i++)
                {
                    if (myMother.HouresNeeds[0, i] >= item.HoursWorking[0, i] &&
                        myMother.HouresNeeds[1, i] <= item.HoursWorking[1, i])
                        problem2--;
                }

                if (problem1 == 0 && problem2 == 0)
                    potentialNanny.Add(item);
            }
            return potentialNanny.AsEnumerable();
        }
        public IEnumerable <Nanny> LessPotentielNanny (Mother mother)
        {
            Mother myMother = dal.GetMother(mother.TeoudatZeout);
            List<Nanny> lessPotentialNanny = new List<Nanny>();// list for the nanny who correspond to the mother
            IEnumerable<Nanny> NannyList = dal.GetAllNanny(null);// take the list of all nanny 
            if (CoordinationMother (mother) ==null)
            {
                int flexibilityHoure = 1;// houres the mother can forget 
                int flexibilityDays = 1; // days the mother can forget
                for ( int i = flexibilityDays; i<6; i++)
                {
                    for ( int j = flexibilityHoure; j < HouresAverageDay(myMother.HouresNeeds,myMother.DaysNeeds );j++)
                    {
                          foreach ( Nanny item in NannyList)
                        {
                            int problem1 = 6;//all days are not compatible
                            for (int k = 0; k < 6; k++)
                            {
                                if (myMother.DaysNeeds[k] == item.DaysWorking[k])
                                    problem1--;
                            }
                            // check if the houres if good for mom and nanny
                            int problem2 = 6;
                            for (int m = 0; m < 6;m++)
                            {
                                if (myMother.HouresNeeds[0, m] >= item.HoursWorking[0, m] &&
                                    myMother.HouresNeeds[1, m] <= item.HoursWorking[1, m])
                                    problem2--;
                            }

                            if (problem1 == i && problem2 == j )
                                lessPotentialNanny.Add(item);
                            if (lessPotentialNanny.Count <= 5)
                            {
                                i = 7;
                                j = 25;
                            }
                        }
                       
                    
                    }
                }
            }
            return lessPotentialNanny.AsEnumerable();
        }
       
        // method for cherche the nanny in zone wanted
        public IEnumerable <Nanny> AccessibleNanny (Mother mother)
        {
            Mother myMother = dal.GetMother(mother.TeoudatZeout);
            List<Nanny> listOfAccessibleNanny = new List<Nanny>();
            IEnumerable<Nanny> NannyList = dal.GetAllNanny(null);// take the list of all nanny 
            foreach ( Nanny item in NannyList)
            {
                if (myMother.AdresseWanted==null)
                {
                    if (CalculateDistance(myMother.Adresse, item.Adresse) <= myMother.DistanceMax)
                        listOfAccessibleNanny.Add(item);
                }
                else
                {
                    if (CalculateDistance(myMother.AdresseWanted, item.Adresse) <= myMother.DistanceMax)
                        listOfAccessibleNanny.Add(item);
                }
            }
            return listOfAccessibleNanny.AsEnumerable();
        }

        //method for view all children without Nanny
        public IEnumerable<Child> ChildWithoutNanny ()
        {
            List<Child> listOfChildWithoutNanny = new List<Child>();
            IEnumerable<Contract> ContractList = dal.GetAllContract(null);// take the list of all contract 
            IEnumerable<Child> ChildList = dal.GetAllChild(null);//take the list of all children
            foreach ( Child item in ChildList)
            {
                bool check = false;
                foreach (Contract c in ContractList)
                {
                    if (item.TeoudatZeout == c.TeoudatZeoutChild)//if there is contract with the teoudat Zeout of the children for check if he have nanny
                        check = true;
                }
                if (!check)
                    listOfChildWithoutNanny.Add(item);
            }
            return listOfChildWithoutNanny.AsEnumerable();
        }

        // method for all nanny whith hollyday TAMAT
        public IEnumerable<Nanny> NannyHolydayTAMAT ()
        {
            List<Nanny> nannyHolydayTAMATList = new List<Nanny>();
            IEnumerable<Nanny> nannyList = dal.GetAllNanny(null);//get all nanny 
            foreach ( Nanny item in nannyList)
            {
                if (item.HollydayTAMAT)
                    nannyHolydayTAMATList.Add(item);
            }
            return nannyHolydayTAMATList.AsEnumerable();
        }

        public delegate bool ConditionDegate (Contract c);
        public IEnumerable<Contract> ListOfContractWanted (ConditionDegate cond)
        {
            return from c in dal.GetAllContract(null)
                   where cond(c)
                   select c;
        }

        public int NumberOfContractWanted (ConditionDegate cond)
        {
            var List_contract = from n in dal.GetAllContract(null)
                                where cond(n)
                                select n;
            return List_contract.Count(); 
        }
        #endregion


        #region Grouping
        IEnumerable <IGrouping<int,Nanny>> Grouping_Nanny (bool MinOrMax=false)
        {
            var result = from item in dal.GetAllNanny(null)
                         orderby CutGroup(item.MinAge, 6)
                         group item by CutGroup(item.MinAge, 6);
            if (MinOrMax == false)
                return result;
            else
                return result.Reverse();

        }
        public int CutGroup (int nbr,int cuter)
        {
                return nbr % cuter;
        }

        IEnumerable<IGrouping<double, Contract>> Grouping_Contract()
        {

            var Distance = from item in dal.GetAllContract(null)
                           orderby CutGroup((int)item.Distance, 5)
                           group item by CutGroup((int)item.Distance, 5);
            foreach (var g in Distance)
            {
                Console.WriteLine("Less than {0}", g);
                foreach ( var c in g)
                {
                    Console.WriteLine(c);
                }
            }

            return Distance;
        }
        #endregion

    }
}
