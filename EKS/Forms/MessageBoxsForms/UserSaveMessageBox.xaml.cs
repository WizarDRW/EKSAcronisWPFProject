using System.Windows;


namespace EKS.Forms.MessageBoxsForms
{
    /// <summary>
    /// Interaction logic for UserSaveMessageBox.xaml
    /// </summary>
    public partial class UserSaveMessageBox : Window
    {
        public UserSaveMessageBox()
        {
            InitializeComponent();
        }

        public bool HasSave { get; set; }

        private void OKBTNClick(object sender, RoutedEventArgs e)
        {
            this.Close();
            HasSave = true;
        }
    }
}
