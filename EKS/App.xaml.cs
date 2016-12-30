using System.Windows;

namespace EKS
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        #region StartUp Objects
        StartAnimation FmsA;
        EKS.Forms.MainProcessesForm MPF = new Forms.MainProcessesForm();
        #endregion

        public void Application_Startup(object sender, StartupEventArgs e)
        {
            FmsA = new StartAnimation();
            FmsA.Show();
            FmsA.Processes();
            FmsA.Close();
            MPF.Show();
        }
    }
}
