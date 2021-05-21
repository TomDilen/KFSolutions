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


        public readonly ISupplierRepository Supplier;
        public readonly ICmpManagerRepository CmpManagers;
        public readonly ICmpIBANRepository CmpIBANs;
        public readonly ICmpSiteContactPersonRepository CmpSiteContactPerson;
        public readonly ICmpSiteRepository CmpSite;
        public readonly ICmpWebCredentialsRepository CmpCredentials;
        public readonly ICmpSiteAddressRepository CmpSiteAddress;


        public readonly IClientRepository Client;
        public readonly ICltAddressRepository CltAddress;
        public readonly ICltWebCredentialsRepository CltWebCredentials;



        public readonly IProductTypeRepository ProductType;
        public readonly IProductQuotationRepository ProductQuotation;
        public readonly IProductRepository Product;
        public readonly ISupplier_Product_PriceRepository Supplier_Product_Price;
        
        


        public readonly IOrderInRepository OrderIn;
        public readonly IOrderLineInRepository OrderLineIn;

        public readonly IOrderOutRepository OrderOut;
        public readonly IOrderLineOutRepository OrderLineOut;

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


            Supplier = new SupplierRepository(aConnectionString);
            CmpManagers = new CmpManagerRepository(aConnectionString);
            CmpIBANs = new CmpIBANRepository(aConnectionString);
            CmpSiteContactPerson = new CmpSiteContactPersonRepository(aConnectionString);
            CmpSite = new CmpSiteRepository(aConnectionString);
            CmpCredentials = new CmpWebCredentialsRepository(aConnectionString);
            CmpSiteAddress = new CmpSiteAddressRepository(aConnectionString);


            Client = new ClientRepository(aConnectionString);
            CltAddress = new CltAddressRepository(aConnectionString);
            CltWebCredentials = new CltWebCredentialsRepository(aConnectionString);

            Product = new ProductRepository(aConnectionString);
            ProductType = new ProductTypeRepository(aConnectionString);
            ProductQuotation = new ProductQuotationRepository(aConnectionString);
            Supplier_Product_Price = new Supplier_Product_PriceRepository(aConnectionString);


            OrderIn = new OrderInRepository(aConnectionString);
            OrderLineIn = new OrderLineInRepository(aConnectionString);


            OrderOut = new OrderOutRepository(aConnectionString);
            OrderLineOut = new OrderLineOutRepository(aConnectionString);

        }
    }
}
