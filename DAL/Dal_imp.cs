using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using static DS.DataSource;

namespace DAL
{
    internal class Dal_imp : Idal
    {
       //public DataSource myDataSource;
        public Dal_imp ()
        {
            DS.DataSource myDataSource = new DS.DataSource();
        }
       

        #region Nanny
        public void AddNanny(Nanny nanny)
        {
          
         
            if (NannyList.Exists (x=> x.TeoudatZeout==nanny.TeoudatZeout))
                throw new Exception("this Nanny already exist !");
            NannyList.Add(nanny);
            //NannyList.Sort();
            
        }
        public bool DeleteNanny(int teoudatZeout)
        {
            if (!!NannyList.Exists(x => x.TeoudatZeout == teoudatZeout))
                throw new Exception("this nanny doesn't exist !");

            NannyList.Remove(NannyList.Find(n => n.TeoudatZeout == teoudatZeout));
            ContractList.Remove(ContractList.Find(n => n.TeoudatZeoutNanny == teoudatZeout));

            return NannyList.Remove(NannyList.Find(n => n.TeoudatZeout == teoudatZeout));

        }
        public void UpdateNanny(Nanny nanny)
        {
            int index = NannyList.FindIndex(x => x.TeoudatZeout == nanny.TeoudatZeout);
            if (index < 0 )
                throw new Exception("this nanny do not found !");
            NannyList[index] = nanny;
        }
        public Nanny GetNanny(int teoudatZeout)
        {

            return NannyList.FirstOrDefault(x => x.TeoudatZeout == teoudatZeout);

        }
        public IEnumerable<Nanny> GetAllNanny(Func<Nanny, bool> predicate = null)
        {
            if (predicate == null)
                return NannyList.AsEnumerable();
            return NannyList.Where(predicate);
        }
        #endregion
        
        #region Mother
        public void AddMother (Mother mother)
        {
            if (MotherList.Exists (x=> x.TeoudatZeout==mother.TeoudatZeout ))
                throw new Exception("this Mom already exist !");
            MotherList.Add(mother);
            //MotherList.Sort();
        }
        public bool DeleteMother ( int teoudatZeout)
        {
            if (!MotherList.Exists(x => x.TeoudatZeout == teoudatZeout))
                throw new Exception("this mom not found !");
            MotherList.Remove(MotherList.Find(x => x.TeoudatZeout == teoudatZeout));
            return MotherList.Remove(MotherList.Find(x => x.TeoudatZeout == teoudatZeout));
        }
        public void UpdateMother (Mother mother)
        {
            int index = MotherList.FindIndex(x => x.TeoudatZeout == mother.TeoudatZeout);
            if (index<0)
                throw new Exception("this mother not found !");
            MotherList[index] = mother;
        }
        public Mother GetMother(int teoudatZeout)
        {
        
                return MotherList.FirstOrDefault(x => x.TeoudatZeout == teoudatZeout);
           
        }
        public IEnumerable<Mother> GetAllMother(Func<Mother, bool> predicate = null)
        {
            if (predicate == null)
                return MotherList.AsEnumerable();
            return MotherList.Where(predicate);
        }
        #endregion

        #region Child
        public void AddChild (Child child)
        {
            if (ChildList.Exists(x=>x.TeoudatZeout==child.TeoudatZeout))
                throw new Exception("this children already exist i'm sorry baby !");
            ChildList.Add(child);
            //ChildList.Sort();
        }
        public bool DeleteChild ( int teoudatZeout )
        {
            if (!ChildList.Exists(x=>x.TeoudatZeout==teoudatZeout))
                throw new Exception("this children not found !");
            ChildList.Remove(ChildList.Find(x => x.TeoudatZeout == teoudatZeout));
            ContractList.Remove(ContractList.Find(x => x.TeoudatZeoutChild == teoudatZeout));
            return ChildList.Remove(ChildList.Find(x => x.TeoudatZeout == teoudatZeout));
        }
        public void UpdateChild (Child child)
        {
            int index = ChildList.FindIndex(x => x.TeoudatZeout == child.TeoudatZeout);
            if (index<0)
                throw new Exception(" this children not found !");
            ChildList[index] = child;
        }
        public Child GetChild(int teoudatZeout)
        {
                return ChildList.FirstOrDefault(x => x.TeoudatZeout == teoudatZeout);
            
        }
        public IEnumerable<Child> GetAllChild(Func<Child, bool> predicate = null)
        {
            if (predicate == null)
                return ChildList.AsEnumerable();
            return ChildList.Where(predicate);
        }

        #endregion

        #region Contract
        public void AddContract (Contract contract)
        {
            if (ContractList.Exists(x=> x.ContractNumber==contract.ContractNumber))
                throw new Exception("this contract already exist !");
            ContractList.Add(contract);
            //ContractList.Sort();
        }
        public bool DeleteContract ( int contractNumber)
        {
            if (!ContractList.Exists(x=>x.ContractNumber==contractNumber))
                throw new Exception(" this contract not found !");
            ContractList.Remove(ContractList.Find(x => x.ContractNumber == contractNumber));
            return ContractList.Remove(ContractList.Find(x => x.ContractNumber == contractNumber));
            
        }
        public void UpdateContract (Contract contract)
        {
            int index = ContractList.FindIndex(x => x.ContractNumber == contract.ContractNumber);
            if (index<0)
                throw new Exception(" this contract is not found");
            ContractList[index] = contract;
        }
        public Contract GetContract(int contractNumber)
        {
            
                return ContractList.FirstOrDefault(x => x.ContractNumber == contractNumber);
           
        }
        public IEnumerable<Contract> GetAllContract(Func<Contract, bool> predicate = null)
        {
            if (predicate == null)
                return ContractList.AsEnumerable();
            return ContractList.Where(predicate);
        }
        #endregion

    }
}
