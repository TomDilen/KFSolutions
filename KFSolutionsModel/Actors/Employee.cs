using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KFSolutionsModel
{

    public class Employee : NotMapped.Person 
    {
        [Required]
        public bool IsActive { get; set; }



        [Required]
        [MaxLength(15)]
        [Column(TypeName = "char")]
        public string PassPortID { get; set; }



        [Required]
        [MaxLength(15)]
        [Column(TypeName = "char")]
        public string IBAN { get; set; }



        [MaxLength(255)]
        //[Column(TypeName = "char")]
        public string  JobInfo { get; set; }



        [MaxLength(255)]
        //[Column(TypeName = "char")]
        public string ExtraInfo { get; set; }



        //=========================================
        //address       # voorlopig juist1
        //Department    # juist 1
        //contract      # voorlog juist 1
        //AppAccount    # 0 of 1


        //--------------navigation propertys-----------//


        //HEB hier de virtual ff weggenomen
        public int Id_EmpDepartment { get; set; }
        public virtual EmpDepartment EmpDepartment { get; set; }

        //--------------1 op 1-----------//
        public virtual EmpAddress EmpAddress { get; set; }
        public virtual EmpContract EmpContract { get; set; }


        public virtual EmpAppAccount EmpAppAccount { get; set; }


        public virtual ICollection<ProductQuotation> ProductQuotations { get; set; }


        public virtual ICollection<OrderIn> OrderIns_OrderedBy { get; set; }

        public virtual ICollection<OrderIn> OrderIns_HandledBy { get; set; }


        public virtual ICollection<OrderOut> OrderOuts_SoldBy { get; set; }

        public virtual ICollection<OrderOut> OrderOuts_PreparedBy { get; set; }

        public virtual ICollection<OrderOut> OrderOuts_InvoiceCreatedBy { get; set; }

        //========================================================================================






    }
}
