using System.Windows;

namespace EKS.Classes
{
    internal class AppStart
    {
        #region StartUp Objects
        StartAnimation FmsA;
        EKS.Forms.MainProcessesForm MPF;
        #endregion

        public bool VerifyEnter { get; set; }

        public void Start()
        {
            MPF = new Forms.MainProcessesForm();
            FmsA = new StartAnimation();

            FmsA.Show();
            FmsA.Processes();

            VerifyEnter = FmsA.VerifyEnter;

            FmsA.Close();

            if (VerifyEnter == true)
            {
                MPF.Show();
            }
            else
            {
                Application.Current.Shutdown();
            }
        }
    }
}
