using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KFSolutionsModel;
using static KFSrepository_EF6.ProductRepository;

namespace KFSrepository_EF6
{


    public interface IProductRepository : ITDSrepository<Product>
    {
        ProductsForStockManagementPackageDTO GetAllForStockManagement();
        List<string> GetExistingEANsFromEanList(List<string> aListEANs);

        List<Product> GetAllforOrderOut();

        List<Product> GetAllForOverview();

        Product Update(Product aProduct);

        List<Product> GetForBalance();
    }

    public class ProductRepository : TDSrepository<Product>, IProductRepository
    {
        public ProductRepository(string aConnectionstring) : base(aConnectionstring)
        {

        }

        public List<string> GetExistingEANsFromEanList(List<string> aListEANs)
        {
            List<string> terug = new List<string>();
            using (KfsContext ctx = new KfsContext(_constring))
            {
                foreach (var item in aListEANs)
                {
                    var gevonden = ctx.Set<Product>()
                        .Select(p => p.EAN)
                        .FirstOrDefault(pean => pean == item);
                    
                    if (!string.IsNullOrEmpty(gevonden)) terug.Add(gevonden);
                }
            }
            return terug;
        }
        public ProductsForStockManagementPackageDTO GetAllForStockManagement()
        {
            ProductsForStockManagementPackageDTO terug = new ProductsForStockManagementPackageDTO();

            List<ProductForStockDTO> opgehaald;
            List<SupplierMinDTO> opgehaaldSupplierMin;

            List<int> tmp = new List<int>();

            using (KfsContext ctx = new KfsContext(_constring))
            {
                //ophalen van data 
                //gegroepeerd per EAN en employeeId en hieruit enkel het laatste id nemen, datum ontbrak :-(
                opgehaald = ctx.Products.Join(ctx.Supplier_Product_Prices,
                     p => p.EAN,
                     spp => spp.EAN_Product,
                     (p, ssp) => new ProductForStockDTO()
                     {
                         EAN = p.EAN,
                         ProductTittle = p.ProductTitle,
                         CountInStock = p.CountInStock,
                         MinCountInStock = p.MinCountInStock,
                         MaxCountInStock = p.MaxCountInStock,
                         WareHouseLocation = p.WareHouseLocation,
                         UnitPrice = ssp.UnitPrice,
                         ID_Supplier = ssp.Id_Supplier,
                         OploopNummer = ssp.Id,
                     })
                    .GroupBy(x => new { x.ID_Supplier, x.EAN }).Select(g => g.OrderByDescending(y => y.OploopNummer).FirstOrDefault())
                    //.OrderByDescending(x => x).Take(100)
                    .ToList();

                Console.WriteLine("===================================================================");
                foreach (var item in opgehaald)
                {
                    int xxx = 0;
                    try
                    {
                        xxx = ctx.OrderIns.Join(ctx.OrderLineIns,
                             o => o.Id,
                             ol => ol.Id_OrderIn,
                             (o, ol) => new
                             {
                                 idAfgehandeld = o.Id_HandledBy,
                                 EAN = ol.EAN_Product,
                                 NumOfProducts = ol.NumberOfProducts,
                             })
                             .Where(x => x.EAN == item.EAN && x.idAfgehandeld == null).Select(x => x.NumOfProducts).Sum();
                    }
                    catch { }

                    item.CountInProgress = xxx;
                }
                Console.WriteLine("===================================================================");



                //id's van de suppliers die betrekking hebben op de gevonden lijst distincten
                tmp = opgehaald.Select(x => x.ID_Supplier).Distinct().ToList();


                opgehaaldSupplierMin = ctx.Suppliers
                               .Where(t => tmp.Contains(t.Id))
                                .Select(s => new SupplierMinDTO()
                                {
                                    Name = s.Name,
                                    Id = s.Id
                                })
                               .ToList();
            }

            foreach (var item in opgehaald)
            {
                item.SuplierName = opgehaaldSupplierMin.Where(x => x.Id == item.ID_Supplier).Select(x=>x.Name).FirstOrDefault();
                //1 als bijbestellen nodig is
                item.IsOrderNeeded = (item.CountInStock + item.CountInProgress) < item.MinCountInStock;
            }

            //Console.WriteLine("===================================================");

            //foreach (var item in opgehaaldSupplierMin)
            //{
            //    //Console.WriteLine(item.EAN +"," + item.ID_Supplier + "," + item.UnitPrice);
            //    //Console.WriteLine(item);
            //    Console.WriteLine(item.Id + ":" + item.Name);
            //}

            //Console.WriteLine("===================================================");

            terug.ProductForStockDTO = opgehaald;
            terug.SupplierMinkDTO = opgehaaldSupplierMin;

            return terug;
        }

        public List<Product> GetAllforOrderOut()
        {
            List<Product> terug = new List<Product>();

            using (KfsContext ctx = new KfsContext(_constring))
            {
                terug = ctx.Products
                    .Include(nameof(Product.ProductType))
                    .ToList();
            }
            return terug;
        }


        public List<Product> GetAllForOverview()
        {
            List<Product> terug = new List<Product>();
            using (KfsContext ctx = new KfsContext(_constring))
            {
                terug = ctx.Set<Product>()
                    .Include(nameof(Product.Supplier_Product_Prices))
                    .Include(nameof(Product.Supplier_Product_Prices) +"."+ nameof(Supplier_Product_Price.Supplier))
                    //.Include(nameof(Employee.EmpContract) + "." + nameof(EmpContract.EmpContractStatuutType))
                    //.Include(nameof(Employee.EmpContract) + "." + nameof(EmpContract.EmpContractType))
                    //.Include(nameof(Employee.EmpAppAccount))
                    .ToList();
            }
            return terug;
        }



        public Product Update(Product aProduct)
        {
            Product gevonden = null;


            using (KfsContext ctx = new KfsContext(_constring))
            {
                gevonden = ctx.Set<Product>()
                    .FirstOrDefault(u => u.EAN == aProduct.EAN);

                if (gevonden == null)
                {
                    throw new DuplicateNameException($"user with {aProduct.EAN} not exist");
                }

                ctx.Entry(gevonden).CurrentValues.SetValues(aProduct);
                //ctx.Entry(gevonden.EmpAddress).CurrentValues.SetValues(aEmployee.EmpAddress);
                //ctx.Entry(gevonden.EmpContract).CurrentValues.SetValues(aEmployee.EmpContract);
                //ctx.Entry(gevonden.EmpAppAccount).CurrentValues.SetValues(aEmployee.EmpAppAccount);
                ctx.SaveChanges();

            }


            return gevonden;
        }

        public List<Product> GetForBalance()
        {
            List<Product> terug = new List<Product>();

            using (KfsContext ctx = new KfsContext(_constring))
            {
                terug = ctx.Products
                    
                    ////.Include(nameof(OrderOut.Client) + "." + nameof(Client.CltAddresss))
                    //.Include(nameof(OrderIn.OrderLineIns))
                    //.Include(nameof(OrderIn.OrderLineIns) + "." + nameof(OrderLineIn.OrderIn))
                    //.Include(nameof(OrderIn.OrderedBy))
                    //.Include(nameof(OrderIn.HandledBy))
                    .ToList();
            }

            return terug;
        }

        public List<Product> GetForSalesBalance()
        {
            List<Product> terug = new List<Product>();

            using (KfsContext ctx = new KfsContext(_constring))
            {
                terug = ctx.Products

                    ////.Include(nameof(OrderOut.Client) + "." + nameof(Client.CltAddresss))
                    //.Include(nameof(OrderIn.OrderLineIns))
                    //.Include(nameof(OrderIn.OrderLineIns) + "." + nameof(OrderLineIn.OrderIn))
                    //.Include(nameof(OrderIn.OrderedBy))
                    //.Include(nameof(OrderIn.HandledBy))
                    .ToList();
            }

            return terug;
        }



        public class ProductsForStockManagementPackageDTO : BaseDTO
        {
            public List<ProductForStockDTO> ProductForStockDTO { get; set; } = new List<ProductForStockDTO>();
            public List<SupplierMinDTO> SupplierMinkDTO { get; set; } = new List<SupplierMinDTO>();

        }
        public class ProductForStockDTO : BaseDTO
        {
            public int OploopNummer { get; set; }//om de laatste er uit te krijgen
            public bool IsChecked { get; set; } = false;
            public string EAN { get; set; }
            public string ProductTittle { get; set; }
            public int CountInStock { get; set; }
            public int MinCountInStock { get; set; }
            public int CountInProgress { get; set; }
            public int MaxCountInStock { get; set; }
            public string WareHouseLocation { get; set; }


            public int ID_Supplier { get; set; }
            public string SuplierName { get; set; }
            public float UnitPrice { get; set; }

            public bool IsOrderNeeded { get; set; }
        }
        public class SupplierMinDTO : BaseDTO
        {
            public int Id { get; set; }
            public string Name { get; set; }



        }
    }

}

