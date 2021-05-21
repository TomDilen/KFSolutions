using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KFSolutionsModel;


namespace KFSrepository_EF6
{


    public interface IOrderInRepository : ITDSrepository<OrderIn>
    {

    }

    public class OrderInRepository : TDSrepository<OrderIn>, IOrderInRepository
    {
        public OrderInRepository(string aConnectionstring) : base(aConnectionstring)
        {

        }
    }

}