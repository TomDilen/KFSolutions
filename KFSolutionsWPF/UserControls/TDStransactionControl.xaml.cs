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

namespace KFSolutionsWPF.UserControls
{
    /// <summary>
    /// Interaction logic for TDStransactionControl.xaml
    /// </summary>
    public partial class TDStransactionControl : UserControl
    {

        public Window ParentWindow { get; set; }
        public FrameworkElement CurrentView { get; private set; }

        //=====================================================================================================

        public TDStransactionControl()
        {
            InitializeComponent();
        }


        public void SlideNewContent(FrameworkElement aNewView)
        {
            aNewView.Width = this.ActualWidth;
            aNewView.Height = this.ActualHeight;


            if(cvsContainer.Children.Count == 0)
            {
                cvsContainer.Children.Add(aNewView);
                return;
            }

            if (cvsContainer.Children.Count == 1)
            {
                //toelaten dat routeevents naar childs gaan 
                cvsContainer.IsHitTestVisible = false;


                FrameworkElement oldContent = (FrameworkElement)cvsContainer.Children[0];

                //hier komt de eventhandler van de animationComplete


                //toevoegen vh nieuwe element
                cvsContainer.Children.Add(aNewView);

                //Console.WriteLine("aantal kids: " + cvsContainer.Children.Count);

                //verwijderen vh oude element

                cvsContainer.IsHitTestVisible = true;
                cvsContainer.Children.Remove(oldContent);
                if(oldContent is IDisposable)
                {
                    (oldContent as IDisposable).Dispose();
                    Console.WriteLine("oude view disposed");
                }
                oldContent = null;
                

            }



        }

        private void cvsContainer_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            foreach (FrameworkElement item in cvsContainer.Children)
            {
                item.Width = this.ActualWidth;
                item.Height = this.ActualHeight;
            }
        }
    }
}
