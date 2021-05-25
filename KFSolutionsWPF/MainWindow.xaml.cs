using KFSolutionsWPF.UserControls;
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

namespace KFSolutionsWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TDStransactionControl _transactionControl;

        private AppRepository<KfsContext> _appDbRespository;


        public MainWindow()
        {
            InitializeComponent();

            _appDbRespository = new AppRepository<KfsContext>("name=KFSsolutions");



            _transactionControl = transControl; //control in de xaml
            _transactionControl.ParentWindow = this;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void ColumnDefinition_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //Console.WriteLine("testmmmmmmm");
            if (e.ChangedButton == MouseButton.Left)
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
            DataContext = new InloggenViewModel();

            //ViewModel = new AccountTypeViewModel();
            //this.DataContext = ViewModel;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _transactionControl.SlideNewContent(new InloggenView(_transactionControl,_appDbRespository));
        }
    }
}
