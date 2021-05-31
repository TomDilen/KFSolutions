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

namespace KFSolutionsWPF.ViewModels
{
    public class SupplierAddNewViewModel : _appViewModel
    {
        //==============================================================================

        public ICommand Command_AddSupplier { get; set; }


        public Supplier NewSupplier { get; set; }
        //==============================================================================

        public SupplierAddNewViewModel(
            AppRepository<KfsContext> aAppDbRepository, TDS_wpf_lib.Transactioncontrol.TDStransactionControl aTDStransactionControl)
                : base(aAppDbRepository, aTDStransactionControl)
        {
            _myView = new SupplierAddNewView();
            _myView.DataContext = this;

            Command_AddSupplier = new RelayCommand(SaveSupplier);

            //nodig om te adden
            NewSupplier = new Supplier();
            NewSupplier.CmpManagers = new List<CmpManager>() { new CmpManager() { IsMain=true} };
            NewSupplier.CmpIBANs = new List<CmpIBAN>() { new CmpIBAN() {IsDefault=true } };
            
            NewSupplier.CmpSites = new List<CmpSite>() { new CmpSite() { IsDefault = true } };
            NewSupplier.CmpSites.ToList()[0].CmpSiteAddress = new CmpSiteAddress();
            NewSupplier.CmpWebCredentials = new CmpWebCredentials();

        }

        private void SaveSupplier(object obj)
        {
            //============================================================

            //============================================================
            Console.WriteLine(NewSupplier.Name);
            Console.WriteLine(NewSupplier.Email);
            Console.WriteLine(NewSupplier.Website);
            Console.WriteLine(NewSupplier.BtwNumber);
            Console.WriteLine(NewSupplier.CompanyNumber);

            Console.WriteLine(NewSupplier.CmpIBANs.ToList()[0].Number);

            Console.WriteLine(NewSupplier.ExtraInfo);


            Console.WriteLine(NewSupplier.CmpManagers.ToList()[0].FirstName);
            Console.WriteLine(NewSupplier.CmpManagers.ToList()[0].NameAddition);
            Console.WriteLine(NewSupplier.CmpManagers.ToList()[0].LastName);
            Console.WriteLine(NewSupplier.CmpManagers.ToList()[0].Email);
            Console.WriteLine(NewSupplier.CmpManagers.ToList()[0].MobileNumber);
            Console.WriteLine(NewSupplier.CmpManagers.ToList()[0].PhoneNumber);




            Console.WriteLine(NewSupplier.CmpSites.ToList()[0].CmpSiteAddress.Street);
            Console.WriteLine(NewSupplier.CmpSites.ToList()[0].CmpSiteAddress.HouseNumber);
            Console.WriteLine(NewSupplier.CmpSites.ToList()[0].CmpSiteAddress.HouseNumberAddition);
            Console.WriteLine(NewSupplier.CmpSites.ToList()[0].CmpSiteAddress.Zipcode);
            Console.WriteLine(NewSupplier.CmpSites.ToList()[0].CmpSiteAddress.City);
            Console.WriteLine(NewSupplier.CmpSites.ToList()[0].CmpSiteAddress.Country);
            Console.WriteLine(NewSupplier.CmpSites.ToList()[0].PhoneNumber);
            Console.WriteLine(NewSupplier.CmpSites.ToList()[0].MobileNumber);
            Console.WriteLine(NewSupplier.CmpSites.ToList()[0].Fax);



            Console.WriteLine(NewSupplier.CmpWebCredentials.UserName);
            Console.WriteLine(NewSupplier.CmpWebCredentials.Password);



            try
            {
                _appDbRespository.Supplier.Add(NewSupplier);
                MessageBox.Show("Leverancier met succes toegevoegd");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.InnerException);
            }


        }
    }
}
        //    CompanyNumber = "551555555",
        //    Name = "supPConderdelen Turnhout",
        //    Website = "supPConderdelenTurnhout.be",
        //    BtwNumber = "BE 4555555",
        //    Email = "supPConderdelenTurnhout@ttt.ccc",
        //    ExtraInfo = "dit is extrainfo over supPConderdelen turnhout",

        //    CmpIBANs = new List<CmpIBAN>() {
        //                        new CmpIBAN { Number = "222-22222-22-222", IsDefault = true  }
        //                    },



        //    CmpManagers = new List<CmpManager>() {
        //                        new CmpManager()
        //                        {
        //                            FirstName = "TomsupPConderdelen",
        //                            //NameAddition = "van",
        //                            LastName = "ManagersupPConderdelen",
        //                            Email = "tom@supPConderdelen.com",
        //                            MobileNumber = "0114",
        //                            PhoneNumber = "222222244522"
        //                        }
        //                    },






//    CmpSites = new List<CmpSite>() {
//                    new CmpSite()
//                    {
//                        IsDefault = true,
//                        CmpSiteAddress = new CmpSiteAddress()
//                        {
//                            Street = "gasthuissstraat",
//                            HouseNumber = 55,
//                            HouseNumberAddition = "22",
//                            Country = "Belgie",
//                            Zipcode = "2000",
//                            City = "Antwerpen"
//                        },
//                        Fax = "222222222",
//                        PhoneNumber = "012345678",
//                        PhoneNumber_2 = "555220",
//                        MobileNumber = "014556699",
//                        Email = "supPConderdelen@tototototm.com",
//                        ExtraInfo = "extra info over hoofdsite van supPConderdelen Turnhout",
//                        CmpSiteContactPersons = new List<CmpSiteContactPerson>()
//                        {
//                            new CmpSiteContactPerson()
//                            {
//                                FirstName = "TomsupPConderdelenContact",
//                                //NameAddition = "van",
//                                LastName = "DilenContact",
//                                Email = "onderdelen@cola.com",
//                                MobileNumber = "0111111111121",
//                                PhoneNumber = "2222222222",

//                                IsDefault = true,
//                                ExtraInfo = "geen extra info over dez contactpersoon van supPConderdelen"
//                            }
//                        },
//                    },
//                },
//};
//appRespository.Supplier.Add(supPConderdelen);












//Supplier supPConderdelen = new Supplier()
//{
//    CmpManagers = new List<CmpManager>() {
//                        new CmpManager()
//                        {
//                            FirstName = "TomsupPConderdelen",
//                            //NameAddition = "van",
//                            LastName = "ManagersupPConderdelen",
//                            Email = "tom@supPConderdelen.com",
//                            MobileNumber = "0114",
//                            PhoneNumber = "222222244522"
//                        }
//                    },

//    CompanyNumber = "551555555",
//    Name = "supPConderdelen Turnhout",
//    Website = "supPConderdelenTurnhout.be",
//    BtwNumber = "BE 4555555",
//    Email = "supPConderdelenTurnhout@ttt.ccc",
//    ExtraInfo = "dit is extrainfo over supPConderdelen turnhout",



//    CmpIBANs = new List<CmpIBAN>() {
//                        new CmpIBAN { Number = "222-22222-22-222", IsDefault = true  }
//                    },
//    CmpSites = new List<CmpSite>() {
//                    new CmpSite()
//                    {
//                        IsDefault = true,
//                        CmpSiteAddress = new CmpSiteAddress()
//                        {
//                            Street = "gasthuissstraat",
//                            HouseNumber = 55,
//                            HouseNumberAddition = "22",
//                            Country = "Belgie",
//                            Zipcode = "2000",
//                            City = "Antwerpen"
//                        },
//                        Fax = "222222222",
//                        PhoneNumber = "012345678",
//                        PhoneNumber_2 = "555220",
//                        MobileNumber = "014556699",
//                        Email = "supPConderdelen@tototototm.com",
//                        ExtraInfo = "extra info over hoofdsite van supPConderdelen Turnhout",
//                        CmpSiteContactPersons = new List<CmpSiteContactPerson>()
//                        {
//                            new CmpSiteContactPerson()
//                            {
//                                FirstName = "TomsupPConderdelenContact",
//                                //NameAddition = "van",
//                                LastName = "DilenContact",
//                                Email = "onderdelen@cola.com",
//                                MobileNumber = "0111111111121",
//                                PhoneNumber = "2222222222",

//                                IsDefault = true,
//                                ExtraInfo = "geen extra info over dez contactpersoon van supPConderdelen"
//                            }
//                        },
//                    },
//                },
//};
//appRespository.Supplier.Add(supPConderdelen);