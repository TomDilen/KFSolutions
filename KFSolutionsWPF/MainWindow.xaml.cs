
using KFSolutionsWPF.ViewModels;
using KFSolutionsWPF.Views;
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
using TDS_wpf_lib.Transactioncontrol;

namespace KFSolutionsWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TDS_wpf_lib.Transactioncontrol.TDStransactionControl _transactionControl;

        private AppRepository<KfsContext> _appDbRespository;


        public MainWindow()
        {
            InitializeComponent();

            _appDbRespository = new AppRepository<KfsContext>("name=KFSsolutions");

            _transactionControl = tdsTranscontrol; //control in de xaml
            _transactionControl.ParentWindow = this;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void ColumnDefinition_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && e.ClickCount == 2)
            {
                Button_ToggleMaximized(null, null);
            }
            //Console.WriteLine("testmmmmmmm");
            else if (e.ChangedButton == MouseButton.Left)
            {
                //Console.WriteLine("test");
                this.DragMove();
            }
        }



        private void Button_Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Minimizid(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Button_ToggleMaximized(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
            }
            else
            {
                this.WindowState = WindowState.Maximized;
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            
            _transactionControl.SlideNewContent(new MainMenuViewModel( _appDbRespository ,_transactionControl),
                TDStransactionControl.TransactionDirection.Right,500);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            //_transactionControl.SlideNewContent(new InloggenViewModel(_appDbRespository, _transactionControl));

            _transactionControl.SlideNewContent(new EmployeeAddNewViewModel(_appDbRespository, _transactionControl));
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Console.WriteLine(this.Width + " = " + this.Height);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _appDbRespository.EmpContractStatuutType.GetAll();
        }
    }
}
