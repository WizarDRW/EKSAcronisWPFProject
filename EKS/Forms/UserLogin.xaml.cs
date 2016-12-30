using System.Windows;
using EKS.Classes;

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
        UserNamePasswordVerify UnpvC = new UserNamePasswordVerify();
        UserLoginForms.UserSignUpForm UsuF = new UserLoginForms.UserSignUpForm();
        private void LogInBTN_Click(object sender, RoutedEventArgs e)
        {
            #region Administration Verify
            UnpvC.NewUserName = UserNameTXTBX.Text;
            UnpvC.NewPassword = PasswordPB.Password.ToString();
            bool VerifyUserName = UnpvC._VerifyUserNameMethod();
            bool VerifyPassword = UnpvC._VerifyPasswordMethod();
            if (VerifyUserName == true && VerifyPassword == true)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı veya Şifreniz Yanlış.\nLütfen Tekrar Deneyin.", "Hatalı Giriş", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            #endregion


        }

        private void UserCreateBTNClick(object sender, RoutedEventArgs e)
        {
                UsuF.Show();
        }
    }
}
