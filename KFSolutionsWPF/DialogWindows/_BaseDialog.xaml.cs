using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TDS_wpf_extentions2.Transactioncontrol;

namespace KFSolutionsWPF.DialogWindows
{
    /// <summary>
    /// Interaction logic for _BaseDialog.xaml
    /// </summary>
    public partial  class _BaseDialog : Window
    {
        public _BaseDialog(TDStransactionControl aTdsTransactionControl)
        {
            

            this.Owner = aTdsTransactionControl.ParentWindow;
            InitializeComponent();
        }
    }
}
