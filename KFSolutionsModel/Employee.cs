using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KFSolutionsModel
{

    public partial class Employee 
    {
        [Required]
        [MaxLength(15)]
        [Column(TypeName = "char")]
        public string PassPortID { get; set; }

        [Required]
        [MaxLength(15)]
        [Column(TypeName = "char")]
        public string IBAN { get; set; }



        public byte Id_Department { get; set; }


    }
}
