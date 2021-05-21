using KFSolutionsModel.NotMapped;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFSolutionsModel
{
    public class CmpWebCredentials : Credentials
    {


        //--------------navigation propertys------------//

        public virtual Supplier Supplier { get; set; }
    }
}
