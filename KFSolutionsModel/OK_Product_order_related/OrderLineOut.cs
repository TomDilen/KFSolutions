using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFSolutionsModel
{
    public class OrderLineOut : NotMapped.OrderLine
    {



        //--------------navigation propertys-----------//

        public int Id_Product { get; set; }
        public virtual Product Product { get; set; }


        public int Id_OrderOut { get; set; }
        public virtual OrderOut OrderOut { get; set; }
    }
}
