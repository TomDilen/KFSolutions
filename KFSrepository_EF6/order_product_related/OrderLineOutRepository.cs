using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KFSolutionsModel;


namespace KFSrepository_EF6
{


    public interface IOrderLineOutRepository : ITDSrepository<OrderLineOut>
    {

    }

    public class OrderLineOutRepository : TDSrepository<OrderLineOut>, IOrderLineOutRepository
    {
        public OrderLineOutRepository(string aConnectionstring) : base(aConnectionstring)
        {

        }
    }

}
