using KFSolutionsModel;
using KFSolutionsWPF.Commands;
using KFSolutionsWPF.Views;
using KFSrepository_EF6;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TDS_wpf_extentions2.Transactioncontrol;

namespace KFSolutionsWPF.ViewModels
{

    public class QuatationsViewModel : _appViewModel
    {
        private const string PATH_QUOTATIONS = "productQuotations";
        private const string PATH_PENDING = PATH_QUOTATIONS+ "/productQuotation_pending";
        private const string PATH_SJABLONS = PATH_QUOTATIONS + "/productQuotation_sjablon";
        private const string PATH_DELETED = PATH_QUOTATIONS + "/productQuotation_deleted";
        private const string PATH_ADDED = PATH_QUOTATIONS + "/productQuotation_added";
        private FileSystemWatcher watcher = new FileSystemWatcher();


        public List<Supplier> SuppliersAll { get; set; }
        public Supplier SelectedSuplier { get; set; }

        public ObservableCollection<ProductQuotation> QuatationsAll { get; set; }
        public ProductQuotation SelectedQutation { get; set; }


        public ICommand Command_MakeJson { get; set; }

        public ICommand Command_NewProduct { get; set; }

        public ICommand Command_ConfirmQuatation { get; set; }

        private List<string> ExistingEANsInDB; 

        //==============================================================================================================
        public QuatationsViewModel(AppRepository<KfsContext> aAppDbRepository, TDStransactionControl aTDStransactionControl)
        : base(aAppDbRepository, aTDStransactionControl)
        {
            _myView = new QuatationsView();
            _myView.DataContext = this;

            watcher.Path = PATH_PENDING;
            watcher.Created += new FileSystemEventHandler(OnPendingFilesChanged);
            watcher.Deleted += new FileSystemEventHandler(OnPendingFilesChanged);
            watcher.EnableRaisingEvents = true;


            Command_MakeJson = new RelayCommand(MakeJsonSjabloon,CanMakeJsonSjabloon);
            Command_NewProduct = new RelayCommand(AddNewProduct, CanAddNewProduct);
            Command_ConfirmQuatation = new RelayCommand(ConfirmQuatation, CanConfirmQuatation);

            SuppliersAll = aAppDbRepository.Supplier.GetAll().ToList();

            

            LoadPendingJsonFiles();

        }

        private bool CanConfirmQuatation(object obj)
        {
            if (SelectedQutation == null) return false;

            if ( ! ExistingEANsInDB.Contains(SelectedQutation.EAN_Product)) return false;

            return true;
        }

        private void ConfirmQuatation(object obj)
        {
            //Console.WriteLine("confirm");
            Supplier_Product_Price toAdd = new Supplier_Product_Price()
            {
                UnitPrice = SelectedQutation.UnitPrice,
                Id_Supplier = SelectedQutation.Supplier.Id,
                EAN_Product = SelectedQutation.EAN_Product
            };
            //Console.WriteLine(toAdd.Id_Supplier);
            try
            {
                _appDbRespository.Supplier_Product_Price.Add(toAdd);
                //MessageBox.Show("Produkt met succes toegevoegd");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.InnerException);
                return;
            }

            MoveJsonfileWithInloggedEmployeeId(PATH_ADDED);

        }
        private void MoveJsonfileWithInloggedEmployeeId(string aDirectory)
        {
            //verplaatsen van jsonfile
            string json = JsonConvert.SerializeObject(SelectedQutation, Formatting.Indented);

            string path = aDirectory + "/";
            string bestandsnaam = string.Format("{0:yy-MM-dd_HH-mm-ss}", DateTime.Now) + "_" +
                _appDbRespository.Employee.InloggedEmployee.Id.ToString("D4") + ".json";

            try
            {
                File.WriteAllText(path + bestandsnaam, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show("er is een fout opgetreden bij schrijven van het bestand\n" +
                    "raadpleeg de leverancier als deze fout zich blijft voordoen\n\n" +
                    ex.Message);
                return;
            }

            //verwijderen van bestand
            File.Delete(SelectedQutation.bestandsPath);
        }

        private bool CanAddNewProduct(object obj)
        {
            if (SelectedQutation == null) return false;

            if (ExistingEANsInDB.Contains(SelectedQutation.EAN_Product)) return false;

            return true;
        }

        private void AddNewProduct(object obj)
        {
            Console.WriteLine("add new product");
            Product toAdd = new Product()
            {
                EAN = SelectedQutation.EAN_Product,
                ExtraInfo = SelectedQutation.ExtraInfo,
                ProductTitle = SelectedQutation.ProductTitle,

            };
            _transactionControl.SlideNewContent(
                new ProductAddNewViewModel(_appDbRespository, _transactionControl,ProductAddNewViewModel.ViewType.NewFromQuatations,toAdd),
                TDStransactionControl.TransactionDirection.Left,500);
        }



        private bool CanMakeJsonSjabloon(object obj)
        {
            if (SelectedSuplier == null) return false;
            return true;
        }

        private void MakeJsonSjabloon(object obj)
        {
            //Console.WriteLine(SelectedSuplier.Name);

            ProductQuotation tmpQuotation = new ProductQuotation()
            {
                EAN_Product = "",
                ProductTitle = "",
                ExtraInfo = "",
                DateQuatation = DateTime.Now,
            };

            string json = JsonConvert.SerializeObject(tmpQuotation, Formatting.Indented);

            string path = PATH_SJABLONS + "/";
            string bestandsnaam = string.Format("{0:yy-MM-dd_HH-mm-ss}", DateTime.Now) + "_" + SelectedSuplier.Id.ToString("D4") + ".json";

            try
            {
                File.WriteAllText(path + bestandsnaam, json);
            }
            catch(Exception ex)
            {
                MessageBox.Show("er is een fout opgetreden bij schrijven van het bestand\n" + 
                    "raadpleeg de leverancier als deze fout zich blijft voordoen\n\n" +
                    ex.Message);
                return;
            }

            if ( MessageBoxResult.Yes ==
                MessageBox.Show("sjabloon met succes aangemaakt, wil je de de map openen?","ok", MessageBoxButton.YesNo, MessageBoxImage.Question))
            {
                Process.Start(Directory.GetCurrentDirectory() + "/" + PATH_SJABLONS);
            }

        }

        private void LoadPendingJsonFiles()
        {
            List<string> EANs = new List<string>();

            ObservableCollection<ProductQuotation> terug = new ObservableCollection<ProductQuotation>();

            foreach (string bestandsnaam in Directory.EnumerateFiles(Directory.GetCurrentDirectory() + "/" + PATH_PENDING, "*.json"))
            {
                //string contents = File.ReadAllText(file);
                //Console.WriteLine("\n------------------" + bestandsnaam);
                ProductQuotation discoveredJson = JsonConvert.DeserializeObject<ProductQuotation>(File.ReadAllText(bestandsnaam));

                //string bestandsnaamZonderExtentie = Path.GetFileName(bestandsnaam);
                string bestandsnaamZonderExtentie = Path.GetFileNameWithoutExtension(bestandsnaam);
                int idLeverancier = Convert.ToInt32(bestandsnaamZonderExtentie.Split('_')[2].Substring(0,4));
                //Console.WriteLine("11111111111111111     " + idLeverancier);

                //string json = JsonConvert.SerializeObject(discoveredJson, Formatting.Indented);

                //Console.WriteLine(json);

                discoveredJson.Supplier = SuppliersAll.FirstOrDefault(X => X.Id == idLeverancier);
                discoveredJson.bestandsPath = bestandsnaam;
                
                terug.Add(discoveredJson);
                EANs.Add(discoveredJson.EAN_Product);
            }

            EANs =  EANs.Distinct().ToList();
            EANs = _appDbRespository.Product.GetExistingEANsFromEanList(EANs);

            this.ExistingEANsInDB = EANs;


            QuatationsAll = terug;
            //return terug;
        }




        private void OnPendingFilesChanged(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("filesysteem veranderd");
            LoadPendingJsonFiles();
        }
    }
}
