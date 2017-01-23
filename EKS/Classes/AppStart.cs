using System.Linq;
using System.Windows;

namespace EKS.Classes
{
    internal class AppStart
    {
        #region StartUp Objects
        StartAnimation FmsA;
        EKS.Forms.MainProcessesForm MPF;
        AuthorityReview AR;
        UsersDatabaseConnection UDC;
        Forms.UserLoginForms.UserSignUpForm UsuF;
        #endregion

        #region Property
        public bool VerifyAdminEnter { get; set; }
        public bool VerifyUserEnter { get; set; }
        public string UserName { get; set; }
        public string ReturnUserAut { get; set; }
        public bool AdministratorEnter { get; set; }
        #endregion

        public void Start()
        {
            MPF = new Forms.MainProcessesForm();
            FmsA = new StartAnimation();
            AR = new Classes.AuthorityReview();
            UDC = new Classes.UsersDatabaseConnection();
            UsuF = new Forms.UserLoginForms.UserSignUpForm();

            UDC.AdminProcVerify();

            FmsA.Show();

            if (UDC.HasDataAut < 1)
            {
                UsuF.Owner = Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);
                UsuF.ShowDialog();
                if (UsuF.Created == false)
                {
                    Application.Current.Shutdown();
                }
            }
            FmsA.Processes();
            
            VerifyUserEnter = FmsA.VerifyUserEnter;

            FmsA.Close();
            if (VerifyUserEnter == true)
            {
                UserName = FmsA.UserName;
                AR.AutUserName = UserName;
                ReturnUserAut = AR.ReturnAut();
                MPF.UserName = UserName;
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
