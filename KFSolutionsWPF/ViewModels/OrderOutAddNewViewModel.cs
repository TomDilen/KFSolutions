﻿using KFSolutionsModel;
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
    public class OrderOutAddNewViewModel : _appViewModel
    {

        //==============================================================================
        public ICommand Command_NavigatBack { get; set; }
        public ICommand Command_ToMainMenu { get; set; }
        public ICommand Command_Save { get; set; }


        public List<Product> ProductsAll { get; set; }

        private List<Product> _workingProductList;
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


            RefreshData();
        }
        //------------------------------------------------------------------------------------------
        private void RefreshData()
        {
            _workingProductList = _appDbRespository.Product.GetAllforOrderOut();

            ProductsAll = _workingProductList;
        }


        //====================================================================================================================

        private bool CanSaveToDB(object obj)
        {
            return true;
        }

        private void SaveToDB(object obj)
        {
            Console.WriteLine("save");


            //OrderOut bestelling_In1 = new OrderOut()
            //{
            //    Id_Client = 1,
            //    OrderLineOuts = new List<OrderLineOut>()
            //    {
            //        new OrderLineOut(){EAN_Product = "222222222" , UnitPrice = 22.33f ,NumberOfProducts=4 },
            //        new OrderLineOut(){EAN_Product = "444444444" , UnitPrice = 22.33f ,NumberOfProducts=4 }
            //    }
            //};
            //appRespository.OrderOut.Add(bestelling_In1);

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

