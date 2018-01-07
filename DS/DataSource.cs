using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DS
{
    public class DataSource
    {
        public static List<Nanny> NannyList { get; set; }
        public static List<Mother> MotherList { get; set; }
        public static List<Child> ChildList { get; set; }
        public static List<Contract> ContractList { get; set; }

        public DataSource()
        {
            NannyList = new List<Nanny>();
            MotherList = new List<Mother>();
            ChildList = new List<Child>();
            ContractList = new List<Contract>();
        }
    }
}
