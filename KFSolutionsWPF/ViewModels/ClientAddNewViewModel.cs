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
    public class ClientAddNewViewModel : _appViewModel
    {
        public string Header { get; set; } = "Nieuwe Klant";
        //==============================================================================
        public ICommand Command_NavigatBack { get; set; }
        public ICommand Command_ToMainMenu { get; set; }
        public ICommand Command_AddClient { get; set; }
        public Client NewClient { get; set; }


        //==============================================================================

        public ClientAddNewViewModel( AppRepository<KfsContext> aAppDbRepository, TDS_wpf_extentions2.Transactioncontrol.TDStransactionControl aTDStransactionControl)
            : base(aAppDbRepository, aTDStransactionControl)
        {
            _myView = new ClientAddNewView();
            _myView.DataContext = this;


            Command_NavigatBack = new RelayCommand(NavigateBack);
            Command_ToMainMenu = new RelayCommand(NavigateToMainMenu);

            Command_AddClient = new RelayCommand(SaveClient);

            NewClient = new Client() { IsActive = true };
            NewClient.CltAddresss = new List<CltAddress>() { new CltAddress()  };
            NewClient.CltWebCredentials = new CltWebCredentials();

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

        private void SaveClient(object obj)
        {

            try
            {
                _appDbRespository.Client.Add(NewClient);
                MessageBox.Show("Client met succes toegevoegd");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.InnerException);
            }

        }
    }
}






















//Console.WriteLine(NewClient.FirstName);
//Console.WriteLine(NewClient.NameAddition);
//Console.WriteLine(NewClient.LastName);
//Console.WriteLine(NewClient.Email);
//Console.WriteLine(NewClient.MobileNumber);
//Console.WriteLine(NewClient.PhoneNumber);
//Console.WriteLine(NewClient.DateOfBirth);
//Console.WriteLine(NewClient.IsMale);


//Console.WriteLine(NewClient.CltAddresss.ToList()[0].Street);
//Console.WriteLine(NewClient.CltAddresss.ToList()[0].HouseNumber);
//Console.WriteLine(NewClient.CltAddresss.ToList()[0].HouseNumberAddition);
//Console.WriteLine(NewClient.CltAddresss.ToList()[0].Zipcode);
//Console.WriteLine(NewClient.CltAddresss.ToList()[0].City);
//Console.WriteLine(NewClient.CltAddresss.ToList()[0].Country);


//Console.WriteLine(NewClient.CltWebCredentials.UserName);
//Console.WriteLine(NewClient.CltWebCredentials.Password);




//    FirstName = "Tim",
//    //NameAddition ,

//    LastName = "Audenaarde",
//    Email = "tim.audenaert@hotmail.be",
//    MobileNumber = "0123456",
//    PhoneNumber = "",
//    DateOfBirth = new DateTime(1980, 04, 01),
//    IsMale = true,

//    IsActive = true,

//    CltAddresss = new List<CltAddress>()
//    {
//        new CltAddress()
//        {
//            Street = "TimseSteenweg",
//            HouseNumber = 33,
//            HouseNumberAddition = "b3",
//            Country = "Belgie",
//            Zipcode = "1000",
//            City = "Bornem"
//        }
//    },
//};

//    CltWebCredentials = new CltWebCredentials()
//    {
//        Password = "Tim__123",
//        UserName = "Tim__123",
//        InlogAttempts = 0,
//        IsBlocked = false,
//        IsPaswordResseted = false,
//        LastResetted = DateTime.Now,
//    },








//appRespository.Client.Add(client_TimAudenaarde);

//Client client_TimAudenaarde = new Client
//{
//    IsActive = true,
//    CltWebCredentials = new CltWebCredentials()
//    {
//        Password = "Tim__123",
//        UserName = "Tim__123",
//        InlogAttempts = 0,
//        IsBlocked = false,
//        IsPaswordResseted = false,
//        LastResetted = DateTime.Now,
//    },
//    FirstName = "Tim",
//    //NameAddition ,

//    LastName = "Audenaarde",
//    Email = "tim.audenaert@hotmail.be",
//    MobileNumber = "0123456",
//    PhoneNumber = "",
//    DateOfBirth = new DateTime(1980, 04, 01),
//    IsMale = true,

//    CltAddresss = new List<CltAddress>()
//    {
//        new CltAddress()
//        {
//            Street = "TimseSteenweg",
//            HouseNumber = 33,
//            HouseNumberAddition = "b3",
//            Country = "Belgie",
//            Zipcode = "1000",
//            City = "Bornem"
//        }
//    },
//};
//appRespository.Client.Add(client_TimAudenaarde);