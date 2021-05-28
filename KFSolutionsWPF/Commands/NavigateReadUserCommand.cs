
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDS_wpf_lib.Transactioncontrol;

namespace KFSolutionsWPF.Commands
{
    public class NavigateReadUserCommand : CommandBase
    {
        private readonly TDStransactionControl _transactionControl;

        public NavigateReadUserCommand(TDStransactionControl aTransactionControl)
        {
            _transactionControl = aTransactionControl;
        }

        public override void Execute(object parameter)
        {
            //_transactionControl.
        }
    }
}
