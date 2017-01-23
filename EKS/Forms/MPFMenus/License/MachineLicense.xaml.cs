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

        private void LicenseAddBTN_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CancelBTN_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
