
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
            this.tabPasswordEncryptionTester = new System.Windows.Forms.TabPage();
            this.btnTestPaswordEncryptAndDecrypt = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgrvTestEncryption = new System.Windows.Forms.DataGridView();
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
            this.tabControlUnitTest.Controls.Add(this.tabPasswordEncryptionTester);
            this.tabControlUnitTest.Controls.Add(this.tabPage2);
            this.tabControlUnitTest.Location = new System.Drawing.Point(57, 106);
            this.tabControlUnitTest.Name = "tabControlUnitTest";
            this.tabControlUnitTest.SelectedIndex = 0;
            this.tabControlUnitTest.Size = new System.Drawing.Size(1085, 444);
            this.tabControlUnitTest.TabIndex = 1;
            // 
            // tabPasswordEncryptionTester
            // 
            this.tabPasswordEncryptionTester.Controls.Add(this.dgrvTestEncryption);
            this.tabPasswordEncryptionTester.Controls.Add(this.btnTestPaswordEncryptAndDecrypt);
            this.tabPasswordEncryptionTester.Location = new System.Drawing.Point(4, 22);
            this.tabPasswordEncryptionTester.Name = "tabPasswordEncryptionTester";
            this.tabPasswordEncryptionTester.Padding = new System.Windows.Forms.Padding(3);
            this.tabPasswordEncryptionTester.Size = new System.Drawing.Size(1077, 418);
            this.tabPasswordEncryptionTester.TabIndex = 0;
            this.tabPasswordEncryptionTester.Text = "test Encryption/Decryption";
            this.tabPasswordEncryptionTester.UseVisualStyleBackColor = true;
            // 
            // btnTestPaswordEncryptAndDecrypt
            // 
            this.btnTestPaswordEncryptAndDecrypt.Location = new System.Drawing.Point(6, 6);
            this.btnTestPaswordEncryptAndDecrypt.Name = "btnTestPaswordEncryptAndDecrypt";
            this.btnTestPaswordEncryptAndDecrypt.Size = new System.Drawing.Size(126, 23);
            this.btnTestPaswordEncryptAndDecrypt.TabIndex = 0;
            this.btnTestPaswordEncryptAndDecrypt.Text = "cmdRunEncryptionTest";
            this.btnTestPaswordEncryptAndDecrypt.UseVisualStyleBackColor = true;
            this.btnTestPaswordEncryptAndDecrypt.Click += new System.EventHandler(this.btnTestPaswordEncryptAndDecrypt_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1077, 418);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgrvTestEncryption
            // 
            this.dgrvTestEncryption.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrvTestEncryption.Location = new System.Drawing.Point(33, 51);
            this.dgrvTestEncryption.Name = "dgrvTestEncryption";
            this.dgrvTestEncryption.Size = new System.Drawing.Size(983, 336);
            this.dgrvTestEncryption.TabIndex = 1;
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
    }
}

