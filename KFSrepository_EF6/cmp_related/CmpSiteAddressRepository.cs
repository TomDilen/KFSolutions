using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KFSolutionsModel;


namespace KFSrepository_EF6
{


    public interface ICmpSiteAddressRepository : ITDSrepository<CmpSiteAddress>
    {

    }

    public class CmpSiteAddressRepository : TDSrepository<CmpSiteAddress>, ICmpSiteAddressRepository
    {
        public CmpSiteAddressRepository(string aConnectionstring) : base(aConnectionstring)
        {

        }
    }

}