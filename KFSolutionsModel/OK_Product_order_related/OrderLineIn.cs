using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFSolutionsModel
{
    public class OrderLineIn : NotMapped.OrderLine
    {


        //--------------navigation propertys-----------//
        //opgelet, deze zijn virtual//

        [Required]
        public string EAN_Product { get; set; }
        public virtual Product Product { get; set; }


        public int Id_OrderIn { get; set; }
        public virtual OrderIn OrderIn { get; set; }
    }
}
