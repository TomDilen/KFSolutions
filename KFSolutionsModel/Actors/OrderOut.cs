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
    public class OrderOut : DBentity
    {

        public DateTime? WebOrderedAt { get; set; }  //nullable

        public DateTime? SoldAt { get; set; }//nullable


        public DateTime? PreparedAt { get; set; }//nullable


        public DateTime? InvoiceCreatedAt { get; set; }//nullable


        [MaxLength(255)]
        public string ExtraInfo { get; set; }




        //--------------navigation propertys-----------//

        public int Id_Client { get; set; }
        public virtual Client Client { get; set; }


        public int? Id_SoldBy { get; set; }
        public virtual Employee SoldBy { get; set; }



        public int? Id_PreparedBy { get; set; }
        public virtual Employee PreparedBy { get; set; }


        public int? Id_InvoiceCreatedBy { get; set; }
        public virtual Employee InvoiceCreatedBy { get; set; }


        public virtual ICollection<OrderLineOut> OrderLineOuts { get; set; }

        //client
        //SoldBy
        //PreparedBy
        //InvoiceCreatedBy
        //OrderLines
        [NotMapped]
        public string _FullNameClient { get; set; }
        [NotMapped]
        public double _TTverkoopPrijs { get; set; }
        [NotMapped]
        public int _AantalStuks { get; set; }
        [NotMapped]
        public string _FullNameEmployeeSolded { get; set; }



    }
}
