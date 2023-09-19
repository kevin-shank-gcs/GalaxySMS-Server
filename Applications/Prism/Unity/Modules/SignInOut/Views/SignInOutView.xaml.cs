using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using GalaxySMS.Client.Entities;
using GalaxySMS.SignInOut.ViewModels;
using GCS.Core.Common.UI.Core;
using GCS.Core.Prism;
using GCS.Framework.Security;

namespace GalaxySMS.SignInOut.Views
{
    /// <summary>
    /// Interaction logic for SignInOutView
    /// </summary>
    public partial class SignInOutView : UserControlViewBase, ISupportDataContext
    {
        public SignInOutView()
        {
            InitializeComponent();
        }
    }
}