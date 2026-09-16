using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace _45.DependencyPropertyExercise
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private string _title="this is the title example";

        public string Title
        {
            get { return _title; }
            set { _title = value;OnPropertyChanged(); }
        }
        private string _icon="*****";

        public string Icon
        {
            get { return _icon; }
            set { _icon = value;OnPropertyChanged(); }
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string propertyName="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
