using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFSolutionsModel.NotMapped
{
    public class PersonMin : DBentity
    {
        [Required(ErrorMessage = "Firstname can not empty")]
        [MaxLength(25)]
        public string FirstName { get; set; }


        [MaxLength(10)]
        public string NameAddition { get; set; }

        [Required(ErrorMessage = "Lastname can not empty")]
        [MaxLength(25)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email can not empty")]
        //[Index(IsUnique = true)] //TODO email check
        //[Unique(ErrorMessage = "This already exist !!")]
        [MaxLength(80)]
        public string Email { get; set; }


        //[Index(IsUnique = true)]
        [MaxLength(20)]
        public string MobileNumber { get; set; }


        [MaxLength(15)]
        public string PhoneNumber { get; set; }

    }
}
