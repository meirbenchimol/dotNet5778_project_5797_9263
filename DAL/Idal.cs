using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public interface Idal
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
        Mother GetMother(int troudatZeout);
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


    }
}
