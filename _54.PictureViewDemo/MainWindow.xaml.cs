using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _54.PictureViewDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel _viewModel;
        private bool _isMouseDown;
        private Point _mousePosition = new Point(0, 0);
        private ScaleTransform _scaleTransform = new ScaleTransform();
        private TranslateTransform _translateTransform = new TranslateTransform();
        private TransformGroup _transformGroup = new TransformGroup();
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _viewModel = DataContext as MainWindowViewModel;
            _transformGroup.Children.Add(_scaleTransform);
            _transformGroup.Children.Add(_translateTransform);
            myImage.RenderTransform = _transformGroup;
            var scale = Math.Min(myCanvas.ActualWidth / myImage.ActualWidth, myCanvas.ActualHeight / myImage.ActualHeight);
            _scaleTransform.ScaleX = scale;
            _scaleTransform.ScaleY = scale;
            _translateTransform.X = (myCanvas.ActualWidth - myImage.ActualWidth * scale) / 2;
            _translateTransform.Y = (myCanvas.ActualHeight - myImage.ActualHeight * scale) / 2;

        }

        private void Canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _isMouseDown = true;
            _mousePosition = e.GetPosition(myCanvas);
        }

        private void Canvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            _isMouseDown = false;
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            var newMousePosition = e.GetPosition(myCanvas);
            _viewModel.X = newMousePosition.X;
            _viewModel.Y = newMousePosition.Y;
            if (_isMouseDown)
            {
                _translateTransform.X += newMousePosition.X - _mousePosition.X;
                _translateTransform.Y += newMousePosition.Y - _mousePosition.Y;
                _mousePosition = newMousePosition;
            }
        }

        private void Canvas_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            Point newMousePosition = e.GetPosition(myCanvas);
            _viewModel.X = newMousePosition.X;
            _viewModel.Y = newMousePosition.Y;

            var delta = e.Delta;
            _viewModel.Delta = delta;

            var scaleChange = delta * 0.001;
            if (_scaleTransform.ScaleX + scaleChange < 0.1) return;

            var inversePoint = _transformGroup.Inverse.Transform(newMousePosition);
            _scaleTransform.ScaleX += scaleChange;
            _scaleTransform.ScaleY += scaleChange;

            _translateTransform.X = -(inversePoint.X * _scaleTransform.ScaleX - newMousePosition.X);
            _translateTransform.Y = -(inversePoint.Y * _scaleTransform.ScaleY - newMousePosition.Y);
        }
    }
}