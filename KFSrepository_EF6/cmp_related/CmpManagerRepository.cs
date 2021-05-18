using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KFSolutionsModel;


namespace KFSrepository_EF6
{


    public interface ICmpManagerRepository : ITDSrepository<CmpManager>
    {

    }

    public class CmpManagerRepository : TDSrepository<CmpManager>, ICmpManagerRepository
    {
        public CmpManagerRepository(string aConnectionstring) : base(aConnectionstring)
        {

        }
    }

}
