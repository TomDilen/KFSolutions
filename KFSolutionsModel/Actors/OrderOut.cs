using KFSolutionsModel.NotMapped;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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





    }
}
