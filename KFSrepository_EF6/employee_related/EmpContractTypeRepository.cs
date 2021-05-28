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


        //=========================================================================================

        private IEnumerable<EmpContractType> _memoryList;
        public override IEnumerable<EmpContractType> GetAll()
        {

            if (_memoryList == null)
            {
                _memoryList = base.GetAll();
            }

            return _memoryList;

            //return base.GetAll();
        }


    }

}
