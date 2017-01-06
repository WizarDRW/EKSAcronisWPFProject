namespace EKS.Classes
{
    public class UserNamePasswordVerify
    {
        UsersDatabaseConnection UDC = new UsersDatabaseConnection();

        #region Property and Strings
        private string DefaultUserName = EKS.Properties.Settings.Default.UserName;
        private string DefaultPassword = EKS.Properties.Settings.Default.Password;
        public string NewUserName { get; set; }
        public string NewPassword { get; set; }
        public bool VerifyUserName { get; private set; }
        public bool VerifyPassword { get; private set; }
        public bool VerifyEnter { get; set; }
        public int VerifyUsersEnter { get; set; }
        #endregion

        #region Defauld Administration Login

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

        public bool _VerifyUserNamePasswordMethod()
        {
            UDC.UserNameVerify = NewUserName;
            UDC.PasswordVerify = NewPassword;
            UDC.UsersSignInSQLTables();
            VerifyUsersEnter = UDC.HasDataUserNameandPassword;
            if (VerifyUsersEnter >= 1)
                return true;
            else
                return false;
        }

        #endregion

    }
}