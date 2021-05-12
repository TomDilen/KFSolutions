using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFSolutionsModel
{

    public partial class Address
    {
        public string Street { get; set; }
        //public int HouseNumber { get; set; }
        
        //public string HouseNumberAddition { get; set; }
        //public string Country { get; set; }
        //public string  Zipcode { get; set; }
        //public string City { get; set; }

        //[NotMapped]
        //public double Latitude { get; set; }

        //[NotMapped]
        //public double Longitude { get; set; }
    }
}
