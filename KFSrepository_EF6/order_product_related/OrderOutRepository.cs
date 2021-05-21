using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KFSolutionsModel;


namespace KFSrepository_EF6
{


    public interface IOrderOutRepository : ITDSrepository<OrderOut>
    {

    }

    public class OrderOutRepository : TDSrepository<OrderOut>, IOrderOutRepository
    {
        public OrderOutRepository(string aConnectionstring) : base(aConnectionstring)
        {

        }
    }

}