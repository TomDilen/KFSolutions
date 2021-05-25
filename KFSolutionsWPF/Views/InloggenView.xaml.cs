using KFSolutionsWPF.UserControls;
using KFSrepository_EF6;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KFSolutionsWPF.Views
{
    /// <summary>
    /// Interaction logic for InloggenView.xaml
    /// </summary>
    public partial class InloggenView : UserControl
    {
        TDStransactionControl _transactionControl;
        private AppRepository<KfsContext> _appDbRespository;

        public InloggenView(TDStransactionControl aTDStransactionControl, AppRepository<KfsContext> aAppDbRespository)
        {
            InitializeComponent();
            _transactionControl = aTDStransactionControl;
            _appDbRespository = aAppDbRespository;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            EmployeeRepository.EmployeeLoggedInDTO ingelogdUser =
                _appDbRespository.Employee.LogIn(txtUsername.Text, txtPassword.Password);

            if (ingelogdUser == null)
            {
                MessageBox.Show("Niet ingelogd");
            }
            else
            {
                MessageBox.Show("hoihoi");
                _transactionControl.SlideNewContent(new MainMenuView(_transactionControl, _appDbRespository));
            }

        }
    }
}
