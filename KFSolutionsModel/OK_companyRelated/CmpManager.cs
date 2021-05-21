using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFSolutionsModel
{
    public class CmpManager : NotMapped.PersonMin
    {
        [Required]
        public bool IsMain { get; set; } = false;




        //--------------navigation propertys------------//

        public virtual ICollection<Supplier> Suppliers { get; set; }
    }
}
