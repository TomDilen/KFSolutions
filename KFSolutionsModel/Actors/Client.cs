using KFSolutionsModel.NotMapped;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFSolutionsModel
{
    public class Client : Person
    {

        [Required]
        public bool IsActive { get; set; }

        [MaxLength(255)]
        public string ExtraInfo { get; set; }




        //--------------navigation propertys-----------//

        public virtual ICollection<CltAddress> CltAddresss { get; set; }
 
        public virtual CltWebCredentials CltWebCredentials { get; set; }


        public virtual ICollection<OrderOut> OrderOuts { get; set; }


        [NotMapped]
        public virtual List<CltAddress> CltAddresssAsList { get; set; }

    }
}
