using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace _36.DatatriggerExercise
{
    public class MainWindowViewModel
    {
        public Person Person { get; set; } = new Person();
        public ObservableCollection<Person> People { get; set; }= new ObservableCollection<Person>();
        public MainWindowViewModel()
        {
            People.Add(new Person() { Name="George01",Age=51,Address="Wuhan,China"});
            People.Add(new Person() { Name="George02",Age=52,Address="Wuhan,China"});
            People.Add(new Person() { Name="George03",Age=53,Address="Wuhan,China"});
            People.Add(new Person() { Name="George04",Age=54,Address="Wuhan,China"});
        }
    }
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
    }
}
