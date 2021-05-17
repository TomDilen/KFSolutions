using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KFSolutionsModel;


namespace KFSrepository_EF6
{


    public interface IEmpContractTypeRepository : ITDSrepository<EmpContractType>
    {

    }

    public class EmpContractTypeRepository : TDSrepository<EmpContractType>, IEmpContractTypeRepository
    {
        public EmpContractTypeRepository(string aConnectionstring) : base(aConnectionstring)
        {

        }
    }

}
