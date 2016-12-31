using System.Windows;

namespace EKS
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        Classes.AppStart _AppStart;

        public void Application_Startup(object sender, StartupEventArgs e)
        {
            _AppStart = new Classes.AppStart();
            _AppStart.Start();
        }
    }
}
