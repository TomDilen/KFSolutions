using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KFSolutionsModel;


namespace KFSrepository_EF6
{


    public interface ICmpSiteContactPersonRepository : ITDSrepository<CmpSiteContactPerson>
    {

    }

    public class CmpSiteContactPersonRepository : TDSrepository<CmpSiteContactPerson>, ICmpSiteContactPersonRepository
    {
        public CmpSiteContactPersonRepository(string aConnectionstring) : base(aConnectionstring)
        {

        }
    }

}
