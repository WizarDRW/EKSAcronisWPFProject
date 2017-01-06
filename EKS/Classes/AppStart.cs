using System.Windows;

namespace EKS.Classes
{
    internal class AppStart
    {
        #region StartUp Objects
        StartAnimation FmsA;
        EKS.Forms.MainProcessesForm MPF;
        #endregion

        public bool VerifyAdminEnter { get; set; }
        public bool VerifyUserEnter { get; set; }

        public void Start()
        {
            MPF = new Forms.MainProcessesForm();
            FmsA = new StartAnimation();

            FmsA.Show();
            FmsA.Processes();

            VerifyAdminEnter = FmsA.VerifyAdminEnter;
            VerifyUserEnter = FmsA.VerifyUserEnter;

            FmsA.Close();

            if (VerifyAdminEnter == true || VerifyUserEnter == true)
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
