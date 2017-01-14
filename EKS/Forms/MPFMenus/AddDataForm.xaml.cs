using System.Windows;

namespace EKS.Forms.MPFMenus
{
    /// <summary>
    /// Interaction logic for AddDataForm.xaml
    /// </summary>
    public partial class AddDataForm : Window
    {
        public AddDataForm()
        {
            InitializeComponent();
        }
        Classes.DatabaseProcess DP;
        
        private void AddBTN_Click(object sender, RoutedEventArgs e)
        {
            DP = new Classes.DatabaseProcess();
            #region Property Values
            DP.Zone = ZoneCMBBX.SelectionBoxItem.ToString();
            DP.Machine = MachineCMBBX.SelectionBoxItem.ToString();
            DP.ComputerLocation = ComputerLocationCMBBX.SelectionBoxItem.ToString();
            DP.BackUpName = BackUpNameTXTBX.Text;
            DP.BackUpDate = BackUpDateDATE.SelectedDate.ToString();
            DP.BackUpProgramName = BackUpProgramNameCMBBX.SelectionBoxItem.ToString();
            DP.BackUpType = BackUpTypeCMBBX.SelectionBoxItem.ToString();
            DP.BackUpVersion = BackUpVersionCMBBX.SelectionBoxItem.ToString();
            DP.BackUpPersonalName = BackUpParsonalNameTXTBX.Text;
            DP.BackUpExplanation = BackUpExplanationCMBBX.SelectionBoxItem.ToString();
            DP.ComputerModel = ComputerModelCMBBX.SelectionBoxItem.ToString();
            DP.OperatorSystem = OperatorSystemCMBBX.SelectionBoxItem.ToString();
            DP.HardDiskInfo = HardDiskInfoTXTBX.Text;
            DP.OtomationIP = OtomationIPTXTBX.Text;
            DP.MachineIP = MachineIPTXTBX.Text;
            DP.Explanation = ExplanationTXTBX.Text;
            #endregion
            DP.Add();
            if (DP.HasSave == true)
            {
                MessageBox.Show("Kaydedildi.", "Bilgi", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Kayit Yapilamadi", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CancelBTN_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
