
namespace KFSolutions
{
    partial class FrmUnitTest
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnInloggen = new System.Windows.Forms.Button();
            this.tabControlUnitTest = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPasswordEncryptionTester = new System.Windows.Forms.TabPage();
            this.txtLenPasw = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtValideKeyResult = new System.Windows.Forms.TextBox();
            this.txtTeValiderenKey = new System.Windows.Forms.TextBox();
            this.txtPaswoordValdiatieResult = new System.Windows.Forms.TextBox();
            this.btnValideerKey = new System.Windows.Forms.Button();
            this.txtTevaliderenPaswoord = new System.Windows.Forms.TextBox();
            this.btnValidatePassword = new System.Windows.Forms.Button();
            this.dgrvTestEncryption = new System.Windows.Forms.DataGridView();
            this.btnTestPaswordEncryptAndDecrypt = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabControlUnitTest.SuspendLayout();
            this.tabPasswordEncryptionTester.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrvTestEncryption)).BeginInit();
            this.SuspendLayout();
            // 
            // btnInloggen
            // 
            this.btnInloggen.Location = new System.Drawing.Point(12, 12);
            this.btnInloggen.Name = "btnInloggen";
            this.btnInloggen.Size = new System.Drawing.Size(146, 53);
            this.btnInloggen.TabIndex = 0;
            this.btnInloggen.Text = "inlog";
            this.btnInloggen.UseVisualStyleBackColor = true;
            // 
            // tabControlUnitTest
            // 
            this.tabControlUnitTest.Controls.Add(this.tabPage2);
            this.tabControlUnitTest.Controls.Add(this.tabPasswordEncryptionTester);
            this.tabControlUnitTest.Controls.Add(this.tabPage1);
            this.tabControlUnitTest.Location = new System.Drawing.Point(57, 106);
            this.tabControlUnitTest.Name = "tabControlUnitTest";
            this.tabControlUnitTest.SelectedIndex = 0;
            this.tabControlUnitTest.Size = new System.Drawing.Size(1085, 538);
            this.tabControlUnitTest.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1077, 512);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "add Employee";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPasswordEncryptionTester
            // 
            this.tabPasswordEncryptionTester.Controls.Add(this.txtLenPasw);
            this.tabPasswordEncryptionTester.Controls.Add(this.label2);
            this.tabPasswordEncryptionTester.Controls.Add(this.label1);
            this.tabPasswordEncryptionTester.Controls.Add(this.txtValideKeyResult);
            this.tabPasswordEncryptionTester.Controls.Add(this.txtTeValiderenKey);
            this.tabPasswordEncryptionTester.Controls.Add(this.txtPaswoordValdiatieResult);
            this.tabPasswordEncryptionTester.Controls.Add(this.btnValideerKey);
            this.tabPasswordEncryptionTester.Controls.Add(this.txtTevaliderenPaswoord);
            this.tabPasswordEncryptionTester.Controls.Add(this.btnValidatePassword);
            this.tabPasswordEncryptionTester.Controls.Add(this.dgrvTestEncryption);
            this.tabPasswordEncryptionTester.Controls.Add(this.btnTestPaswordEncryptAndDecrypt);
            this.tabPasswordEncryptionTester.Location = new System.Drawing.Point(4, 22);
            this.tabPasswordEncryptionTester.Name = "tabPasswordEncryptionTester";
            this.tabPasswordEncryptionTester.Padding = new System.Windows.Forms.Padding(3);
            this.tabPasswordEncryptionTester.Size = new System.Drawing.Size(1077, 512);
            this.tabPasswordEncryptionTester.TabIndex = 0;
            this.tabPasswordEncryptionTester.Text = "test Encryption/Decryption";
            this.tabPasswordEncryptionTester.UseVisualStyleBackColor = true;
            // 
            // txtLenPasw
            // 
            this.txtLenPasw.Location = new System.Drawing.Point(291, 14);
            this.txtLenPasw.Name = "txtLenPasw";
            this.txtLenPasw.Size = new System.Drawing.Size(22, 20);
            this.txtLenPasw.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(446, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(248, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "enkel hoofdletters, kleine letters , min = 5, max = 20";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(446, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(397, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "1 hoofdletter, 1 kleine letter, 1 cijfer en 1 speciaal teken, min 8; max 20 teken" +
    "s lang";
            // 
            // txtValideKeyResult
            // 
            this.txtValideKeyResult.Location = new System.Drawing.Point(322, 35);
            this.txtValideKeyResult.Name = "txtValideKeyResult";
            this.txtValideKeyResult.Size = new System.Drawing.Size(108, 20);
            this.txtValideKeyResult.TabIndex = 4;
            // 
            // txtTeValiderenKey
            // 
            this.txtTeValiderenKey.Location = new System.Drawing.Point(22, 36);
            this.txtTeValiderenKey.Name = "txtTeValiderenKey";
            this.txtTeValiderenKey.Size = new System.Drawing.Size(131, 20);
            this.txtTeValiderenKey.TabIndex = 3;
            // 
            // txtPaswoordValdiatieResult
            // 
            this.txtPaswoordValdiatieResult.Location = new System.Drawing.Point(322, 9);
            this.txtPaswoordValdiatieResult.Name = "txtPaswoordValdiatieResult";
            this.txtPaswoordValdiatieResult.Size = new System.Drawing.Size(108, 20);
            this.txtPaswoordValdiatieResult.TabIndex = 4;
            // 
            // btnValideerKey
            // 
            this.btnValideerKey.Location = new System.Drawing.Point(159, 35);
            this.btnValideerKey.Name = "btnValideerKey";
            this.btnValideerKey.Size = new System.Drawing.Size(124, 21);
            this.btnValideerKey.TabIndex = 2;
            this.btnValideerKey.Text = "validate key";
            this.btnValideerKey.UseVisualStyleBackColor = true;
            this.btnValideerKey.Click += new System.EventHandler(this.btnValideerKey_Click);
            // 
            // txtTevaliderenPaswoord
            // 
            this.txtTevaliderenPaswoord.Location = new System.Drawing.Point(22, 10);
            this.txtTevaliderenPaswoord.Name = "txtTevaliderenPaswoord";
            this.txtTevaliderenPaswoord.Size = new System.Drawing.Size(131, 20);
            this.txtTevaliderenPaswoord.TabIndex = 3;
            this.txtTevaliderenPaswoord.Text = "iskdjsdlfkD8_";
            this.txtTevaliderenPaswoord.TextChanged += new System.EventHandler(this.txtTevaliderenPaswoord_TextChanged);
            // 
            // btnValidatePassword
            // 
            this.btnValidatePassword.Location = new System.Drawing.Point(159, 9);
            this.btnValidatePassword.Name = "btnValidatePassword";
            this.btnValidatePassword.Size = new System.Drawing.Size(124, 21);
            this.btnValidatePassword.TabIndex = 2;
            this.btnValidatePassword.Text = "validate pw";
            this.btnValidatePassword.UseVisualStyleBackColor = true;
            this.btnValidatePassword.Click += new System.EventHandler(this.btnValidatePassword_Click);
            // 
            // dgrvTestEncryption
            // 
            this.dgrvTestEncryption.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrvTestEncryption.Location = new System.Drawing.Point(23, 160);
            this.dgrvTestEncryption.Name = "dgrvTestEncryption";
            this.dgrvTestEncryption.Size = new System.Drawing.Size(983, 336);
            this.dgrvTestEncryption.TabIndex = 1;
            // 
            // btnTestPaswordEncryptAndDecrypt
            // 
            this.btnTestPaswordEncryptAndDecrypt.Location = new System.Drawing.Point(23, 131);
            this.btnTestPaswordEncryptAndDecrypt.Name = "btnTestPaswordEncryptAndDecrypt";
            this.btnTestPaswordEncryptAndDecrypt.Size = new System.Drawing.Size(198, 23);
            this.btnTestPaswordEncryptAndDecrypt.TabIndex = 0;
            this.btnTestPaswordEncryptAndDecrypt.Text = "cmdRunEncryptionTestDLL";
            this.btnTestPaswordEncryptAndDecrypt.UseVisualStyleBackColor = true;
            this.btnTestPaswordEncryptAndDecrypt.Click += new System.EventHandler(this.btnTestPaswordEncryptAndDecrypt_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1077, 512);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // FrmUnitTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1198, 656);
            this.Controls.Add(this.tabControlUnitTest);
            this.Controls.Add(this.btnInloggen);
            this.Name = "FrmUnitTest";
            this.Text = "Form1";
            this.tabControlUnitTest.ResumeLayout(false);
            this.tabPasswordEncryptionTester.ResumeLayout(false);
            this.tabPasswordEncryptionTester.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrvTestEncryption)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnInloggen;
        private System.Windows.Forms.TabControl tabControlUnitTest;
        private System.Windows.Forms.TabPage tabPasswordEncryptionTester;
        private System.Windows.Forms.Button btnTestPaswordEncryptAndDecrypt;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgrvTestEncryption;
        private System.Windows.Forms.TextBox txtTevaliderenPaswoord;
        private System.Windows.Forms.Button btnValidatePassword;
        private System.Windows.Forms.TextBox txtPaswoordValdiatieResult;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtValideKeyResult;
        private System.Windows.Forms.TextBox txtTeValiderenKey;
        private System.Windows.Forms.Button btnValideerKey;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLenPasw;
        private System.Windows.Forms.TabPage tabPage1;
    }
}

