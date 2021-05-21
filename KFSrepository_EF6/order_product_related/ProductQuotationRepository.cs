using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KFSolutionsModel;


namespace KFSrepository_EF6
{


    public interface IProductQuotationRepository : ITDSrepository<ProductQuotation>
    {

    }

    public class ProductQuotationRepository : TDSrepository<ProductQuotation>, IProductQuotationRepository
    {
        public ProductQuotationRepository(string aConnectionstring) : base(aConnectionstring)
        {

        }
    }

}