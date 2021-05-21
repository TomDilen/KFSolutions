using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KFSolutionsModel;


namespace KFSrepository_EF6
{


    public interface ISupplier_Product_PriceRepository : ITDSrepository<Supplier_Product_Price>
    {

    }

    public class Supplier_Product_PriceRepository : TDSrepository<Supplier_Product_Price>, ISupplier_Product_PriceRepository
    {
        public Supplier_Product_PriceRepository(string aConnectionstring) : base(aConnectionstring)
        {

        }
    }

}