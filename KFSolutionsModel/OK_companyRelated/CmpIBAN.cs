using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFSolutionsModel
{
    public class CmpIBAN : NotMapped.IBAN
    {

        [Required]
        public bool IsDefault { get; set; } = false;



        //--------------navigation propertys------------//
        public virtual ICollection<Company> Companys { get; set; }
    }
}
