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
        //private List<Supplier> _memoryList;
        //public override IEnumerable<Supplier> GetAll()
        //{

        //    if (_memoryList == null)
        //    {
        //        _memoryList = base.GetAll().ToList();
        //    }

        //    return _memoryList;

        //    //return base.GetAll();
        //}
    }

}