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

            //try
            //{


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

                #region employee_TomDilen

                Employee employee_TomDilen = new Employee()
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
                    ExtraInfo = "zag er ne toffe gast uit bij de sollicitatie",

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
                appRespository.Employee.Add(employee_TomDilen);

                #endregion

                #region employee_MaggieDeBlock

                Employee employee_MaggieDeBlock = new Employee()
                {
                    //-------------------personMin---------
                    FirstName = "Maggie",
                    NameAddition = "De",
                    LastName = "Block",
                    Email = "dikkiedik@dik.dik",
                    MobileNumber = "0123 45 67 89",
                    PhoneNumber = "23 23 23 23 23",

                    //navprops


                    //-------------------Person------------
                    DateOfBirth = new DateTime(1981, 04, 22),
                    IsMale = true,
                    //nav props
                    EmpAddress = new EmpAddress()
                    {
                        Street = "vetstraat",
                        HouseNumber = 55,
                        //HouseNumberAddition = "nvt",
                        Zipcode = "1000",
                        City = "Brussel",
                        Country = "Belgium"
                    },

                    //-------------------Employee----------
                    PassPortID = "01222244444",
                    IBAN = "12220132148888",
                    JobInfo = "mondmaskers verbranden",
                    ExtraInfo = "toffe griet yoh",

                    //navProps 
                    //id voor departement is genoeg :-)
                    Id_EmpDepartment = 3, //1=Administrator, 2=Verkoop, 3=Magazijn

                    EmpContract = new EmpContract()
                    {
                        MonthSalary = 1400.22f,
                        DateOfStart = new DateTime(1950, 11, 22),
                        Id_EmpContractStatuutType = 2,   // 1=Arbeider, 2=Bediende, 3=Ambtenaar
                        Id_EmpContractType = 2   // 1=Onbepaalde duur, 2=Jobstudent, 3=Interim
                    },

                    EmpAppAccount = new EmpAppAccount
                    {
                        AppPermissions = Int64.MaxValue,
                        Password = "Maggie",
                        UserName = "Maggie",
                        IsPaswordResseted = true,
                        LastResetted = DateTime.Now,
                        IsBlocked = false,
                        InlogAttempts = 0,
                    }
                };
                appRespository.Employee.Add(employee_MaggieDeBlock);

                #endregion


                #region employee_AlexanderDeCroo

                Employee employee_AlexanderDeCroo = new Employee()
                {
                    //-------------------personMin---------
                    FirstName = "Alexander",
                    NameAddition = "De",
                    LastName = "Kraai",
                    Email = "Graaier@graai.graai",
                    MobileNumber = "0123 45 67 40",
                    PhoneNumber = "23 23 23 23 98",

                    //navprops


                    //-------------------Person------------
                    DateOfBirth = new DateTime(1982, 04, 1),
                    IsMale = true,
                    //nav props
                    EmpAddress = new EmpAddress()
                    {
                        Street = "wetstraat",
                        HouseNumber = 55,
                        //HouseNumberAddition = "nvt",
                        Zipcode = "1040",
                        City = "Vettigem",
                        Country = "Duitsland"
                    },

                    //-------------------Employee----------
                    PassPortID = "5555555555",
                    IBAN = "121212121212",
                    JobInfo = "Graaien in de vetpot",
                    ExtraInfo = "nen echte fille de papa",

                    //navProps 
                    //id voor departement is genoeg :-)
                    Id_EmpDepartment = 2, //1=Administrator, 2=Verkoop, 3=Magazijn

                    EmpContract = new EmpContract()
                    {
                        MonthSalary = 1200.22f,
                        DateOfStart = new DateTime(1970, 11, 22),
                        Id_EmpContractStatuutType = 3,   // 1=Arbeider, 2=Bediende, 3=Ambtenaar
                        Id_EmpContractType = 3   // 1=Onbepaalde duur, 2=Jobstudent, 3=Interim
                    },

                    EmpAppAccount = new EmpAppAccount
                    {
                        AppPermissions = Int64.MaxValue,
                        Password = "Alexander",
                        UserName = "Alexander",
                        IsPaswordResseted = true,
                        LastResetted = DateTime.Now,
                        IsBlocked = false,
                        InlogAttempts = 0,
                    }
                };
                appRespository.Employee.Add(employee_AlexanderDeCroo);

                #endregion




                #endregion--------------------------------------------------------------------------------------





                #region------------------------------------------- Add Suppliers--------------------------------
                Supplier supPConderdelen = new Supplier()
                {
                    CmpManagers = new List<CmpManager>() {
                        new CmpManager()
                        {
                            FirstName = "TomsupPConderdelen",
                            //NameAddition = "van",
                            LastName = "ManagersupPConderdelen",
                            Email = "tom@supPConderdelen.com",
                            MobileNumber = "0114",
                            PhoneNumber = "222222244522"
                        }
                    },

                    CompanyNumber = "551555555",
                    Name = "supPConderdelen Turnhout",
                    Website = "supPConderdelenTurnhout.be",
                    BtwNumber = "BE 4555555",
                    Email = "supPConderdelenTurnhout@ttt.ccc",
                    ExtraInfo = "dit is extrainfo over supPConderdelen turnhout",



                    CmpIBANs = new List<CmpIBAN>() {
                        new CmpIBAN { Number = "222-22222-22-222", IsDefault = true  }
                    },
                    CmpSites = new List<CmpSite>() {
                    new CmpSite()
                    {
                        IsDefault = true,
                        CmpSiteAddress = new CmpSiteAddress()
                        {
                            Street = "gasthuissstraat",
                            HouseNumber = 55,
                            HouseNumberAddition = "22",
                            Country = "Belgie",
                            Zipcode = "2000",
                            City = "Antwerpen"
                        },
                        Fax = "222222222",
                        PhoneNumber = "012345678",
                        PhoneNumber_2 = "555220",
                        MobileNumber = "014556699",
                        Email = "supPConderdelen@tototototm.com",
                        ExtraInfo = "extra info over hoofdsite van supPConderdelen Turnhout",
                        CmpSiteContactPersons = new List<CmpSiteContactPerson>()
                        {
                            new CmpSiteContactPerson()
                            {
                                FirstName = "TomsupPConderdelenContact",
                                //NameAddition = "van",
                                LastName = "DilenContact",
                                Email = "onderdelen@cola.com",
                                MobileNumber = "0111111111121",
                                PhoneNumber = "2222222222",

                                IsDefault = true,
                                ExtraInfo = "geen extra info over dez contactpersoon van supPConderdelen"
                            }
                        },
                    },
                },
            };
            appRespository.Supplier.Add(supPConderdelen);





            Supplier supCocaCola = new Supplier()
            {
                CmpManagers = new List<CmpManager>() {
                        new CmpManager()
                        {
                            FirstName = "TomCocaCola",
                            //NameAddition = "van",
                            LastName = "DilenManager",
                            Email = "tomCola@cola.com",
                            MobileNumber = "011111111111",
                            PhoneNumber = "222222222"
                        }
                    },

                CompanyNumber = "55555555",
                Name = "Cocacola Turnhout",
                Website = "CocColaTurnhout.be",
                BtwNumber = "BE 444444444",
                Email = "cococolaTurnhout@ttt.ccc",
                ExtraInfo = "dit is extrainfo over coca cola turnhout",



                CmpIBANs = new List<CmpIBAN>() {
                        new CmpIBAN { Number = "222-22222-22-222", IsDefault = true  }
                    },
                CmpSites = new List<CmpSite>() {
                    new CmpSite()
                    {
                        IsDefault = true,
                        CmpSiteAddress = new CmpSiteAddress()
                        {
                            Street = "druivenstraat",
                            HouseNumber = 55,
                            HouseNumberAddition = "22",
                            Country = "Belgie",
                            Zipcode = "2300",
                            City = "Turnhout"
                        },
                        Fax = "1111111111",
                        PhoneNumber = "4444444444",
                        PhoneNumber_2 = "2222222222",
                        MobileNumber = "55555555",
                        Email = "tomtom@tototototm.com",
                        ExtraInfo = "extra info over hoofdsite van cococola Turnhout",
                        CmpSiteContactPersons = new List<CmpSiteContactPerson>()
                        {
                            new CmpSiteContactPerson()
                            {
                                FirstName = "TomCocaColaContact",
                                //NameAddition = "van",
                                LastName = "DilenContact",
                                Email = "tomCola@cola.com",
                                MobileNumber = "011111111111",
                                PhoneNumber = "222222222",

                                IsDefault = true,
                                ExtraInfo = "geen extra info over dez contactpersoon"
                            }
                        },
                    },
                },
            };
            appRespository.Supplier.Add(supCocaCola);


            //========================================================================================

            Supplier supKenField = new Supplier()
            {
                CmpManagers = new List<CmpManager>() {
                        new CmpManager()
                        {
                            FirstName = "Ken",
                            //NameAddition = "van",
                            LastName = "Field",
                            Email = "ken@multimedi.be",
                            MobileNumber = "0478670924",
                            //PhoneNumber = "222222244522"
                        }
                    },

                CompanyNumber = "000111222",
                Name = "KenFieldSupplier",
                Website = "KenFieldSupplier.be",
                BtwNumber = "BE 4555588",
                Email = "ken@multimedi.be",
                ExtraInfo = "Teacher .Net developper at Multimedi",



                CmpIBANs = new List<CmpIBAN>() {
                        new CmpIBAN { Number = "2222222222", IsDefault = true  }
                    },
                CmpSites = new List<CmpSite>() {
                    new CmpSite()
                    {
                        IsDefault = true,
                        CmpSiteAddress = new CmpSiteAddress()
                        {
                            Street = "Avenue de Kenfield",
                            HouseNumber = 55,
                            //HouseNumberAddition = "22",
                            Country = "KenLand",
                            Zipcode = "9999",
                            City = "Fieldegem"
                        },
                        Fax = "222222222",
                        PhoneNumber = "0478670924",

                    },
                },
            };
            appRespository.Supplier.Add(supKenField);


            #endregion--------------------------------------------------------------------------------------




            #region------------------------------------------- Add Clients ---------------------------------

            Client client_TimAudenaarde = new Client
            {
                IsActive = true,
                CltWebCredentials = new CltWebCredentials()
                {
                    Password = "Tim__123",
                    UserName = "Tim__123",
                    InlogAttempts = 0,
                    IsBlocked = false,
                    IsPaswordResseted = false,
                    LastResetted = DateTime.Now,
                },
                FirstName = "Tim",
                //NameAddition ,

                LastName = "Audenaarde",
                Email = "tim.audenaert@hotmail.be",
                MobileNumber = "0123456",
                PhoneNumber = "",
                DateOfBirth = new DateTime(1980,04,01),
                IsMale = true,

                CltAddresss = new List<CltAddress>()
                {
                    new CltAddress()
                    {
                        Street = "TimseSteenweg",
                        HouseNumber = 33,
                        HouseNumberAddition = "b3",
                        Country = "Belgie",
                        Zipcode = "1000",
                        City = "Bornem"
                    }
                },
            };
            appRespository.Client.Add(client_TimAudenaarde);


            //==================================================================================


            Client client_KennyBruwier = new Client
            {
                IsActive = true,
                CltWebCredentials = new CltWebCredentials()
                {
                    Password = "Kenny__123",
                    UserName = "Kenny__123",
                    InlogAttempts = 0,
                    IsBlocked = false,
                    IsPaswordResseted = false,
                    LastResetted = DateTime.Now,
                },
                FirstName = "Kenny",
                //NameAddition ,

                LastName = "Bruwier",
                Email = "kweetnognie",
                MobileNumber = "2222222",
                PhoneNumber = "014555555",
                DateOfBirth = new DateTime(1975, 04, 01),
                IsMale = true,

                CltAddresss = new List<CltAddress>()
                {
                    new CltAddress()
                    {
                        Street = "Avenue le Kennedy",
                        HouseNumber =66,
                        //HouseNumberAddition = "b3",
                        Country = "Belgie",
                        Zipcode = "1000",
                        City = "RupelMonde"
                    }
                },
            };
            appRespository.Client.Add(client_KennyBruwier);
            


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


            //}
            //catch (Exception ex)
            //{
            //    System.Windows.Forms.MessageBox.Show(ex.Message);
            //}
        }
    }
}
