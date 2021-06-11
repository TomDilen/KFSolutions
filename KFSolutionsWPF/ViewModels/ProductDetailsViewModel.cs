using KFSolutionsModel;
using KFSolutionsWPF.Commands;
using KFSolutionsWPF.TDS;
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
    public class ProductDetailsViewModel : _appViewModel
    {

        public string Header { get; set; } = "Product beheer";
        //==============================================================================
        public ICommand Command_NavigatBack { get; set; }
        public ICommand Command_ToMainMenu { get; set; }


        public ICommand Command_AddNewProduct { get; set; }

        public ICommand Command_UpdateDBitemButtonInDatagridClick { get; set; }

        public List<Product> ItemsFromDB { get; set; }
        public Product  SelectedItemFromDB { get; set; }
        //==============================================================================


        public ProductDetailsViewModel(
                AppRepository<KfsContext> aAppDbRepository, TDStransactionControl aTDStransactionControl)
            : base(aAppDbRepository, aTDStransactionControl)
        {
            _myView = new ProductDetailsView();
            _myView.DataContext = this;


            Command_NavigatBack = new RelayCommand(NavigateBack);
            Command_ToMainMenu = new RelayCommand(NavigateToMainMenu);

            Command_AddNewProduct =  new RelayCommand(NavigateToNewEmployee);

            Command_UpdateDBitemButtonInDatagridClick = new RelayCommand(UpdateDBitemButtonInDatagridClick);

            ItemsFromDB = _appDbRespository.Product.GetAllForOverview();
            foreach (var item in ItemsFromDB)
            {
                item.Supplier_Product_Prices = item.Supplier_Product_Prices.DistinctBy(p => p.Id_Supplier).ToList();
            }
            //_ProductsForStockManagement.ProductForStockDTO.DistinctBy(p => p.EAN).Select(x => x).ToList();


            //.Include(nameof(Product.Supplier_Product_Prices))
            //.Include(nameof(Product.Supplier_Product_Prices) + "." + nameof(Supplier_Product_Price.Supplier))
            ////.Include(nameof(Employee.EmpContract) + "." + nameof(EmpContract.EmpContractStatuutType))
            ////.Include(nameof(Employee.EmpContract) + "." + nameof(EmpContract.EmpContractType))
            ////.Include(nameof(Employee.EmpAppAccount))
            //.ToList();



            //EAN
            //ProductTitle
            //SellingPriceRecommended
            //BTWpercentage
            //WareHouseLocation
        }

        private void UpdateDBitemButtonInDatagridClick(object obj)
        {
            //Console.WriteLine("geklikt op bewerken => " + SelectedItemFromDB.Id);
            _transactionControl.SlideNewContent(
                new ProductAddNewViewModel(_appDbRespository, _transactionControl , ProductAddNewViewModel.ViewType.Edit, SelectedItemFromDB),
                TDStransactionControl.TransactionDirection.Left, 500);
        }

        private void NavigateToNewEmployee(object obj)
        {
            Console.WriteLine("navigate naar nieuw product");
            _transactionControl.SlideNewContent(
                new ProductAddNewViewModel(_appDbRespository, _transactionControl,ProductAddNewViewModel.ViewType.New),
                TDStransactionControl.TransactionDirection.Left, 500);
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





