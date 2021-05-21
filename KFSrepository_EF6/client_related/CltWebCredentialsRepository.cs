using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KFSolutionsModel;


namespace KFSrepository_EF6
{


    public interface ICltWebCredentialsRepository : ITDSrepository<CltWebCredentials>
    {

    }

    public class CltWebCredentialsRepository : TDSrepository<CltWebCredentials>, ICltWebCredentialsRepository
    {
        public CltWebCredentialsRepository(string aConnectionstring) : base(aConnectionstring)
        {

        }
    }

}
