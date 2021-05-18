using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFSolutionsModel.NotMapped
{
    public class IBAN : DBentity
    {
        [Required(ErrorMessage = "IBAN number can not empty")]
        [MaxLength(34)]
        public string Number { get; set; }


    }
}
