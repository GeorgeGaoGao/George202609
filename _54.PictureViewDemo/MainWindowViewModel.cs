using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace _54.PictureViewDemo
{
    public class MainWindowViewModel:INotifyPropertyChanged
    {
		private double _x;

		public double X
		{
			get { return _x; }
			set { _x = value; OnPropertyChanged(); }
		}
		private double _y;

		public double Y
		{
			get { return _y; }
			set { _y = value;OnPropertyChanged(); }
		}
		private double _delta;

		public double Delta
		{
			get { return _delta; }
			set { _delta = value; OnPropertyChanged(); }
		}



		public event PropertyChangedEventHandler? PropertyChanged;
		public void OnPropertyChanged([CallerMemberName]string propertyName="")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
    }
}
