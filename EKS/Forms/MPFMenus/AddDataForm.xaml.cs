using System;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;
using EKS.Database_Tools;

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
        EksDBEntities Entity = new EksDBEntities();
        public string UserName { get; set; }
        public string FilePath { get; set; }
        public EksDBEntities EntityProp { get => Entity; set => Entity = value; }

        private void AddBTN_Click(object sender, RoutedEventArgs e)
        {
            if (ZoneCMBBX.SelectionBoxItem.ToString() != "" && MachineCMBBX.SelectionBoxItem.ToString() != "" && ComputerLocationCMBBX.SelectionBoxItem.ToString() != "" &&
                BackUpDateDATE.SelectedDate.ToString() != "" && BackUpProgramNameCMBBX.SelectionBoxItem.ToString() != "" &&
                BackUpTypeCMBBX.SelectionBoxItem.ToString() != "" && BackUpVersionCMBBX.SelectionBoxItem.ToString() != "" &&
                BackUpExplanationCMBBX.SelectionBoxItem.ToString() != "" && ComputerModelCMBBX.SelectionBoxItem.ToString() != "" && OperatorSystemCMBBX.SelectionBoxItem.ToString() != "" &&
                HardDiskInfoTXTBX.Text != "" && OtomationIPTXTBX.Text != "" && MachineIPTXTBX.Text != "")
            {
                DP = new Classes.DatabaseProcess();
                string D = BackUpDateDATE.SelectedDate.ToString().Replace(".", "");
                string DateDeletePoint = D.Substring(0, D.Length - 9);
                if (DateDeletePoint.Length == 7)
                {
                    DateDeletePoint = "0" + DateDeletePoint;
                }
                if (BackUpAddInfo.Text == "" || BackUpAddInfo.Text == " " || BackUpAddInfo.Text == "  ")
                {
                    BackUpAddInfo.Text = null;
                    DP.BackUpAddInfo = this.BackUpAddInfo.Text; 
                    DP.BackUpName = MachineCMBBX.SelectionBoxItem.ToString().Replace(" ", "_") + '_' + ComputerLocationCMBBX.SelectionBoxItem.ToString().Replace(" ", "_") + '_' + DateDeletePoint + '_';
                }
                else
                {
                    DP.BackUpName = MachineCMBBX.SelectionBoxItem.ToString().Replace(" ", "_") + '_' + ComputerLocationCMBBX.SelectionBoxItem.ToString().Replace(" ", "_") + '_' + BackUpAddInfo.Text.Replace(" ", "_") + '_' + DateDeletePoint + '_';
                }
                #region Property Values
                DP.Zone = ZoneCMBBX.SelectionBoxItem.ToString();
                DP.Machine = MachineCMBBX.SelectionBoxItem.ToString();
                DP.ComputerLocation = ComputerLocationCMBBX.SelectionBoxItem.ToString();
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
                    DP.LicenseAddPath = FilePath;
                }
                else if (LicanseBTN.IsEnabled == false)
                {
                    DP.LicenseAddPath = this.FilePath;
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
        int i = 0;
        private void LicanseBTN_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog OFDialog = new Microsoft.Win32.OpenFileDialog();
            OFDialog.FileName = "Document";
            OFDialog.DefaultExt = ".txt";
            //OFDialog.Filter = "Text Document (.txt)|*.txt|MS Office Word (.doc)|*.doc|MS Office Word (.xlsx)|*.xlsx";

            Nullable<bool> result = OFDialog.ShowDialog();

            if (result == true)
            {
                FilePath = OFDialog.FileNames[0].ToString();
                LabelPath.Content = FilePath;
            }
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
            MachineCMBBX.Items.Add("CONTI APEX");
            MachineCMBBX.Items.Add("CIN APEX 1");
            MachineCMBBX.Items.Add("CIN APEX 2");
            MachineCMBBX.Items.Add("VMI APEX 1");
            MachineCMBBX.Items.Add("VMI APEX 2");
            MachineCMBBX.Items.Add("VMI APEX 3");
            MachineCMBBX.Items.Add("VMI APEX 4");
        }

        private void ZoneCItemCapraz_Selected(object sender, RoutedEventArgs e)
        {
            MachineCMBBX.Items.Clear();
            MachineCMBBX.Items.Add("PLY CUTTER");
            MachineCMBBX.Items.Add("FISCHER (CA102246)");
            MachineCMBBX.Items.Add("FISCHER (CA102248)");
            MachineCMBBX.Items.Add("FISCHER (CA104167)");
            MachineCMBBX.Items.Add("VMI KAT KESİM 1");
            MachineCMBBX.Items.Add("VMI KAT KESİM 2");
        }

        private void ZoneCItemLI_Selected(object sender, RoutedEventArgs e)
        {
            MachineCMBBX.Items.Clear();
            MachineCMBBX.Items.Add("H7");
            MachineCMBBX.Items.Add("H8");
            MachineCMBBX.Items.Add("H9");
            MachineCMBBX.Items.Add("H10");
            MachineCMBBX.Items.Add("N1");
        }

        private void ZoneCItemP_Selected(object sender, RoutedEventArgs e)
        {
            MachineCMBBX.Items.Clear();
            MachineCMBBX.Items.Add("TR SCADA");
            MachineCMBBX.Items.Add("TBR SCADA");
            MachineCMBBX.Items.Add("LTM SCADA");
            MachineCMBBX.Items.Add("OKJ SCADA");
            MachineCMBBX.Items.Add("HF SCADA");
            MachineCMBBX.Items.Add("PRES YZ SCADA");
        }

        private void ZoneCItemBM_Selected(object sender, RoutedEventArgs e)
        {
            MachineCMBBX.Items.Clear();
            MachineCMBBX.Items.Add("BOYA 2");
            MachineCMBBX.Items.Add("BOYA 6");
            MachineCMBBX.Items.Add("BOYA 7");
            MachineCMBBX.Items.Add("BOYA 8");
            MachineCMBBX.Items.Add("BOYA 9");
            MachineCMBBX.Items.Add("BOYA 10");
            MachineCMBBX.Items.Add("BOYA 11");
        }

        private void ZoneCItemPS_Selected(object sender, RoutedEventArgs e)
        {
            MachineCMBBX.Items.Clear();
            MachineCMBBX.Items.Add("PC 1 (ANA)");
            MachineCMBBX.Items.Add("PC 2 (YEDEK)");
            MachineCMBBX.Items.Add("EMİSYON");
        }

        private void ZoneCItemSEC11_Selected(object sender, RoutedEventArgs e)
        {
            MachineCMBBX.Items.Clear();
            MachineCMBBX.Items.Add("PC 1 (ANA)");
            MachineCMBBX.Items.Add("PC 2 (YEDEK)");
            MachineCMBBX.Items.Add("KLİMALAR");
        }

        private void ZoneCItemTestCenter_Selected(object sender, RoutedEventArgs e)
        {
            MachineCMBBX.Items.Clear();
            MachineCMBBX.Items.Add("ASM 9600 (1-2)");
            MachineCMBBX.Items.Add("ASM 9600 (3-4)");
            MachineCMBBX.Items.Add("U-CAN");
            MachineCMBBX.Items.Add("RR PC");
            MachineCMBBX.Items.Add("TBR ENDURANCE(4 POZİSYONLU)");
            MachineCMBBX.Items.Add("7-1");
            MachineCMBBX.Items.Add("7-2");
            MachineCMBBX.Items.Add("BYTEWISE RUNOUT PC");
            MachineCMBBX.Items.Add("KESİT ANALİZ PC");
        }

        private void ZoneCItemLastControl_Selected(object sender, RoutedEventArgs e)
        {
            MachineCMBBX.Items.Clear();
            MachineCMBBX.Items.Add("UF-UNIFORMITY 1");
            MachineCMBBX.Items.Add("UF-UNIFORMITY 2");
            MachineCMBBX.Items.Add("UF-UNIFORMITY 3");
            MachineCMBBX.Items.Add("UF-UNIFORMITY 4");
            MachineCMBBX.Items.Add("UF-UNIFORMITY 5");
            MachineCMBBX.Items.Add("UF-UNIFORMITY 6");
            MachineCMBBX.Items.Add("UF-UNIFORMITY 7");
            MachineCMBBX.Items.Add("UF-UNIFORMITY 8");
            MachineCMBBX.Items.Add("UF-UNIFORMITY 9");
            MachineCMBBX.Items.Add("UF-UNIFORMITY 10");
            MachineCMBBX.Items.Add("UF-UNIFORMITY 11");
            MachineCMBBX.Items.Add("UF-UNIFORMITY 12");
            MachineCMBBX.Items.Add("UF-UNIFORMITY 13");
            MachineCMBBX.Items.Add("UF-UNIFORMITY 14");
            MachineCMBBX.Items.Add("INTACT 1600 1");
            MachineCMBBX.Items.Add("INTACT 1600 2");
            MachineCMBBX.Items.Add("INTACT 1600 3");
            MachineCMBBX.Items.Add("INTACT 2800");
            MachineCMBBX.Items.Add("TBR XRAY 1");
            MachineCMBBX.Items.Add("TBR XRAY 2");
            MachineCMBBX.Items.Add("HOFFMAN");
        }

        private void ZoneCItemRBM_Selected(object sender, RoutedEventArgs e)
        {
            MachineCMBBX.Items.Clear();
            for (int i = 0; i < 30; i++)
            {
                MachineCMBBX.Items.Add("RB " + (i + 1));
            }
        }

        private void ZoneCItemTBRRBM_Selected(object sender, RoutedEventArgs e)
        {
            MachineCMBBX.Items.Clear();
            for (int i = 1; i <= 5; i++)
            {
                MachineCMBBX.Items.Add("TBR RB " + (i));
            }
        }

        private void ZoneCItemKCL_Selected(object sender, RoutedEventArgs e)
        {
            MachineCMBBX.Items.Clear();
            MachineCMBBX.Items.Add("INSTRON 1");
            MachineCMBBX.Items.Add("INSTRON 2");
            MachineCMBBX.Items.Add("OTOMDR");
            MachineCMBBX.Items.Add("MDR 2000");
            MachineCMBBX.Items.Add("MV 2000");
            MachineCMBBX.Items.Add("LAB SERVER");
        }

        private void ZoneCItemOther_Selected(object sender, RoutedEventArgs e)
        {
            MachineCMBBX.Items.Clear();
            MachineCMBBX.Items.Add("YANGIN ÜNİTESİ");
            MachineCMBBX.Items.Add("602 ÜNİTESİ");
            MachineCMBBX.Items.Add("UÇAK ÜNİTESİ");
            MachineCMBBX.Items.Add("503 SU HAZIRLAMA ÜNİTESİ");
            MachineCMBBX.Items.Add("501 KOMPRESÖR");
            MachineCMBBX.Items.Add("401 POMPA İSTASYONU");
            MachineCMBBX.Items.Add("DİĞER");
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
                        var lisansid = EntityProp.BACKUPANDRECOVERTABLE.FirstOrDefault
                            (t => t.BOLGE == ZoneCMBBX.SelectionBoxItem.ToString() && 
                            t.MAKINA == MachineCMBBX.SelectionBoxItem.ToString() && 
                            t.BILGISAYAR_LOKASYONU == ComputerLocationCMBBX.SelectionBoxItem.ToString());
                        this.FilePath = lisansid.LISANS_DOSYASI;
                    }
                    else
                    {
                        LicanseBTN.IsEnabled = true;
                    }
                }
            }

        }


        #region CheckBoxChecked

        private void HarddiscCH_Checked(object sender, RoutedEventArgs e)
        {
            BackUpFilesPath.IsEnabled = true;
            OtomationCH.IsChecked = false;
            PetlasCH.IsChecked = false;
        }

        private void OtomationCH_Checked(object sender, RoutedEventArgs e)
        {
            BackUpFilesPath.IsEnabled = true;
            HarddiscCH.IsChecked = false;
            PetlasCH.IsChecked = false;
        }

        private void PetlasCH_Checked(object sender, RoutedEventArgs e)
        {
            BackUpFilesPath.IsEnabled = true;
            HarddiscCH.IsChecked = false;
            OtomationCH.IsChecked = false;
        }

        private void HarddiscCH_Unchecked(object sender, RoutedEventArgs e)
        {
            if (HarddiscCH.IsChecked == false && OtomationCH.IsChecked == false && PetlasCH.IsChecked == false)
            {
                BackUpFilesPath.IsEnabled = false;
            }
        }

        private void OtomationCH_Unchecked(object sender, RoutedEventArgs e)
        {
            if (HarddiscCH.IsChecked == false && OtomationCH.IsChecked == false && PetlasCH.IsChecked == false)
            {
                BackUpFilesPath.IsEnabled = false;
            }
        }

        private void PetlasCH_Unchecked(object sender, RoutedEventArgs e)
        {
            if (HarddiscCH.IsChecked == false && OtomationCH.IsChecked == false && PetlasCH.IsChecked == false)
            {
                BackUpFilesPath.IsEnabled = false;
            }
        }
        #endregion


    }
}
