using System.Windows;
using System.Data.SqlClient;
using EKS.Database_Tools;

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
        Classes.DatabaseProcess DP = new Classes.DatabaseProcess();
        public BACKUPANDRECOVERTABLE UpdateSelectedData { get; set; }

        private void UpdateBTN_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CancelBTN_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ZoneCMBBX.SelectedValue = UpdateSelectedData.BOLGE;
        }

        #region ComboBoc Selected
        private void ZoneCItemMixers_Selected(object sender, RoutedEventArgs e)
        {
            MachineCMBBX.Items.Clear();
            MachineCMBBX.Items.Add("MIXER 01");
            MachineCMBBX.Items.Add("MIXER 02");
            MachineCMBBX.Items.Add("MIXER 03");
            MachineCMBBX.Items.Add("MIXER 04");
            MachineCMBBX.Items.Add("MIXER 05");
            MachineCMBBX.Items.Add("MIXER 06");
            MachineCMBBX.Items.Add("MIXER 07");
            MachineCMBBX.Items.Add("MIXER 08");
            MachineCMBBX.Items.Add("MIXER 09");
            MachineCMBBX.Items.Add("MIXER 10");
            MachineCMBBX.Items.Add("MIXER 11");
            MachineCMBBX.Items.Add("MIXER 12");
        }

        private void ZoneCItemKalender_Selected(object sender, RoutedEventArgs e)
        {
            MachineCMBBX.Items.Clear();
            MachineCMBBX.Items.Add("KALENDER 1 ROOL");
            MachineCMBBX.Items.Add("KALENDER 2 ROOL");
            MachineCMBBX.Items.Add("KALENDER 3 ROOL");
            MachineCMBBX.Items.Add("KALENDER 4 ROOL");
        }

        private void ZoneCItemExtruder_Selected(object sender, RoutedEventArgs e)
        {
            MachineCMBBX.Items.Clear();
            MachineCMBBX.Items.Add("YENI CHODOS EXTRUDER");
            MachineCMBBX.Items.Add("TRIPLEX EXTRUDER");
            MachineCMBBX.Items.Add("QUADROPLEX EXTRUDER");
            MachineCMBBX.Items.Add("QUINTOPLEX EXTRUDER");
            MachineCMBBX.Items.Add("APEX EXTRUDER");
            MachineCMBBX.Items.Add("CIN QUINTOPLEX EXTRUDER");
            MachineCMBBX.Items.Add("CIN QUADROPLEX EXTRUDER");
        }
        #endregion

        private void LicanseBTN_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
