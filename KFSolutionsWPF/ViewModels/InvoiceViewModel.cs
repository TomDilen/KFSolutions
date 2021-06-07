using KFSolutionsWPF.Commands;
using KFSolutionsWPF.Views;
using KFSrepository_EF6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TDS_wpf_extentions2.Transactioncontrol;

namespace KFSolutionsWPF.ViewModels
{
    public class InvoiceViewModel : _appViewModel
    {

        //==============================================================================

        public ICommand Command_NavigatBack { get; set; }
        public ICommand Command_ToMainMenu { get; set; }
        public ICommand Command_Print{ get; set; }

        public Uri BrowserUri { get; set; }
        //==============================================================================


        public InvoiceViewModel(
               AppRepository<KfsContext> aAppDbRepository, TDStransactionControl aTDStransactionControl)
            : base(aAppDbRepository, aTDStransactionControl)
        {
            _myView = new InvoiceView();
            _myView.DataContext = this;


            Command_NavigatBack = new RelayCommand(NavigateBack);
            Command_ToMainMenu = new RelayCommand(NavigateToMainMenu);
            Command_Print = new RelayCommand(Print);

            //BrowserUri. = @"C:\Users\Tompie_HD2\source\repos\KFSolutions\KFSolutionsWPF\bin\Debug\accountancy\invoices\CV_dilenTom.pdf";

        }
        //C:\Users\Tompie_HD2\source\repos\KFSolutions\KFSolutionsWPF\bin\Debug\accountancy\invoices\CV_dilenTom.pdf

        private void Print(object obj)
        {
            Console.WriteLine("print");
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
