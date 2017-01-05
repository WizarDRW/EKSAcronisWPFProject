using System;
using System.Data.SqlClient;
using EKS.Forms.UserLoginForms;
using System.Windows;

namespace EKS.Classes
{
    interface ILawWrite
    {
        string Name { get; set; }
        string LastName { get; set; }
        string UserName { get; set; }
        string Password { get; set; }
        void UsersSignUpSQLTables();
    }
    public class UsersDatabaseConnection : UserSignUpForm, ILawWrite
    {
        #region Property
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool VerifyTableEntered { get; set; }
        public int HasDataNameLastName { get; set; }
        public int HasDataUserName { get; set; }
        #endregion

        public void UsersSignUpSQLTables()
        {
            string conString = @"Data Source=WIZARDRW\WIZARDRW;Initial Catalog=EKSAcronisDatabases;Integrated Security=True";
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            #region User Control
            using (SqlCommand cmd = new SqlCommand("ULNReg", con))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", Name);
                cmd.Parameters.AddWithValue("@lastname", LastName);
                cmd.Parameters.AddWithValue("@username", UserName);
                SqlParameter NameandLastNameParam = new SqlParameter("@LNResult", System.Data.SqlDbType.Int);
                SqlParameter UserNameParam = new SqlParameter("@UResult", System.Data.SqlDbType.Int);
                NameandLastNameParam.Direction = System.Data.ParameterDirection.Output;
                UserNameParam.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(NameandLastNameParam);
                cmd.Parameters.Add(UserNameParam);
                cmd.ExecuteNonQuery();
                HasDataNameLastName = Convert.ToInt32(NameandLastNameParam.Value);
                HasDataUserName = Convert.ToInt32(UserNameParam.Value);
            }

            if (HasDataNameLastName > 0)
            {
                MessageBox.Show(Name + ' ' + LastName + "\nKullanici Zaten Mevcut", "Bilgi", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (HasDataUserName > 0)
            {
                MessageBox.Show(UserName + "\nBu Kullanici Adi Zaten Var.", "Bilgi", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                #region CreateUsers
                try
                {
                    string cmdString = "insert into USERS(NAME, LASTNAME, USERNAME, PASSWORD) values(@Name, @LastName,@UserName, @Password)";
                    SqlCommand cmd = new SqlCommand(cmdString, con);
                    cmd.Parameters.AddWithValue("@Name", this.Name);
                    cmd.Parameters.AddWithValue("@LastName", this.LastName);
                    cmd.Parameters.AddWithValue("@UserName", this.UserName);
                    cmd.Parameters.AddWithValue("@Password", this.Password);
                    cmd.ExecuteNonQuery();
                    VerifyTableEntered = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                #endregion
            }
            #endregion
            con.Close();

        }
        
    }
}
