using KFSolutionsModel.NotMapped;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFSolutionsModel
{
    public class Product  
    {
        // ! bij deze is de EAN code Het ID , 
        // het id mag dus geen automatisch oplopend nummer zijn
        // niet 100% tevreden, string voor een ID?
        // normaal is deze 13 karakters lang, maar voor testing ok voorlopig
        [Key]
        [MinLength(5)]
        [MaxLength(20)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        
        public string EAN { get; set; }



        [Required(ErrorMessage = "Street can not empty")]
        [MaxLength(30)]
        public string ProductTitle { get; set; }


        [MaxLength(255)]
        public string ExtraInfo { get; set; }


        //[Required(ErrorMessage = "SellingPrice can not empty")]
        public float SellingPriceRecommended { get; set; }


        public float BTWpercentage { get; set; }


        [Required(ErrorMessage = "CountInStock can not empty")]
        public int CountInStock { get; set; }


        [Required(ErrorMessage = "MinCountInStock can not empty")]
        public int MinCountInStock { get; set; }


        [Required(ErrorMessage = "MaxCountInStock can not empty")]
        public int MaxCountInStock { get; set; }



        [Required(ErrorMessage = "WareHouseLocation can not empty")]
        [MaxLength(10)]
        public string WareHouseLocation { get; set; }



        public byte[] Image { get; set; }


        //--------------navigation propertys-----------//

        public int Id_ProductType { get; set; }
        public virtual ProductType ProductType { get; set; }

        public virtual ICollection<OrderLineIn> OrderLineIns { get; set; }
        public virtual ICollection<OrderLineOut> OrderLineOuts { get; set; }



        public virtual ICollection<Supplier_Product_Price> Supplier_Product_Prices { get; set; }

        //[NotMapped]
        //public virtual ICollection<ProductQuotation> ProductQuotations { get; set; }


    }
}
