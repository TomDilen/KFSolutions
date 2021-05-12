using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KFSolutionsModel;


namespace KFSrepository_EF6
{
    public interface IDepartmentRepository : ITDSrepository<Department>
    {

    }

    public class DepartmentRepository : TDSrepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(string aConnectionstring) : base(aConnectionstring)
        {

        }
    }
}

