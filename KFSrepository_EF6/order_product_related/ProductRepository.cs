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
    }

}

