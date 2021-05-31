using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TDS_wpf_lib.Transactioncontrol
//namespace KFSolutionsWPF.TDSnavigationViewModel
{
    //public class TDSnavigationViewModel<Tview> : INotifyPropertyChanged where Tview : UserControl, new()
    public class TDStransactionViewModel //: INotifyPropertyChanged
    {

       //public event PropertyChangedEventHandler PropertyChanged;

        public UserControl _myView;

        public readonly TDStransactionControl _transactionControl;
        



        public TDStransactionViewModel(TDStransactionControl aTDStransactionControl)
        {

            _transactionControl = aTDStransactionControl;

        }

        //protected void OnPropertyChanged(string aPropertyName = null)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(aPropertyName));
        //}

    }
}
