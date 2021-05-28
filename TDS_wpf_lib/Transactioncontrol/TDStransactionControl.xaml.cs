using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TDS_wpf_lib.Transactioncontrol
{
    /// <summary>
    /// Interaction logic for TDStransactionControl.xaml
    /// </summary>
    public partial class TDStransactionControl : UserControl
    {
        public enum TransactionDirection {
            None,
            Left,
            Right,
            Up,
            Down,
            FadeIn,
        }


        private const string APP_BACKGROUND = @"images/appBackground.png";
        public Window ParentWindow { get; set; }
        public UserControl CurrentView { get; private set; }
        //public TDSnavigationViewModel CurrentViewModel { get; private set; }

        //=====================================================================================================

        public TDStransactionControl()
        {
            InitializeComponent();
            if (File.Exists(APP_BACKGROUND))
            {
                try
                {
                    ImageBrush ib = new ImageBrush();
                    ib.ImageSource = new BitmapImage(new Uri(APP_BACKGROUND, UriKind.Relative));
                    cvsContainer.Background = ib;
                }
                catch (FileNotFoundException ex) { MessageBox.Show("Test"); }
            }
        }
        //====================================================================================================

        public void SlideNewContent(TDStransactionViewModel aTDSnavigationViewModel)
        {
            Slide(aTDSnavigationViewModel._myView, TransactionDirection.None,0);
        }
        public void SlideNewContent(TDStransactionViewModel aTDSnavigationViewModel,
            TransactionDirection aTransactionDirection)
        {
            Slide(aTDSnavigationViewModel._myView, aTransactionDirection, 400);
        }
        public void SlideNewContent(TDStransactionViewModel aTDSnavigationViewModel, 
            TransactionDirection aTransactionDirection, int aAnimationDurationInMilliseconde)
        {
            Slide(aTDSnavigationViewModel._myView, aTransactionDirection, aAnimationDurationInMilliseconde);
        }


        private void Slide(FrameworkElement aNewView, TransactionDirection aDirection, int aMilliseconde)
        {
            aNewView.Width = this.ActualWidth;
            aNewView.Height = this.ActualHeight;


            if (cvsContainer.Children.Count == 0)
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
                EventHandler onAnimationCompleteHandler = delegate (object sender, EventArgs e)
                {
                    cvsContainer.IsHitTestVisible = true;
                    cvsContainer.Children.Remove(oldContent);
                    if (oldContent is IDisposable)
                    {
                        (oldContent as IDisposable).Dispose();
                        Console.WriteLine("oude view disposed");
                    }
                    oldContent = null;

                };
                //toevoegen vh nieuwe element
                //cvsContainer.Children.Add(aNewView);
                SlideAnimation(aNewView, oldContent, onAnimationCompleteHandler,aDirection, aMilliseconde );

                //Console.WriteLine("aantal kids: " + cvsContainer.Children.Count);

                //verwijderen vh oude element

                //cvsContainer.IsHitTestVisible = true;
                //cvsContainer.Children.Remove(oldContent);
                //if (oldContent is IDisposable)
                //{
                //    (oldContent as IDisposable).Dispose();
                //    Console.WriteLine("oude view disposed");
                //}
                //oldContent = null;

            }
        }

        //======================================================================================================================
        private void SlideAnimation(FrameworkElement newContent,
                    FrameworkElement oldContent,
                    EventHandler completedEventhandler,
                    TransactionDirection aDirection,
                    int aMilliseconde)
        {

            if (aDirection == TransactionDirection.None) aMilliseconde = 0;


            double StartPunt = 0;

            switch (aDirection)
            {
                //-------------------------------------------------------------------------------------------------
                case TransactionDirection.None:
                case TransactionDirection.Right:
                    {
                        StartPunt = 0;
                        Canvas.SetLeft(newContent, StartPunt - cvsContainer.ActualWidth);

                        cvsContainer.Children.Add(newContent);


                        DoubleAnimation outAnnimatie = CreateDoubleAnimation(StartPunt, StartPunt + cvsContainer.ActualWidth, null, aMilliseconde);
                        DoubleAnimation inAnnimatie = CreateDoubleAnimation(StartPunt - cvsContainer.ActualWidth, StartPunt, completedEventhandler, aMilliseconde);

                        oldContent.BeginAnimation(Canvas.LeftProperty, outAnnimatie);
                        newContent.BeginAnimation(Canvas.LeftProperty, inAnnimatie);

                    }
                    break;

                //-------------------------------------------------------------------------------------------------
                case TransactionDirection.Left:
                    {
                        StartPunt = 0;
                        Canvas.SetLeft(newContent, StartPunt + cvsContainer.ActualWidth);

                        cvsContainer.Children.Add(newContent);


                        DoubleAnimation outAnnimatie = CreateDoubleAnimation(StartPunt, StartPunt - cvsContainer.ActualWidth, null, aMilliseconde);
                        DoubleAnimation inAnnimatie = CreateDoubleAnimation(StartPunt + cvsContainer.ActualWidth, StartPunt, completedEventhandler, aMilliseconde);

                        oldContent.BeginAnimation(Canvas.LeftProperty, outAnnimatie);
                        newContent.BeginAnimation(Canvas.LeftProperty, inAnnimatie);

                    }
                    break;
                //-------------------------------------------------------------------------------------------------
                case TransactionDirection.Up:
                    {
                        StartPunt = 0;
                        Canvas.SetTop(newContent, StartPunt + cvsContainer.ActualHeight);

                        cvsContainer.Children.Add(newContent);


                        DoubleAnimation outAnnimatie = CreateDoubleAnimation(StartPunt, StartPunt - cvsContainer.ActualHeight, null, aMilliseconde);
                        DoubleAnimation inAnnimatie = CreateDoubleAnimation(StartPunt + cvsContainer.ActualHeight, StartPunt, completedEventhandler, aMilliseconde);



                        oldContent.BeginAnimation(Canvas.TopProperty, outAnnimatie);
                        newContent.BeginAnimation(Canvas.TopProperty, inAnnimatie);

                    }
                    break;

                //-------------------------------------------------------------------------------------------------
                case TransactionDirection.Down:

                    {
                        StartPunt = 0;
                        Canvas.SetTop(newContent, StartPunt - cvsContainer.ActualHeight);

                        cvsContainer.Children.Add(newContent);


                        DoubleAnimation outAnnimatie = CreateDoubleAnimation(StartPunt, StartPunt + cvsContainer.ActualHeight, null, aMilliseconde);
                        DoubleAnimation inAnnimatie = CreateDoubleAnimation(StartPunt - cvsContainer.ActualHeight, StartPunt, completedEventhandler, aMilliseconde);

                        oldContent.BeginAnimation(Canvas.TopProperty, outAnnimatie);
                        newContent.BeginAnimation(Canvas.TopProperty, inAnnimatie);

                    }
                    break;
                case TransactionDirection.FadeIn:

                    {
                        StartPunt = 0;
                        Canvas.SetTop(newContent, 0);

                        cvsContainer.Children.Add(newContent);


                        //DoubleAnimation outAnnimatie = CreateDoubleAnimation(StartPunt, StartPunt + cvsContainer.ActualHeight, null, aMilliseconde);
                        //DoubleAnimation inAnnimatie = CreateDoubleAnimation(StartPunt - cvsContainer.ActualHeight, StartPunt, completedEventhandler, aMilliseconde);
                        //========================================test
                        DoubleAnimation infade = CreateDoubleAnimation(0, 1, completedEventhandler, aMilliseconde);
                        DoubleAnimation outfade = CreateDoubleAnimation(1, 0, null , aMilliseconde/5);
                        //testanim.FillBehavior = FillBehavior.Stop;

                        newContent.BeginAnimation(UIElement.OpacityProperty, infade);
                        oldContent.BeginAnimation(UIElement.OpacityProperty, outfade);

                    }
                    break;

                //-------------------------------------------------------------------------------------------------
                default:
                    break;
            }


        }
        //=======================================================================================================================
        DoubleAnimation CreateDoubleAnimation(double from, double to, EventHandler completedEventhandler, int aMilliseconde)
        {
            Duration _animationDuration = new Duration(TimeSpan.FromMilliseconds(aMilliseconde));

            DoubleAnimation terug = new DoubleAnimation(from, to, _animationDuration);

            if (completedEventhandler != null)
            {
                terug.Completed += completedEventhandler;
            }
            return terug;
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
//public static readonly DependencyProperty ColorProperty =

//    DependencyProperty.Register("Color", typeof(Brush), typeof(TDStransactionControl),

//        new PropertyMetadata(Brushes.Transparent));

//public Brush Color

//{

//    get { return (Brush)GetValue(ColorProperty); }

//    set { SetValue(ColorProperty, value); }

//}
//public static readonly DependencyProperty bgImageProperty =
//    DependencyProperty.Register("bgImage", typeof(ImageSource), typeof(TDStransactionControl), new PropertyMetadata(null));
//public object bgImage
//{
//    get { return GetValue(bgImageProperty); }
//    set { SetValue(bgImageProperty, value); }
//}



