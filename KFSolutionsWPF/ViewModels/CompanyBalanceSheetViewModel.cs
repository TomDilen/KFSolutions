using KFSolutionsModel;
using KFSolutionsWPF.Commands;
using KFSolutionsWPF.Views;
using KFSrepository_EF6;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TDS_wpf_extentions2.Transactioncontrol;

namespace KFSolutionsWPF.ViewModels
{
    class CompanyBalanceSheetViewModel : _appViewModel
    {

        public string Header { get; set; } = "Bedrijfscijfers";

        //==============================================================================
        public ICommand Command_NavigatBack { get; set; }
        public ICommand Command_ToMainMenu { get; set; }



        //------------------------------------------------------------------------------

        public ICommand Command_ViewInvoiceButtonInDatagridClick { get; set; }

        //==============================================================================
        public List<OrderOut> OrdersOutFromDB { get; set; }
        private List<OrderOut> _OrdersOutFromDB { get; set; }

        public List<OrderIn> OrdersInFromDB { get; set; }
        private List<OrderIn> _OrdersInFromDB { get; set; }

        public List<Product> ProductsFromDBforStock { get; set; }
        private List<Product> _ProductsFromDB { get; set; }


        private List<ProductHelper> _ProductHelpersWorkerList { get; set; }

        public List<ProductHelper> ProductHelpersForProducts { get; set; }
        public ObservableCollection<string> Chart_ProductHelpersForProductsNames { get; set; }
        public ChartValues<int> Chart_ProductHelpersForProductsValues { get; set; }

        public List<ProductHelper> ProductHelpersForEmployees { get; set; }
        public ObservableCollection<string> Chart_ProductHelpersForEmployeesNames { get; set; }
        public ChartValues<int> Chart_ProductHelpersForEmployeesValues { get; set; }



        public OrderOut SelectedOrdersOutFromDBInDatagridDetailsVerkoop { get; set; }




        public double TTsumSolded { get; set; }
        public int TTproduktenSolded { get; set; }

        public double TTsumBuyed { get; set; }
        public int TTproduktenBuyed { get; set; }
        public double TTsumBuyedAfterHandled { get; set; }
        public int TTproduktenBuyedAfterHandled { get; set; }

        public double TTstockValue { get; set; }
        public double TTstockProductCount{ get; set; }

        public string AangkochtStockVerkochtBalance { get; set; }


        private DateTime _selectedDateFrom;
        public DateTime SelectedDateFrom
        {
            get { return _selectedDateFrom; }
            set {
                _selectedDateFrom = value;
                SelectDate();
            }
        }
        private DateTime _selectedDateTo;
        public DateTime SelectedDateTo
        {
            get { return _selectedDateTo; }
            set
            {
                _selectedDateTo = value;
                SelectDate();
            }
        }

        bool IsInit = false;

        //==============================================================================


        public CompanyBalanceSheetViewModel(
            AppRepository<KfsContext> aAppDbRepository, TDStransactionControl aTDStransactionControl)
            : base(aAppDbRepository, aTDStransactionControl)
        {
            _myView = new CompanyBalanceSheetView();
            _myView.DataContext = this;


            Command_NavigatBack = new RelayCommand(NavigateBack);
            Command_ToMainMenu = new RelayCommand(NavigateToMainMenu);


            Command_ViewInvoiceButtonInDatagridClick = new RelayCommand(ViewInvoiceButtonInDatagridClick);


            //===============================================================================
            //data uit db laden
            //===============================================================================

            _OrdersOutFromDB = _appDbRespository.OrderOut.GetForBalance();

            foreach (var item in _OrdersOutFromDB)
            {
                item._FullNameClient = item.Client.FirstName + " " + item.Client.NameAddition + " " + item.Client.LastName;
                item._FullNameEmployeeSolded = item.SoldBy.FirstName + " " + item.SoldBy.NameAddition + " " + item.SoldBy.LastName;
                foreach (var ol in item.OrderLineOuts)
                {
                    item._TTverkoopPrijs += (ol.NumberOfProducts * ol.UnitPrice);
                    item._AantalStuks += ol.NumberOfProducts;
                }
            }

            //-----------------------------------------------------------------------------------------

            _OrdersInFromDB = _appDbRespository.OrderIn.GetForBalance();

            foreach (var item in _OrdersInFromDB)
            {
                if (item.HandledBy != null)
                {
                    item._FullNameEmployeeHandledBy = item.HandledBy.FirstName + " " + item.HandledBy.NameAddition + " " + item.HandledBy.LastName;
                }
                item._FullNameEmployeeOrderedBy = item.OrderedBy.FirstName + " " + item.OrderedBy.NameAddition + " " + item.OrderedBy.LastName;
                //item._FullNameSupplier = item.Supplier. + " " + item.OrderedBy.NameAddition + " " + item.OrderedBy.LastName;

                foreach (var ol in item.OrderLineIns)
                {
                    item._TTaankoopPrijs += (ol.NumberOfProducts * ol.UnitPrice);
                    item._AantalStuks += (ol.NumberOfProducts);
                }
            }

            //-----------------------------------------------------------------------------------------

            _ProductsFromDB = _appDbRespository.Product.GetForBalance();

            foreach (var item in _ProductsFromDB)
            {
                item.CalculatatedStockValue = item.CountInStock * item.SellingPriceRecommended;
            }


            //-----------------------------------------------------------------------------------------
            _ProductHelpersWorkerList = new List<ProductHelper>();
            foreach (var item in _OrdersOutFromDB)
            {
                foreach (var ol in item.OrderLineOuts)
                {
                    _ProductHelpersWorkerList.Add(new ProductHelper()
                    {
                        EAN = ol.EAN_Product,
                        ProductTitle = ol.Product.ProductTitle,
                        UnitPrice = ol.UnitPrice,
                        NumberOfProducts = ol.NumberOfProducts,
                        TTPrice = ol.UnitPrice * ol.NumberOfProducts,
                        DateSaled = (DateTime)item.SoldAt,
                        EmpSaled = item.SoldBy,
                        EmpFullName = item.SoldBy.FirstName + " " + item.SoldBy.NameAddition + " " + item.SoldBy.LastName,


                    }) ;
                }
  
            }





            //===============================================================================
            //datums juist zetten waar publics worden geinit
            //===============================================================================

            SelectedDateFrom = DateTime.Now.AddDays(-7).Date;
            SelectedDateTo = DateTime.Now.Date;

            IsInit = true;
            SelectDate();

        }

        private void SelectDate()
        {
            if (IsInit == false) return;

            Console.WriteLine(_selectedDateFrom);
            Console.WriteLine(_selectedDateTo);

            if (_selectedDateFrom > _selectedDateTo)
            {
                MessageBox.Show("Geselecteerde datum 'Van' kan niet later zijn dan 'tot', de datum 'van' is gelijk gesteld op 'tot'");
                _selectedDateFrom = _selectedDateTo;
            }

            DateTime tot = _selectedDateTo.AddDays(1);




            //==================================================== oreders out
            OrdersOutFromDB = _OrdersOutFromDB.Where( x => 
                x.PreparedAt >= SelectedDateFrom &&
                x.PreparedAt < tot
                )
                .ToList();

            TTsumSolded = OrdersOutFromDB.Sum(x => x._TTverkoopPrijs);
            TTproduktenSolded = OrdersOutFromDB.Sum(x => x._AantalStuks);

            //====================================================== orders in
            OrdersInFromDB = _OrdersInFromDB.Where(x =>
                x.OrderedAt >= SelectedDateFrom &&
                x.OrderedAt < tot
            ).ToList();

            TTsumBuyed = OrdersInFromDB.Where(x => x.HandledBy != null).Sum(x => x._TTaankoopPrijs);
            TTproduktenBuyed = OrdersInFromDB.Where(x => x.HandledBy != null).Sum(x => x._AantalStuks);
            TTsumBuyedAfterHandled = OrdersInFromDB.Sum(x => x._TTaankoopPrijs);
            TTproduktenBuyedAfterHandled = OrdersInFromDB.Sum(x => x._AantalStuks);

            //====================================================== stock details
            ProductsFromDBforStock = _ProductsFromDB;
            TTstockValue = ProductsFromDBforStock.Sum(x => x.CalculatatedStockValue);
            TTstockProductCount = ProductsFromDBforStock.Sum(x => x.CountInStock);

            //========================================================ProductHelpersForProducts

            ProductHelpersForProducts = new List<ProductHelper>();
            foreach (var item in _ProductHelpersWorkerList)
            {
                if (item.DateSaled < SelectedDateFrom || item.DateSaled >= tot) continue;

                //kijken of EAN al voorkomt in lijst
                ProductHelper gevonden = null;
                foreach (var listItem in ProductHelpersForProducts)
                {
                    if (listItem.EAN == item.EAN) { 
                        gevonden = listItem; break; 
                    }
                }
                //komt niet voor
                if (gevonden == null)
                {
                    //hard copy, geen shadow
                    ProductHelpersForProducts.Add(new ProductHelper() { 
                        EAN = item.EAN,
                        DateSaled = item.DateSaled,
                        EmpFullName = "NVT",
                        EmpSaled = item.EmpSaled,
                        ProductTitle = item.ProductTitle,
                        UnitPrice = item.UnitPrice, //niet van belang
                        NumberOfProducts = item.NumberOfProducts,
                        TTPrice = item.NumberOfProducts * item.UnitPrice,
                    });
                }
                else
                {
                    gevonden.NumberOfProducts += item.NumberOfProducts;
                    gevonden.TTPrice += item.NumberOfProducts * item.UnitPrice;
                }
            }

            ProductHelpersForProducts = ProductHelpersForProducts.OrderByDescending(x => x.NumberOfProducts).ToList();

            Chart_ProductHelpersForProductsNames = new ObservableCollection<string>();
            Chart_ProductHelpersForProductsValues = new ChartValues<int>();
            foreach (var item in ProductHelpersForProducts)
            {
                Chart_ProductHelpersForProductsNames.Add(item.ProductTitle);
                Chart_ProductHelpersForProductsValues.Add(item.NumberOfProducts);
            }



            //========================================================ProductHelpersForEmployees
            ProductHelpersForEmployees = new List<ProductHelper>();
            foreach (var item in _ProductHelpersWorkerList)
            {
                if (item.DateSaled < SelectedDateFrom || item.DateSaled >= tot) continue;

                //kijken of EAN al voorkomt in lijst
                ProductHelper gevonden = null;
                foreach (var listItem in ProductHelpersForEmployees)
                {
                    if (listItem.EmpSaled.Id == item.EmpSaled.Id)
                    {
                        gevonden = listItem; break;
                    }
                }
                //komt niet voor
                if (gevonden == null)
                {
                    //hard copy, geen shadow
                    ProductHelpersForEmployees.Add(new ProductHelper()
                    {
                        EAN = "nvt",
                        DateSaled = item.DateSaled,
                        EmpFullName = item.EmpFullName,
                        EmpSaled = item.EmpSaled,
                        ProductTitle = item.ProductTitle,
                        UnitPrice = item.UnitPrice, //niet van belang
                        NumberOfProducts = item.NumberOfProducts,
                        TTPrice = item.NumberOfProducts * item.UnitPrice,
                    });
                }
                else
                {
                    gevonden.NumberOfProducts += item.NumberOfProducts;
                    gevonden.TTPrice += item.NumberOfProducts * item.UnitPrice;
                }
            }

            ProductHelpersForEmployees = ProductHelpersForEmployees.OrderByDescending(x => x.NumberOfProducts).ToList();

            Chart_ProductHelpersForEmployeesNames = new ObservableCollection<string>();
            Chart_ProductHelpersForEmployeesValues= new ChartValues<int>();
            foreach (var item in ProductHelpersForEmployees)
            {
                Chart_ProductHelpersForEmployeesNames.Add(item.EmpFullName);
                Chart_ProductHelpersForEmployeesValues.Add(item.NumberOfProducts);
            }


            int balance = TTproduktenBuyed - (int)TTstockProductCount - TTproduktenSolded;
            AangkochtStockVerkochtBalance = $"{TTproduktenBuyed}-{TTstockProductCount}-{TTproduktenSolded}={balance}";


        }


        private void ViewInvoiceButtonInDatagridClick(object obj)
        {
            //Console.WriteLine("geklikt op view => " + SelectedOrdersOutFromDBInDatagridDetailsVerkoop.Id);
            string filename = PDF.PDFinvoice.Create(SelectedOrdersOutFromDBInDatagridDetailsVerkoop.Id, _appDbRespository);
            Process.Start(filename);
        }

        private void NavigateToMainMenu(object obj)
        {
            _transactionControl.SlideNewContent(
                new MainMenuViewModel(_appDbRespository, _transactionControl),
                TDStransactionControl.TransactionDirection.Right, 500);
        }

        private void NavigateBack(object obj)
        {
            _transactionControl.SlideNewContent(
                new MainMenuViewModel(_appDbRespository, _transactionControl),
                TDStransactionControl.TransactionDirection.Right, 500);
        }



    }

    public class ProductHelper
    {
        public string EAN { get; set; }
        public string ProductTitle { get; set; }

        public DateTime DateSaled { get; set; }
        public Employee EmpSaled { get; set; }

        public string EmpFullName { get; set; }

        public double UnitPrice { get; set; }

        public int NumberOfProducts { get; set; }
        public double TTPrice { get; set; }
    }
}

