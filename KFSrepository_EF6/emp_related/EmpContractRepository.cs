using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KFSolutionsModel;


namespace KFSrepository_EF6
{


    public interface IEmpContractRepository : ITDSrepository<EmpContract>
    {

    }

    public class EmpContractRepository : TDSrepository<EmpContract>, IEmpContractRepository
    {
        public EmpContractRepository(string aConnectionstring) : base(aConnectionstring)
        {

        }
    }

}
