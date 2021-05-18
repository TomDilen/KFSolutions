﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFSolutionsModel
{
    public class Company : NotMapped.DBentity
    {

        [Required(ErrorMessage = "CompanyNumber can not empty")] 
        [MaxLength(20)] //voorb belgie: 0123.321.123 
        public string CompanyNumber { get; set; }


        [Required(ErrorMessage = "Name of company can not empty")]
        [MaxLength(40)]
        public string Name { get; set; }

        //[Required(ErrorMessage = "Website can not empty")]
        [Index(IsUnique = true)]
        [MaxLength(150)]
        public string Website { get; set; }

        [Required(ErrorMessage = "BTW can not empty")]
        [MaxLength(20)]
        public string BtwNumber { get; set; }


        [MaxLength(255)]
        public string ExtraInfo { get; set; }



        //--------------navigation propertys-----------//
        public virtual ICollection<CmpManager> CmpManagers { get; set; }
        public virtual ICollection<CmpIBAN> CmpIBANs { get; set; }
        public virtual ICollection<CmpSite> CmpSites { get; set; }
        //Site[]
        //Manager
        //IBAN[]
    }
}