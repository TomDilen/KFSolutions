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
    public class ProductQuotation : DBentity
    {

        public float UnitPrice { get; set; }


        [Required(ErrorMessage = "DateQuatation can not empty")]
        public DateTime DateQuatation { get; set; }



        public DateTime? DateRegistered { get; set; }


        [MaxLength(255, ErrorMessage = "max length of ExtraInfo is 255")]
        public string ExtraInfo { get; set; }


        //--------------navigation propertys-----------//






        public int Id_Supplier { get; set; }
        public virtual Supplier Supplier { get; set; }


        public int? Id_EmployeeRegistered { get; set; }
        public virtual Employee EmployeeRegistered { get; set; }


        //----------------------------deze relatie weggehaald-------
        ////[NotMapped]
        [Required]
        public string EAN_Product { get; set; }

        //[NotMapped]
        //public virtual Product Product { get; set; }

    }
}
