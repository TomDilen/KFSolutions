using KFSolutionsModel;
using KFSolutionsWPF.Commands;
using KFSolutionsWPF.DialogWindows;
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

namespace KFSolutionsWPF.ViewModels
{
    public class OrderOutAddNewViewModel : _appViewModel
    {

        //==============================================================================

        public string Header { get; set; } = "Order voor klant";


        public ICommand Command_NavigatBack { get; set; }
        public ICommand Command_ToMainMenu { get; set; }
        public ICommand Command_Save { get; set; }
        public ICommand Command_SeeInvoice { get; set; }
        public ICommand Command_NewClient { get; set; }
        public ICommand Command_ClearOrder { get; set; }


        public ICommand Command_DataGridProductsButtonclick { get; set; }
        public ICommand Command_DataGridOrdersButtonclick { get; set; }


        //------------------------------------------------------from DB
        public List<Client> ClientsAll { get; set; }

        public List<Product> ProductsAll { get; set; }

        //-------------------------------------------------------------
        public Product SelectedProductFromAssortiment { get; set; }
        public Client SelectedClient { get; set; }


        public ObservableCollection<InternalOrderlineHelper> ProductsOrdered { get; set; }
        public InternalOrderlineHelper SelectedProductOrdered { get; set; }


        

        private List<Product> _workingProductList;
        private bool _isSavedToDB = false;
        //==============================================================================


        public OrderOutAddNewViewModel(
            AppRepository<KfsContext> aAppDbRepository, TDStransactionControl aTDStransactionControl)
            : base(aAppDbRepository, aTDStransactionControl)
        {
            _myView = new OrderOutAddNewView();
            _myView.DataContext = this;

            Command_NavigatBack = new RelayCommand(NavigateBack);
            Command_ToMainMenu = new RelayCommand(NavigateToMainMenu);
            Command_Save = new RelayCommand(SaveToDB, CanSaveToDB);
            Command_SeeInvoice = new RelayCommand(SeeInvoice, CanSeeInvoice);
            Command_NewClient = new RelayCommand(NavigateToNewclient);
            Command_ClearOrder = new RelayCommand(ClearOrder); 


            Command_DataGridProductsButtonclick = new RelayCommand(DataGridProductsButtonclick);
            Command_DataGridOrdersButtonclick = new RelayCommand(DataGridOrdersButtonclick);

            //moeilijk doen over ICollection :-(
            ClientsAll = _appDbRespository.Client.GetAllClientsWithAdress();
            foreach (Client clnt in ClientsAll)
            {
                clnt.CltAddresssAsList = clnt.CltAddresss.ToList();
            }

            
            RefreshData();
        }









        //------------------------------------------------------------------------------------------
        private void RefreshData()
        {
            Console.WriteLine("refresh data");
            //deze wel terug laden bij refresh, omdat stockcount aangepast wordt
            _workingProductList = _appDbRespository.Product.GetAllforOrderOut();
            ProductsAll = _workingProductList;

            ProductsOrdered = new ObservableCollection<InternalOrderlineHelper>();

            SelectedClient = null;
            _isSavedToDB = false;
        }


        //====================================================================================================================
        private void DataGridProductsButtonclick(object obj)
        {
            //Console.WriteLine("datagrid doubleclick => " + SelectedProductFromAssortiment.ProductTitle);

            int maxCountToOrder = SelectedProductFromAssortiment.CountInStock -
                ProductsOrdered
                    .Where(x => x.EAN == SelectedProductFromAssortiment.EAN)
                    .Select(x => x.Count)
                    .Sum();

            if (maxCountToOrder < 1)
            {
                MessageBox.Show("Je kan dit produkt niet verkopen, de stock is leeg");
                return;
            }


            FrmSetNumberOfProductsByOrdersOut frm = new FrmSetNumberOfProductsByOrdersOut(
                _transactionControl, SelectedProductFromAssortiment, maxCountToOrder);



            if (frm.ShowDialog()==true)
            {
                float prijsZonderBtw = frm.SelectedCount * SelectedProductFromAssortiment.SellingPriceRecommended;
                float btwToeslag = prijsZonderBtw / 100 * SelectedProductFromAssortiment.BTWpercentage;
                ProductsOrdered.Add(new InternalOrderlineHelper()
                {
                    Count = frm.SelectedCount,
                    EAN = SelectedProductFromAssortiment.EAN,
                    _BTWaddition = btwToeslag,
                    UnitPrice = SelectedProductFromAssortiment.SellingPriceRecommended,
                    _BtwPercentage = SelectedProductFromAssortiment.BTWpercentage,
                    _calculatedPriceWithoutBTW = prijsZonderBtw,
                    _calculatedPriceWithBtw = prijsZonderBtw + btwToeslag,
                    _ProduktTitle = SelectedProductFromAssortiment.ProductTitle,
                }) ;
                Console.WriteLine("update" + ProductsOrdered.Count);
            };

        }
        private void DataGridOrdersButtonclick(object obj)
        {
            ProductsOrdered.Remove(SelectedProductOrdered);
        }
        private bool CanSaveToDB(object obj)
        {
            if (_isSavedToDB) return false;
            if (SelectedClient == null) return false;
            if (ProductsOrdered.Count == 0) return false;
            return true;
        }

        private void ClearOrder(object obj)
        {
            if (_isSavedToDB)
            {
                RefreshData();
            }
          

            else if(ProductsOrdered.Count > 0 )
            {
                if( MessageBoxResult.No ==
                    MessageBox.Show("U hebt de gegevens nog niet geregistreerd, wil u toch opnieuw beginnen?", "opnieuw" , 
                        MessageBoxButton.YesNo, MessageBoxImage.Question))
                {
                    return;
                }
            }
            SelectedClient = null;
            ProductsOrdered.Clear();
            _isSavedToDB = false;
        }


        private void SaveToDB(object obj)
        {


            List<OrderLineOut> lines = new List<OrderLineOut>();
            foreach (var item in ProductsOrdered)
            {
                lines.Add(new OrderLineOut() { 
                    EAN_Product = item.EAN, UnitPrice = item.UnitPrice, NumberOfProducts = item.Count ,
                });
            }
            DateTime nu = DateTime.Now;
            OrderOut bestelling = new OrderOut()
            {
                Id_Client = SelectedClient.Id,
                OrderLineOuts = lines,
                Id_InvoiceCreatedBy = _appDbRespository.Employee.InloggedEmployee.Id,
                Id_PreparedBy = _appDbRespository.Employee.InloggedEmployee.Id,
                Id_SoldBy = _appDbRespository.Employee.InloggedEmployee.Id,
                InvoiceCreatedAt = nu,
                PreparedAt = nu,
                SoldAt = nu,
            };


            try
            {
                _appDbRespository.OrderOut.Add(bestelling);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.InnerException);
                return;
            }
            MessageBox.Show("Verkoop met succes geregistreerd");

            //enkel als effectief gesaved is
            _isSavedToDB = true;



            Console.WriteLine("=======================PDF===============");

            OrderOut orderToPrint = bestelling;



        }
        private bool CanSeeInvoice(object obj)
        {
            return _isSavedToDB;
        }

        private void SeeInvoice(object obj)
        {
            Console.WriteLine("makeinvoice");
        }

        private void NavigateToMainMenu(object obj)
        {
            if (ProductsOrdered.Count > 0)
            {
                if (MessageBoxResult.No ==
                    MessageBox.Show("U hebt de gegevens nog niet geregistreerd, wil u toch weg gaan?", "weg gaan?",
                        MessageBoxButton.YesNo, MessageBoxImage.Exclamation))
                {
                    return;
                }
            }
            _transactionControl.SlideNewContent(
                new MainMenuViewModel(_appDbRespository, _transactionControl),
                TDStransactionControl.TransactionDirection.Right, 500);
        }

        private void NavigateBack(object obj)
        {
            if (ProductsOrdered.Count > 0)
            {
                if (MessageBoxResult.No ==
                    MessageBox.Show("U hebt de gegevens nog niet geregistreerd, wil u toch weg gaan?", "weg gaan?",
                        MessageBoxButton.YesNo, MessageBoxImage.Exclamation))
                {
                    return;
                }
            }
            _transactionControl.SlideNewContent(
                new MainMenuViewModel(_appDbRespository, _transactionControl),
                TDStransactionControl.TransactionDirection.Right, 500);
        }
        private void NavigateToNewclient(object obj)
        {
            if (ProductsOrdered.Count > 0)
            {
                if (MessageBoxResult.No ==
                    MessageBox.Show("U hebt de gegevens nog niet geregistreerd, wil u toch weg gaan?", "weg gaan?",
                        MessageBoxButton.YesNo, MessageBoxImage.Exclamation))
                {
                    return;
                }
            }
            _transactionControl.SlideNewContent(
                new ClientAddNewViewModel(_appDbRespository, _transactionControl),
                TDStransactionControl.TransactionDirection.Left, 500);
        }


















        public class InternalOrderlineHelper : INotifyPropertyChanged
        {
            public string EAN { get; set; }
            public int Count { get; set; }
            public float UnitPrice { get; set; }

            public float _BTWaddition { get; set; }
            public string _ProduktTitle { get; set; }
            public float _BtwPercentage { get; set; }

            public float _calculatedPriceWithoutBTW { get; set; }
            public float _calculatedPriceWithBtw { get; set; }

            public event PropertyChangedEventHandler PropertyChanged;
        }

    }
}

