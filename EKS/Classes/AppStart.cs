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
        public string ReturnUserAut { get; set; }
        public bool AdministratorEnter { get; set; }

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


            if (VerifyAdminEnter == true)
            {
                AdministratorEnter = true;
                MessageBox.Show("Administrator Girisi", "Giris", MessageBoxButton.OK, MessageBoxImage.Information);
                MPF.Show();
            }
            else if (VerifyUserEnter == true)
            {
                UserName = FmsA.UserName;
                AR.AutUserName = UserName;
                ReturnUserAut = AR.ReturnAut();
                MPF.Authority = ReturnUserAut;
                MPF.Show();
            }
            else
            {
                Application.Current.Shutdown();
            }
        }
    }
}
