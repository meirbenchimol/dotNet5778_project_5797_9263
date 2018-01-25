using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace BL
{
    public interface IBL
    {
        #region Nanny
        void AddNanny(Nanny nanny);
        bool DeleteNanny(int teouatZeout);
        void UpdateNanny(Nanny nanny);
        Nanny GetNanny(int teoudatZeout);
        IEnumerable<Nanny> GetAllNanny(Func<Nanny, bool> predicate = null);
        #endregion

        #region Mother
        void AddMother(Mother mother);
        bool DeleteMother(int teoudatZeout);
        void UpdateMother(Mother mother);
        Mother GetMother(int teoudatZeout);
        IEnumerable<Mother> GetAllMother(Func<Mother, bool> predicate = null);
        #endregion

        #region Child
        void AddChild(Child child);
        bool DeleteChild(int teoudatZeout);
        void UpdateChild(Child child);
        Child GetChild(int teoudatZeout);
        IEnumerable<Child> GetAllChild(Func<Child, bool> predicate = null);
        #endregion

        #region Contract
        void AddContract(Contract contract);
        bool DeleteContract(int contractNumber);
        void UpdateContract(Contract contract);
        Contract GetContract(int contractnumber);
        IEnumerable<Contract> GetAllContract(Func<Contract, bool> predicate = null);
        #endregion

        #region Methods
        int PriceOfMonth(Contract contract);
        int CalculateDistance(string source, string dest);
        IEnumerable<Nanny> CoordinationMother(Mother mother);
        IEnumerable<Nanny> LessPotentielNanny(Mother mother);
        IEnumerable<Nanny> AccessibleNanny(Mother mother);
        IEnumerable<Child> ChildWithoutNanny();
        IEnumerable<Nanny> NannyHolydayTAMAT();
        //public delegate bool ConditionDelegate(Contract c);
        //IEnumerable<Contract> ListOfContractWanted(ConditionDelegate cond);
        //int NumberOfContractWanted(ConditionDelegate cond);
        #endregion

        #region Grouping
        IEnumerable<IGrouping<int, Nanny>> Grouping_Nanny(bool MinOrMax = false);
        IEnumerable<IGrouping<double, Contract>> Grouping_Contract();
        #endregion 

    }
}
