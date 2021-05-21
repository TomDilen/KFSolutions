
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFSolutionsModel
{
    public class ProductType : NotMapped.TypeTable
    {


        //--------------navigation propertys-----------//

        public virtual ICollection<Product> Products { get; set; }
    }
}
