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
    public class ClientDetailsViewModel : _appViewModel
    {
        public string Header { get; set; } = "Klanten overzicht";
        //==============================================================================
        public ICommand Command_NavigatBack { get; set; }
        public ICommand Command_ToMainMenu { get; set; }


        public ICommand Command_DeleteDBitemButtonInDatagridClick { get; set; }
        public ICommand Command_UpdateDBitemButtonInDatagridClick { get; set; }
        public ICommand Command_ViewDBitemButtonInDatagridClick { get; set; }


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

            Command_DeleteDBitemButtonInDatagridClick = new RelayCommand(DeleteDBitemButtonInDatagridClick);
            Command_UpdateDBitemButtonInDatagridClick = new RelayCommand(UpdateDBitemButtonInDatagridClick);
            Command_ViewDBitemButtonInDatagridClick = new RelayCommand(ViewDBitemButtonInDatagridClick);
        }

        private void ViewDBitemButtonInDatagridClick(object obj)
        {
            Console.WriteLine("geklikt op view => " + SelectedItemFromDB.Id);
        }

        private void UpdateDBitemButtonInDatagridClick(object obj)
        {
            Console.WriteLine("geklikt op bewerken => " + SelectedItemFromDB.Id);
        }

        private void DeleteDBitemButtonInDatagridClick(object obj)
        {
            Console.WriteLine("geklikt op delete => " + SelectedItemFromDB.Id);
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