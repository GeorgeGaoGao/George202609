using System;
using System.Collections.Generic;
using System.Text;

namespace _47.AttachedPropertyExercise
{
    public class MainWindowViewModel:ObservableObject
    {
		private Person _person=new Person();
			//=new Person() { UserName="George",Password="12345678"};

		public Person Person
		{
			get { return _person; }
			set { _person = value; OnPropertyChanged(); }
		}

	}
}
