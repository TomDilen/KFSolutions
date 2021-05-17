using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFSolutionsModel
{
    class CompanyInfo 
    {

        public string Name { get; set; }

        [Required]
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Mobile { get; set; }
        public string Fax { get; set; }

        public string Website { get; set; }
        public string Email { get; set; }
        public string BTWnr { get; set; }

        public string ExtraInfo { get; set; }


        //[Required] //mss nog aanpassen, kan meerdere adressen hebben, maar de telefoon is daaran gelinkt
        //public Address Address1 { get; set; }
        //public Address Address2 { get; set; }

        //public Person ContactPerson { get; set; }

        //public IBAN IBANnr { get; set; }


    }
}
