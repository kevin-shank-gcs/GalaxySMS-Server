﻿using GCS.Core.Prism;
using Telerik.Windows.Controls;

namespace GalaxySMS.Site.RibbonTabs
{
    /// <summary>
    ///     Interaction logic for ViewBTab.xaml
    /// </summary>
    public partial class ViewBTab : RadRibbonTab, ISupportDataContext
    {
        public ViewBTab()
        {
            InitializeComponent();
            SetResourceReference(StyleProperty, typeof(RadRibbonTab));
        }
    }
}