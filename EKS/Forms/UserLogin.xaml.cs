using System.Windows;
using EKS.Classes;
using EKS;

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
        AppStart _AppStart { get; set; }
        #endregion
        public bool VerifyEnter { get; set; }

        private void LogInBTN_Click(object sender, RoutedEventArgs e)
        {
            #region Administration Verify
            UnpvC.NewUserName = UserNameTXTBX.Text;
            UnpvC.NewPassword = PasswordPB.Password.ToString();
            bool VerifyUserName = UnpvC._VerifyUserNameMethod();
            bool VerifyPassword = UnpvC._VerifyPasswordMethod();

            if (VerifyUserName == true && VerifyPassword == true)
            {
                VerifyEnter = true;
                this.Close();
            }
            else if (VerifyUserName == false || VerifyPassword == false)
            {
                MessageBox.Show("Kullanıcı Adı veya Şifreniz Yanlış.\nLütfen Tekrar Deneyin.", "Hatalı Giriş", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            #endregion
        }

        private void UserCreateBTNClick(object sender, RoutedEventArgs e)
        {
            UsuF = new UserLoginForms.UserSignUpForm();
            UsuF.Show();
        }
    }
}
