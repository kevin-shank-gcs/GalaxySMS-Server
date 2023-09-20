using System;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using GalaxySMS.Client.Entities;
using GalaxySMS.Common.Shared.Constants;
using GCS.Core.Common.UI.Core;
using GCS.Core.Prism;
using GCS.Framework.Security;
using Prism.Regions;

namespace GalaxySMS.UserAuthentication.Views
{
    [Export(PrismModuleViewNames.SignInOutView)]
    /// <summary>
    /// Interaction logic for SignInOutView
    /// </summary>
    public partial class SignInOutView : UserControlViewBase, ISupportDataContext, INavigationAware
    {

        [ImportingConstructor]
        public SignInOutView()
        {
            InitializeComponent();
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }
 

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
        }
    }
}
