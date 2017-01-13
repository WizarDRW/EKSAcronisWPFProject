using System.Windows;
using System.Data.SqlClient;
using System.Data;
using System.Linq;

namespace EKS.Forms
{
    /// <summary>
    /// Interaction logic for MainProcessesForm.xaml
    /// </summary>
    public partial class MainProcessesForm : Window
    {
        public MainProcessesForm()
        {
            InitializeComponent();
        }
        public string Authority { get; set; }

        Classes.InFile IF = new Classes.InFile();
        
        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            if (Authority == "ADMIN")
            {
                DatabaseUserControl.Visibility = Visibility.Visible;
            }
        }
        
        private void DatabaseDeleteMenuClick(object sender, RoutedEventArgs e)
        {

        }

        private void DatabaseAddMenuClick(object sender, RoutedEventArgs e)
        {
            MPFMenus.AddDataForm ad = new MPFMenus.AddDataForm();
            ad.Owner = Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);
            ad.ShowDialog();
        }

        private void DatabaseUpdateMenuClick(object sender, RoutedEventArgs e)
        {

        }

        private void DatabaseFindMenuClick(object sender, RoutedEventArgs e)
        {

        }

        private void MPFClosed(object sender, System.EventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void DatabaseListClick(object sender, RoutedEventArgs e)
        {
            string ListString = "select * from BACKUPANDRECOVERTABLE";
            using (SqlConnection con = new SqlConnection(IF.FilePath()))
            using (SqlCommand cmd = new SqlCommand(ListString, con))
            {
                con.Open();
                using (SqlDataAdapter dA = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    dA.Fill(dt);
                    MainDataGrid.ItemsSource = dt.DefaultView;
                }
                con.Close();
            }
        }

        private void DatabaseUserControlClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
