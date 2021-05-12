using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFSolutionsModel
{

    public partial class Person 
    {
        public string FirstName { get; set; }

        public string NameAddition { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public bool? IsMale { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string MobileNumber { get; set; }
        public string PhoneNumber { get; set; }




    }

}
