using KFSolutions.UnitTestBusiness;
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
    public partial class FrmUnitTest : Form
    {
        public FrmUnitTest()
        {
            InitializeComponent();
        }

        private void btnTestPaswordEncryptAndDecrypt_Click(object sender, EventArgs e)
        {
            dgrvTestEncryption.DataSource =
               UnitTestBusiness.UITencrytpDecryptItem.Test_Encryp_DecryptVersie1(100);
        }

        private void btnValidatePassword_Click(object sender, EventArgs e)
        {
            UITcustomEncrypter testEncrypter = new UITcustomEncrypter();
            if (testEncrypter.IsValidStringToEncrypt(txtTevaliderenPaswoord.Text)){
                txtPaswoordValdiatieResult.Text = "ok";
            }
            else
            {
                txtPaswoordValdiatieResult.Text = "ONGELDIG PASSWOORD";
            }

            //string kleineLetters = "abcdefghijklmnopqrstuvwxyz";
            //string groteLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            //string cijfers = "0123456789";
            //string toegelatenPaswoord = "!@#$%^&*()_+=[{]};:<>|./?,-";
            //string toegelatenGebruikersnaam = "_";
        }
    }
}
