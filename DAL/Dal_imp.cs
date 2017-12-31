using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DS;

namespace DAL
{
    internal class Dal_imp : Idal
    {
        DataSource myDataSource;
       

        #region Nanny
        public void AddNanny(Nanny nanny)
        {
            Nanny nan = GetNanny(nanny.TeoudatZeout);
            if (nan != null)
                throw new Exception("this Nanny already exist !");
            myDataSource.nannyList.Add(nan);
        }
        public bool DeleteNanny(int teouatZeout)
        {
            Nanny nan = GetNanny(teouatZeout);
            if (nan == null)
                throw new Exception("this nanny doesn't exist !");
            myDataSource.nannyList.RemoveAll(x => x.TeoudatZeout == teouatZeout);
            myDataSource.contractList.RemoveAll(x => x.TeoudatZeoutNanny == teouatZeout);

            return myDataSource.nannyList.Remove(nan);
        }
        public void UpdateNanny(Nanny nanny)
        {
            int index = myDataSource.nannyList.FindIndex(x => x.TeoudatZeout == nanny.TeoudatZeout);
            if (index == -1)
                throw new Exception("this nanny do not found !");
            myDataSource.nannyList[index] = nanny;

        }
        public Nanny GetNanny(int teoudatZeout)
        {
            return myDataSource.nannyList.FirstOrDefault(x => x.TeoudatZeout == teoudatZeout);
        }
        public  IEnumerable<Nanny> GetAllNanny(Func<Nanny, bool> predicate = null)
        {
            if (predicate == null)
                return myDataSource.nannyList.AsEnumerable();
            return myDataSource.nannyList.Where(predicate);
        }
        #endregion
        
        #region Mother
        public void AddMother (Mother mother)
        {
            Mother mom = GetMother(mother.TeoudatZeout);
            if (mom != null)
                throw new Exception("this Mom already exist !");
            myDataSource.motherList.Add(mom);
        }
        public bool DeleteMother ( int teoudatZeout)
        {
            Mother mom = GetMother(teoudatZeout);
            if (mom == null)
                throw new Exception("this mom not found !");
            myDataSource.motherList.RemoveAll(x => x.TeoudatZeout == teoudatZeout);
            return myDataSource.motherList.Remove(mom);
        }
        public void UpdateMother (Mother mother)
        {
            int index = myDataSource.motherList.FindIndex(x => x.TeoudatZeout == mother.TeoudatZeout);
            if (index == -1)
                throw new Exception("this mother not found !");
            myDataSource.motherList[index] = mother;
        }
        public Mother GetMother ( int teoudatZeout)
        {
            return myDataSource.motherList.FirstOrDefault(x => x.TeoudatZeout == teoudatZeout);
        }
        public IEnumerable<Mother> GetAllMother(Func<Mother, bool> predicate = null)
        {
            if (predicate == null)
                return myDataSource.motherList.AsEnumerable();
            return myDataSource.motherList.Where(predicate);
        }
        #endregion

        #region Child
        public void AddChild (Child child)
        {
            Child children = GetChild(child.TeoudatZeout);
            if (children != null)
                throw new Exception("this children already exist i'm sorry baby !");
            myDataSource.childList.Add(children);
        }
        public bool DeleteChild ( int teoudatZeout )
        {
            Child children = GetChild(teoudatZeout);
            if (children == null)
                throw new Exception("this children not found !");
            myDataSource.childList.RemoveAll(x => x.TeoudatZeout == teoudatZeout);
            myDataSource.contractList.RemoveAll(x => x.TeoudatZeoutChild == teoudatZeout);
            return myDataSource.childList.Remove(children);
        }
        public void UpdateChild (Child child)
        {
            int index = myDataSource.childList.FindIndex(x => x.TeoudatZeout == child.TeoudatZeout);
            if (index == -1)
                throw new Exception(" this children not found !");
            myDataSource.childList[index] = child;
        }
        public Child GetChild (int teoudatZeout)
        {
            return myDataSource.childList.FirstOrDefault(x => x.TeoudatZeout == teoudatZeout);
        }
        public IEnumerable<Child> GetAllChild(Func<Child, bool> predicate = null)
        {
            if (predicate == null)
                return myDataSource.childList.AsEnumerable();
            return myDataSource.childList.Where(predicate);
        }

        #endregion

        #region Contract
        public void AddContract (Contract contract)
        {
            Contract con = GetContract(contract.ContractNumber);
            if (con != null)
                throw new Exception("this contract already exist !");
            myDataSource.contractList.Add(contract);
        }
        public bool DeleteContract ( int contractNumber)
        {
            Contract con = GetContract(contractNumber);
            if (con == null)
                throw new Exception(" this contract not found !");
            myDataSource.contractList.RemoveAll(x => x.ContractNumber == contractNumber);

            return myDataSource.contractList.Remove(con);
        }
        public void UpdateContract (Contract contract)
        {
            int index = myDataSource.contractList.FindIndex(x => x.ContractNumber == contract.ContractNumber);
            if (index == -1)
                throw new Exception(" this contract is not found");
            myDataSource.contractList[index] = contract;
        }
        public Contract GetContract ( int contractNumber)
        {
            return myDataSource.contractList.FirstOrDefault(x => x.ContractNumber == contractNumber);
        }
        public IEnumerable<Contract> GetAllContract(Func<Contract, bool> predicate = null)
        {
            if (predicate == null)
                return myDataSource.contractList.AsEnumerable();
            return myDataSource.contractList.Where(predicate);
        }
        #endregion

    }
}
