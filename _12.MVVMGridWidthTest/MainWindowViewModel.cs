using GeorgeWpfDLL;
using System;
using System.Collections.Generic;
using System.Text;

namespace _12.MVVMGridWidthTest
{
    public class MainWindowViewModel:ObservableObject
    {
		private double _gridWidth;

		public double GridWidth
		{
			get { return _gridWidth; }
			set { _gridWidth= value; OnPropertyChanged(); }
		}

	}
}
