using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KFSolutionsModel;


namespace KFSrepository_EF6
{


    public interface IProductTypeRepository : ITDSrepository<ProductType>
    {

    }

    public class ProductTypeRepository : TDSrepository<ProductType>, IProductTypeRepository
    {
        public ProductTypeRepository(string aConnectionstring) : base(aConnectionstring)
        {

        }
    }

}
