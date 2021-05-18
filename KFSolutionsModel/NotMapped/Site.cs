using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFSolutionsModel.NotMapped
{
    public class Site : DBentity
    {


        [Required]
        [MaxLength(20)]
        [Column(TypeName = "char")]
        public string Fax { get; set; }



        [Required]
        [MaxLength(20)]
        [Column(TypeName = "char")]
        public string PhoneNumber { get; set; }


        [MaxLength(20)]
        [Column(TypeName = "char")]
        public string PhoneNumber_2 { get; set; }

        [MaxLength(20)]
        [Column(TypeName = "char")]
        public string MobileNumber { get; set; }

        [MaxLength(20)]
        [Column(TypeName = "char")]
        public string Email { get; set; }

        [MaxLength(255)]
        //[Column(TypeName = "char")]
        public string ExtraInfo { get; set; }


    }
}
