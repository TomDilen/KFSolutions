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
        List<string> GetExistingEANsFromEanList(List<string> aListEANs);
    }

    public class ProductRepository : TDSrepository<Product>, IProductRepository
    {
        public ProductRepository(string aConnectionstring) : base(aConnectionstring)
        {

        }

        public List<string> GetExistingEANsFromEanList(List<string> aListEANs)
        {
            List<string> terug = new List<string>();
            using (KfsContext ctx = new KfsContext(_constring))
            {
                foreach (var item in aListEANs)
                {
                    var gevonden = ctx.Set<Product>()
                        .Select(p => p.EAN)
                        .FirstOrDefault(pean => pean == item);

                    if (!string.IsNullOrEmpty(gevonden)) terug.Add(gevonden);
                }
            }
            return terug;
        }



        //private List<Product> _memoryList;
        //public override IEnumerable<Product> GetAll()
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

