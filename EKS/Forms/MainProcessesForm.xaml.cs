using System.Windows;

namespace EKS.Forms
{
    /// <summary>
    /// Interaction logic for MainProcessesForm.xaml
    /// </summary>
    public partial class MainProcessesForm : Window
    {
        public MainProcessesForm()
        {
            InitializeComponent();
        }

        private void MPFClosed(object sender, System.EventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
