using KFSolutionsModel;
using KFSolutionsWPF.Commands;
using KFSolutionsWPF.TDS;
using KFSolutionsWPF.Views;
using KFSrepository_EF6;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TDS_wpf_extentions2.Transactioncontrol;
using static KFSrepository_EF6.ProductRepository;

namespace KFSolutionsWPF.ViewModels
{
    public class StockManagementViewModel : _appViewModel
    {
        public string Header { get; set; } = "Stockbeheer";
        //===========================================================================================================
        public List<ProductForStockDTO> ProductsAll { get; set; }

        public ProductForStockDTO SelectedProduct { get; set; }

        

        public List<TemporyOrderedOuts> AvailableTempOrdersOutdependentOfSelectedProduct { get; set; }
        public List<TemporyOrderedOuts> OrdersInSelected { get; set; }

        private List<TemporyOrderedOuts> _workingTempOrdersOut { get; set; }


        private int CanSave_CounterOrdersSelected = 0;


        //-------------------------------------------------------------------------------------
        public ICommand Command_NavigatBack { get; set; }
        public ICommand Command_ToMainMenu { get; set; }
        public ICommand Command_Save { get; set; }


        public ICommand Command_DataGridProductSelectionChanged { get; set; }


        public ICommand Command_CheckInDatagridSuppliers { get; set; }
        //===========================================================================================================


        public StockManagementViewModel(
            AppRepository<KfsContext> aAppDbRepository, TDStransactionControl aTDStransactionControl)
            : base(aAppDbRepository, aTDStransactionControl)
        {
            _myView = new StockManagementView();
            _myView.DataContext = this;


            Command_NavigatBack = new RelayCommand(NavigateBack);
            Command_ToMainMenu = new RelayCommand(NavigateToMainMenu);
            Command_Save = new RelayCommand(SaveToDB, CanSaveToDB);


            Command_DataGridProductSelectionChanged = new RelayCommand(DataGridProductSelectionChanged);
            Command_CheckInDatagridSuppliers = new RelayCommand(CheckInDatagridSuppliers);



            RefreschData();

        }



        private bool CanSaveToDB(object obj)
        {
            return CanSave_CounterOrdersSelected>0;
        }

        private void SaveToDB(object obj)
        {
            foreach (var item in OrdersInSelected)
            {
                if (item.SettedCount < 1)
                {
                    MessageBox.Show( $"u diente een numerieke waarde in te geven dat hoger" +
                        $" ligt dan 0 in de kolom 'Aantal' in rij '{item.ProductName}'" , 
                        "validatie fout", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }


            //orderins opbouwen
            //============================

            var idsSuppliers = OrdersInSelected.Select(x => x.ID_supplier).Distinct();

            List<OrderIn> lstOrderInsBuilded = new List<OrderIn>();

            foreach (var item in idsSuppliers)
            {
                OrderIn newOrder = new OrderIn()
                {
                    Id_OrderedBy = _appDbRespository.Employee.InloggedEmployee.Id,
                    Id_Supplier = item,
                    OrderedAt = DateTime.Now,
                };
                newOrder.OrderLineIns = new List<OrderLineIn>();
                foreach (var ordselctd in OrdersInSelected)
                {
                    if (ordselctd.ID_supplier == item)
                    {
                        newOrder.OrderLineIns.Add(
                            new OrderLineIn()
                            {
                                EAN_Product = ordselctd.EAN,
                                UnitPrice = ordselctd.UnitPrice,
                                NumberOfProducts = ordselctd.SettedCount
                            });
                    }
                }
                lstOrderInsBuilded.Add(newOrder);
            }

            //messagebox string opbouwen (ook test)
            //==========================================

            StringBuilder sb = new StringBuilder();

            foreach (var buildedOrder in lstOrderInsBuilded)
            {
                sb.Append("\n" + OrdersInSelected.Where(x => x.ID_supplier == buildedOrder.Id_Supplier).Select(x => x.Name_supplier).FirstOrDefault() + "\n");
                sb.Append("===============================\n");
                foreach (var item in buildedOrder.OrderLineIns)
                {
                    sb.Append($"Aantal: {item.NumberOfProducts}  \tEAN: {item.EAN_Product} \n");
                }
            }


            //save to db
            //==========

            if (MessageBoxResult.Yes ==
                MessageBox.Show("wil je de volgende bestellingen verzenden naar de leverancier(s)?\n" +
                    sb.ToString(),
                    "Verzend Bestellingen naar leverancier", MessageBoxButton.YesNo, MessageBoxImage.Question))
            {
                foreach (var item in lstOrderInsBuilded)
                {
                    try
                    {
                        _appDbRespository.OrderIn.Add(item);
                        
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message + ex.InnerException);
                        return;
                    }
                    MessageBox.Show("Bestellingen met succes geregistreerd");
                }

                RefreschData();
            }

        }

        private void RefreschData()
        {
            CanSave_CounterOrdersSelected = 0;
            //package uit db halen
            ProductsForStockManagementPackageDTO _ProductsForStockManagement =
                _appDbRespository.Product.GetAllForStockManagement();


            ProductsAll = _ProductsForStockManagement.ProductForStockDTO.DistinctBy(p => p.EAN).Select(x => x).ToList();
            AvailableTempOrdersOutdependentOfSelectedProduct = null;
            OrdersInSelected = null;

            //werkLijst maken van TemporyOrderedOuts objecten
            _workingTempOrdersOut = _ProductsForStockManagement.ProductForStockDTO
                      //.Where(x => x.EAN == SelectedProduct.EAN)
                      .Select(p => new TemporyOrderedOuts
                      {
                          EAN = p.EAN,
                          ProductName = p.ProductTittle,
                          CalculatedCount = Math.Max( p.MaxCountInStock - p.CountInStock - p.CountInProgress, 1),
                          SettedCount = Math.Max(p.MaxCountInStock - p.CountInStock - p.CountInProgress, 1),
                          UnitPrice = p.UnitPrice,
                          ID_supplier = p.ID_Supplier,
                          Name_supplier = p.SuplierName,
                          IsChecked = false,
                      })
                      .OrderBy(x => x.UnitPrice)
                      .ToList();
        }

        private void DataGridProductSelectionChanged(object obj)
        {
            if (SelectedProduct == null)
            {
                //Console.WriteLine("SelectedProduct=null");
                AvailableTempOrdersOutdependentOfSelectedProduct = null;
            }
            else
            {
                AvailableTempOrdersOutdependentOfSelectedProduct = _workingTempOrdersOut
                    .Where(x => x.EAN == SelectedProduct.EAN)
                    .ToList();
            }
            
        }
        
        private void CheckInDatagridSuppliers(object obj)
        {

            int teller = 0;
            foreach (var item in AvailableTempOrdersOutdependentOfSelectedProduct)
                if (item.IsChecked == true) teller++;



            //komt altijd van 1, dus alle IsBefore afzetten
            if (teller == 0) 
            {
                foreach (var item in AvailableTempOrdersOutdependentOfSelectedProduct)
                {
                    item.IsBeforeChecked = false;
                    item.SettedCount = item.CalculatedCount;
                }
            }
            //komt altijd van 0
            else if (teller == 1) 
            {
                foreach (var item in AvailableTempOrdersOutdependentOfSelectedProduct)
                    if(item.IsChecked) item.IsBeforeChecked = true;
            }
            //komt altijd van 1, dus 
            //kijken of vorige geset was, dan deze afzetten (incl before), 
            //before setten voor geschekte welke before niet geset was
            else
            {
                foreach (var item in AvailableTempOrdersOutdependentOfSelectedProduct)
                {
                    if (item.IsChecked && item.IsBeforeChecked)
                    {
                        item.IsBeforeChecked = false; item.IsChecked = false;
                        item.SettedCount = item.CalculatedCount;
                    }
                    else if(item.IsChecked)
                    {
                        item.IsBeforeChecked = true;
                    }
                }
            }
            //Console.WriteLine("--------------------------------------------");
            //foreach (var item in AvailableTempOrdersOutdependentOfSelectedProduct)
            //{
            //    Console.WriteLine(item.Name_supplier + "\t" + item.IsChecked);
            //}

            //Console.WriteLine("--------------------------------------------");

            //de property ischecked bijwerken van AllProducts
            foreach (var Prod in ProductsAll)
            {
                foreach (var item in AvailableTempOrdersOutdependentOfSelectedProduct)
                {
                    if (item.EAN == Prod.EAN) { 
                        Prod.IsChecked = item.IsChecked; 
                        if(item.IsChecked)
                            break; 
                    };
                }
            }

            //de data source bijwerken voor de bestellingen
            OrdersInSelected = _workingTempOrdersOut
                .Where(x => x.IsChecked == true)
                .ToList();

            CanSave_CounterOrdersSelected = OrdersInSelected.Count();



        }

        //===========================================================================================================
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


        //============================================================================================================
        


        public class TemporyOrderedOuts : INotifyPropertyChanged
        {
            public bool IsChecked { get; set; } = false;
            public bool IsBeforeChecked { get; set; } = false;
            public string EAN { get; set; }
            public int CalculatedCount { get; set; }
            public int SettedCount { get; set; }
            public float UnitPrice { get; set; }
            public int ID_supplier { get; set; }
            //visual
            public string ProductName { get; set; }
            public string Name_supplier { get; set; }

            

            public event PropertyChangedEventHandler PropertyChanged;
        }

    }
}

