
using KFSolutionsWPF.Commands;
using KFSolutionsWPF.Views;
using KFSrepository_EF6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using TDS_wpf_extentions2.Transactioncontrol;

namespace KFSolutionsWPF.ViewModels
{
    //public class MainMenuViewModel<Tview> : _appViewModel<Tview> where Tview : UserControl, new()
    public class MainMenuViewModel: _appViewModel
    {
        //==============================================================================

        public string Header { get; set; } = "Hoofd menu";


        //-------------------- navbar -----------------------------
        public ICommand Command_LogOut { get; }


        //-------------------- Magazijnier ------------------------



        //-------------------- Verkoper ---------------------------
        public ICommand Command_Quatations { get; }

        public ICommand Command_NewOrderOut { get; }
        //-------------------- Admin ------------------------------



        //NU MEE BEZIG
        public ICommand Command_EmployeeDetails { get; }
        public ICommand Command_ClientDetails { get; }
        public ICommand Command_SupplierDetails { get; }




        //==============================================================================

        public MainMenuViewModel(AppRepository<KfsContext> aAppDbRepository, TDS_wpf_extentions2.Transactioncontrol.TDStransactionControl aTDStransactionControl) 
            : base(aAppDbRepository, aTDStransactionControl)
        {
            _myView = new MainMenuView();
            _myView.DataContext = this;


            //-------------------- navbar -----------------------------
            Command_LogOut = new RelayCommand(LogOut);

            //-------------------- Magazijnier ------------------------
            Command_NewOrderOut = new RelayCommand( NavigateToOrderOutAddNew);


            //-------------------- Verkoper ---------------------------
            Command_Quatations = new RelayCommand(NavigateToQuatationsViewModel);


            //-------------------- Admin ------------------------------

            //NU MEE BEZIG
            Command_EmployeeDetails = new RelayCommand(NavigateToEmployeeDetails);
            Command_ClientDetails = new RelayCommand(NavigateToClientDetails);
            Command_SupplierDetails = new RelayCommand(NavigateToSupplierDetails);

        }

        private void NavigateToSupplierDetails(object obj)
        {
            _transactionControl.SlideNewContent(new SupplierDetailsViewModel(_appDbRespository, _transactionControl),
                TDStransactionControl.TransactionDirection.Left, 500);
        }

        private void NavigateToClientDetails(object obj)
        {
            _transactionControl.SlideNewContent(new ClientDetailsViewModel(_appDbRespository, _transactionControl),
                    TDStransactionControl.TransactionDirection.Left, 500);
        }

        private void NavigateToEmployeeDetails(object obj)
        {
            _transactionControl.SlideNewContent(new EmployeeDetailsViewModel(_appDbRespository, _transactionControl),
                TDStransactionControl.TransactionDirection.Left, 500);
        }

        private void NavigateToOrderOutAddNew(object obj)
        {
            _transactionControl.SlideNewContent(new OrderOutAddNewViewModel(_appDbRespository, _transactionControl),
                TDStransactionControl.TransactionDirection.Left, 500);
        }

        private void NavigateToQuatationsViewModel(object obj)
        {
            _transactionControl.SlideNewContent(new QuatationsViewModel(_appDbRespository, _transactionControl),
              TDStransactionControl.TransactionDirection.Left, 500);
        }

        private void LogOut(object obj)
        {
            _appDbRespository.Employee.LogOut();
           

            _transactionControl.SlideNewContent(new InloggenViewModel(_appDbRespository, _transactionControl),
                TDStransactionControl.TransactionDirection.Up, 400);
        }
    }
}
