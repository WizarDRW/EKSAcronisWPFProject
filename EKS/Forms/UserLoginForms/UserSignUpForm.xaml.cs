using System.Windows;
using EKS.Classes;

namespace EKS.Forms.UserLoginForms
{
    /// <summary>
    /// Interaction logic for UserSignUpForm.xaml
    /// </summary>
    public partial class UserSignUpForm : Window
    {
        public UserSignUpForm()
        {
            InitializeComponent();
        }
        UsersDatabaseConnection UDC;
        private void SaveBTNClick(object sender, RoutedEventArgs e)
        {
            Transporter();
        }

        #region voidMethods
        public delegate void UserSingUpSQLTables();
        void Transporter()
        {
            if (PasswordTXT.Password == PasswordConfirmTXT.Password && NameTXT.Text != null && LastNameTXT.Text != null && UserNameTXT.Text != null)
            {
                UDC = new UsersDatabaseConnection();
                UDC.Name = NameTXT.Text;
                UDC.LastName = LastNameTXT.Text;
                UDC.UserName = UserNameTXT.Text;
                UDC.Password = PasswordTXT.Password;
                UserSingUpSQLTables conSingUp = UDC.UsersSignUpSQLTables;
                conSingUp();
            }
            else
            {
                MessageBox.Show("Hepsi Dolmalı ve Şifre ile Şifre Onayı Aynı Olmalı", "Bilgi", MessageBoxButton.OK);
            }

        }
        #endregion

        private void CancelBTNClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
