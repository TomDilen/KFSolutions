using KFSolutionsModel.NotMapped;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFSolutionsModel
{
    public class CltAddress : Address
    {



        //--------------navigation propertys-----------//

        public int Id_Client { get; set; }
        public virtual Client Client { get; set; }

    }
}
