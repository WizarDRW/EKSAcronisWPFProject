using System;
using System.Data.SqlClient;
using System.Linq;
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
        Classes.MachineIsThere MIT;
        License.MachineLicense ML;
        Classes.InFile IF;

        public string UserName { get; set; }
        public int LicenseID { get; set; }

        private void AddBTN_Click(object sender, RoutedEventArgs e)
        {
            if (ZoneCMBBX.SelectionBoxItem.ToString() != "" && MachineCMBBX.SelectionBoxItem.ToString() != "" && ComputerLocationCMBBX.SelectionBoxItem.ToString() != "" &&
                BackUpDateDATE.SelectedDate.ToString() != "" && BackUpProgramNameCMBBX.SelectionBoxItem.ToString() != "" &&
                BackUpTypeCMBBX.SelectionBoxItem.ToString() != "" && BackUpVersionCMBBX.SelectionBoxItem.ToString() != "" &&
                BackUpExplanationCMBBX.SelectionBoxItem.ToString() != "" && ComputerModelCMBBX.SelectionBoxItem.ToString() != "" && OperatorSystemCMBBX.SelectionBoxItem.ToString() != "" &&
                HardDiskInfoTXTBX.Text != "" && OtomationIPTXTBX.Text != "" && MachineIPTXTBX.Text != "")
            {
                string D = BackUpDateDATE.SelectedDate.ToString().Replace(".", "");
                string DateDeletePoint = D.Substring(0, D.Length - 9);
                if (DateDeletePoint.Length == 7)
                {
                    DateDeletePoint = "0" + DateDeletePoint;
                }
                DP = new Classes.DatabaseProcess();
                #region Property Values
                DP.Zone = ZoneCMBBX.SelectionBoxItem.ToString();
                DP.Machine = MachineCMBBX.SelectionBoxItem.ToString();
                DP.ComputerLocation = ComputerLocationCMBBX.SelectionBoxItem.ToString();
                DP.BackUpName = MachineCMBBX.SelectionBoxItem.ToString().Replace(" ", "_") + '_' + ComputerLocationCMBBX.SelectionBoxItem.ToString().Replace(" ", "_") + '_' + DateDeletePoint + '_';
                DP.BackUpDate = BackUpDateDATE.SelectedDate.ToString();
                DP.BackUpProgramName = BackUpProgramNameCMBBX.SelectionBoxItem.ToString();
                DP.BackUpType = BackUpTypeCMBBX.SelectionBoxItem.ToString();
                DP.BackUpVersion = BackUpVersionCMBBX.SelectionBoxItem.ToString();
                DP.BackUpExplanation = BackUpExplanationCMBBX.SelectionBoxItem.ToString();
                DP.ComputerModel = ComputerModelCMBBX.SelectionBoxItem.ToString();
                DP.OperatorSystem = OperatorSystemCMBBX.SelectionBoxItem.ToString();
                DP.HardDiskInfo = HardDiskInfoTXTBX.Text;
                DP.OtomationIP = OtomationIPTXTBX.Text;
                DP.MachineIP = MachineIPTXTBX.Text;
                DP.PetlasIP = PetlasIPTXTBX.Text;
                if (LicanseBTN.IsEnabled == true)
                {
                    DP.LicenseID = ML.LicenseID;
                }
                else if (LicanseBTN.IsEnabled == false)
                {
                    DP.LicenseID = this.LicenseID;
                }
                DP.Explanation = ExplanationTXTBX.Text;
                #endregion
                DP.UserName = UserName;
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

        private void LicanseBTN_Click(object sender, RoutedEventArgs e)
        {
            ML = new License.MachineLicense();
            ML.Owner = Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);
            ML.ShowDialog();
        }

        #region ComboBox Items Selected
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
            MachineCMBBX.Items.Add("ESKİ 3 ROOL KALENDER");
            MachineCMBBX.Items.Add("YENİ 3 ROOL KALENDER");
            MachineCMBBX.Items.Add("ESKİ COMERIO KALENDER");
            MachineCMBBX.Items.Add("YENİ COMERIO KALENDER");
            MachineCMBBX.Items.Add("ESKİ ASTAR KALENDER");
            MachineCMBBX.Items.Add("YENİ ASTAR KALENDER");
            MachineCMBBX.Items.Add("4 ROOL KALENDER");
        }

        private void ZoneCItemExtruder_Selected(object sender, RoutedEventArgs e)
        {
            MachineCMBBX.Items.Clear();
            MachineCMBBX.Items.Add("YENI CHODOS EXTRUDER");
            MachineCMBBX.Items.Add("TRIPLEX EXTRUDER");
            MachineCMBBX.Items.Add("QUADROPLEX EXTRUDER");
            MachineCMBBX.Items.Add("APEX EXTRUDER");
            MachineCMBBX.Items.Add("BERSTROFF EXTRUDER");
            MachineCMBBX.Items.Add("EMS EXTRUDER");
            MachineCMBBX.Items.Add("CIN QUINTOPLEX EXTRUDER");
            MachineCMBBX.Items.Add("CIN QUADROPLEX EXTRUDER");
        }

        private void ZoneCItemKT_Selected(object sender, RoutedEventArgs e)
        {
            MachineCMBBX.Items.Clear();
            MachineCMBBX.Items.Add("KİMYASAL TARTIM 1");
            MachineCMBBX.Items.Add("KİMYASAL TARTIM 2");
            MachineCMBBX.Items.Add("KİMYASAL TARTIM 3");
            MachineCMBBX.Items.Add("KİMYASAL TARTIM 4");
            MachineCMBBX.Items.Add("MANUEL KİMYASAL TARTIM");
        }

        private void ZoneCItemPnomatik_Selected(object sender, RoutedEventArgs e)
        {
            MachineCMBBX.Items.Clear();
            MachineCMBBX.Items.Add("PC 1");
            MachineCMBBX.Items.Add("PC 2");
            MachineCMBBX.Items.Add("PC 3");
            MachineCMBBX.Items.Add("PC 4");
            MachineCMBBX.Items.Add("PC 5");
            MachineCMBBX.Items.Add("PC 6");
            MachineCMBBX.Items.Add("PC 7");
            MachineCMBBX.Items.Add("PC 8");
        }

        private void ZoneCItemBead_Selected(object sender, RoutedEventArgs e)
        {
            MachineCMBBX.Items.Clear();
            MachineCMBBX.Items.Add("");
        }

        private void ZoneCItemCapraz_Selected(object sender, RoutedEventArgs e)
        {
            MachineCMBBX.Items.Clear();
            MachineCMBBX.Items.Add("");
        }

        private void ZoneCItemLI_Selected(object sender, RoutedEventArgs e)
        {
            MachineCMBBX.Items.Clear();
            MachineCMBBX.Items.Add("");
        }

        private void ZoneCItemP_Selected(object sender, RoutedEventArgs e)
        {
            MachineCMBBX.Items.Clear();
            MachineCMBBX.Items.Add("");
        }

        private void ZoneCItemBM_Selected(object sender, RoutedEventArgs e)
        {
            MachineCMBBX.Items.Clear();
            MachineCMBBX.Items.Add("");
        }

        private void ZoneCItemPS_Selected(object sender, RoutedEventArgs e)
        {
            MachineCMBBX.Items.Clear();
            MachineCMBBX.Items.Add("");
        }

        private void ZoneCItemTestCenter_Selected(object sender, RoutedEventArgs e)
        {
            MachineCMBBX.Items.Clear();
            MachineCMBBX.Items.Add("");
        }

        private void ZoneCItemLastControl_Selected(object sender, RoutedEventArgs e)
        {
            MachineCMBBX.Items.Clear();
            MachineCMBBX.Items.Add("");
        }

        private void ZoneCItemRBM_Selected(object sender, RoutedEventArgs e)
        {
            MachineCMBBX.Items.Clear();
            MachineCMBBX.Items.Add("");
        }

        private void ZoneCItemKCL_Selected(object sender, RoutedEventArgs e)
        {
            MachineCMBBX.Items.Clear();
            MachineCMBBX.Items.Add("");
        }

        private void ZoneCItemOther_Selected(object sender, RoutedEventArgs e)
        {
            MachineCMBBX.Items.Clear();
            MachineCMBBX.Items.Add("");
        }
        #endregion


        private void ZoneCMBBX_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            MachineCMBBX.IsEnabled = true;
            if (MachineCMBBX.SelectedIndex == -1)
            {
                ComputerLocationCMBBX.SelectedItem = null;
                BackUpDateDATE.IsEnabled = false;
                BackUpProgramNameCMBBX.IsEnabled = false;
                BackUpTypeCMBBX.IsEnabled = false;
                BackUpVersionCMBBX.IsEnabled = false;
                BackUpExplanationCMBBX.IsEnabled = false;
                ComputerModelCMBBX.IsEnabled = false;
                OperatorSystemCMBBX.IsEnabled = false;
                HardDiskInfoTXTBX.IsEnabled = false;
                OtomationIPTXTBX.IsEnabled = false;
                MachineIPTXTBX.IsEnabled = false;
                PetlasIPTXTBX.IsEnabled = false;
                ExplanationTXTBX.IsEnabled = false;
                ComputerLocationCMBBX.IsEnabled = false;
                LicanseBTN.IsEnabled = false;
            }
        }

        private void MachineCMBBX_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            ComputerLocationCMBBX.IsEnabled = true;
        }

        private void ComputerLocationCMBBX_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            BackUpDateDATE.SelectedDate = null;
            BackUpDateDATE.IsEnabled = true;
            if (BackUpDateDATE.SelectedDate == null)
            {
                BackUpProgramNameCMBBX.IsEnabled = false;
                BackUpTypeCMBBX.IsEnabled = false;
                BackUpVersionCMBBX.IsEnabled = false;
                BackUpExplanationCMBBX.IsEnabled = false;
                ComputerModelCMBBX.IsEnabled = false;
                OperatorSystemCMBBX.IsEnabled = false;
                HardDiskInfoTXTBX.IsEnabled = false;
                OtomationIPTXTBX.IsEnabled = false;
                MachineIPTXTBX.IsEnabled = false;
                PetlasIPTXTBX.IsEnabled = false;
                ExplanationTXTBX.IsEnabled = false;
            }

        }

        private void BackUpDateDATE_SelectedDateChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            IF = new Classes.InFile();
            BackUpProgramNameCMBBX.IsEnabled = true;
            BackUpTypeCMBBX.IsEnabled = true;
            BackUpVersionCMBBX.IsEnabled = true;
            BackUpExplanationCMBBX.IsEnabled = true;
            ComputerModelCMBBX.IsEnabled = true;
            OperatorSystemCMBBX.IsEnabled = true;
            HardDiskInfoTXTBX.IsEnabled = true;
            OtomationIPTXTBX.IsEnabled = true;
            MachineIPTXTBX.IsEnabled = true;
            PetlasIPTXTBX.IsEnabled = true;
            ExplanationTXTBX.IsEnabled = true;
            MIT = new Classes.MachineIsThere();
            MIT.Zone = ZoneCMBBX.SelectionBoxItem.ToString();
            MIT.Machine = MachineCMBBX.SelectionBoxItem.ToString();
            MIT.CLocation = ComputerLocationCMBBX.SelectionBoxItem.ToString();
            if (ZoneCMBBX.SelectedIndex > -1)
            {
                if (MachineCMBBX.SelectedIndex > -1)
                {
                    if (MIT.IsThere() > 0)
                    {
                        LicanseBTN.IsEnabled = false;
                        using (SqlConnection con = new SqlConnection(IF.FilePath()))
                        {
                            con.Open();
                            using (SqlCommand cmd = new SqlCommand("select * from BACKUPANDRECOVERTABLE where BOLGE='" + ZoneCMBBX.SelectionBoxItem.ToString() + "' " +
                                "and MAKINA='" + MachineCMBBX.SelectionBoxItem.ToString() + "' and [BILGISAYAR LOKASYONU]='" + ComputerLocationCMBBX.SelectionBoxItem.ToString() + "'", con))
                            {
                                SqlDataReader dR = cmd.ExecuteReader();
                                dR.Read();
                                this.LicenseID = (int)dR["LISANS ID"];
                            }
                        }
                    }
                    else
                    {
                        LicanseBTN.IsEnabled = true;
                    }
                }
            }

        }
    }
}
