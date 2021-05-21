using KFSolutionsModel.NotMapped;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFSolutionsModel
{
    public class Supplier_Product_Price : DBentity
    {


        public float UnitPrice { get; set; }


        //--------------navigation propertys-----------//
        public string EAN_Product { get; set; }
        public virtual Product Product { get; set; }

        public int Id_Supplier { get; set; }
        public virtual Supplier Supplier { get; set; }

    }
}
