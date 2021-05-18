using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFSolutionsModel
{
    public class CmpSiteAddress : NotMapped.Address
    {


        //--------------navigation propertys-----------//
        public virtual CmpSite CmpSite { get; set; }

    }
}
