
using KFSolutionsModel;
using KFSolutionsWPF.ViewModels;
using KFSolutionsWPF.Views;
using KFSrepository_EF6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TDS_wpf_extentions2.Transactioncontrol;

namespace KFSolutionsWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TDS_wpf_extentions2.Transactioncontrol.TDStransactionControl _transactionControl;

        private AppRepository<KfsContext> _appDbRespository;


        public MainWindow()
        {
            InitializeComponent();

            _appDbRespository = new AppRepository<KfsContext>("name=KFSsolutions");
            LoadMinData(_appDbRespository);

            _transactionControl = tdsTranscontrol; //control in de xaml
            _transactionControl.ParentWindow = this;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void ColumnDefinition_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && e.ClickCount == 2)
            {
                Button_ToggleMaximized(null, null);
            }
            //Console.WriteLine("testmmmmmmm");
            else if (e.ChangedButton == MouseButton.Left)
            {
                //Console.WriteLine("test");
                this.DragMove();
            }
        }



        private void Button_Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Minimizid(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Button_ToggleMaximized(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
            }
            else
            {
                this.WindowState = WindowState.Maximized;
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

            _transactionControl.SlideNewContent(new MainMenuViewModel(_appDbRespository, _transactionControl),
                TDStransactionControl.TransactionDirection.Right, 500);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //inloggen
            EmployeeRepository.EmployeeLoggedInDTO IngelogdGebruiker = _appDbRespository.Employee.LogIn("Tom_0123", "Tom_0123");
            if (_appDbRespository.Employee.InloggedEmployee == null)
            {
                MessageBox.Show("niet ingelogd tijdens test");
            }
            Console.WriteLine("ingelogd tijdens test: " + _appDbRespository.Employee.InloggedEmployee.FirstName);




            //_transactionControl.SlideNewContent(new InloggenViewModel(_appDbRespository, _transactionControl));
            //_transactionControl.SlideNewContent(new EmployeeAddNewViewModel(_appDbRespository, _transactionControl));
            //_transactionControl.SlideNewContent(new SupplierAddNewViewModel(_appDbRespository, _transactionControl));
            //_transactionControl.SlideNewContent(new ClientAddNewViewModel(_appDbRespository, _transactionControl));
            //_transactionControl.SlideNewContent(new ProductAddNewViewModel(_appDbRespository, _transactionControl));
            _transactionControl.SlideNewContent(new QuatationsViewModel(_appDbRespository, _transactionControl));
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Console.WriteLine(this.Width + " = " + this.Height);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }





        public static void LoadMinData(AppRepository<KfsContext> appRespository)
        {

            //als deze gebruiker bestaat, returnen, data moet niet opnieuw opgeslagen worden
            EmployeeRepository.EmployeeLoggedInDTO tmpTest = appRespository.Employee.LogIn("Tom_0123", "Tom_0123");
            if (tmpTest != null) return;



            #region =============================== MIN APPLICATIE VEREISTE ====================================


            #region------------------------------------------- Add Departments------------------------------

            EmpDepartment newDep_admin = new EmpDepartment()
            {
                DefaultPermissions = 0b0111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111,
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
                DefaultPermissions = 0b0000_0000_0000_0000_1111_1111_1111_1111_1111_1111_0000_0000_0000_0000_0000_0000,
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



            #region------------------------------------------- Add ProductType------------------------------
            ProductType productType_Dranken = new ProductType()
            {
                DescriptionNL = "Dranken",
                DescriptionEN = "Drinks"
            };
            appRespository.ProductType.Add(productType_Dranken);
            ProductType productType_Speelgoed = new ProductType()
            {
                DescriptionNL = "Speelgoed",
                DescriptionEN = "Toys"
            };
            appRespository.ProductType.Add(productType_Speelgoed);
            ProductType productType_Voedingswaren = new ProductType()
            {
                DescriptionNL = "Voedingswaren",
                DescriptionEN = "Foodstuffs"
            };
            appRespository.ProductType.Add(productType_Voedingswaren);
            ProductType productType_AutoOnderdelen = new ProductType()
            {
                DescriptionNL = "Auto onderdelen",
                DescriptionEN = "Car parts"
            };
            appRespository.ProductType.Add(productType_AutoOnderdelen);
            #endregion--------------------------------------------------------------------------------------



            #region employee_TomDilen amdin met alle rechten

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
                    //AppPermissions = 0b0100_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_1111_1111_1111_1111_1111,
                    AppPermissions = 0b0111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111,
                    Password = "Tom_0123",
                    UserName = "Tom_0123",
                    IsPaswordResseted = true,
                    LastResetted = DateTime.Now,
                    IsBlocked = false,
                    InlogAttempts = 0,
                }
            };
            appRespository.Employee.Add(employee_TomDilen);

            MessageBox.Show("Database terug geinitialiseerd");

            #endregion


            #endregion






            #region =========================================TESTDATA=============================================



            #region------------------------------------------- Add Employees  ------------------------------



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

                //EmpAppAccount = new EmpAppAccount
                //{
                //    AppPermissions = Int64.MaxValue,
                //    Password = "Maggie",
                //    UserName = "Maggie",
                //    IsPaswordResseted = true,
                //    LastResetted = DateTime.Now,
                //    IsBlocked = false,
                //    InlogAttempts = 0,
                //}
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
                    Password = "Alex_0123",
                    UserName = "Alex_0123",
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
                DateOfBirth = new DateTime(1980, 04, 01),
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



            #region------------------------------------------- Add Products---------------------------------
            Product product_Spaghetti = new Product()
            {
                //---------   id = EAN (geen oplopend nummer)
                EAN = "1111111111",

                ProductTitle = "Spaghetti Bolognaise",
                //ExtraInfo = "",

                SellingPriceRecommended = 5.22f,
                CountInStock = 0,
                MinCountInStock = 100,
                MaxCountInStock = 500,
                WareHouseLocation = "H44,01",
                BTWpercentage = 6,
                Id_ProductType = 2, //producType 1=Speelgoed, 2=Voedingswaren 3=Autoonderdelen
                //Image 


            };
            appRespository.Product.Add(product_Spaghetti);


            Product product_Ballenbad = new Product()
            {
                //---------   id = EAN (geen oplopend nummer)
                EAN = "222222222",

                ProductTitle = "Ballen bad",
                //ExtraInfo = "",

                SellingPriceRecommended = 105.22f,
                CountInStock = 0,
                MinCountInStock = 5,
                MaxCountInStock = 10,
                WareHouseLocation = "H44,02",
                BTWpercentage = 21,
                Id_ProductType = 1, //producType 1=Speelgoed, 2=Voedingswaren 3=Autoonderdelen
                //Image 

            };
            appRespository.Product.Add(product_Ballenbad);


            Product product_DoosLego = new Product()
            {
                //---------   id = EAN (geen oplopend nummer)
                EAN = "33333333",

                ProductTitle = "Lego StormMinds",
                //ExtraInfo = "",

                SellingPriceRecommended = 205.22f,
                CountInStock = 0,
                MinCountInStock = 6,
                MaxCountInStock = 20,
                WareHouseLocation = "H20,01",
                BTWpercentage = 21,
                Id_ProductType = 1, //producType 1=Speelgoed, 2=Voedingswaren 3=Autoonderdelen
                //Image 
                Supplier_Product_Prices = new List<Supplier_Product_Price>()
                {
                    new Supplier_Product_Price()
                    {
                        UnitPrice = 44.44f,
                        Id_Supplier = 1,
                        EAN_Product= "222222222"
                    }
                }

            };
            appRespository.Product.Add(product_DoosLego);


            Product product_NummerPlatenAuto = new Product()
            {
                //---------   id = EAN (geen oplopend nummer)
                EAN = "444444444",

                ProductTitle = "Nummerplaat",
                //ExtraInfo = "",

                SellingPriceRecommended = 15.99f,
                CountInStock = 0,
                MinCountInStock = 20,
                MaxCountInStock = 80,
                WareHouseLocation = "H47,02",
                BTWpercentage = 21,
                Id_ProductType = 3, //producType 1=Speelgoed, 2=Voedingswaren 3=Autoonderdelen
                //Image 

            };
            appRespository.Product.Add(product_NummerPlatenAuto);


            #endregion--------------------------------------------------------------------------------------



            #region------------------------------------------- Add OrdersIn --------------------------------

            OrderIn bestellengOut_1 = new OrderIn()
            {
                Id_OrderedBy = 1,
                Id_Supplier = 1,
                OrderedAt = DateTime.Now,
                OrderLineIns = new List<OrderLineIn>()
                {
                    new OrderLineIn(){ EAN_Product = "222222222", UnitPrice = 22.2f, NumberOfProducts=5},
                    new OrderLineIn(){ EAN_Product = "444444444", UnitPrice = 33.2f, NumberOfProducts=5}
                }
            };
            appRespository.OrderIn.Add(bestellengOut_1);
            #endregion--------------------------------------------------------------------------------------





            #region------------------------------------------- Add OrdersOut--------------------------------
            OrderOut bestelling_In1 = new OrderOut()
            {
                Id_Client = 1,
                OrderLineOuts = new List<OrderLineOut>()
                {
                    new OrderLineOut(){EAN_Product = "222222222" , UnitPrice = 22.33f ,NumberOfProducts=4 },
                    new OrderLineOut(){EAN_Product = "444444444" , UnitPrice = 22.33f ,NumberOfProducts=4 }
                }
            };
            appRespository.OrderOut.Add(bestelling_In1);


            #endregion--------------------------------------------------------------------------------------




            #region------------------------------------------- Add Quatations-------------------------------
            ProductQuotation quotation1 = new ProductQuotation()
            {
                ProductTitle = "Fanta blikjes 33cl",
                UnitPrice = 0.45f,
                DateQuatation = DateTime.Now,
                ExtraInfo = "goei materiaal",
                EAN_Product = "8888888",
                Id_Supplier = 1

            };
            appRespository.ProductQuotation.Add(quotation1);

            //ProductQuotation quotation2 = new ProductQuotation()
            //{
            //    UnitPrice = 10.20f,
            //    DateQuatation = DateTime.Now,
            //    //DateRegistered = 
            //    ExtraInfo = "",
            //    Id_Product = 2

            //};
            //appRespository.ProductQuotation.Add(quotation2);

            #endregion--------------------------------------------------------------------------------------



            #endregion============================================================================================











            ////inloggen
            //EmployeeRepository.EmployeeLoggedInDTO IngelogdGebruiker = appRespository.Employee.LogIn("Tom_0123", "Tom_0123");
            //if (IngelogdGebruiker == null)
            //{
            //    System.Windows.Forms.MessageBox.Show("null");
            //}
            //else
            //{
            //    System.Windows.Forms.MessageBox.Show("joepi, ingelogd");
            //}




        }
    }
}