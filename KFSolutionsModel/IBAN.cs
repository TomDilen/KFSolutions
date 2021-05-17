using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFSolutionsModel
{
    public class IBAN 
    {

        [MaxLength(34)]
        [Required]
        public string Number { get; set; }
        public bool IsDefault { get; set; }
    }
}
