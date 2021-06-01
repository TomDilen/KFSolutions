﻿using KFSolutionsModel;
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
    //public class test
    //{
    //    public string Name { get; set; }
    //}

    public class EmployeeAddNewViewModel : _appViewModel
    {
        //==============================================================================
        public ICommand Command_AddEmployee { get; set; }

        public Employee NewEmployee { get; set; }

        public List<EmpDepartment> DepartmentsAvailable { get; set; }
        public List<EmpContractStatuutType> ContractStatuutTypesAvailable { get; set; }

        public List<EmpContractType> ContractTypesAvailable { get; set; }

        //==============================================================================
        public EmployeeAddNewViewModel(
            AppRepository<KfsContext> aAppDbRepository, TDStransactionControl aTDStransactionControl)
            : base(aAppDbRepository, aTDStransactionControl)
        {
            _myView = new EmployeeAddNewView();
            _myView.DataContext = this;

            DepartmentsAvailable = aAppDbRepository.EmpDepartment.GetAll().ToList();
            ContractStatuutTypesAvailable = aAppDbRepository.EmpContractStatuutType.GetAll().ToList();
            ContractTypesAvailable = aAppDbRepository.EmpContractType.GetAll().ToList();
            //string k = DepartmentsAvailable[0].DescriptionNL

            Command_AddEmployee = new RelayCommand(SaveEmployee);

            NewEmployee = new Employee();
            NewEmployee.EmpAddress = new EmpAddress();
            NewEmployee.EmpContract = new EmpContract();
            NewEmployee.EmpAppAccount = new EmpAppAccount();
            NewEmployee.EmpContract.DateOfStart = DateTime.Now;
            NewEmployee.DateOfBirth = new DateTime(2000, 1, 1);
            //NewEmployee.IsMale = false;
            //NewEmployee.FirstName = "snulleke";
        }

        private void SaveEmployee(object obj)
        {

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




            NewEmployee.EmpAppAccount.AppPermissions = 0b0111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111;
            NewEmployee.EmpAppAccount.IsPaswordResseted = true;
            NewEmployee.EmpAppAccount.LastResetted = DateTime.Now;
            NewEmployee.EmpAppAccount.IsBlocked = false;
            NewEmployee.EmpAppAccount.InlogAttempts = 0;

            Console.WriteLine(NewEmployee.EmpAppAccount.Password);
            Console.WriteLine(NewEmployee.EmpAppAccount.UserName);


            try
            {
                _appDbRespository.Employee.Add(NewEmployee);
                MessageBox.Show("Werkgever met succes toegevoegd");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + ex.InnerException);
            }
            



        }
    }
}




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