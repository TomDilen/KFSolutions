using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KFSolutionsModel;


namespace KFSrepository_EF6
{


    public interface IEmployeeRepository : ITDSrepository<Employee>
    {

    }

    public class EmployeeRepository : TDSrepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(string aConnectionstring) : base(aConnectionstring)
        {

        }
    }

}
