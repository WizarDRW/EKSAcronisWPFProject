﻿using System;
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

        private void OKBTNClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}