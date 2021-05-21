using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KFSolutionsModel;


namespace KFSrepository_EF6
{


    public interface ICmpSiteRepository : ITDSrepository<CmpSite>
    {

    }

    public class CmpSiteRepository : TDSrepository<CmpSite>, ICmpSiteRepository
    {
        public CmpSiteRepository(string aConnectionstring) : base(aConnectionstring)
        {

        }
    }

}
