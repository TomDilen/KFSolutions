using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFSolutionsModel
{
    public class Supplier : Company
    {
        [Required]
        public bool IsActive { get; set; }


        //[MaxLength(255)]
        //public string ExtraInfo { get; set; }



        //company


    }
}
