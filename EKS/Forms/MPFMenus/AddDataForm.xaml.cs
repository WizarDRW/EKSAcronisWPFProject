using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
