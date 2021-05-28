﻿
using KFSolutionsWPF.Views;
using KFSrepository_EF6;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TDS_wpf_lib.Transactioncontrol;

namespace KFSolutionsWPF.ViewModels
{
    //public class _appViewModel<Tview> : TDSnavigationViewModel<Tview> where Tview : UserControl, new()
    public class _appViewModel : TDStransactionViewModel
    {

        protected AppRepository<KfsContext> _appDbRespository;


        public _appViewModel(AppRepository<KfsContext> aAppDbRepository, TDStransactionControl aTDStransactionControl)
            : base(aTDStransactionControl)
        {

            _appDbRespository = aAppDbRepository;
        }




    }
}
