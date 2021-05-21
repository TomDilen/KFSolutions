using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFSolutionsModel.NotMapped
{
    public class OrderLine : DBentity
    {
        public int NumberOfProducts { get; set; }
        public float UnitPrice { get; set; }


    }
}
