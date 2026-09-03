using GeorgeWpfDLL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace _03.ContentControlExercise
{
    public class MainWindowViewModel:ObservableObject
    {
        private Person _selectedPerson;

        public Person SelectedPerson
        {
            get { return _selectedPerson; }
            set { _selectedPerson = value; OnPropertyChanged(); }
        }

        public ObservableCollection<Person> People { get; set; } = new ObservableCollection<Person>{
        new Person(){Name="George01",Age=51,Address="汉口春天01"},
        new Person(){Name="George02",Age=52,Address="汉口春天02"},
        new Person(){Name="George03",Age=53,Address="汉口春天03"},
        };
    }
}
