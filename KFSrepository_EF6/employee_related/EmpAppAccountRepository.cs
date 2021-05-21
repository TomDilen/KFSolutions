using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KFSolutionsModel;


namespace KFSrepository_EF6
{


    public interface IEmpAppAccountRepository : ITDSrepository<EmpAppAccount>
    {

    }

    public class EmpAppAccountRepository : TDSrepository<EmpAppAccount>, IEmpAppAccountRepository
    {
        public EmpAppAccountRepository(string aConnectionstring) : base(aConnectionstring)
        {

        }
    }

}
