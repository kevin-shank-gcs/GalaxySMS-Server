﻿using System.ComponentModel.Composition;
using GalaxySMS.Prism.Infrastructure;
using GalaxySMS.Site.RibbonTabs;
using GCS.Core.Common.UI.Core;
using GCS.Core.Prism;
using Prism.Regions;

namespace GalaxySMS.Site.Views
{
    /// <summary>
    /// Interaction logic for FirstView.xaml
    /// </summary>
    [Export("ViewB")]
    [DependentView(typeof(ViewBTab), RegionNames.RibbonTabRegion)]
    [DependentView(typeof(ViewC), RegionNames.LeftSidebarRegion)]
    [RegionMemberLifetime(KeepAlive = false)]
    public partial class ViewB : UserControlViewBase, ISupportDataContext
    {
        public ViewB()
        {
            InitializeComponent();
        }
    }
}
