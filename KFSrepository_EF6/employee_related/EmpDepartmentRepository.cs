using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KFSolutionsModel;


namespace KFSrepository_EF6
{


    public interface IEmpDepartmentRepository : ITDSrepository<EmpDepartment>
    {

    }

    public class EmpDepartmentRepository : TDSrepository<EmpDepartment>, IEmpDepartmentRepository
    {
        public EmpDepartmentRepository(string aConnectionstring) : base(aConnectionstring)
        {

        }

        //========================================================================================================
        private IEnumerable<EmpDepartment> _memoryList;
        public override IEnumerable<EmpDepartment> GetAll()
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
