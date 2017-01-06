using System.Windows;
using EKS.Classes;
using EKS;
using System.Linq;

namespace EKS.Forms
{
    /// <summary>
    /// Interaction logic for UserLogin.xaml
    /// </summary>
    public partial class UserLogin : Window
    {
        public UserLogin()
        {
            InitializeComponent();
        }

        #region Objects
        UserNamePasswordVerify UnpvC = new UserNamePasswordVerify();
        UserLoginForms.UserSignUpForm UsuF;
        #endregion

        #region Property
        public bool VerifyAdminEnter { get; set; }
        public bool VerifyUserEnter { get; set; }
        public bool VerifyUserLogInEnter { get; set; }
        #endregion

        private delegate bool UserLogInVerify();

        private void LogInBTN_Click(object sender, RoutedEventArgs e)
        {
            #region Administration Verify
            UnpvC.NewUserName = UserNameTXTBX.Text;
            UnpvC.NewPassword = PasswordPB.Password.ToString();
            bool VerifyAdminUserNameandPassword = UnpvC._VerifyAdminUserNameMethod();
            bool VerifyPassword = UnpvC._VerifyAdminPasswordMethod();

            UserLogInVerify _UserLogInVerifyDel = UnpvC._VerifyUserNamePasswordMethod;
            bool VerifyUserNameandPassword = _UserLogInVerifyDel();

            if (VerifyAdminUserNameandPassword == true && VerifyPassword == true)
            {
                VerifyAdminEnter = true;
                this.Close();
            }
            else if (VerifyUserNameandPassword == true)
            {
                VerifyUserEnter = true;
                this.Close();
            }
            else if (VerifyAdminUserNameandPassword == false || VerifyPassword == false || VerifyUserNameandPassword == false)
            {
                MessageBox.Show("Kullanıcı Adı veya Şifreniz Yanlış.\nLütfen Tekrar Deneyin.", "Hatalı Giriş", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            #endregion
            ///
            #region User Verify 
            #endregion
        }

        private void UserCreateBTNClick(object sender, RoutedEventArgs e)
        {
            UsuF = new UserLoginForms.UserSignUpForm();
            UsuF.Owner = Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);
            UsuF.ShowDialog();
        }

        private void ExitBTN_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
