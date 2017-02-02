using System.Windows;
using System.Data.SqlClient;
using System;

namespace EKS.Forms.MPFMenus
{
    /// <summary>
    /// Interaction logic for UserAuthority.xaml
    /// </summary>
    public partial class UserAuthority : Window
    {
        public UserAuthority()
        {
            InitializeComponent();
        }
        Classes.InFile IF;
        public string cmdString;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            UserNamesCMBBX.Items.Clear();
            IF = new Classes.InFile();
            using (SqlConnection con = new SqlConnection(IF.FilePath()))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("Select * from USERS",con))
                {
                    SqlDataReader dR = cmd.ExecuteReader();
                    while (dR.Read())
                    {
                        UserNamesCMBBX.Items.Add(dR["USERNAME"]);
                    }
                }
                con.Close();
            }
        }

        private void UserNamesCMBBX_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            string UserName = UserNamesCMBBX.SelectedItem.ToString();
            string Aut;
            IF = new Classes.InFile();
            using (SqlConnection con = new SqlConnection(IF.FilePath()))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("Select * from USERS where USERNAME='" + UserName.TrimEnd() +"'", con))
                {
                    SqlDataReader dR = cmd.ExecuteReader();
                    dR.Read();
                    Aut = dR["AUTHORITY"].ToString();
                }
                con.Close();
            }
            if (Aut == "UNKNOWN USER")
            {
                AAuthorityCMBBX.SelectedIndex = 0;
            }
            if (Aut == "OTHER USER")
            {
                AAuthorityCMBBX.SelectedIndex = 1;
            }
            if (Aut == "USER")
            {
                AAuthorityCMBBX.SelectedIndex = 2;
            }
            if (Aut == "ADMIN")
            {
                AAuthorityCMBBX.SelectedIndex = 3;
            }
        }
        private void SaveBTN_Click(object sender, RoutedEventArgs e)
        {
            IF = new Classes.InFile();
            if (AAuthorityCMBBX.SelectedIndex == 0)
            {
                cmdString = "update USERS set AUTHORITY='UNKNOWN USER' where USERNAME='" + UserNamesCMBBX.SelectionBoxItem.ToString() + "'";
            }
            else if (AAuthorityCMBBX.SelectedIndex == 1)
            {
                cmdString = "update USERS set AUTHORITY='OTHER USER' where USERNAME='" + UserNamesCMBBX.SelectionBoxItem.ToString() + "'";
            }
            else if (AAuthorityCMBBX.SelectedIndex == 2)
            {
                cmdString = "update USERS set AUTHORITY='USER' where USERNAME='" + UserNamesCMBBX.SelectionBoxItem.ToString() + "'";
            }
            else if (AAuthorityCMBBX.SelectedIndex == 3)
            {
                cmdString = "update USERS set AUTHORITY='ADMIN' where USERNAME='" + UserNamesCMBBX.SelectionBoxItem.ToString() + "'";
            }
            using (SqlConnection con = new SqlConnection(IF.FilePath()))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(cmdString, con))
                {
                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Kullanıcı Değiştirildi.", "Kaydedildi", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı Değiştirilemedi", "Başarısız", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    }
                }
                con.Close();
            }
            this.Close();
        }

        private void CancelBTN_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
