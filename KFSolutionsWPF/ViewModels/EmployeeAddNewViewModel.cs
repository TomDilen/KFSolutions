using KFSolutionsModel;
using KFSolutionsWPF.Commands;
using KFSolutionsWPF.TDS;
using KFSolutionsWPF.Views;
using KFSrepository_EF6;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using TDS_wpf_extentions2.Transactioncontrol;

namespace KFSolutionsWPF.ViewModels
{
    //public class test
    //{
    //    public string Name { get; set; }
    //}

    public class EmployeeAddNewViewModel : _appViewModel
    {

        //==============================================================================


        public string Header { get; set; } = "Nieuwe werknemer";
        //==============================================================================
        public ICommand Command_NavigatBack { get; set; }
        public ICommand Command_ToMainMenu { get; set; }
        public ICommand Command_AddEmployee { get; set; }

        public Employee NewEmployee { get; set; }

        public List<EmpDepartment> DepartmentsAvailable { get; set; }
        public List<EmpContractStatuutType> ContractStatuutTypesAvailable { get; set; }

        public List<EmpContractType> ContractTypesAvailable { get; set; }

        public bool IsNewMode { get; set; } = false;
        //==============================================================================
        public EmployeeAddNewViewModel(
            AppRepository<KfsContext> aAppDbRepository, TDStransactionControl aTDStransactionControl , Employee aEmployee = null)
            : base(aAppDbRepository, aTDStransactionControl)
        {
            _myView = new EmployeeAddNewView();
            _myView.DataContext = this;

            DepartmentsAvailable = aAppDbRepository.EmpDepartment.GetAll().ToList();
            ContractStatuutTypesAvailable = aAppDbRepository.EmpContractStatuutType.GetAll().ToList();
            ContractTypesAvailable = aAppDbRepository.EmpContractType.GetAll().ToList();
            //string k = DepartmentsAvailable[0].DescriptionNL

            Command_NavigatBack = new RelayCommand(NavigateBack);
            Command_ToMainMenu = new RelayCommand(NavigateToMainMenu);

            Command_AddEmployee = new RelayCommand(SaveEmployee);



            NewEmployee = aEmployee;
            if (aEmployee == null)
            {
                IsNewMode = true;

                NewEmployee = new Employee();
                NewEmployee.IsActive = true;
                NewEmployee.EmpAddress = new EmpAddress();
                NewEmployee.EmpContract = new EmpContract();
                NewEmployee.EmpAppAccount = new EmpAppAccount();
                NewEmployee.EmpContract.DateOfStart = DateTime.Now;
                NewEmployee.DateOfBirth = new DateTime(2000, 1, 1);
                NewEmployee.IsActive = true;


            }


            if(IsNewMode == false)
            {
                Header = "Werknemer bewerken";

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
                new EmployeeDetailsViewModel(_appDbRespository, _transactionControl),
                TDStransactionControl.TransactionDirection.Right, 500);
        }

        private void SaveEmployee(object obj)
        {


            if (!ValidateAll()) return;


            Console.WriteLine(NewEmployee.FirstName);
            Console.WriteLine(NewEmployee.NameAddition);
            Console.WriteLine(NewEmployee.LastName);

            Console.WriteLine(NewEmployee.Email);
            Console.WriteLine(NewEmployee.MobileNumber);
            Console.WriteLine(NewEmployee.PhoneNumber);

            Console.WriteLine(NewEmployee.DateOfBirth);
            Console.WriteLine(NewEmployee.IsMale);


            Console.WriteLine(NewEmployee.EmpAddress.Street);
            Console.WriteLine(NewEmployee.EmpAddress.HouseNumber);
            Console.WriteLine(NewEmployee.EmpAddress.HouseNumberAddition);
            Console.WriteLine(NewEmployee.EmpAddress.Zipcode);
            Console.WriteLine(NewEmployee.EmpAddress.City);
            Console.WriteLine(NewEmployee.EmpAddress.Country);


            Console.WriteLine(NewEmployee.PassPortID);
            Console.WriteLine(NewEmployee.IBAN);
            //Console.WriteLine(NewEmployee.JobInfo);//er uit
            Console.WriteLine(NewEmployee.ExtraInfo);
            Console.WriteLine(NewEmployee.Id_EmpDepartment);


            Console.WriteLine(NewEmployee.EmpContract.Id_EmpContractType);
            Console.WriteLine(NewEmployee.EmpContract.Id_EmpContractStatuutType);
            Console.WriteLine(NewEmployee.EmpContract.MonthSalary);
            Console.WriteLine(NewEmployee.EmpContract.DateOfStart);
            //Console.WriteLine(NewEmployee.EmpContract.ExtraInfo); //er uit



            //Console.WriteLine(NewEmployee.EmpAppAccount.Password);
            //Console.WriteLine(NewEmployee.EmpAppAccount.UserName);


            //NewEmployee.EmpAppAccount.AppPermissions = NewEmployee.EmpDepartment.DefaultPermissions;

            //NewEmployee.EmpAppAccount.AppPermissions = DepartmentsAvailable.First(x => x.Id == NewEmployee.Id_EmpDepartment).DefaultPermissions;
            //NewEmployee.EmpAppAccount.AppPermissions = 0b0111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111;



            //Console.WriteLine("===============================================================");
            //Console.WriteLine("depId: " + NewEmployee.Id_EmpDepartment);
            //Console.WriteLine("permiss:  " + NewEmployee.EmpAppAccount.AppPermissions);
            //Console.WriteLine("===============================================================");

            if (IsNewMode)
            {
                try
                {
                    
                    NewEmployee.EmpAppAccount.IsPaswordResseted = true;
                    NewEmployee.EmpAppAccount.LastResetted = DateTime.Now;
                    NewEmployee.EmpAppAccount.IsBlocked = false;
                    NewEmployee.EmpAppAccount.InlogAttempts = 0;

                    _appDbRespository.Employee.Add(NewEmployee);
                    MessageBox.Show("Werkgever met succes toegevoegd");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + ex.InnerException);
                }
            }

            else
            {

                try
                {
                    _appDbRespository.Employee.Update(NewEmployee);
                    MessageBox.Show("TODO : Werkgever met succes aangepast");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + ex.InnerException);
                }
            }


        }

        private bool ValidateAll()
        {
            if (string.IsNullOrEmpty(NewEmployee.FirstName) || NewEmployee.FirstName.Length < 2 || NewEmployee.FirstName.Length > 25)
            {
                MessageBox.Show("Voornaam moet 2 tot 25 tekens bevatten");
                return false;
            }
            if (NewEmployee.NameAddition != null && NewEmployee.NameAddition.Length > 10)
            {
                MessageBox.Show("tussenvoegsel mag maximum 10 tekens bevatten");
                return false;
            }

            if (string.IsNullOrEmpty(NewEmployee.LastName) || NewEmployee.LastName.Length < 2 || NewEmployee.LastName.Length > 25)
            {
                MessageBox.Show("Achternaam moet 2 tot 25 tekens bevatten");
                return false;
            }

            if (!RegexUtilities.IsValidEmail(NewEmployee.Email))
            {
                MessageBox.Show("Email is geen geldig email");
                return false;
            }

            if (NewEmployee.MobileNumber != null && NewEmployee.MobileNumber.Length > 20)
            {
                MessageBox.Show("Gsm mag maximum 20 tekens bevatten");
                return false;
            }
            if (NewEmployee.PhoneNumber != null && NewEmployee.PhoneNumber.Length > 15)
            {
                MessageBox.Show("Telefoon mag maximum 15 tekens bevatten");
                return false;
            }
            if (string.IsNullOrEmpty(NewEmployee.EmpAddress.Street) || NewEmployee.EmpAddress.Street.Length < 2 || NewEmployee.EmpAddress.Street.Length > 30)
            {
                MessageBox.Show("Straat moet 2 tot 30 tekens bevatten");
                return false;
            }
            if (NewEmployee.EmpAddress.HouseNumber < 1 || NewEmployee.EmpAddress.HouseNumber > 3000)
            {
                MessageBox.Show("geen geldig huisnummer");
                return false;
            }
            if (NewEmployee.EmpAddress.HouseNumberAddition != null && NewEmployee.EmpAddress.HouseNumberAddition.Length > 8)
            {
                MessageBox.Show("Bus kan maximum 8 tekens bevatten");
                return false;
            }
            if (string.IsNullOrEmpty(NewEmployee.EmpAddress.Zipcode) || NewEmployee.EmpAddress.Zipcode.Length < 4 || NewEmployee.EmpAddress.Zipcode.Length > 12)
            {
                MessageBox.Show("postcode moet 4 tot maximum 12 tekens bevatten");
                return false;
            }
            if (string.IsNullOrEmpty(NewEmployee.EmpAddress.City) || NewEmployee.EmpAddress.City.Length < 4 || NewEmployee.EmpAddress.City.Length > 20)
            {
                MessageBox.Show("Gemeente moet 4 tot maximum 20 tekens bevatten");
                return false;
            }
            if (string.IsNullOrEmpty(NewEmployee.EmpAddress.Country) || NewEmployee.EmpAddress.Country.Length < 4 || NewEmployee.EmpAddress.Country.Length > 20)
            {
                MessageBox.Show("Land moet 4 tot maximum 20 tekens bevatten");
                return false;
            }
            if (string.IsNullOrEmpty(NewEmployee.PassPortID) || NewEmployee.PassPortID.Length < 4 || NewEmployee.PassPortID.Length > 15)
            {
                MessageBox.Show("rijksregisternummer moet 5 tot maximum 15 tekens bevatten");
                return false;
            }
            if (string.IsNullOrEmpty(NewEmployee.IBAN) || NewEmployee.IBAN.Length < 4 || NewEmployee.IBAN.Length > 15)
            {
                MessageBox.Show("IBAN moet 5 tot maximum 15 tekens bevatten");
                return false;
            }
            if (NewEmployee.Id_EmpDepartment < 1)
            {
                MessageBox.Show("Afdeling is niet ingevuld");
                return false;
            }
            if (NewEmployee.EmpContract.Id_EmpContractType < 1)
            {
                MessageBox.Show("contracttype is niet ingevuld");
                return false;
            }
            if (NewEmployee.EmpContract.Id_EmpContractStatuutType < 1)
            {
                MessageBox.Show("Statuut is niet ingevuld");
                return false;
            }
            if (NewEmployee.EmpContract.MonthSalary < 1)
            {
                MessageBox.Show("Ongeldig maandsalaris");
                return false;
            }
            if (NewEmployee.EmpContract.DateOfStart == null)
            {
                MessageBox.Show("Startdatum moet ingevuld zijn");
                return false;
            }


            if (IsNewMode)
            {

                //cijfers, grote en kleine letters, underscores en range
                if ( string.IsNullOrEmpty(NewEmployee.EmpAppAccount.UserName) ||
                    !new Regex("^[0-9A-Za-z_]{5,20}$").IsMatch(NewEmployee.EmpAppAccount.UserName))
                {
                    MessageBox.Show("Geen geldig gebruikersnaam");
                    return false;
                }

                if (string.IsNullOrEmpty(NewEmployee.EmpAppAccount.Password) ||
                    !new Regex(
                        "^"
                        +
                        "(?=.*[A-Z]+)"          // [A-Z] betekend een hoofdletter, het plusje betekend '1 of meer'
                        +
                        "(?=.*[a-z]+)"          // [a-z] betekend een kleine letter, het plusje betekend '1 of meer'
                        +
                        "(?=.*[0-9]+)"          // [0-9] betekend een digital, het plusje betekend '1 of meer'
                        +
                        $"(?=.*[_]+)"           //tekens tss aanhalingstekenz, het plusje betekend '1 of meer'
                        +
                        ".{8,20}$"              //kijken of het geheel 8tot 20 lang is, 
                    ).IsMatch(NewEmployee.EmpAppAccount.Password))
                {
                    MessageBox.Show("Geen geldig Passwoord");
                    return false;
                }
            }

            return true;
        }
    }
}


            //NewEmployee.FirstName
            //NewEmployee.NameAddition
            //NewEmployee.LastName
            //NewEmployee.Email
            //NewEmployee.MobileNumber
            //NewEmployee.PhoneNumber

            //NewEmployee.EmpAddress.Street
            //NewEmployee.EmpAddress.HouseNumber
            //NewEmployee.EmpAddress.HouseNumberAddition

            //NewEmployee.EmpAddress.Zipcode
            //NewEmployee.EmpAddress.City
            //NewEmployee.EmpAddress.Country

            //NewEmployee.PassPortID
            //NewEmployee.IBAN
            //NewEmployee.Id_EmpDepartment = min1
            //NewEmployee.EmpContract.Id_EmpContractStatuutType
            //NewEmployee.EmpContract.Id_EmpContractType
            //NewEmployee.EmpContract.MonthSalary
            //NewEmployee.EmpContract.DateOfStart


            //username en paswoord enkel bij nieuwe controleren

            //NewEmployee.EmpAppAccount.UserName
            //NewEmployee.EmpAppAccount.Password






//          //-------------------Employee----------
//          PassPortID = "0122222111",
//          IBAN = "12220132145545",
//          JobInfo = "waarken lak een biest",
//          ExtraInfo = "zag er ne toffe gast uit bij de sollicitatie",

//          //navProps 
//          //id voor departement is genoeg :-)
//          Id_EmpDepartment = 1, //1=Administrator, 2=Verkoop, 3=Magazijn

//          EmpContract = new EmpContract()
//          {
//              MonthSalary = 2222.22f,
//              DateOfStart = new DateTime(2020, 12, 2),
//              Id_EmpContractStatuutType = 1,   // 1=Arbeider, 2=Bediende, 3=Ambtenaar
//              Id_EmpContractType = 1   // 1=Onbepaalde duur, 2=Jobstudent, 3=Interim
//          },

//    EmpAppAccount = new EmpAppAccount
//    {
//        AppPermissions = 0b0100_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_1111_1111_1111_1111_1111,
//        Password = "Tom_0123",
//        UserName = "Tom_0123",
//        IsPaswordResseted = true,
//        LastResetted = DateTime.Now,
//        IsBlocked = false,
//        InlogAttempts = 0,
//    }
//};
//appRespository.Employee.Add(employee_TomDilen);

//====================================================================================================

//Employee employee_TomDilen = new Employee()
//{
//    //-------------------personMin---------
//    FirstName = "Tom",
//    //NameAddition = "niet vereist",
//    LastName = "Dilen",
//    Email = "tomtom@tom.tom",
//    MobileNumber = "0123 11 22 33",
//    //PhoneNumber = "niet vereist",

//    //navprops


//    //-------------------Person------------
//    DateOfBirth = new DateTime(1981, 04, 22),
//    IsMale = true,
//    //nav props
//    EmpAddress = new EmpAddress()
//    {
//        Street = "Duivenstraat",
//        HouseNumber = 55,
//        //HouseNumberAddition = "nvt",
//        Zipcode = "2300",
//        City = "Turnhout",
//        Country = "Belgium"
//    },

//    //-------------------Employee----------
//    PassPortID = "0122222111",
//    IBAN = "12220132145545",
//    JobInfo = "waarken lak een biest",
//    ExtraInfo = "zag er ne toffe gast uit bij de sollicitatie",

//    //navProps 
//    //id voor departement is genoeg :-)
//    Id_EmpDepartment = 1, //1=Administrator, 2=Verkoop, 3=Magazijn

//    EmpContract = new EmpContract()
//    {
//        MonthSalary = 2222.22f,
//        DateOfStart = new DateTime(2020, 12, 2),
//        Id_EmpContractStatuutType = 1,   // 1=Arbeider, 2=Bediende, 3=Ambtenaar
//        Id_EmpContractType = 1   // 1=Onbepaalde duur, 2=Jobstudent, 3=Interim
//    },

//    EmpAppAccount = new EmpAppAccount
//    {
//        AppPermissions = 0b0100_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_1111_1111_1111_1111_1111,
//        Password = "Tom_0123",
//        UserName = "Tom_0123",
//        IsPaswordResseted = true,
//        LastResetted = DateTime.Now,
//        IsBlocked = false,
//        InlogAttempts = 0,
//    }
//};
//appRespository.Employee.Add(employee_TomDilen);