using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFSolutionsModel
{
    public class Supplier : NotMapped.DBentity
    {
        [Required]
        public bool IsActive { get; set; }



        [Required(ErrorMessage = "CompanyNumber can not empty")] 
        [MaxLength(20)] //voorb belgie: 0123.321.123 
        public string CompanyNumber { get; set; }


        [Required(ErrorMessage = "Name of company can not empty")]
        [MaxLength(40)]
        public string Name { get; set; }

        //[Required(ErrorMessage = "Website can not empty")]
        [Index(IsUnique = true)]
        [MaxLength(150, ErrorMessage ="Length of Website is max 150 char")]
        public string Website { get; set; }

        [Required(ErrorMessage = "BTW can not empty")]
        [MaxLength(20)]
        public string BtwNumber { get; set; }

        [MaxLength(80)]
        [Required(ErrorMessage = "BTW can not empty")]
        [Column(TypeName = "char")]
        public string Email { get; set; }


        [MaxLength(255)]
        public string ExtraInfo { get; set; }



        //--------------navigation propertys-----------//
        public virtual ICollection<CmpManager> CmpManagers { get; set; }
        public virtual ICollection<CmpIBAN> CmpIBANs { get; set; }
        public virtual ICollection<CmpSite> CmpSites { get; set; }


        public virtual CmpWebCredentials CmpWebCredentials { get; set; }




        public virtual ICollection<OrderIn> OrderIns { get; set; }


        public virtual ICollection<Supplier_Product_Price> Supplier_Product_Prices { get; set; }


        public virtual ICollection<ProductQuotation> ProductQuotations { get; set; }

    }
}


