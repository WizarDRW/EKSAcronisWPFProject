using System;
using System.Data.SqlClient;
using EKS.Forms.UserLoginForms;
using System.Windows;
using System.IO;
using System.Data.Entity;
using System.Collections.Generic;
using EKS.Database_Tools;
using System.Linq;
using System.Windows.Documents;

namespace EKS.Classes
{
    public class UsersDatabaseConnection : UserSignUpForm
    {
        EksDBEntities Entity = new EksDBEntities();
        USERS User = new USERS();
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
        public EksDBEntities EntityProp { get => Entity; set => Entity = value; }
        public USERS UserProp { get => User; set => User = value; }
        #endregion

        #region User Create Control
        public void UsersSignUpSQLTables()
        {
            var namelast = EntityProp.USERS.FirstOrDefault(t => t.NAME == Name && t.LASTNAME == LastName);
            var username = EntityProp.USERS.FirstOrDefault(t => (t.USERNAME == UserName));
            if (namelast != null)
            {
                MessageBox.Show(Name + ' ' + LastName + "\nKisi Zaten Mevcut", "Bilgi",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (username != null)
            {
                MessageBox.Show(UserName + "\nBu Kullanici Adi Zaten Mevcut.", "Bilgi",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                AdminProcVerify();

                if (HasDataAut >= 1)
                {
                    UserProp.NAME = Name;
                    UserProp.LASTNAME = LastName;
                    UserProp.USERNAME = UserName;
                    UserProp.PASSWORD = Password;
                    UserProp.AUTHORITY = "UNKNOWN USER";
                    Entity.USERS.Add(UserProp);
                    EntityProp.SaveChanges();
                }
                else
                {
                    UserProp.NAME = Name;
                    UserProp.LASTNAME = LastName;
                    UserProp.USERNAME = UserName;
                    UserProp.PASSWORD = Password;
                    UserProp.AUTHORITY = "ADMIN";
                    Entity.USERS.Add(UserProp);
                    EntityProp.SaveChanges();
                }
                VerifyTableEntered = true;
            }
        }
        #endregion

        #region User Enter Verify
        public void UsersSignInSQLTables()
        {
            var username = EntityProp.USERS.FirstOrDefault(t => (t.USERNAME == UserNameVerify && t.PASSWORD == PasswordVerify));
            if (username != null)
                HasDataUserNameandPassword = 1;
            else
                MessageBox.Show("Kullanici Adi veya Sifre Hatali.", "Hatali Giris", MessageBoxButton.OK, MessageBoxImage.Hand);
        }
        #endregion

        public void AdminProcVerify()
        {
            var aut = EntityProp.USERS.FirstOrDefault(t => (t.AUTHORITY == "ADMIN"));
            if (aut != null)
                HasDataAut = 1;
        }
    }   //Database Dogrulamalar

    internal class DatabaseProcess
    {
        public DatabaseProcess()
        {
            Classes.MemoryControl MC = new MemoryControl();
            MC.MemoryStart();
        }

        EksDBEntities Entity = new EksDBEntities();
        BACKUPANDRECOVERTABLE BackupTable = new BACKUPANDRECOVERTABLE();

        #region Properties
        public string Zone { get; set; }
        public string Machine { get; set; }
        public string ComputerLocation { get; set; }
        public string BackUpAddInfo { get; set; }
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
        public bool HasSave { get; set; }
        public string LicenseAddPath { get; set; }
        public bool LicenseEnter { get; set; }
        public EksDBEntities EntityProp { get => Entity; set => Entity = value; }
        public BACKUPANDRECOVERTABLE BackupTableProp { get => BackupTable; set => BackupTable = value; }
        #endregion

        #region Processes
        public void Add()
        {
            BackUpPersonalName = NameAndLastName();

            BackupTableProp.BOLGE = Zone;
            BackupTableProp.MAKINA = Machine;
            BackupTableProp.BILGISAYAR_LOKASYONU = ComputerLocation;
            BackupTableProp.BACKUP_ADI = BackUpName;
            BackupTableProp.BACKUP_TARIHI = DateTime.Parse(BackUpDate);
            BackupTableProp.KAYIT_TARIHI = DateTime.Now;
            BackupTableProp.BACKUP_PROGRAM_ADI = BackUpProgramName;
            BackupTableProp.BACKUP_TIPI = BackUpType;
            BackupTableProp.BACKUP_VERSIYONU = BackUpVersion;
            BackupTableProp.BACKUP_ALAN_PERSONEL = BackUpPersonalName;
            BackupTableProp.BACKUP_NEDENI = BackUpExplanation;
            BackupTableProp.BILGISAYAR_MODELI = ComputerModel;
            BackupTableProp.ISLETIM_SISTEMI = OperatorSystem;
            BackupTableProp.HARDDISK_BILGISI = HardDiskInfo;
            BackupTableProp.OTOMASYON_IP = OtomationIP;
            BackupTableProp.MAKINA_IP = MachineIP;
            BackupTableProp.PETLAS_IP = PetlasIP;
            BackupTableProp.LISANS_DOSYASI = LicenseAddPath;
            BackupTableProp.ACIKLAMALAR = Explanation;
            try
            {
                EntityProp.BACKUPANDRECOVERTABLE.Add(BackupTableProp);
                EntityProp.SaveChanges();
                HasSave = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void Delete(int DELETEPROP)
        {
            if (DELETEPROP != null)
            {
                var selectedID = EntityProp.BACKUPANDRECOVERTABLE.Where(t => t.ID == DELETEPROP).FirstOrDefault();
                EntityProp.BACKUPANDRECOVERTABLE.Remove(selectedID);
                EntityProp.SaveChanges();
            }
        }

        public void Update()
        {

        }

        public void Find()
        {

        }

        public string NameAndLastName()
        {
            var namelastname = EntityProp.USERS.FirstOrDefault(t => t.USERNAME == UserName);
            return namelastname.NAME.TrimEnd() + ' ' + namelastname.LASTNAME.TrimEnd();
        }
        #endregion

    }   //Islemler

    internal class Authority
    {
        EksDBEntities Entity = new EksDBEntities();
        public string Aut { get; set; }
        public EksDBEntities EntityProp { get => Entity; set => Entity = value; }
        public USERS user { get => user; set => user = value; }


        public string AutMethod(String AutUserName)
        {
            var vautUserName = EntityProp.USERS.FirstOrDefault(t => t.USERNAME == AutUserName);
            if (vautUserName.AUTHORITY != null)
            {
                return vautUserName.AUTHORITY.ToString();
            }
            else
            {
                return null;
            }
        }
    }   //Kullanıcı Doğrulama

    internal class MachineIsThere
    {
        EksDBEntities Entity = new EksDBEntities();
        public string Zone { get; set; }
        public string Machine { get; set; }
        public string CLocation { get; set; }
        public int HT { get; set; }
        public EksDBEntities EntityProp { get => Entity; set => Entity = value; }

        public int IsThere()
        {

            var MachineIsThere = EntityProp.BACKUPANDRECOVERTABLE.FirstOrDefault(t=>t.BOLGE == Zone &&
            t.MAKINA == Machine && t.BILGISAYAR_LOKASYONU == CLocation);
            if (MachineIsThere != null)
            {
                return HT = 1;
            }
            else
            {
                return HT = 0;
            }
        }
    }   //Makinenin Olup olmadığı Stored Procedure
}