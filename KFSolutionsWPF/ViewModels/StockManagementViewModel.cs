using KFSolutionsModel;
using KFSolutionsWPF.Commands;
using KFSolutionsWPF.Views;
using KFSrepository_EF6;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TDS_wpf_extentions2.Transactioncontrol;
using static KFSrepository_EF6.ProductRepository;

namespace KFSolutionsWPF.ViewModels
{
    public class StockManagementViewModel : _appViewModel
    {

        //===========================================================================================================
        public List<ProductForStockDTO> ProductsAll { get; set; }
        public ProductForStockDTO SelectedProduct { get; set; }


        private  ProductsForStockManagementPackageDTO ProductsForStockManagement { get; set; }
        
        public ICommand Command_NavigatBack { get; set; }
        public ICommand Command_ToMainMenu { get; set; }
        //===========================================================================================================


        public StockManagementViewModel(
            AppRepository<KfsContext> aAppDbRepository, TDStransactionControl aTDStransactionControl)
            : base(aAppDbRepository, aTDStransactionControl)
        {
            _myView = new StockManagementView();
            _myView.DataContext = this;

            Command_NavigatBack = new RelayCommand(NavigateBack);
            Command_ToMainMenu = new RelayCommand(NavigateToMainMenu);


            //
            ProductsForStockManagement = aAppDbRepository.Product.GetAllForStockManagement();

            ProductsAll = ProductsForStockManagement.OpsCollProductForStockDTO;

          //var x=  SelectedProduct.Supplier_Product_Prices.ToList()[0].Supplier;

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

    }
}

