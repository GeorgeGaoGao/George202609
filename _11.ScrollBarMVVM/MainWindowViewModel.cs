using GeorgeWpfDLL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace _11.ScrollBarMVVM
{
    public class MainWindowViewModel : ObservableObject
    {
        private double _gridWidth;

        public double GridWidth
        {
            get { return _gridWidth; }
            set { _gridWidth = value; OnPropertyChanged(); }
        }
        private double _stackPanelWidth;

        public double StackPanelWidth
        {
            get { return _stackPanelWidth; }
            set { _stackPanelWidth = value; OnPropertyChanged(); }
        }

        private double _scrollBarMaximum;

        public double ScrollBarMaximum
        {
            get { return _scrollBarMaximum; }
            set { _scrollBarMaximum = value; OnPropertyChanged(); }
        }

        private double _scrollBarPosition;

        public double ScrollBarPosition
        {
            get { return _scrollBarPosition; }
            set { _scrollBarPosition = value; OnPropertyChanged(); }
        }

        private double _scrollBarLeft;

        public double ScrollBarLeft
        {
            get { return _scrollBarLeft; }
            set { _scrollBarLeft = value; OnPropertyChanged(); }
        }
        public ICommand GridLoadedCommand { get; set; }
        public ICommand WindowSizeChangedCommand { get; set; }
        public ICommand StackPanelSizeChangedCommand { get; set; }

        public MainWindowViewModel()
        {
            GridLoadedCommand = new RelayCommand(OnGridLoadedCommand);

             WindowSizeChangedCommand = new RelayCommand(OnWindowSizeChangedCommand);
            StackPanelSizeChangedCommand = new RelayCommand(OnStackPanelSizeChangedCommand);
        }

        private void OnGridLoadedCommand(object obj)
        {
            Grid grid = obj as Grid;
            GridWidth = grid.ActualWidth;
        }

        private void OnStackPanelSizeChangedCommand(object obj)
        {
            StackPanel stackPanel = obj as StackPanel;
            StackPanelWidth = stackPanel.ActualWidth;
        }



        private void OnWindowSizeChangedCommand(object obj)
        {
            Grid grid = obj as Grid;
            GridWidth = grid.ActualWidth;

        }
    }
}
