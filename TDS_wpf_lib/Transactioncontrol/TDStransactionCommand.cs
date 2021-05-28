
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TDS_wpf_lib.Transactioncontrol
{
    public class TDStransactionCommand : ICommand
    {

        readonly Action<object> _execute;
        readonly Predicate<object> _canExecute;


        //private bool _canExecute;

        private readonly TDStransactionControl _transactionControl;

        public TDStransactionCommand(Action<object> execute, TDStransactionControl aTransactionControl) 
            : this(execute, null, aTransactionControl) { }

        public TDStransactionCommand(Action<object> execute ,Predicate<object> canExecute,
            TDStransactionControl aTransactionControl)
        {
            _transactionControl = aTransactionControl;


            if (execute == null)
                throw new ArgumentNullException("execute");
            _execute = execute; 


            _canExecute = canExecute;
        }

        [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            //return _canExecute;
            return _canExecute == null ? true : _canExecute(parameter);
        }
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public void Execute(object parameter) { _execute(parameter); }
    }
}
