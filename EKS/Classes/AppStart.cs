using System.Windows;

namespace EKS.Classes
{
    internal class AppStart
    {
        #region StartUp Objects
        StartAnimation FmsA;
        EKS.Forms.MainProcessesForm MPF;
        AuthorityReview AR;
        #endregion

        public bool VerifyAdminEnter { get; set; }
        public bool VerifyUserEnter { get; set; }
        public string UserName { get; set; }

        public void Start()
        {
            MPF = new Forms.MainProcessesForm();
            FmsA = new StartAnimation();
            AR = new Classes.AuthorityReview(); //Yetkiyi Etki Yapacak Class

            FmsA.Show();
            FmsA.Processes();

            VerifyAdminEnter = FmsA.VerifyAdminEnter;
            VerifyUserEnter = FmsA.VerifyUserEnter;

            FmsA.Close();

            UserName = FmsA.UserName;


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
