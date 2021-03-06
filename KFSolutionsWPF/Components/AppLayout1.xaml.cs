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

namespace KFSolutionsWPF.Components
{
    /// <summary>
    /// Interaction logic for AppLayout1.xaml
    /// </summary>
    public partial class AppLayout1 : UserControl
    {
        public AppLayout1()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.Register("Header", typeof(string), typeof(AppLayout1), new PropertyMetadata(string.Empty));



        public string Header
        {
            get { return (string)GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }


        
        //public static DependencyProperty InnerContentProperty = 
        //    DependencyProperty.Register("InnerContent", typeof(UIElement), typeof(AppLayout1));
        //public UIElement InnerContent
        //{
        //    get { return (UIElement)GetValue(InnerContentProperty); }
        //    set { SetValue(InnerContentProperty, value); }
        //}
    }
}
