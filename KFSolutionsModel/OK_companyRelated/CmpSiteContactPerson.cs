using KFSolutionsModel.NotMapped;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFSolutionsModel
{
    public  class CmpSiteContactPerson : PersonMin
    {

        
        [Required]
        public bool IsDefault { get; set; } = false;

        [MaxLength(255)]
        //[Column(TypeName = "char")]
        public string ExtraInfo { get; set; }



        //--------------navigation propertys-----------//

        public int Id_CmpSite { get; set; }
        public virtual CmpSite CmpSite { get; set; }
    }
}
