using KFSolutionsModel.NotMapped;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFSolutionsModel
{
    public class ProductQuotation : DBentity
    {

        [Required]
        [MinLength(5)]
        [MaxLength(20)]
        public string EAN_Product { get; set; }

        public float UnitPrice { get; set; }

        [Required(ErrorMessage = "ProductTitle can not empty")]
        [MinLength(4, ErrorMessage = "ProductTitle moet minstens 5 tekens bevatten")]
        [MaxLength(20,  ErrorMessage = "ProductTitle mag maximum 20 tekens bevatten")]
        public string  ProductTitle { get; set; }

     
        [Required(ErrorMessage = "DateQuatation can not empty")]
        public DateTime DateQuatation { get; set; }


        [JsonIgnore]
        public DateTime? DateRegistered { get; set; }

     
        [MaxLength(255, ErrorMessage = "max length of ExtraInfo is 255")]
        public string ExtraInfo { get; set; }


        //--------------navigation propertys-----------//


        [JsonIgnore]
        public int Id_Supplier { get; set; }
        [JsonIgnore]
        public virtual Supplier Supplier { get; set; }

        [JsonIgnore]
        public int? Id_EmployeeRegistered { get; set; }
        [JsonIgnore]
        public virtual Employee EmployeeRegistered { get; set; }

    }
}
