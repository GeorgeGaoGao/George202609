using System;
using System.Collections.Generic;
using System.Text;

namespace _47.AttachedPropertyExercise
{
    public class Person:ObservableObject
    {
		private string _userName;

		public string UserName
		{
			get { return _userName; }
			set { _userName = value; OnPropertyChanged(); }
		}


		private string _password;

		public string Password
		{
			get { return _password; }
			set { _password = value; OnPropertyChanged(); }
		}



	}
}
