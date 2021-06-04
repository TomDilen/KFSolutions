using KFSolutionsModel;
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
    public class OrderInHandlerViewModel : _appViewModel
    {

        //==============================================================================
        public List<OrderIn> OrdersIn { get; set; }


        public ICommand Command_NavigatBack { get; set; }
        public ICommand Command_ToMainMenu { get; set; }
        public ICommand Command_Save { get; set; }
        public ICommand Command_CheckChange { get; set; }

        private List<int> _checkedItems;
        //==============================================================================


        public OrderInHandlerViewModel(
                AppRepository<KfsContext> aAppDbRepository, TDStransactionControl aTDStransactionControl)
            : base(aAppDbRepository, aTDStransactionControl)
        {
            _myView = new OrderInHandlerView();
            _myView.DataContext = this;


            Command_NavigatBack = new RelayCommand(NavigateBack);
            Command_ToMainMenu = new RelayCommand(NavigateToMainMenu);
            Command_Save = new RelayCommand(SaveToDB, CanSaveToDB);
            Command_CheckChange = new RelayCommand(CheckChange);


            RefreschData();
        }


        public void RefreschData()
        {
            OrdersIn = _appDbRespository.OrderIn.GetAll_forOrderInHandling();
            _checkedItems = new List<int>();
        }

        private void CheckChange(object obj)
        {
            _checkedItems = new List<int>();

            foreach (var item in OrdersIn)
                if (item.IsChecked) _checkedItems.Add(item.Id);

        }

        private bool CanSaveToDB(object obj)
        {
            return _checkedItems.Count > 0;
        }

        private void SaveToDB(object obj)
        {

            _appDbRespository.OrderIn.HandlelOrders(_checkedItems, _appDbRespository.Employee.InloggedEmployee.Id);

            RefreschData();
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
