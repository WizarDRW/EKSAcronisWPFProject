﻿using EKS.Forms;
using EKS;

namespace EKS.Classes
{
    public class UserNamePasswordVerify
    {
        UsersDatabaseConnection UDC = new UsersDatabaseConnection();

        #region Defauld Administration Login
        #region Property and Strings
        private string DefaultUserName = EKS.Properties.Settings.Default.UserName;
        private string DefaultPassword = EKS.Properties.Settings.Default.Password;
        public string NewUserName { get; set; }
        public string NewPassword { get; set; }
        public bool VerifyUserName { get; private set; }
        public bool VerifyPassword { get; private set; }
        public bool VerifyEnter { get; set; }
        #endregion

        public bool _VerifyAdminUserNameMethod()
        {
            if (NewUserName == DefaultUserName)
            { return VerifyUserName = true; }
            else
            { return VerifyUserName = false; }

        }
        public bool _VerifyAdminPasswordMethod()
        {
            if (NewPassword == DefaultPassword)
            { return VerifyPassword = true; }
            else
            { return VerifyPassword = false; }
        }
        #endregion

        #region User Login
        public bool _VerifyUserNameMethod()
        {
            return false;
        }

        public bool _VerifyUserPasswordMethod()
        {
            return false;
        }
        #endregion

    }
}
//Temel sorun bool Haberleşmesi
//Property ler ile interface kuralları oluşturup Metot ile return yapılmalı
//Property ler tek başına döndürmüyor
//işlem bittikten sonra Memory den atmak Tekrar kullanıcı girişini engelleyebilir Çözüm bulunmalı.