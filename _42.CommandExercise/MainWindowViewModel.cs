using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace _42.CommandExercise
{
    public class MainWindowViewModel
    {
        public ICommand ActionCommand { get; }
        public ICommand ActionParamCommand { get; }
        public ICommand windowCommand { get; }
        public MainWindowViewModel()
        {
            ActionCommand = new RelayCommand(OnActionCommand);
            ActionParamCommand = new RelayCommand(OnActionParamCommand);
            windowCommand = new RelayCommand<Window>(OnWindowCommand);
        }

        private void OnWindowCommand(Window window)
        {
            MessageBox.Show($"这个命令带入了一个window参数，它的title是：{window.Title}");
        }

        private void OnActionParamCommand(object parameter)
        {
            MessageBox.Show($"ActionParamCommand，带入的参数是{parameter}");
        }

        private void OnActionCommand()
        {
            MessageBox.Show("ActionCommand模式");
        }
    }
    public class RelayCommand : ICommand
    {
        private Action _action;
        private Action<object> _objectAction;
        public RelayCommand()
        {

        }
        public RelayCommand(Action action)
        {
            _action = action;
        }
        public RelayCommand(Action<object> objectAction)
        {
            _objectAction = objectAction;
        }
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _action?.Invoke();
            _objectAction?.Invoke(parameter);
        }
    }
    public class RelayCommand<T> : ICommand

    {
        public RelayCommand(Action<T> action)
        {
            _action = action;
        }
        private readonly Action<T> _action;
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {

            if (parameter is T)
            {
                var p = (T)parameter;
            }
            else
            {
                var p=(T)Convert.ChangeType(parameter, typeof(T));
            }
            
            _action?.Invoke((T)parameter);

        }
    }
}
