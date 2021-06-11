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
        List<Supplier> GetAllForOverview();
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

        public List<Supplier> GetAllForOverview()
        {
            List<Supplier> terug = new List<Supplier>();
            using (KfsContext ctx = new KfsContext(_constring))
            {
                terug = ctx.Set<Supplier>()

                    .Include(nameof(Supplier.CmpSites))
                     .Include(nameof(Supplier.Supplier_Product_Prices))
                     .Include(nameof(Supplier.Supplier_Product_Prices) + "." + nameof(Supplier_Product_Price.Product))
                    //.OrderBy(x => x.Supplier_Product_Prices.)//.Include(parent => parent.Children.OrderBy(child => child.Order))
                    .Where(x => x.IsActive)
                    .ToList();


                for (int i = 0; i < terug.Count; i++)
                {
                    terug[i].Supplier_Product_Prices = terug[i].Supplier_Product_Prices.OrderBy(x => x.Product.ProductTitle).ThenBy(x=>x.Id).ToList();

                    //address ook nog als default setten
                    terug[i].AddressForDetails = terug[i].CmpSites.ToList()[0].CmpSiteAddress;
                }

            }


            return terug;
        }
    }

}