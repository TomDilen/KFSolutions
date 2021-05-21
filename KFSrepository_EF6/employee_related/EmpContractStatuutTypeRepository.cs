using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KFSolutionsModel;


namespace KFSrepository_EF6
{


    public interface IEmpContractStatuutTypeRepository : ITDSrepository<EmpContractStatuutType>
    {

    }

    public class EmpContractStatuutTypeRepository : TDSrepository<EmpContractStatuutType>, IEmpContractStatuutTypeRepository
    {
        public EmpContractStatuutTypeRepository(string aConnectionstring) : base(aConnectionstring)
        {

        }
    }

}
