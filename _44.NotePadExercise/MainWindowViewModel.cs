using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace _44.NotePadExercise
{
    public class MainWindowViewModel
    {
        public ICommand TextBoxPreviewMouseDownCommand { get; set; }
        public MainWindowViewModel()
        {
            TextBoxPreviewMouseDownCommand = new RelayCommand<TextBox>(OnTextBoxPreviewMouseDownCommand, 
                OnTextBoxPreviewMouseDownCommandCanExecute);
        }

        private bool OnTextBoxPreviewMouseDownCommandCanExecute(TextBox box)
        {
            if (box.Text.Length == 0) return true;
            return false;
        }

        private void OnTextBoxPreviewMouseDownCommand(TextBox obj)
        {
            MessageBox.Show($"带进的参数为： {obj.Name}");
        }
    }
    //public class RelayCommand<T> : ICommand
    //{
    //    private readonly Action<T> _execute;
    //    private readonly Predicate<T>? _canExecute;

    //    public RelayCommand(Action<T> execute, Predicate<T>? canExecute = null)
    //    {
    //        _execute = execute ?? throw new ArgumentNullException(nameof(execute));
    //        _canExecute = canExecute;
    //    }

    //    public bool CanExecute(object? parameter)
    //    {
    //        if (_canExecute == null) return true;

    //        try
    //        {
    //            return _canExecute(ConvertParameter(parameter));
    //        }
    //        catch
    //        {
    //            return false;
    //        }
    //    }

    //    public void Execute(object? parameter)
    //    {
    //        _execute(ConvertParameter(parameter));
    //    }

    //    public event EventHandler? CanExecuteChanged
    //    {
    //        add => CommandManager.RequerySuggested += value;
    //        remove => CommandManager.RequerySuggested -= value;
    //    }

    //    public void RaiseCanExecuteChanged()
    //    {
    //        CommandManager.InvalidateRequerySuggested();
    //    }

    //    private static T ConvertParameter(object? parameter)
    //    {
    //        if (parameter is T t)
    //            return t;

    //        if (parameter == null)
    //        {
    //            // 引用类型或 Nullable<T> 可以传 null
    //            if (default(T) is null)
    //                return default!;

    //            throw new ArgumentNullException(nameof(parameter),
    //                $"{typeof(T)} 不是可空类型，不能接收 null。");
    //        }

    //        try
    //        {
    //            return (T)Convert.ChangeType(parameter, typeof(T));
    //        }
    //        catch (Exception ex)
    //        {
    //            throw new ArgumentException(
    //                $"无法将参数从 {parameter.GetType()} 转换为 {typeof(T)}。",
    //                nameof(parameter), ex);
    //        }
    //    }
    //}

    public class RelayCommand<T> : ICommand
    {
        private readonly Action<T> _execute;
        private readonly Func<T, bool>? _canExecute;
        public RelayCommand(Action<T> action, Func<T, bool> canExecute=null)
        {
            _execute = action;
            _canExecute = canExecute;
        }
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            if (_canExecute==null)
            {
                return true;
            }
            try
            {
                return _canExecute(ConvertParameter(parameter));
            }
            catch (Exception)
            {

                return false;
            }
        }

        public void Execute(object? parameter)
        {
            _execute(ConvertParameter(parameter));
        }
        private static T ConvertParameter(object? parameter)
        {
            if (parameter is T t)
            {
                return t;
            }
            if (parameter == null)
            {
                if (default(T) == null)
                {
                    return default;
                }
                throw new ArgumentNullException(nameof(parameter), $"{typeof(T)}不是可空类型，不能接收 null。");
            }
            try
            {
                return (T)Convert.ChangeType(parameter, typeof(T));
            }
            catch (Exception ex)
            {

                throw new ArgumentException($"无法将参数从{parameter.GetType()} 转换成 {typeof(T)}", nameof(parameter), ex);
            }
        }
    }



    //public class RelayCommand<T> : ICommand
    //{
    //    public Action<T> _action { get; }
    //    public RelayCommand(Action<T> action)
    //    {
    //        _action = action;
    //    }
    //    public event EventHandler? CanExecuteChanged;

    //    public bool CanExecute(object? parameter)
    //    {
    //        return true;
    //    }

    //    public void Execute(object? parameter)
    //    {

    //        if (parameter != null)
    //        {
    //            T p;
    //            if (parameter is T)
    //            {
    //                p = (T)parameter;
    //            }
    //            else
    //            {
    //                p = (T)Convert.ChangeType(parameter, typeof(T));
    //            }
    //            _action?.Invoke(p);
    //        }


    //    }
    //}
}
