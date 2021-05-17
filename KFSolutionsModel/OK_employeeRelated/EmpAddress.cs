using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFSolutionsModel
{
    public class EmpAddress : NotMapped.Address
    {




        //--------------navigation propertys-----------//
        //is een 1 op 1 relatie
        public virtual Employee Employee { get; set; }
    }
}
