using System.Windows;
using System.Threading.Tasks;
using System;
using System.Linq;

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
        public bool VerifyAdminEnter = false;
        public bool VerifyUserEnter = false;
        public void Processes()
        {
            FmuL = new Forms.UserLogin();
            ClmC = new Classes.MemoryControl();
            ClmC.MemoryStart();
            FmuL.Owner = Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);//Task Bar da diger formlarin gozukmemesi icin
            FmuL.ShowDialog();
            VerifyAdminEnter = FmuL.VerifyAdminEnter;
            VerifyUserEnter = FmuL.VerifyUserEnter;
        }
    }
}
