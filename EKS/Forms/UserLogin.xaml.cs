using System.Windows;
using EKS.Classes;
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
        public bool VerifyUserEnter { get; set; }
        public bool VerifyUserLogInEnter { get; set; }
        #endregion

        private delegate bool UserLogInVerify();

        private void LogInBTN_Click(object sender, RoutedEventArgs e)
        {
            #region Administration and Users Verify
            UnpvC.NewUserName = UserNameTXTBX.Text;
            UnpvC.NewPassword = PasswordPB.Password.ToString();

            UserLogInVerify _UserLogInVerifyDel = UnpvC._VerifyUserNamePasswordMethod;
            bool VerifyUserNameandPassword = _UserLogInVerifyDel();

            if (VerifyUserNameandPassword == true)
            {
                VerifyUserEnter = true;
                this.Close();
            }
            else if (VerifyUserNameandPassword == false)
            {
                MessageBox.Show("Kullanıcı Adı veya Şifreniz Yanlış.\nLütfen Tekrar Deneyin.", "Hatalı Giriş", MessageBoxButton.OK, MessageBoxImage.Information);
            }

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
