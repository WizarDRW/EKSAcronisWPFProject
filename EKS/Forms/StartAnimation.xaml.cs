using System.Windows;
using System.Threading.Tasks;

namespace EKS
{
    /// <summary>
    /// Interaction logic for StartAnimation.xaml
    /// </summary>
    public partial class StartAnimation : Window
    {
        public StartAnimation()
        {
            InitializeComponent();
        }

        #region Classes Object
        private Classes.MemoryControl ClmC;
        private Forms.UserLogin FmuL;
        #endregion
        public bool VerifyEnter = false;
        public void Processes()
        {
           FmuL = new Forms.UserLogin();
           ClmC = new Classes.MemoryControl();
           ClmC.MemoryStart();
           FmuL.ShowDialog();
           VerifyEnter = FmuL.VerifyEnter;
        }
    }
}
