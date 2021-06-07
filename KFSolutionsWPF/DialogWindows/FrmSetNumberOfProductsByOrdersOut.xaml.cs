using KFSolutionsModel;
using System;
using System.Collections.Generic;
using System.Drawing;
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
    /// Interaction logic for FrmSetNumberOfProductsByOrdersOut.xaml
    /// </summary>
    public partial class FrmSetNumberOfProductsByOrdersOut : Window
    {
        public int SelectedCount { get { return (int)numInput.Value; } }
        public FrmSetNumberOfProductsByOrdersOut(TDStransactionControl aTdsTransactionControl,  Product aProduct, int aMaxNumberOfProducts)
        {
            this.Owner = aTdsTransactionControl.ParentWindow;

            InitializeComponent();
            txtCaption1.FontSize = 16;
            txtCaption1.Text = "Produkt: " + aProduct.ProductTitle + "\n";
            //txtCaption1.FontSize = 16;
            txtCaption1.Text += "EAN: " + aProduct.EAN + "\n";
            txtCaption1.Text += $"geef het aantal in dat je wil bestellen [max {aMaxNumberOfProducts}]";

            numInput.Value = 1;
            numInput.Maximum = aMaxNumberOfProducts;
            numInput.Minimum = 1;
            numInput.Font = new Font("Segoe UI", 20); ;

            numInput.Select();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        //btn OK
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void numInput_Enter(object sender, EventArgs e)
        {
            numInput.Select(0, numInput.Value.ToString().Length);
        }

        private void numInput_Click(object sender, EventArgs e)
        {
            numInput.Select(0, numInput.Value.ToString().Length);
        }
    }
}
