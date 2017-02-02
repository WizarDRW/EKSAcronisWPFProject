using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace EKS.Forms.MPFMenus.License
{
    /// <summary>
    /// Interaction logic for MachineLicense.xaml
    /// </summary>
    public partial class MachineLicense : Window
    {
        public MachineLicense()
        {
            InitializeComponent();
        }

        public int i = 0;
        Classes.InFile IF = new Classes.InFile();
        public int LicenseID { get; set; }
        public bool Enter { get; set; }
        private void CancelBTN_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddBTN_Click(object sender, RoutedEventArgs e)
        {
            if (FileNameTXTBX.Text != "" && FilePathTXTBX.Text != "")
            {
                using (SqlConnection con = new SqlConnection(IF.FilePath()))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(@"insert into LICENSE values('" + FileNameTXTBX.Text + "', '" + FilePathTXTBX.Text + "')",con))
                    {
                        if (cmd.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("Lisans Kaydedildi.", "Başarılı", MessageBoxButton.OK , MessageBoxImage.Information);
                            Enter = true;
                        }
                        else
                        {
                            MessageBox.Show("Lisans Kaydı Başarısız.", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    using (SqlCommand cmd = new SqlCommand("select * from LICENSE where [DOSYA ADI]='" + FileNameTXTBX.Text + "' and [DOSYA YOLU]='" + FilePathTXTBX.Text + "'", con))
                    {
                        SqlDataReader dR = cmd.ExecuteReader();
                        dR.Read();
                        LicenseID = (int)dR["LICANSE ID"];
                    }
                    con.Close();
                }
            }
            else
            {
                MessageBox.Show("Boş Bırakılamaz!", "Uyarı!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
