using KFSolutions.UnitTestBusiness;
using KFSolutionsModel;
using KFSrepository_EF6;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KFSolutions
{
    public partial class FrmUnitTest : Form
    {
        private AppRepository<KfsContext> _appDbRespository;

        public FrmUnitTest()
        {
            InitializeComponent();

            _appDbRespository = new AppRepository<KfsContext>("name=KFSsolutions");

            //----------------------------------------------------------------------
            _____TESTDATA.LoadTestData(_appDbRespository);
            //----------------------------------------------------------------------

        }

        private void btnTestPaswordEncryptAndDecrypt_Click(object sender, EventArgs e)
        {
            dgrvTestEncryption.DataSource =
               UnitTestBusiness.UITencrytpDecryptItem.Test_Encryp_DecryptVersie1(100);
        }

        private void btnValidatePassword_Click(object sender, EventArgs e)
        {
            UITcustomEncrypter testEncrypter = new UITcustomEncrypter();

            if (testEncrypter.IsValidStringToEncrypt(txtTevaliderenPaswoord.Text))
            {
                txtPaswoordValdiatieResult.Text = "ok";
            }
            else
            {
                txtPaswoordValdiatieResult.Text = "ONGELDIG PASSWOORD";
            }
        }

        private void btnValideerKey_Click(object sender, EventArgs e)
        {
            UITcustomEncrypter testEncrypter = new UITcustomEncrypter();


            if (testEncrypter.IsValidKeyToEncrypt(txtTeValiderenKey.Text))
            {
                txtValideKeyResult.Text = "ok";
            }
            else
            {
                txtValideKeyResult.Text = "ONGELDIG Key";
            }
        }

        private void txtTevaliderenPaswoord_TextChanged(object sender, EventArgs e)
        {
            txtLenPasw.Text = txtTevaliderenPaswoord.Text.Length.ToString();
        }
    }
}
