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
    public class OrderIn : DBentity
    {
        //id wordt het factuurnummer


        [Required(ErrorMessage = "Ordered date can not empty")]
        public DateTime OrderedAt { get; set; }


        public DateTime? HandledAt { get; set; }  //nullable



        [MaxLength(255)]
        public string ExtraInfo { get; set; }


        //--------------navigation propertys-----------//

        public int Id_Supplier { get; set; }
        public virtual Supplier Supplier { get; set; }



        public int Id_OrderedBy { get; set; }
        public virtual Employee OrderedBy { get; set; }


        public int? Id_HandledBy { get; set; }
        public virtual Employee HandledBy { get; set; }


        public virtual ICollection<OrderLineIn> OrderLineIns { get; set; }



        [NotMapped]
        public bool IsChecked { get; set; }

        ////
        //Supplier
        //OrderedBy
        //HandledBy(magazijnier)
        //OrderLines


        //[NotMapped]
        //public string _FullNameSupplier { get; set; }
        [NotMapped]
        public double _TTaankoopPrijs { get; set; }
        [NotMapped]
        public int _AantalStuks { get; set; }
        [NotMapped]
        public string _FullNameEmployeeHandledBy{ get; set; }
        [NotMapped]
        public string _FullNameEmployeeOrderedBy { get; set; }



    }
}
