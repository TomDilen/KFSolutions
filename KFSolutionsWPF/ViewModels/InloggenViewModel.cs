using KFSolutionsModel;
using KFSolutionsWPF.Commands;
using KFSolutionsWPF.Views;
using KFSrepository_EF6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TDS_wpf_extentions2.Transactioncontrol;

namespace KFSolutionsWPF.ViewModels
{
    //public class InloggenViewModel<Tview> : _appViewModel<Tview> where Tview : UserControl, new()
    public class InloggenViewModel : _appViewModel
    {
        //==============================================================================

        public ICommand Command_Inloggen { get; set; }

        public string StatusMessage { get; set; }

        public string Username { get; set; } //= "Tom_0123";
        public string Password { get; set; } //= "Tom_0123";


        //==============================================================================

        public InloggenViewModel(
            AppRepository<KfsContext> aAppDbRepository, TDS_wpf_extentions2.Transactioncontrol.TDStransactionControl aTDStransactionControl)
            : base(aAppDbRepository, aTDStransactionControl)
        {
            _myView = new InloggenView();
            _myView.DataContext = this;


            Command_Inloggen = new AsyncRelayCommand(Login, /*aTDStransactionControl, aAppDbRepository,*/ (ex) => StatusMessage= ex.Message);

        }

        private async Task Login()
        {
            string password = ((InloggenView)this._myView).txtPassword.Password;
           

            StatusMessage = "Bezig met inloggen...";


            await Task.Delay(1000);


            _appDbRespository.Employee.LogIn(Username, password);

            if (_appDbRespository.Employee.InloggedEmployee == null)
            {
                StatusMessage = "";
                MessageBox.Show("username paswoord combinatie niet gevonden");
            }
            else
            {

                _transactionControl.SlideNewContent(new MainMenuViewModel(_appDbRespository, _transactionControl),
                    TDStransactionControl.TransactionDirection.Down, 400);
            }
            //await Task.Delay(5000);
            
        }



    }
}
