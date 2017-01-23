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

        public string UserName { get; set; }
        public string Authority { get; set; }

        Classes.InFile IF = new Classes.InFile();
        Classes.DatabaseProcess DP = new Classes.DatabaseProcess();

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            //if (Authority == "ADMIN")
            //{
                DatabaseList.Visibility = Visibility.Visible;
                DatabaseAddMenu.Visibility = Visibility.Visible;
                DatabaseDeleteMenu.Visibility = Visibility.Visible;
                DatabaseUpdateMenu.Visibility = Visibility.Visible;
                DatabaseDataFindMenu.Visibility = Visibility.Visible;
                DatabaseUserControl.Visibility = Visibility.Visible;
            //}
        }

        private void DatabaseDeleteMenuClick(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Silmek Istediğnize Emin misiniz?", "Emin misiniz?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                DataRowView DRV = (DataRowView)MainDataGrid.SelectedItem;
                int index = MainDataGrid.CurrentCell.Column.DisplayIndex;
                string cellID = DRV.Row.ItemArray[0].ToString();
                DP.DELETEPROP = cellID;
                DP.Delete();
                DatabaseListClick(sender, e);
            }
        }

        private void DatabaseAddMenuClick(object sender, RoutedEventArgs e)
        {
            MPFMenus.AddDataForm ad = new MPFMenus.AddDataForm();
            ad.UserName = UserName;
            ad.Owner = Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);
            ad.ShowDialog();
            DatabaseListClick(sender, e);
        }

        private void DatabaseUpdateMenuClick(object sender, RoutedEventArgs e)
        {
            MPFMenus.UpdateDataForm UDF = new MPFMenus.UpdateDataForm();
            UDF.Owner = Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);
            UDF.ShowDialog();
            DatabaseListClick(sender, e);
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
