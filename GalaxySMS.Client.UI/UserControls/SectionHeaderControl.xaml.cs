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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GalaxySMS.Client.UI
{
    /// <summary>
    /// Interaction logic for SectionHeaderControl.xaml
    /// </summary>
    public partial class SectionHeaderControl : UserControl
    {
        public SectionHeaderControl()
        {
            InitializeComponent();
        }

        #region HeaderText
        public static readonly DependencyProperty HeaderTextProperty =
            DependencyProperty.Register(
                "HeaderText",
                typeof(string),
                typeof(UserControl),
                new UIPropertyMetadata(null));
        public string HeaderText
        {
            get { return (string)GetValue(HeaderTextProperty); }
            set { SetValue(HeaderTextProperty, value); }
        }
        #endregion
    }
}
