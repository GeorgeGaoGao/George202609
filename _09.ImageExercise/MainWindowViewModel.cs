using GeorgeWpfDLL;
using System;
using System.Collections.Generic;
using System.Text;

namespace _09.ImageExercise
{
    public class MainWindowViewModel : ObservableObject
    {

        public double StackPanelActualWidth { get; set; }
        public double ViewPortWidth { get; set; }

        public MainWindowViewModel()
        {
            ScrollMaximum = StackPanelActualWidth - ViewPortWidth;
        }


        private double _canvasLeft;

        public double CanvasLeft
        {
            get { return _canvasLeft; }
            set { _canvasLeft = value; OnPropertyChanged(); }
        }
        private double _x;

        public double X
        {
            get { return _x; }
            set { _x = value;OnPropertyChanged(); }
        }

        private double _scrollMaximum;

        public double ScrollMaximum
        {
            get { return _scrollMaximum; }
            set { _scrollMaximum = value; OnPropertyChanged(); }
        }



    }
}
