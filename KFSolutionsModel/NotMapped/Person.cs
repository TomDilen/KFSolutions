using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFSolutionsModel.NotMapped
{
    public class Person : PersonMin
    {
        public DateTime? DateOfBirth { get; set; }


        [Required(ErrorMessage = "gender can not empty")]
        public bool IsMale { get; set; }


        //Adress is verhuisd naar Employee en naar Client, 
        //beter apparte tabellen voor adressen van employees, leveranciers en 
        //klanten
        //public Address 

    }
}
