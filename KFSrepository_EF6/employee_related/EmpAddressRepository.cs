using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KFSolutionsModel;


namespace KFSrepository_EF6
{


    public interface IEmpAddressRepository : ITDSrepository<EmpAddress>
    {

    }

    public class EmpAddressRepository : TDSrepository<EmpAddress>, IEmpAddressRepository
    {
        public EmpAddressRepository(string aConnectionstring) : base(aConnectionstring)
        {

        }
    }

}
