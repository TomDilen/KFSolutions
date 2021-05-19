using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KFSolutionsModel;


namespace KFSrepository_EF6
{


    public interface ICmpWebCredentialsRepository : ITDSrepository<CmpWebCredentials>
    {

    }

    public class CmpWebCredentialsRepository : TDSrepository<CmpWebCredentials>, ICmpWebCredentialsRepository
    {
        public CmpWebCredentialsRepository(string aConnectionstring) : base(aConnectionstring)
        {

        }
    }

}
