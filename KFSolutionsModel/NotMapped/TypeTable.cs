using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFSolutionsModel.NotMapped
{
    public class TypeTable : DBentity
    {
        [Required(ErrorMessage = "Name of DescriptionNL can not empty")]
        [MaxLength(15)]
        //[Index(IsUnique = true)]
        public string DescriptionNL  {get;set; }

        [Required(ErrorMessage = "Name of DescriptionEN can not empty")]
        [MaxLength(15)]
        //[Index(IsUnique = true)]
        public string DescriptionEN { get; set; }
    }
}
