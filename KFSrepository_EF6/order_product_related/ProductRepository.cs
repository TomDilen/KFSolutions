using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KFSolutionsModel;


namespace KFSrepository_EF6
{


    public interface IProductRepository : ITDSrepository<Product>
    {

    }

    public class ProductRepository : TDSrepository<Product>, IProductRepository
    {
        public ProductRepository(string aConnectionstring) : base(aConnectionstring)
        {

        }
        private List<Product> _memoryList;
        public override IEnumerable<Product> GetAll()
        {

            if (_memoryList == null)
            {
                _memoryList = base.GetAll().ToList();
            }

            return _memoryList;

            //return base.GetAll();
        }
    }

}

