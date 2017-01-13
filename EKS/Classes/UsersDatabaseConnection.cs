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
        public int HasDataAut { get; set; }
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
                MessageBox.Show(UserName + "\nBu Kullanici Adi Zaten Mevcut.", "Bilgi", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                #region CreateUsers
                try
                {
                    AdminProcVerify();
                    string cmdString;
                    if (HasDataAut >= 1)
                    {
                        cmdString = "insert into USERS(NAME, LASTNAME, USERNAME, PASSWORD) values(@Name, @LastName,@UserName, @Password)";
                    }
                    else
                    {
                        cmdString = "insert into USERS(NAME, LASTNAME, USERNAME, PASSWORD, AUTHORITY) values(@Name, @LastName,@UserName, @Password, 'ADMIN')";
                    }
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

        public void AdminProcVerify()
        {
            SqlConnection con = new SqlConnection(IF.FilePath());
            con.Open();
            using (SqlCommand cmd = new SqlCommand("AVerify", con))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter AuthorityProcParam = new SqlParameter("@Aut", System.Data.SqlDbType.Int);
                AuthorityProcParam.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(AuthorityProcParam);
                cmd.ExecuteNonQuery();
                HasDataAut = Convert.ToInt32(AuthorityProcParam.Value);
            }
            con.Close();
        }
    }   //Database Dogrulamalar

    internal class DatabaseProcess : Forms.MPFMenus.AddDataForm //Textbox ve combobx bos geliyor
    {
        public DatabaseProcess()
        {
            Classes.MemoryControl MC = new MemoryControl();
            MC.MemoryStart();
        }
        InFile conString = new InFile();

        public bool HasSave { get; set; }

        #region Processes
        public void Add()
        {
            using (SqlConnection conn = new SqlConnection(conString.FilePath()))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("AddValues", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    #region SQLPARAMETERS
                    SqlParameter ZoneParam = new SqlParameter("@BOLGE", ZoneCMBBX.SelectedItem);
                    SqlParameter MachineParam = new SqlParameter("@MAKINA", MachineCMBBX.SelectedItem);
                    SqlParameter ComputerLocationParam = new SqlParameter("@BILGISAYARLOKASYONU", ComputerLocationCMBBX.SelectedItem);
                    SqlParameter BackUpNameParam = new SqlParameter("@BACKUPADI", BackUpNameTXTBX.Text);
                    SqlParameter BackUpDateParam = new SqlParameter("@BACKUPTARIHI", BackUpDateCMBBX.SelectedDate);
                    SqlParameter BackUpProgramNameParam = new SqlParameter("@BACKUPPROGRAMADI", BackUpProgramNameCMBBX.SelectedItem);
                    SqlParameter BackUpTypeParam = new SqlParameter("@BACKUPTIPI", BackUpTypeCMBBX.SelectedItem);
                    SqlParameter BackUpVersionParam = new SqlParameter("@BACKUPVERSIYONU", BackUpVersionCMBBX.SelectedItem);
                    SqlParameter BackUpPersonalNameParam = new SqlParameter("@BACKUPALANPERSONEL", BackUpParsonalNameTXTBX.Text);
                    SqlParameter BackUpExplanationParam = new SqlParameter("@BACKUPNEDENI", BackUpExplanationCMBBX.SelectedItem);
                    SqlParameter ComputerModelParam = new SqlParameter("@BACKUPTIPI", ComputerModelCMBBX.SelectedItem);
                    SqlParameter OperatorSystemParam = new SqlParameter("@ISLETIMSISTEMI", OperatorSystemCMBBX.SelectedItem);
                    SqlParameter HarddiskInfoParam = new SqlParameter("@BACKUPALANPERSONEL", HardDiskInfoTXTBX.Text);
                    SqlParameter OtomationIPParam = new SqlParameter("@BACKUPALANPERSONEL", OtomationIPTXTBX.Text);
                    SqlParameter MachineIPParam = new SqlParameter("@MAKINAIP", MachineIPTXTBX.Text);
                    SqlParameter ExplanationParam = new SqlParameter("@ACIKLAMALAR", ExplanationTXTBX.Text);
                    #endregion

                    ZoneParam.Direction = ParameterDirection.Input;
                    MachineParam.Direction = ParameterDirection.Input;
                    ComputerLocationParam.Direction = ParameterDirection.Input;
                    BackUpNameParam.Direction = ParameterDirection.Input;
                    BackUpDateParam.Direction = ParameterDirection.Input;
                    BackUpProgramNameParam.Direction = ParameterDirection.Input;
                    BackUpTypeParam.Direction = ParameterDirection.Input;
                    BackUpVersionParam.Direction = ParameterDirection.Input;
                    BackUpPersonalNameParam.Direction = ParameterDirection.Input;
                    BackUpExplanationParam.Direction = ParameterDirection.Input;
                    ComputerModelParam.Direction = ParameterDirection.Input;
                    OperatorSystemParam.Direction = ParameterDirection.Input;
                    HarddiskInfoParam.Direction = ParameterDirection.Input;
                    OtomationIPParam.Direction = ParameterDirection.Input;
                    MachineIPParam.Direction = ParameterDirection.Input;
                    ExplanationParam.Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(ZoneParam);
                    cmd.Parameters.Add(MachineParam);
                    cmd.Parameters.Add(ComputerLocationParam);
                    cmd.Parameters.Add(BackUpNameParam);
                    cmd.Parameters.Add(BackUpDateParam);
                    cmd.Parameters.Add(BackUpProgramNameParam);
                    cmd.Parameters.Add(BackUpTypeParam);
                    cmd.Parameters.Add(BackUpVersionParam);
                    cmd.Parameters.Add(BackUpPersonalNameParam);
                    cmd.Parameters.Add(BackUpExplanationParam);
                    cmd.Parameters.Add(ComputerModelParam);
                    cmd.Parameters.Add(OperatorSystemParam);
                    cmd.Parameters.Add(HarddiskInfoParam);
                    cmd.Parameters.Add(OtomationIPParam);
                    cmd.Parameters.Add(MachineIPParam);
                    cmd.Parameters.Add(ExplanationParam);

                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        HasSave = true;
                    }
                    else
                    {
                        HasSave = false;
                    }

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

    internal class Authority
    {
        public string Aut { get; set; }
        InFile IF = new InFile();
        


        public string AutMethod(String AutUserName)
        {
            using (SqlConnection con = new SqlConnection(IF.FilePath()))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("Select * from USERS where USERNAME = '" + AutUserName + "'", con))
                {
                    cmd.ExecuteNonQuery();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        return dr["AUTHORITY"].ToString();
                    }
                    else
                    {
                        return null;
                    }
                }
                con.Close();
            }
        }
    } //Yetki Kontrolu
}
