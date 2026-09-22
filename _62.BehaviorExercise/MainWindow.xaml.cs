using Microsoft.Xaml.Behaviors;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _62.BehaviorExercise
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }

    public class HoverGlowBehavior : Behavior<UIElement>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.MouseEnter += AssociatedObject_MouseEnter;
            AssociatedObject.MouseLeave += AssociatedObject_MouseLeave;
        }

        private void AssociatedObject_MouseLeave(object sender, MouseEventArgs e)
       => AssociatedObject.Opacity = 1;

        private void AssociatedObject_MouseEnter(object sender, MouseEventArgs e)
       => AssociatedObject.Opacity = 0.5;

        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.MouseEnter -= AssociatedObject_MouseEnter;
            AssociatedObject.MouseLeave -= AssociatedObject_MouseLeave;
        }

    }

    public class TextBlockShadowBehavior : Behavior<UIElement>
    {
        private DropShadowEffect dropShadowEffect = new DropShadowEffect();
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.MouseEnter += AssociatedObject_MouseEnter;
            AssociatedObject.MouseLeave += AssociatedObject_MouseLeave;
            dropShadowEffect.ShadowDepth = 2;
            dropShadowEffect.BlurRadius = 0;
            dropShadowEffect.Color = Color.FromRgb(0, 255, 0);
        }

        private void AssociatedObject_MouseLeave(object sender, MouseEventArgs e)
        {
            AssociatedObject.Effect = null;
            //UIElement uiElement = sender as UIElement;
            //uiElement.Effect = null;
        }

        private void AssociatedObject_MouseEnter(object sender, MouseEventArgs e)
        {
            AssociatedObject.Effect = dropShadowEffect;
            //UIElement uiElement = sender as UIElement; 
            //uiElement.Effect= dropShadowEffect;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.MouseEnter -= AssociatedObject_MouseEnter;
            AssociatedObject.MouseLeave -= AssociatedObject_MouseLeave;
        }

    }


    public class DragBehavior : Behavior<FrameworkElement>
    {
        private bool _isDragging = false;
        private Point _startPoint;
        private FrameworkElement _parent;
        private TranslateTransform _translateTransform = new TranslateTransform();

        protected override void OnAttached()
        {
            base.OnAttached();
            _parent = AssociatedObject.Parent as FrameworkElement;
            AssociatedObject.RenderTransform = _translateTransform;

            AssociatedObject.MouseDown += AssociatedObject_MouseDown;
            AssociatedObject.MouseMove += AssociatedObject_MouseMove;
            AssociatedObject.MouseUp += AssociatedObject_MouseUp;
        }

        private void AssociatedObject_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _isDragging = true;
            Point currentPosition = e.GetPosition(_parent);

            if (!(AssociatedObject.RenderTransform is TranslateTransform))
            {
                AssociatedObject.RenderTransform = _translateTransform;
            }
            _startPoint.X = currentPosition.X - _translateTransform.X;
            _startPoint.Y = currentPosition.Y - _translateTransform.Y;
        }

        private void AssociatedObject_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isDragging)
            {
                Point currentPoint = e.GetPosition(_parent);
                double x = currentPoint.X - _startPoint.X;
                double y = currentPoint.Y - _startPoint.Y;
                _translateTransform.X = x;
                _translateTransform.Y = y;
            }

        }

        private void AssociatedObject_MouseUp(object sender, MouseButtonEventArgs e)
        {
            _isDragging = false;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
        }
    }
}