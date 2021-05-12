using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KFSolutionsModel;


namespace KFSrepository_EF6
{


    public interface IAddressRepository : ITDSrepository<Address>
    {

    }

    public class AddressRepository : TDSrepository<Address>, IAddressRepository
    {
        public AddressRepository(string aConnectionstring) : base(aConnectionstring)
        {

        }
    }

}
