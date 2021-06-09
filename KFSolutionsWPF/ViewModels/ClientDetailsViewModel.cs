using KFSolutionsModel;
using KFSolutionsWPF.Commands;
using KFSolutionsWPF.Views;
using KFSrepository_EF6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TDS_wpf_extentions2.Transactioncontrol;

namespace KFSolutionsWPF.ViewModels
{
    public class ClientDetailsViewModel : _appViewModel
    {
        public string Header { get; set; } = "Klanten overzicht";
        //==============================================================================
        public ICommand Command_NavigatBack { get; set; }
        public ICommand Command_ToMainMenu { get; set; }
        public ICommand Command_ToNewClient { get; set; }


        public ICommand Command_DeleteDBitemButtonInDatagridClick { get; set; }
        public ICommand Command_UpdateDBitemButtonInDatagridClick { get; set; }
        //public ICommand Command_ViewDBitemButtonInDatagridClick { get; set; }


        public List<Client> ItemsFromDB { get; set; }
        public Client SelectedItemFromDB { get; set; }
        //==============================================================================


        public ClientDetailsViewModel(
            AppRepository<KfsContext> aAppDbRepository, TDStransactionControl aTDStransactionControl)
            : base(aAppDbRepository, aTDStransactionControl)
        {
            _myView = new ClientDetailsView();
            _myView.DataContext = this;


            ItemsFromDB = _appDbRespository.Client.GetAllForOverview();


            Command_NavigatBack = new RelayCommand(NavigateBack);
            Command_ToMainMenu = new RelayCommand(NavigateToMainMenu);
            Command_ToNewClient = new RelayCommand(NavigateToNewClient);

            Command_DeleteDBitemButtonInDatagridClick = new RelayCommand(DeleteDBitemButtonInDatagridClick);
            Command_UpdateDBitemButtonInDatagridClick = new RelayCommand(UpdateDBitemButtonInDatagridClick);
            //Command_ViewDBitemButtonInDatagridClick = new RelayCommand(ViewDBitemButtonInDatagridClick);


            //SelectedItemFromDB.

        }

        private void NavigateToNewClient(object obj)
        {
            _transactionControl.SlideNewContent(
                new ClientAddNewViewModel(_appDbRespository, _transactionControl),
                TDStransactionControl.TransactionDirection.Left, 500);
        }

        //private void ViewDBitemButtonInDatagridClick(object obj)
        //{
        //    Console.WriteLine("geklikt op view => " + SelectedItemFromDB.Id);
        //}

        private void UpdateDBitemButtonInDatagridClick(object obj)
        {
            //Console.WriteLine("geklikt op bewerken => " + SelectedItemFromDB.Id);
            _transactionControl.SlideNewContent(
                new ClientAddNewViewModel(_appDbRespository, _transactionControl, SelectedItemFromDB),
                TDStransactionControl.TransactionDirection.Left, 500);
        }

        private void DeleteDBitemButtonInDatagridClick(object obj)
        {
            //Console.WriteLine("geklikt op delete => " + SelectedItemFromDB.Id);
            if (MessageBoxResult.Yes ==
                MessageBox.Show(
                    $"Weet je zeker dat je {SelectedItemFromDB.FirstName} {SelectedItemFromDB.LastName} wil verwijderen?", "Verwijderen",
                    MessageBoxButton.YesNo, MessageBoxImage.Question))
                        {
                try
                {
                    _appDbRespository.Client.Delete(SelectedItemFromDB);

                    ItemsFromDB = _appDbRespository.Client.GetAllForOverview();
                    MessageBox.Show("client met succes verwijderd");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + ex.InnerException);
                }
            }
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