using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFSolutionsModel.NotMapped
{

    public class Address : DBentity
    {

        [Required(ErrorMessage = "Street can not empty")]
        [MaxLength(30)]
        public string Street { get; set; }


        [Required(ErrorMessage = "HouseNumber can not empty")]
        public int HouseNumber { get; set; }


        [MaxLength(8)]
        public string HouseNumberAddition { get; set; }


        [Required(ErrorMessage = "Country can not empty")]
        [MaxLength(25)]
        public string Country { get; set; }



        [Required(ErrorMessage = "Zipcode can not empty")]
        [MaxLength(12)]
        public string Zipcode { get; set; }


        [Required(ErrorMessage = "City can not empty")]
        [MaxLength(20)]
        public string City { get; set; }



        public double? Latitude { get; set; }


        public double? Longitude { get; set; }

    }

}
