using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KFSolutionsModel;


namespace KFSrepository_EF6
{


    public interface IOrderLineInRepository : ITDSrepository<OrderLineIn>
    {

    }

    public class OrderLineInRepository : TDSrepository<OrderLineIn>, IOrderLineInRepository
    {
        public OrderLineInRepository(string aConnectionstring) : base(aConnectionstring)
        {

        }
    }

}
