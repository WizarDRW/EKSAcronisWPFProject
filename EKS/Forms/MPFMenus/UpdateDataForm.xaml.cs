using System.Windows;
using System.Data.SqlClient;
using EKS.Database_Tools;
using System.Linq;
using System;

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
        EksDBEntities entity = new EksDBEntities();
        Classes.MachineIsThere MIT;
        Classes.DatabaseProcess DP = new Classes.DatabaseProcess();

        public BACKUPANDRECOVERTABLE UpdateSelectedData { get; set; }
        public EksDBEntities EntityProp { get => entity; set => entity = value; }
        public string FilePath { get; private set; }

        private void UpdateBTN_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UpdateSelectedData.BOLGE = ZoneCMBBX.SelectionBoxItem.ToString();
                UpdateSelectedData.MAKINA = MachineCMBBX.SelectionBoxItem.ToString();
                UpdateSelectedData.BILGISAYAR_LOKASYONU = ComputerLocationCMBBX.SelectionBoxItem.ToString();
                UpdateSelectedData.BACKUP_TARIHI = (DateTime)BackUpDateDATE.SelectedDate;
                UpdateSelectedData.BACKUP_NEDENI = BackUpExplanationCMBBX.SelectionBoxItem.ToString();
                UpdateSelectedData.BACKUP_TIPI = BackUpTypeCMBBX.SelectionBoxItem.ToString();
                UpdateSelectedData.BACKUP_PROGRAM_ADI = BackUpProgramNameCMBBX.SelectionBoxItem.ToString();
                UpdateSelectedData.BACKUP_VERSIYONU = BackUpVersionCMBBX.SelectionBoxItem.ToString();
                UpdateSelectedData.BILGISAYAR_MODELI = ComputerModelCMBBX.SelectionBoxItem.ToString();
                UpdateSelectedData.HARDDISK_BILGISI = HardDiskInfoTXTBX.Text;
                UpdateSelectedData.ISLETIM_SISTEMI = OperatorSystemCMBBX.SelectionBoxItem.ToString();
                UpdateSelectedData.OTOMASYON_IP = OtomationIPTXTBX.Text;
                UpdateSelectedData.MAKINA_IP = MachineIPTXTBX.Text;
                UpdateSelectedData.PETLAS_IP = PetlasIPTXTBX.Text;
                UpdateSelectedData.LISANS_DOSYASI = FilePath;
                UpdateSelectedData.ACIKLAMALAR = ExplanationTXTBX.Text;

                DP.Update(UpdateSelectedData);

                MessageBox.Show("Guncellendi", "ID = " + UpdateSelectedData.ID, MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata olustu Kod: \n\n" + ex.ToString(), "Hata!", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }

        private void CancelBTN_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ZoneCMBBX.Text = UpdateSelectedData.BOLGE;
            MachineCMBBX.Text = UpdateSelectedData.MAKINA;
            ComputerLocationCMBBX.Text = UpdateSelectedData.BILGISAYAR_LOKASYONU;
            BackUpDateDATE.Text = UpdateSelectedData.BACKUP_TARIHI.ToString(); //DataTime
            BackUpProgramNameCMBBX.Text = UpdateSelectedData.BACKUP_PROGRAM_ADI;
            BackUpTypeCMBBX.Text = UpdateSelectedData.BACKUP_TIPI.TrimEnd();
            BackUpVersionCMBBX.Text = UpdateSelectedData.BACKUP_VERSIYONU.TrimEnd();
            BackUpExplanationCMBBX.Text = UpdateSelectedData.BACKUP_NEDENI;
            ComputerModelCMBBX.Text = UpdateSelectedData.BILGISAYAR_MODELI;
            OperatorSystemCMBBX.Text = UpdateSelectedData.ISLETIM_SISTEMI;
            HardDiskInfoTXTBX.Text = UpdateSelectedData.HARDDISK_BILGISI;
            OtomationIPTXTBX.Text = UpdateSelectedData.OTOMASYON_IP;
            MachineIPTXTBX.Text = UpdateSelectedData.MAKINA_IP;
            PetlasIPTXTBX.Text = UpdateSelectedData.PETLAS_IP;
            ExplanationTXTBX.Text = UpdateSelectedData.ACIKLAMALAR;
            LabelPath.Content = UpdateSelectedData.LISANS_DOSYASI;
        }

        private void LicanseBTN_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog OFDialog = new Microsoft.Win32.OpenFileDialog();
            OFDialog.FileName = "Document";
            OFDialog.DefaultExt = ".txt";

            Nullable<bool> result = OFDialog.ShowDialog();

            if (result == true)
            {
                FilePath = OFDialog.FileNames[0].ToString();
                LabelPath.Content = FilePath;
            }
        }

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
                        LicanseBTN.IsEnabled = IsEnabled;
                        var lisansid = EntityProp.BACKUPANDRECOVERTABLE.FirstOrDefault
                            (t => t.BOLGE == ZoneCMBBX.SelectionBoxItem.ToString() &&
                            t.MAKINA == MachineCMBBX.SelectionBoxItem.ToString() &&
                            t.BILGISAYAR_LOKASYONU == ComputerLocationCMBBX.SelectionBoxItem.ToString());
                        this.FilePath = lisansid.LISANS_DOSYASI;
                    }
                }
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
    }
}
