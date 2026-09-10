using System;
using System.Collections.Generic;
using System.Text;

namespace _35.ValidationRuleExercise
{
    public class MainWindowViewModel
    {
        public Person Person { get; set; } = new Person() { Name = "George8888", Age = 52, Address = "wuhan,china" };
    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public double Money { get; set; }
    }
}
