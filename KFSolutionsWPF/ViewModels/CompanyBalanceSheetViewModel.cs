using KFSolutionsModel;
using KFSolutionsWPF.Commands;
using KFSolutionsWPF.Views;
using KFSrepository_EF6;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public OrderOut SelectedOrdersOutFromDBInDatagridDetailsVerkoop { get; set; }


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



            OrdersOutFromDB = _appDbRespository.OrderOut.GetForBalance();

            foreach (var item in OrdersOutFromDB)
            {
                item._FullNameClient = item.Client.FirstName + " " + item.Client.NameAddition + " " + item.Client.LastName;

                foreach (var ol in item.OrderLineOuts)
                {
                    item._TTverkoopPrijs += (ol.NumberOfProducts * ol.UnitPrice);
                    item._AantalStuks += ol.NumberOfProducts;
                }
            }

            OrderOut tmp = new OrderOut();
            //tmp.OrderLineOuts;
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
}

