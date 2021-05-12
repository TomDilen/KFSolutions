using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFSolutionsModel
{
    public class Department : DBentity
    {
        [Required(ErrorMessage = "Name of Description of aDepartment can not empty")]
        [MaxLength(15)]
        [Index(IsUnique = true)]
        public string Description { get; set; }


        public UInt64 DefaultPermissions { get; set; }


    }
}
