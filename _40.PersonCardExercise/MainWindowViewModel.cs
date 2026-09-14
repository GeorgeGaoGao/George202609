using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace _40.PersonCardExercise
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        private Person _currentPerson=new Person() { Name="George",Age=52,Address="Wuhan",Money=10000};

        public Person CurrentPerson
        {
            get { return _currentPerson; }
            set { _currentPerson = value;OnPropertyChanged(); }
        }
        public ObservableCollection<Person> People { get; set; }=new ObservableCollection<Person>();
        public MainWindowViewModel()
        {
            People.Add(new Person() { Name = "George01", Age = 51, Address = "Wuhan01", Money = 10001 });
            People.Add(new Person() { Name = "George02", Age = 52, Address = "Wuhan02", Money = 10002 });
            People.Add(new Person() { Name = "George03", Age = 53, Address = "Wuhan03", Money = 10003 });
            People.Add(new Person() { Name = "George04", Age = 54, Address = "Wuhan04", Money = 10004 });
            People.Add(new Person() { Name = "George05", Age = 55, Address = "Wuhan05", Money = 10005 });
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string propertyName="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
