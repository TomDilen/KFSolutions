using KFSolutionsModel.NotMapped;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFSolutionsModel
{
    public class EmpContractStatuutType : TypeTable
    {



        //--------------navigation propertys-----------//
        //opgelet, deze zijn virtual//

        public virtual ICollection<EmpContract> EmpContracts { get; set; }
    }
}
