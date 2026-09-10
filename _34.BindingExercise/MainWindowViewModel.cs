using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace _34.BindingExercise
{
    public class MainWindowViewModel
    {
        public Person Person { get; set; }=new Person() { Name="George",Age=52,Address="Wuhan,China"};
        public ObservableCollection<Person> People { get; set; } = new ObservableCollection<Person>();
        public MainWindowViewModel()
        {
            Random random = new Random();
            People.Add(new Person() { Name = "George01", Age = random.Next(1,100),Money=random.Next(1000,1000000),  Address = "wuhan 01" });
            People.Add(new Person() { Name = "George02", Age = random.Next(1, 100), Money = random.Next(1000, 1000000), Address = "wuhan 02" });
            People.Add(new Person() { Name = "George03", Age = random.Next(1, 100), Money = random.Next(1000, 1000000), Address = "wuhan 03" });
            People.Add(new Person() { Name = "George04", Age = random.Next(1, 100), Money = random.Next(1000, 1000000), Address = "wuhan 04" });
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public double Money { get; set; }
    }
}
