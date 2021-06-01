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
using System.Windows;
using System.Windows.Input;
using TDS_wpf_extentions2.Transactioncontrol;

namespace KFSolutionsWPF.ViewModels
{
    class ProductAddNewViewModel : _appViewModel
    {
        public enum ViewType
        {
            ReadOnly,
            Edit, 
            New,
            NewFromQuatations
        }

        //==============================================================================
        public ICommand Command_AddProduct { get; set; }
        public Product NewProduct { get; set; }

        public List<ProductType> ProductTypesAvailable { get; set; }
        public ObservableCollection<Single> BtwAvailable { get; set; } = new ObservableCollection<Single>() { 6, 12, 21 };

        private ViewType _viewtype;
        //==============================================================================


        public ProductAddNewViewModel(
            
            AppRepository<KfsContext> aAppDbRepository, 
            TDStransactionControl aTDStransactionControl,
            ViewType aviewType,
            Product aInitProduct = null)
                : base(aAppDbRepository, aTDStransactionControl)
        {
            _myView = new ProductAddNewView();
            _myView.DataContext = this;
            _viewtype = aviewType;


            Command_AddProduct = new RelayCommand(SaveProduct);

            //needed for add
            ProductTypesAvailable = _appDbRespository.ProductType.GetAll().ToList();

            NewProduct = new Product() { CountInStock = 0, BTWpercentage = 21, MinCountInStock = 10, MaxCountInStock = 100 };

            switch (_viewtype)
            {
                case ViewType.ReadOnly:
                    throw new NotImplementedException("niet geimplementeerd");
                    break;
                case ViewType.Edit:
                    throw new NotImplementedException("niet geimplementeerd");
                    break;
                case ViewType.New:
                    break;
                case ViewType.NewFromQuatations:
                    if(aInitProduct==null) throw new NotImplementedException("ainitproduct mag niet null zijn");
                    NewProduct = aInitProduct;
                    break;
                default:
                    throw new NotImplementedException("niet geimplementeerd");
                    break;
            }



        }

        private void SaveProduct(object obj)
        {
            if (NewProduct.MaxCountInStock < NewProduct.MinCountInStock)
            {
                MessageBox.Show("max in stock kan niet kleiner zijn dan min in stock");
            }
            if (NewProduct.MinCountInStock < 0)
            {
                MessageBox.Show("min in stock kan niet kleiner zijn 0");
            }

            Console.WriteLine(NewProduct.ProductTitle);

            Console.WriteLine(NewProduct.EAN);
            Console.WriteLine(NewProduct.Id_ProductType);

            Console.WriteLine(NewProduct.SellingPriceRecommended);
            Console.WriteLine(NewProduct.BTWpercentage);

            Console.WriteLine(NewProduct.WareHouseLocation);
            Console.WriteLine(NewProduct.CountInStock);
            Console.WriteLine(NewProduct.MinCountInStock);
            Console.WriteLine(NewProduct.MaxCountInStock);

            Console.WriteLine(NewProduct.ExtraInfo);

            ////TODO:
            //Console.WriteLine(NewProduct.Image);


            switch (_viewtype)
            {
                case ViewType.ReadOnly:
                    throw new NotImplementedException("niet geimplementeerd");
                    break;
                case ViewType.Edit:
                    throw new NotImplementedException("niet geimplementeerd");
                    break;
                case ViewType.New:
                    throw new NotImplementedException("niet geimplementeerd");
                    break;
                case ViewType.NewFromQuatations:
                    try
                    {
                        _appDbRespository.Product.Add(NewProduct);
                        MessageBox.Show("Produkt met succes toegevoegd");
                        NavigateBack();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message + ex.InnerException);
                        return;
                    }
                    break;
                default:
                    throw new NotImplementedException("niet geimplementeerd");
                    break;
            }
        }
        public void NavigateBack()
        {
            switch (_viewtype)
            {
                case ViewType.ReadOnly:
                    throw new NotImplementedException("niet geimplementeerd");
                    break;
                case ViewType.Edit:
                    throw new NotImplementedException("niet geimplementeerd");
                    break;
                case ViewType.New:
                    throw new NotImplementedException("niet geimplementeerd");
                    break;
                case ViewType.NewFromQuatations:
                    _transactionControl.SlideNewContent(new QuatationsViewModel(_appDbRespository, _transactionControl),
                        TDStransactionControl.TransactionDirection.Right, 500);
                    break;
                default:
                    throw new NotImplementedException("niet geimplementeerd");
                    break;
            }
        }


    }
}



//    //---------   id = EAN (geen oplopend nummer)
//    EAN = "1111111111",

//    ProductTitle = "Spaghetti Bolognaise",
//    //ExtraInfo = "",

//    SellingPriceRecommended = 5.22f,
//    CountInStock = 0,
//    MinCountInStock = 100,
//    MaxCountInStock = 500,

//    WareHouseLocation = "H44,01",

//    BTWpercentage = 6,
//    Id_ProductType = 2, //producType 1=Speelgoed, 2=Voedingswaren 3=Autoonderdelen
//                        //Image 


//};
//appRespository.Product.Add(product_Spaghetti);


//Product product_Spaghetti = new Product()
//{
//    //---------   id = EAN (geen oplopend nummer)
//    EAN = "1111111111",

//    ProductTitle = "Spaghetti Bolognaise",
//    //ExtraInfo = "",

//    SellingPriceRecommended = 5.22f,
//    CountInStock = 0,
//    MinCountInStock = 100,
//    MaxCountInStock = 500,
//    WareHouseLocation = "H44,01",
//    BTWpercentage = 6,
//    Id_ProductType = 2, //producType 1=Speelgoed, 2=Voedingswaren 3=Autoonderdelen
//                        //Image 


//};
//appRespository.Product.Add(product_Spaghetti);