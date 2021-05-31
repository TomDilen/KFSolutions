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

namespace KFSolutionsWPF.ViewModels
{
    public class QuatationsViewModel : _appViewModel
    {
        public List<Supplier> SuppliersAll { get; set; }
        Supplier SelectedSuplier { get; set; }

        public ICommand Command_MakeJson { get; set; }

        public QuatationsViewModel(AppRepository<KfsContext> aAppDbRepository, TDS_wpf_lib.Transactioncontrol.TDStransactionControl aTDStransactionControl)
        : base(aAppDbRepository, aTDStransactionControl)
        {
            _myView = new QuatationsView();
            _myView.DataContext = this;


            Command_MakeJson = new RelayCommand(MakeJson,CanMakeJson);


            SuppliersAll = aAppDbRepository.Supplier.GetAll().ToList();

            //foreach (var item in SuppliersAll)
            //{
            //    Console.WriteLine(item.Name);
            //}

        }

        private bool CanMakeJson(object obj)
        {
            return true;
        }

        private void MakeJson(object obj)
        {
            Console.WriteLine(SelectedSuplier.Name);
        }
    }
}
