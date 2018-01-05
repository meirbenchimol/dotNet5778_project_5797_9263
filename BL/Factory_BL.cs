using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace BL
{
    class Factory_BL
    {
        static IBL bl = null;
        public static IBL GetBL ()
        {
            if (bl==null)//singleton
             bl = new BL_imp();
            return bl;
        }
    }
}
