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
        #endregion

        public void UsersSignUpSQLTables()
        {
            string conString = @"Data Source=WIZARDRW\WIZARDRW;Initial Catalog=EKSAcronisDatabases;Integrated Security=True";
            SqlConnection con = new SqlConnection(conString);
            try
            {
                string cmdString = "insert into USERS(NAME, LASTNAME, USERNAME, PASSWORD) values(@Name, @LastName,@UserName, @Password)";
                con.Open();
                SqlCommand cmd = new SqlCommand(cmdString, con);
                cmd.Parameters.AddWithValue("@Name", this.Name);
                cmd.Parameters.AddWithValue("@LastName", this.LastName);
                cmd.Parameters.AddWithValue("@UserName", this.UserName);
                cmd.Parameters.AddWithValue("@Password", this.Password);
                cmd.ExecuteNonQuery();
                con.Close();
                VerifyTableEntered = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void ReadDatabases()
        {
            string conString = @"Data Source=WIZARDRW\WIZARDRW;Initial Catalog=EKSAcronisDatabases;Integrated Security=True";
            SqlConnection con = new SqlConnection(conString);
            try
            {
                con.Open();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
