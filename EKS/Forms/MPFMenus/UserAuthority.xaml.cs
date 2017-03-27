using System.Windows;
using System.Data.SqlClient;
using System.Linq;
using EKS.Database_Tools;
using System.ComponentModel;

namespace EKS.Forms.MPFMenus
{
    /// <summary>
    /// Interaction logic for UserAuthority.xaml
    /// </summary>
    public partial class UserAuthority : Window
    {
        private UserAuthority()
        {
            InitializeComponent();
        }
        private static UserAuthority _instance = null;

        public static UserAuthority Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UserAuthority();
                }
                return _instance;
            }
        }


        EksDBEntities Entity = new EksDBEntities();
        public string cmdString;
        public USERS user {get => user; set => user = value; }
        public EksDBEntities EntityProp { get => Entity; set => Entity = value; }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var items = EntityProp.USERS.Select(t => t.USERNAME);
            UserNamesCMBBX.Items.Clear();

            foreach (var item in items)
            {
                UserNamesCMBBX.Items.Add(item);
            }
        }

        private void UserNamesCMBBX_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            string UserName = UserNamesCMBBX.SelectedItem.ToString();
            string Aut;
            var username = EntityProp.USERS.FirstOrDefault(t => t.USERNAME == UserName.TrimEnd());
            Aut = username.AUTHORITY.ToString();
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
            if (AAuthorityCMBBX.SelectedIndex == 0)
            {
                var orginal = EntityProp.USERS.FirstOrDefault(t => t.USERNAME == UserNamesCMBBX.SelectionBoxItem.ToString());
                if (orginal != null)
                    orginal.AUTHORITY = "UNKNOWN USER";
            }
            else if (AAuthorityCMBBX.SelectedIndex == 1)
            {
                var orginal = EntityProp.USERS.FirstOrDefault(t=> t.USERNAME == UserNamesCMBBX.SelectionBoxItem.ToString());
                if (orginal != null)
                    orginal.AUTHORITY = "OTHER USER";
            }
            else if (AAuthorityCMBBX.SelectedIndex == 2)
            {
                var orginal = EntityProp.USERS.FirstOrDefault(t => t.USERNAME == UserNamesCMBBX.SelectionBoxItem.ToString());
                if (orginal != null)
                    orginal.AUTHORITY = "USER";
            }
            else if (AAuthorityCMBBX.SelectedIndex == 3)
            {
                var orginal = EntityProp.USERS.FirstOrDefault(t => t.USERNAME == UserNamesCMBBX.SelectionBoxItem.ToString());
                if (orginal != null)
                    orginal.AUTHORITY = "ADMIN";
            }
            EntityProp.SaveChanges();
            CancelBTN_Click(sender, e);
        }

        private void CancelBTN_Click(object sender, RoutedEventArgs e)
        {
            this.Closing += Window_Closing;

            base.Close();
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}
