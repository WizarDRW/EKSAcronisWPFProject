using System;
using System.Data.SqlClient;
using EKS.Forms.UserLoginForms;
using System.Windows;
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

    internal class DatabaseProcess
    {
        public DatabaseProcess()
        {
            Classes.MemoryControl MC = new MemoryControl();
            MC.MemoryStart();
        }
        InFile conString = new InFile();

        #region Properties
        public string Zone { get; set; }
        public string Machine { get; set; }
        public string ComputerLocation { get; set; }
        public string BackUpName { get; set; }
        public string BackUpDate { get; set; }
        public string BackUpProgramName { get; set; }
        public string BackUpType { get; set; }
        public string BackUpVersion { get; set; }
        public string BackUpPersonalName { get; set; }
        public string UserName { get; set; }
        public string BackUpExplanation { get; set; }
        public string ComputerModel { get; set; }
        public string OperatorSystem { get; set; }
        public string HardDiskInfo { get; set; }
        public string OtomationIP { get; set; }
        public string MachineIP { get; set; }
        public string PetlasIP { get; set; }
        public int LicenseID { get; set; }
        public string Explanation { get; set; }
        public string DELETEPROP { get; set; }
        public bool HasSave { get; set; }
        public bool LicenseEnter { get; set; }
        #endregion

        #region Processes
        public void Add()
        {
            using (SqlConnection conn = new SqlConnection(conString.FilePath()))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO BACKUPANDRECOVERTABLE (BOLGE, MAKINA, [BILGISAYAR LOKASYONU],"
                                                       + "[BACKUP ADI], [BACKUP TARIHI], [BACKUP PROGRAM ADI], [BACKUP TIPI],"
                                                       + "[BACKUP VERSIYONU], [BACKUP ALAN PERSONEL], [BACKUP NEDENI], [BILGISAYAR MODELI],"
                                                       + "[ISLETIM SISTEMI], [HARDDISK BILGISI], [OTOMASYON IP], [MAKINA IP], [PETLAS IP], [LISANS ID], ACIKLAMALAR) "
                                                       + "VALUES('" + Zone + "', '" + Machine + "', '" + ComputerLocation + "', '" + BackUpName + "', "
                                                       + "CONVERT(Datetime, '" + BackUpDate + "', 104), '" + BackUpProgramName + "', '" + BackUpType + "', '" + BackUpVersion + "', '" + NameAndLastName() + "', "
                                                       + "'" + BackUpExplanation + "', '" + ComputerModel + "', '" + OperatorSystem + "', '" + HardDiskInfo + "', '" + OtomationIP + "',"
                                                       + "'" + MachineIP + "', '" + PetlasIP + "', '" + LicenseID + "' ,'" + Explanation + "')", conn))
                {
                    try
                    {
                        cmd.ExecuteNonQuery();
                        HasSave = true;
                    }
                    catch (Exception ex)
                    {
                        HasSave = false;
                        MessageBox.Show(ex.ToString(), "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                }
                conn.Close();
            }
        }

        public void Delete()
        {
            using (SqlConnection conn = new SqlConnection(conString.FilePath()))
            {
                conn.Open();
                string cmdString = "Delete from BACKUPANDRECOVERTABLE where ID = " + DELETEPROP;
                using (SqlCommand cmd = new SqlCommand(cmdString, conn))
                {
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
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

        public string NameAndLastName()
        {
            using (SqlConnection conn = new SqlConnection (conString.FilePath()))
            {
                conn.Open();
                string cmdString = "select * from USERS where USERNAME = '" + UserName + "'";
                using (SqlCommand cmd = new SqlCommand(cmdString, conn))
                {
                    cmd.ExecuteNonQuery();
                    SqlDataReader dR = cmd.ExecuteReader();
                    dR.Read();
                    string name = dR["NAME"].ToString();
                    string lastName = dR["LASTNAME"].ToString();
                    return name.TrimEnd() + " " + lastName.TrimEnd();
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
    }

    internal class MachineIsThere
    {
        public string Zone { get; set; }
        public string Machine { get; set; }
        public string CLocation { get; set; }
        public int HT { get; set; }
        InFile IF = new InFile();
        public int IsThere()
        {
            using (SqlConnection con = new SqlConnection(IF.FilePath()))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("MachineIsThere", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@bolge", Zone);
                    cmd.Parameters.AddWithValue("@makina", Machine);
                    cmd.Parameters.AddWithValue("@BLokasyon", CLocation);
                    SqlParameter IsThereParam = new SqlParameter("@LNResult", System.Data.SqlDbType.Int);
                    IsThereParam.Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(IsThereParam);
                    cmd.ExecuteNonQuery();
                    return HT = Convert.ToInt32(IsThereParam.Value);
                }
                con.Close();
            }
        }
    }
}