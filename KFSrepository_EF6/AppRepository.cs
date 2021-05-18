using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFSrepository_EF6
{
    public class AppRepository<T>
    {

        public readonly IEmpAppAccountRepository EmpAppAccount;
        public readonly IEmpAddressRepository EmpAddress;
        public readonly IEmployeeRepository Employee;
        public readonly IEmpContractRepository EmpContract;
        public readonly IEmpContractStatuutTypeRepository EmpContractStatuutType;
        public readonly IEmpContractTypeRepository EmpContractType;
        public readonly IEmpDepartmentRepository EmpDepartment;

        public readonly ICmpSiteContactPersonRepository CmpSiteContactPerson;
        public readonly ICmpSiteRepository CmpSite;
        public readonly ICmpSiteAddressRepository CmpSiteAddress;
        public readonly ICmpIBANRepository CmpIBAN;
        public readonly ICmpManagerRepository CmpManager;



        //=======================================================================

        public AppRepository(string aConnectionString)
        {

            Employee = new EmployeeRepository(aConnectionString);
            EmpAddress = new EmpAddressRepository(aConnectionString);
            EmpAppAccount = new EmpAppAccountRepository(aConnectionString);
            EmpContract = new EmpContractRepository(aConnectionString);
            EmpContractStatuutType = new EmpContractStatuutTypeRepository(aConnectionString);
            EmpContractType = new EmpContractTypeRepository(aConnectionString);
            EmpDepartment = new EmpDepartmentRepository(aConnectionString);

            CmpSiteContactPerson = new CmpSiteContactPersonRepository(aConnectionString);
            CmpSite = new CmpSiteRepository(aConnectionString);
            CmpSiteAddress = new CmpSiteAddressRepository(aConnectionString);
            CmpIBAN = new CmpIBANRepository(aConnectionString);
            CmpManager = new CmpManagerRepository(aConnectionString);

        }
    }
}
