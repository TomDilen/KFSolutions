using KFSolutionsWPF.Views;
using KFSrepository_EF6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDS_wpf_extentions2.Transactioncontrol;

namespace KFSolutionsWPF.ViewModels
{
    public class OrderInAddNewViewModel : _appViewModel
    {

        //==============================================================================
        



        //==============================================================================


        public OrderInAddNewViewModel(
            AppRepository<KfsContext> aAppDbRepository, TDStransactionControl aTDStransactionControl)
            : base(aAppDbRepository, aTDStransactionControl)
        {
            _myView = new OrderInAddNewView();
            _myView.DataContext = this;



        }
    }
}

