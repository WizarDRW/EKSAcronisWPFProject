using System.Windows;
using System.Data.SqlClient;

namespace EKS.Forms.MPFMenus
{
    /// <summary>
    /// Interaction logic for UpdateDataForm.xaml
    /// </summary>
    public partial class UpdateDataForm : Window
    {
        public UpdateDataForm()
        {
            InitializeComponent();
        }
        Classes.InFile IF = new Classes.InFile();
        Classes.DatabaseProcess DP = new Classes.DatabaseProcess();

        private void UpdateBTN_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CancelBTN_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(IF.FilePath()))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("Select * From BACKUPANDRECOVERTABLE"))
                {
                    SqlDataReader dR = cmd.ExecuteReader();
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                }
            }
        }
    }
}
