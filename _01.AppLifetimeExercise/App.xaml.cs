using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;

namespace _01.AppLifetimeExercise
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Debug.WriteLine("OnStartup is executed");
        }
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            Debug.WriteLine("OnActivated is executed");
        }
        protected override void OnDeactivated(EventArgs e)
        {
            base.OnDeactivated(e);
            Debug.WriteLine("OnDeactivated is executed");
        }
        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            Debug.WriteLine("Onexit is executed");
        }
    }

}
