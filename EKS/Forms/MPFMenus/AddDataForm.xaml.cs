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
            if (ZoneCMBBX.SelectionBoxItem.ToString() != "" && MachineCMBBX.SelectionBoxItem.ToString() != "" && ComputerLocationCMBBX.SelectionBoxItem.ToString() != "" &&
                BackUpNameTXTBX.Text != "" && BackUpDateDATE.SelectedDate.ToString() != "" && BackUpProgramNameCMBBX.SelectionBoxItem.ToString() != "" &&
                BackUpTypeCMBBX.SelectionBoxItem.ToString() != "" && BackUpVersionCMBBX.SelectionBoxItem.ToString() != "" && BackUpParsonalNameTXTBX.Text != "" &&
                BackUpExplanationCMBBX.SelectionBoxItem.ToString() != "" && ComputerModelCMBBX.SelectionBoxItem.ToString() != "" && OperatorSystemCMBBX.SelectionBoxItem.ToString() != "" &&
                HardDiskInfoTXTBX.Text != "" && OtomationIPTXTBX.Text != "" && MachineIPTXTBX.Text != "" && ExplanationTXTBX.Text != "")
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
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Kayit Yapilamadi", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Bos Birakilamaz.", "Bilgi", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }

        private void CancelBTN_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        #region ComboBox Selected
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

        private void BackUpNameTXTBX_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            switch (e.Key)
            {
                case System.Windows.Input.Key.Space:
                    var _cursorPosition = BackUpNameTXTBX.SelectionStart;
                    var _selectionLength = BackUpNameTXTBX.SelectionLength;
                    BackUpNameTXTBX.Text = BackUpNameTXTBX.Text.Replace(" ", "_");
                    BackUpNameTXTBX.SelectionStart = _cursorPosition + 1;
                    BackUpNameTXTBX.SelectionLength = _selectionLength + 1;
                    BackUpNameTXTBX.Focus();
                    break;
                default:
                    break;
            }
        }
    }
}
