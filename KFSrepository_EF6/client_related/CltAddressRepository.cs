using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KFSolutionsModel;


namespace KFSrepository_EF6
{


    public interface ICltAddressRepository : ITDSrepository<CltAddress>
    {

    }

    public class CltAddressRepository : TDSrepository<CltAddress>, ICltAddressRepository
    {
        public CltAddressRepository(string aConnectionstring) : base(aConnectionstring)
        {

        }
    }

}
