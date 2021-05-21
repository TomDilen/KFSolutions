using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFSolutionsModel
{
    public class OrderLineOut : NotMapped.OrderLine
    {



        //--------------navigation propertys-----------//

        [Required]
        public string EAN_Product { get; set; }
        public virtual Product Product { get; set; }


        public int Id_OrderOut { get; set; }
        public virtual OrderOut OrderOut { get; set; }
    }
}
