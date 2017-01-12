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
        MessageBoxsForms.UserSaveMessageBox USM;

        private void SaveBTNClick(object sender, RoutedEventArgs e)
        {
            Transporter();
        }

        #region voidMethods
        private delegate void UserSingUpSQLTables();

        private void Transporter()
        {
            if (PasswordTXT.Password == PasswordConfirmTXT.Password && PasswordTXT.Password != "" && NameTXT.Text != "" && LastNameTXT.Text != "" && UserNameTXT.Text != "")
            {
                if (UserNameTXT.Text == Properties.Settings.Default.UserName)
                {
                    MessageBox.Show(UserNameTXT.Text + "\nBu Kullanici Adi Zaten Mevcut.", "Uyari!", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    UDC = new UsersDatabaseConnection();
                    UDC.Name = NameTXT.Text;
                    UDC.LastName = LastNameTXT.Text;
                    UDC.UserName = UserNameTXT.Text;
                    UDC.Password = PasswordTXT.Password;
                    UserSingUpSQLTables conSingUp = UDC.UsersSignUpSQLTables;
                    conSingUp();
                    if (UDC.VerifyTableEntered == true)
                    {
                        USM = new MessageBoxsForms.UserSaveMessageBox();
                        USM.Owner = this;
                        USM.ShowDialog();
                        if (USM.HasSave == true)
                        {
                            this.Close();
                        }
                    }
                }
            }
            else if (UserNameTXT.Text == Properties.Settings.Default.UserName)
            {
                MessageBox.Show(UserNameTXT.Text + "\nBu Kullanici Adi Zaten Mevcut.", "Uyari!", MessageBoxButton.OK, MessageBoxImage.Information);
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
