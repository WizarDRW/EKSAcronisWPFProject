using System;
using System.Data.SqlClient;
using EKS.Forms.UserLoginForms;
using System.Windows;
using System.Data;
using System.IO;

namespace EKS.Classes
{
    interface ILawWrite
    {
        string Name { get; set; }
        string LastName { get; set; }
        string UserName { get; set; }
        string Password { get; set; }
        void UsersSignUpSQLTables();
        void UsersSignInSQLTables();
    }

    struct InFile
    {
        public string _filepath { get; set; }
        public string FileDataTXT { get; set; }
        public string FilePath()
        {
            _filepath = @"ConnString.txt";
            FileStream FS = new FileStream(_filepath, FileMode.Open, FileAccess.Read);
            StreamReader sw = new StreamReader(FS);
            return FileDataTXT = sw.ReadLine();
        }
    }   //txt dosyasi cekimi struct

    public class UsersDatabaseConnection : UserSignUpForm, ILawWrite
    {
        #region Property
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string UserNameVerify { get; set; }
        public string PasswordVerify { get; set; }
        public bool VerifyTableEntered { get; set; }
        public int HasDataNameLastName { get; set; }
        public int HasDataUserName { get; set; }
        public int HasDataUserNameandPassword { get; set; }
        #endregion

        InFile IF = new Classes.InFile();

        #region User Create Control
        public void UsersSignUpSQLTables()
        {
            SqlConnection con = new SqlConnection(IF.FilePath());
            con.Open();
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
            con.Close();

        }
        #endregion

        #region User Enter Verify
        public void UsersSignInSQLTables()
        {
            using (SqlConnection con = new SqlConnection(IF.FilePath()))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("ULNVerify", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@username", UserNameVerify);
                    cmd.Parameters.AddWithValue("@password", PasswordVerify);
                    SqlParameter param = new SqlParameter("@UResult", System.Data.SqlDbType.Int);
                    param.Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(param);
                    cmd.ExecuteNonQuery();
                    HasDataUserNameandPassword = Convert.ToInt32(param.Value);
                }
            }
        }
        #endregion
    }   //Database Dogrulamalar

    internal class DatabaseProcess : Forms.MainProcessesForm
    {
        public DatabaseProcess()
        {
            Classes.MemoryControl MC = new MemoryControl();
            MC.MemoryStart();
        }
        InFile conString = new InFile();

        #region Processes
        public void Add()
        {
            using (SqlConnection conn = new SqlConnection(conString.FilePath()))
            {
                conn.Open();
                string cmdString = "";
                using (SqlCommand cmd = new SqlCommand(cmdString, conn))
                {

                }
            }
        }

        public void Delete()
        {
            using (SqlConnection conn = new SqlConnection(conString.FilePath()))
            {
                conn.Open();
                string cmdString = "";
                using (SqlCommand cmd = new SqlCommand(cmdString, conn))
                {

                }
            }
        }

        public void Update()
        {
            using (SqlConnection conn = new SqlConnection(conString.FilePath()))
            {
                conn.Open();
                string cmdString = "";
                using (SqlCommand cmd = new SqlCommand(cmdString, conn))
                {

                }
            }
        }

        public void Find()
        {
            using (SqlConnection conn = new SqlConnection(conString.FilePath()))
            {
                conn.Open();
                string cmdString = "";
                using (SqlCommand cmd = new SqlCommand(cmdString, conn))
                {

                }
            }
        }
        #endregion
    }   //Islemler

    abstract class Authority
    {
        public string Aut { get; set; }
        InFile IF = new InFile();
        public void AutMethod()
        {
            using (SqlConnection con = new SqlConnection(IF.FilePath()))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand())
                {

                }
            }
        }
    } //Yetki Kontrolu
}
