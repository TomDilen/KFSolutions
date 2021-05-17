using KFSolutionsModel;
using KFSrepository_EF6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFSolutions
{
    public static class _____TESTDATA
    {
        public static void LoadTestData(AppRepository<KfsContext> appRespository)
        {


            #region------------------------------------------- Add Departments------------------------------

            EmpDepartment newDep_admin = new EmpDepartment()
            {
                DefaultPermissions = 0b1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111,
                DescriptionNL = "Administrator",
                DescriptionEN = "Administrator"
            };
            appRespository.EmpDepartment.Add(newDep_admin);

            EmpDepartment newDep_Sales = new EmpDepartment()
            {
                DefaultPermissions = 0b0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_1111_1111_1111_1111_1111,
                DescriptionEN = "Sales",
                DescriptionNL = "Verkoop"
            };
            appRespository.EmpDepartment.Add(newDep_Sales);


            EmpDepartment newDep_Warehouse = new EmpDepartment()
            {
                DefaultPermissions = 0b0000_0000_0000_0000_0000_0000_1111_1111_1111_1111_1111_0000_0000_0000_0000_0000,
                DescriptionEN = "Ware House",
                DescriptionNL = "Magazijn"
            };
            appRespository.EmpDepartment.Add(newDep_Warehouse);

            #endregion--------------------------------------------------------------------------------------


            #region------------------------------------------- Add Contract types---------------------------
            EmpContractType newContrType_onbDuur = new EmpContractType()
            {
                DescriptionEN = "Indefinitely",
                DescriptionNL = "Onbepaalde duur"
            };
            appRespository.EmpContractType.Add(newContrType_onbDuur);

            EmpContractType newContrType_jobstudent = new EmpContractType()
            {
                DescriptionEN = "Student job",
                DescriptionNL = "Jobstudent"
            };
            appRespository.EmpContractType.Add(newContrType_jobstudent);

            EmpContractType newContrType_interim = new EmpContractType()
            {
                DescriptionEN = "Interim",
                DescriptionNL = "Interim"
            };
            appRespository.EmpContractType.Add(newContrType_interim);

            #endregion--------------------------------------------------------------------------------------


            #region------------------------------------------- Add EmpContractStatuutType-------------------
            EmpContractStatuutType empContrStatuutType_arbeider = new EmpContractStatuutType
            {
                DescriptionEN = "Worker",
                DescriptionNL = "Arbeider"
            };
            appRespository.EmpContractStatuutType.Add(empContrStatuutType_arbeider);

            EmpContractStatuutType empContrStatuutType_bediende = new EmpContractStatuutType
            {
                DescriptionEN = "Servant",
                DescriptionNL = "Bediende"
            };
            appRespository.EmpContractStatuutType.Add(empContrStatuutType_bediende);

            EmpContractStatuutType empContrStatuutType_Ambtenaar = new EmpContractStatuutType
            {
                DescriptionEN = "Civil servant",
                DescriptionNL = "Ambtenaar"
            };
            appRespository.EmpContractStatuutType.Add(empContrStatuutType_Ambtenaar);


            #endregion--------------------------------------------------------------------------------------


            #region------------------------------------------- Add Employees  ------------------------------

            Employee employee_1 = new Employee()
            {
                //-------------------personMin---------
                FirstName = "Tom",
                //NameAddition = "niet vereist",
                LastName = "Dilen",
                Email = "tomtom@tom.tom",
                MobileNumber = "0123 11 22 33",
                //PhoneNumber = "niet vereist",

                //navprops


                //-------------------Person------------
                DateOfBirth = new DateTime(1981, 04, 22),
                IsMale = true,
                //nav props
                EmpAddress = new EmpAddress()
                {
                    Street = "Duivenstraat",
                    HouseNumber = 55,
                    //HouseNumberAddition = "nvt",
                    Zipcode = "2300",
                    City = "Turnhout",
                    Country = "Belgium"
                },

                //-------------------Employee----------
                PassPortID = "0122222111",
                IBAN = "12220132145545",
                JobInfo = "waarken lak een biest",
                extraInfo = "zag er ne toffe gast uit bij de sollicitatie",

                //navProps 
                //id voor departement is genoeg :-)
                Id_EmpDepartment = 1, //1=Administrator, 2=Verkoop, 3=Magazijn

                EmpContract = new EmpContract()
                {
                    MonthSalary = 2222.22f,
                    DateOfStart = new DateTime(2020, 12, 2),
                    Id_EmpContractStatuutType = 1,   // 1=Arbeider, 2=Bediende, 3=Ambtenaar
                    Id_EmpContractType = 1   // 1=Onbepaalde duur, 2=Jobstudent, 3=Interim
                },

                EmpAppAccount = new EmpAppAccount
                {
                    AppPermissions = Int64.MaxValue,
                    Password = "aaaaaaaaa",
                    UserName = "4444444444444444",
                    IsPaswordResseted = true,
                    LastResetted = DateTime.Now,
                    IsBlocked = false,
                    InlogAttempts = 0,
                }


            };
            appRespository.Employee.Add(employee_1);


            //Employee emp1 = new Employee()
            //{
            //    //----------------------people---------
            //    FirstName = "Joske",
            //    NameAddition = "De",
            //    LastName = "Keizer",
            //    Email = "tomtom@tomtom.com",
            //    IsMale = true,
            //    DateOfBirth = new DateTime(1920, 12, 8),
            //    MobileNumber = "20000020000",
            //    PhoneNumber = null,

            //    //--------------------Employee---------
            //    PassPortID = "011-111-44",
            //    IBAN = "BE444444444444",
            //    Id_Department = 1, // TODO : nog bijweerken
            //    AppPermissions = UInt64.MaxValue, //TODO
            //    RecruitedAt = DateTime.Now,
            //    FiredAt = DateTime.Now,

            //    IsPaswordUsernameResseted = true,
            //    Password = "adm",
            //    UserName = "adm",

            //    //-------------------Adress------------

            //    Address = new Address()
            //    {
            //        Street = "E34",
            //        HouseNumber = 15,
            //        HouseNumberAddition = "bus 1",
            //        Zipcode = "2000",
            //        City = "Antwaarpe",
            //        Country = "Belgium",
            //    }
            //    //Address = null,
            //};

            //appRespository.Employee.Add(emp1);



            #endregion--------------------------------------------------------------------------------------





            #region------------------------------------------- Add Departments------------------------------


            #endregion--------------------------------------------------------------------------------------





            #region------------------------------------------- Add Departments------------------------------
            #endregion--------------------------------------------------------------------------------------
            #region------------------------------------------- Add Departments------------------------------
            #endregion--------------------------------------------------------------------------------------
            #region------------------------------------------- Add Departments------------------------------
            #endregion--------------------------------------------------------------------------------------
            #region------------------------------------------- Add Departments------------------------------
            #endregion--------------------------------------------------------------------------------------
            #region------------------------------------------- Add Departments------------------------------
            #endregion--------------------------------------------------------------------------------------
            #region------------------------------------------- Add Departments------------------------------
            #endregion--------------------------------------------------------------------------------------


        }
    }
}
