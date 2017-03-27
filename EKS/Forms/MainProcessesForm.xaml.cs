using System.Windows;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using EKS.Database_Tools;
using System.Windows.Data;
using System.Collections;
using System.Windows.Controls;
using System;
using System.Collections.Generic;

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
        EksDBEntities Entity = new EksDBEntities();
        BACKUPANDRECOVERTABLE bc = new BACKUPANDRECOVERTABLE();
        public string UserName { get; set; }
        public string Authority { get; set; }
        public EksDBEntities EntityProp { get => Entity; set => Entity = value; }
        public BACKUPANDRECOVERTABLE Bc { get => bc; set => bc = value; }

        Classes.DatabaseProcess DP = new Classes.DatabaseProcess();
        Forms.MPFMenus.UserAuthority _instance = MPFMenus.UserAuthority.Instance;

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            if (Authority == "ADMIN")
            {
                DatabaseList.Visibility = Visibility.Visible;
                DatabaseAddMenu.Visibility = Visibility.Visible;
                DatabaseDeleteMenu.Visibility = Visibility.Visible;
                DatabaseUpdateMenu.Visibility = Visibility.Visible;
                DatabaseDataFindMenu.Visibility = Visibility.Visible;
                DatabaseUserControl.Visibility = Visibility.Visible;
            }
            else if (Authority == "USER")
            {
                DatabaseList.Visibility = Visibility.Visible;
                DatabaseAddMenu.Visibility = Visibility.Visible;
                DatabaseDeleteMenu.Visibility = Visibility.Visible;
                DatabaseUpdateMenu.Visibility = Visibility.Visible;
                DatabaseDataFindMenu.Visibility = Visibility.Visible;
            }
            else if (Authority == "OTHER USER")
            {
                DatabaseList.Visibility = Visibility.Visible;
            }
        }
        DataTable dT = new DataTable();
        private void DatabaseDeleteMenuClick(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Silmek Istediğnize Emin misiniz?", "Emin misiniz?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                if (MainDataGrid.SelectedIndex >= 0)
                {
                    if (MainDataGrid.SelectedItems[0] == null)
                    {
                        MessageBox.Show("Dosya Bos", "Bilgi", MessageBoxButton.OK, MessageBoxImage.None);
                    }
                    else
                    {
                        BACKUPANDRECOVERTABLE deleteItem = MainDataGrid.SelectedItems[0] as BACKUPANDRECOVERTABLE;
                        DP.Delete(deleteItem.ID);
                        Entity.SaveChanges();
                    }
                }
                else
                {
                    MessageBox.Show("Lutfen Satir Secin", "Bilgi.", MessageBoxButton.OK, MessageBoxImage.Hand);
                }
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
            BACKUPANDRECOVERTABLE UpdateSData = MainDataGrid.SelectedItems[0] as BACKUPANDRECOVERTABLE;
            MPFMenus.UpdateDataForm UDF = new MPFMenus.UpdateDataForm() { UpdateSelectedData = UpdateSData };
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
            MainDataGrid.ItemsSource = EntityProp.BACKUPANDRECOVERTABLE.ToList();
        }

        private void DatabaseUserControlClick(object sender, RoutedEventArgs e)
        {
            _instance.Owner = Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);
            _instance.ShowDialog();
        }
    }
}
