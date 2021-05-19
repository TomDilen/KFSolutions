using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KFSolutionsModel;


namespace KFSrepository_EF6
{


    public interface ISupplierRepository : ITDSrepository<Supplier>
    {

    }

    public class SupplierRepository : TDSrepository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(string aConnectionstring) : base(aConnectionstring)
        {

        }
    }

}