using KFSolutionsWPF.Views;
using KFSrepository_EF6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDS_wpf_lib.Transactioncontrol;

namespace KFSolutionsWPF.ViewModels
{
    public class EmployeeAddNewViewModel : _appViewModel
    {
        //==============================================================================

        //public ICommand Command_Inloggen { get; set; }

        //public string StatusMessage { get; set; }

        //public string Username { get; set; } = "Tom_0123";
        //public string Password { get; set; } = "Tom_0123";


        //==============================================================================
        public EmployeeAddNewViewModel(
            AppRepository<KfsContext> aAppDbRepository, TDStransactionControl aTDStransactionControl)
            : base(aAppDbRepository, aTDStransactionControl)
        {
            _myView = new EmployeeAddNewView();
            _myView.DataContext = this;
        }
    }
}
