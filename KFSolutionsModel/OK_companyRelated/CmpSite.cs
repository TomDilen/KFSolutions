using KFSolutionsModel.NotMapped;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace KFSolutionsModel
{
    public class CmpSite : Site //, ISetInactiveInsteadOfRemove
    {


        [Required]
        public bool IsDefault { get; set; } = false;





        //--------------navigation propertys-----------//


        public int Id_Company { get; set; }
        public virtual Company Company { get; set; }

        public virtual ICollection<CmpSiteContactPerson> CmpSiteContactPersons { get; set; }

        public virtual CmpSiteAddress CmpSiteAddress { get; set; }
    }

}





