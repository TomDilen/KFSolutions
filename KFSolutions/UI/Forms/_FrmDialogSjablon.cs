using KFSolutionsModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KFSolutions
{
    public partial class _FrmDialogSjablon : Form
    {
        //hier moet een permission komen

        protected Employee _UserCurrentlyLoggedIn;

        public _FrmDialogSjablon(Employee aUserCurrentlyLoggedIn)
        {
            _UserCurrentlyLoggedIn = aUserCurrentlyLoggedIn;


            InitializeComponent();
        }
    }
}
