using System.Collections.Generic;
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
        

        private void CancelBTN_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddBTN_Click(object sender, RoutedEventArgs e)
        {
            if (FileNameTXTBX.Text != "" && FilePathTXTBX.Text != "")
            {

            }
            else
            {
                MessageBox.Show("Boş Bırakılamaz!", "Uyarı!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
