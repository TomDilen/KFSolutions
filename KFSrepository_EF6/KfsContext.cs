using KFSolutionsModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFSrepository_EF6
{
    public class KfsContext : DbContext
    {
        public DbSet<EmpAddress> EmpAddresss { get; set; }
        public DbSet<EmpAppAccount> EmpAppAccounts { get; set; }
        public DbSet<EmpContract> EmpContracts { get; set; }
        public DbSet<EmpContractStatuutType> EmpContractStatuutTypes { get; set; }
        public DbSet<EmpContractType> EmpContractTypes { get; set; }
        public DbSet<EmpDepartment> EmpDepartments { get; set; }
        public DbSet<Employee> Employees { get; set; }

        //--------------------------------------------------------------------------
        public DbSet<CmpManager> CmpManagers { get; set; }
        public DbSet<CmpIBAN> CmpIBANs { get; set; }
        public DbSet<CmpSite> CmpSites { get; set; }
        public DbSet<CmpSiteAddress> CmpSiteAddresss { get; set; }
        public DbSet<CmpSiteContactPerson> CmpSiteContactPersons { get; set; }
        public DbSet<CmpWebCredentials> CmpCredentialss { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        //--------------------------------------------------------------------------
        public DbSet<Client> Clients { get; set; }
        public DbSet<CltAddress> CltAddresss { get; set; }
        public DbSet<CltWebCredentials> CltWebCredentialss { get; set; }

        //--------------------------------------------------------------------------

        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<ProductQuotation> ProductQuotations { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier_Product_Price> Supplier_Product_Prices { get; set; }

        //--------------------------------------------------------------------------
        public DbSet<OrderLineIn> OrderLineIns { get; set; }
        public DbSet<OrderIn> OrderIns { get; set; }

        //--------------------------------------------------------------------------

        public DbSet<OrderOut> OrderOuts { get; set; }
        public DbSet<OrderLineOut> OrderLineOuts { get; set; }

        //============================================================================================
        public KfsContext(string aNameOrConnectionString) : base(aNameOrConnectionString)
        {
            //this.Configuration.LazyLoadingEnabled = false;

            //Database.SetInitializer(new CreateDatabaseIfNotExists<KfsContext>()); //deze als dbOk is, is ook de standaard
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<KfsContext>());
            Database.SetInitializer(new DropCreateDatabaseAlways<KfsContext>()); //bij het testen

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            #region employee related

            //maakt een 1 op veel relatie
            modelBuilder.Entity<Employee>()
                .HasRequired<EmpDepartment>(b => b.EmpDepartment)
                .WithMany(a => a.Employees)
                .HasForeignKey<int>(b => b.Id_EmpDepartment);


            //dit is een 1 op 1 relatie
            modelBuilder.Entity<EmpAddress>()
                .HasOptional(x => x.Employee)
                .WithRequired(a => a.EmpAddress);


            //dit is een 1 op 1 relatie
            modelBuilder.Entity<EmpContract>()
                .HasOptional(x => x.Employee)
                .WithRequired(a => a.EmpContract);

            //maakt een 1 op veel relatie
            modelBuilder.Entity<EmpContract>()
                .HasRequired<EmpContractType>(b => b.EmpContractType)
                .WithMany(a => a.EmpContracts)
                .HasForeignKey<int>(b => b.Id_EmpContractType);

            //maakt een 1 op veel relatie
            modelBuilder.Entity<EmpContract>()
                .HasRequired<EmpContractStatuutType>(b => b.EmpContractStatuutType)
                .WithMany(a => a.EmpContracts)
                .HasForeignKey<int>(b => b.Id_EmpContractStatuutType);


            //dit is een 1 op 0 of 1 relatie
            modelBuilder.Entity<Employee>()
                .HasOptional(x => x.EmpAppAccount)
                .WithRequired(a => a.Employee);

            #endregion



            #region Company related


            // <Company>  0* -------  0* <CmpManager>
            modelBuilder.Entity<Supplier>()
                .HasMany(t => t.CmpManagers)
                .WithMany(t => t.Suppliers)
            .Map(m =>
            {
                m.ToTable("Companys_CmpManagers");
                m.MapLeftKey("Id_Company");
                m.MapRightKey("Id_CmpManager");
            });

            // <Company>  0* -------  0* <CmpIBAN>
            modelBuilder.Entity<Supplier>()
                .HasMany(t => t.CmpIBANs)
                .WithMany(t => t.Suppliers)
            .Map(m =>
            {
                m.ToTable("Companys_CmpIBANs");
                m.MapLeftKey("Id_Company");
                m.MapRightKey("Id_CmpIBAN");
            });

            //maakt een 1 op veel relatie
            modelBuilder.Entity<CmpSite>()
                .HasRequired<Supplier>(b => b.Supplier)
                .WithMany(a => a.CmpSites)
                .HasForeignKey<int>(b => b.Id_Company);

            //maakt een 1 op veel relatie
            modelBuilder.Entity<CmpSiteContactPerson>()
                .HasRequired<CmpSite>(b => b.CmpSite)
                .WithMany(a => a.CmpSiteContactPersons)
                .HasForeignKey<int>(b => b.Id_CmpSite);

            //dit is een 1 op 1 relatie
            modelBuilder.Entity<CmpSiteAddress>()
                .HasOptional(x => x.CmpSite)
                .WithRequired(a => a.CmpSiteAddress);

            //dit is een 1 op 0 of 1 relatie
            modelBuilder.Entity<Supplier>()
                .HasOptional(x => x.CmpWebCredentials)
                .WithRequired(a => a.Supplier);




            #endregion



            #region Client related

            //maakt een 1 op veel relatie
            modelBuilder.Entity<CltAddress>()
                .HasRequired<Client>(b => b.Client)
                .WithMany(a => a.CltAddresss)
                .HasForeignKey<int>(b => b.Id_Client);


            //dit is een 1 op 0 of 1 relatie
            modelBuilder.Entity<Client>()
                .HasOptional(x => x.CltWebCredentials)
                .WithRequired(a => a.Client);

            #endregion



            #region product related

            //maakt een 1 op veel relatie
            modelBuilder.Entity<Product>()
                .HasRequired<ProductType>(b => b.ProductType)
                .WithMany(a => a.Products)
                .HasForeignKey<int>(b => b.Id_ProductType);

            //maakt een 1 op veel relatie
            modelBuilder.Entity<Supplier_Product_Price>()
                .HasRequired<Supplier>(b => b.Supplier)
                .WithMany(a => a.Supplier_Product_Prices)
                .HasForeignKey<int>(b => b.Id_Supplier);



            //maakt een 1 op veel relatie
            modelBuilder.Entity<Supplier_Product_Price>()
                .HasRequired<Product>(b => b.Product)
                .WithMany(a => a.Supplier_Product_Prices)
                .HasForeignKey<string>(b => b.EAN_Product);





            //maakt een 1 op veel relatie
            modelBuilder.Entity<ProductQuotation>()
                .HasRequired<Supplier>(b => b.Supplier)
                .WithMany(a => a.ProductQuotations)
                .HasForeignKey<int>(b => b.Id_Supplier);






            #endregion




            #region order IN related

            //maakt een 1 op veel relatie
            modelBuilder.Entity<OrderLineIn>()
                .HasRequired<Product>(b => b.Product)
                .WithMany(a => a.OrderLineIns)
                .HasForeignKey<string>(b => b.EAN_Product);


            //maakt een 1 op veel relatie
            modelBuilder.Entity<OrderIn>()
                .HasRequired<Supplier>(b => b.Supplier)
                .WithMany(a => a.OrderIns)
                .HasForeignKey<int>(b => b.Id_Supplier);


            //maakt een 1 op veel relatie
            modelBuilder.Entity<OrderIn>()
                .HasRequired<Employee>(b => b.OrderedBy)
                .WithMany(a => a.OrderIns_OrderedBy)
                .HasForeignKey<int>(b => b.Id_OrderedBy);

            //maakt een 0 of 1 op veel relatie
            modelBuilder.Entity<OrderIn>()
                .HasOptional<Employee>(b => b.HandledBy)
                .WithMany(a => a.OrderIns_HandledBy)
                .HasForeignKey<int?>(b => b.Id_HandledBy);


            //maakt een 1 op veel relatie
            modelBuilder.Entity<OrderLineIn>()
                .HasRequired<OrderIn>(b => b.OrderIn)
                .WithMany(a => a.OrderLineIns)
                .HasForeignKey<int>(b => b.Id_OrderIn);


            #endregion




            #region order OUT Related


            //maakt een 1 op veel relatie
            modelBuilder.Entity<OrderLineOut>()
                .HasRequired<Product>(b => b.Product)
                .WithMany(a => a.OrderLineOuts)
                .HasForeignKey<string>(b => b.EAN_Product);



            //maakt een 1 op veel relatie
            modelBuilder.Entity<OrderOut>()
                .HasRequired<Client>(b => b.Client)
                .WithMany(a => a.OrderOuts)
                .HasForeignKey<int>(b => b.Id_Client);


            //maakt een 0 of 1 op veel relatie
            modelBuilder.Entity<OrderOut>()
                .HasOptional<Employee>(b => b.SoldBy)
                .WithMany(a => a.OrderOuts_SoldBy)
                .HasForeignKey<int?>(b => b.Id_SoldBy);


            //maakt een 0 of 1 op veel relatie
            modelBuilder.Entity<OrderOut>()
                .HasOptional<Employee>(b => b.PreparedBy)
                .WithMany(a => a.OrderOuts_PreparedBy)
                .HasForeignKey<int?>(b => b.Id_PreparedBy);


            //maakt een 0 of 1 op veel relatie
            modelBuilder.Entity<OrderOut>()
                .HasOptional<Employee>(b => b.InvoiceCreatedBy)
                .WithMany(a => a.OrderOuts_InvoiceCreatedBy)
                .HasForeignKey<int?>(b => b.Id_InvoiceCreatedBy);


            //maakt een 1 op veel relatie
            modelBuilder.Entity<OrderLineOut>()
                .HasRequired<OrderOut>(b => b.OrderOut)
                .WithMany(a => a.OrderLineOuts)
                .HasForeignKey<int>(b => b.Id_OrderOut);


            #endregion





            base.OnModelCreating(modelBuilder);

        }



    }
}
