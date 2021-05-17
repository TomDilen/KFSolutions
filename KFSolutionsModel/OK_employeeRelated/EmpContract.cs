using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFSolutionsModel
{
    public class EmpContract : NotMapped.DBentity
    {
        [Required(ErrorMessage = "Name of DescriptionEN can not empty")]
        public float MonthSalary { get; set; }


        [Required(ErrorMessage = "DateOfStart can not empty")]
        public DateTime DateOfStart { get; set; }



        //[Required(ErrorMessage = "TypeOfContract can not empty")]
        //public EmpContractType TypeOfContract { get; set; }



        //[Required(ErrorMessage = "TypeOfContract can not empty")]
        //public EmpContractStatuutType TypeOfContractStatuutType { get; set; }



        //--------------navigation propertys-----------//
        public virtual Employee Employee { get; set; }

        //virtual ff weggenomen//
        public int Id_EmpContractType { get; set; }
        public virtual EmpContractType EmpContractType { get; set; }

        //virtual weggenomen
        public int Id_EmpContractStatuutType { get; set; }
        public virtual EmpContractStatuutType EmpContractStatuutType { get; set; }

    }
}
