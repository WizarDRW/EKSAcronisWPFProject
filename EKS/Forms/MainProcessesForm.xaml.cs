using System.Windows;
using System.Data.SqlClient;
using System.Data;

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

        private string conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|EKSDatabase.mdf;Integrated Security=True";
        private string ListString = "select * from USERS";
        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            using (SqlConnection con = new SqlConnection(conString))
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

        private void DatabaseDeleteMenuClick(object sender, RoutedEventArgs e)
        {

        }

        private void DatabaseAddMenuClick(object sender, RoutedEventArgs e)
        {

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
    }
}
