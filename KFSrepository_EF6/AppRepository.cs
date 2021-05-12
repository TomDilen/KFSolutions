using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFSrepository_EF6
{
    public class AppRepository<T>
    {

        
        public readonly IDepartmentRepository Department;
        public readonly IEmployeeRepository Employee;
        public readonly IAddressRepository Address;
        
        

        public AppRepository(string aConnectionString)
        {
                
            Employee = new EmployeeRepository(aConnectionString);
            Department = new DepartmentRepository(aConnectionString);
            Address = new AddressRepository(aConnectionString);
        }
    }
}
