
using KFSolutionsWPF.Views;
using KFSrepository_EF6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KFSolutionsWPF.ViewModels
{
    //public class MainMenuViewModel<Tview> : _appViewModel<Tview> where Tview : UserControl, new()
    public class MainMenuViewModel: _appViewModel
    {
        //==============================================================================
        //public ICommand NavigateMainMenuCommand { get; }


        //==============================================================================

        public MainMenuViewModel(AppRepository<KfsContext> aAppDbRepository, TDS_wpf_lib.Transactioncontrol.TDStransactionControl aTDStransactionControl) 
            : base(aAppDbRepository, aTDStransactionControl)
        {
            _myView = new MainMenuView();
            _myView.DataContext = this;

            // TDSnavigationView x = new InloggenView();
            //NavigateMainMenuCommand = new NavigateMainMenuCommand(aTransactionControl,)
        }
}
}
