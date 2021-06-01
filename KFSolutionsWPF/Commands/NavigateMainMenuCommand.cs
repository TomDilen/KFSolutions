
using KFSolutionsWPF.Views;
using KFSrepository_EF6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDS_wpf_extentions2.Transactioncontrol;

namespace KFSolutionsWPF.Commands
{
    class NavigateMainMenuCommand : CommandBase
    {
        private readonly TDStransactionControl _transactionControl;
        private AppRepository<KfsContext> _appDbRespository;

        public NavigateMainMenuCommand(TDStransactionControl aTransactionControl, AppRepository<KfsContext> aAppDbRespository)
        {
            _transactionControl = aTransactionControl;
            _appDbRespository = aAppDbRespository;
        }

        public override void Execute(object parameter)
        {
           // _transactionControl.SlideNewContent(new MainMenuView(_transactionControl, _appDbRespository));
        }
    }
}
