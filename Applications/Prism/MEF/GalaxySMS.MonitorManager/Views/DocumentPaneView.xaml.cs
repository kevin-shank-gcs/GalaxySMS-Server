using System;
using System.ComponentModel.Composition;
using System.Windows.Controls;
using GalaxySMS.TelerikWPF.Infrastructure;
using Prism.Regions;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Docking;
using PRISMIActiveAware = Prism.IActiveAware;

namespace GalaxySMS.MonitorManager.Views
{
    /// <summary>
    /// Interaction logic for NewDocument.xaml
    /// </summary>
    public partial class DocumentPaneView : RadDocumentPane, PRISMIActiveAware
    {

        public DocumentPaneView()
        {
            InitializeComponent();
        }

        public event EventHandler IsActiveChanged;

        protected override void OnIsActiveChanged()
        {
            base.OnIsActiveChanged();
            this.OnIsActiveChanged(EventArgs.Empty);
        }

        private void OnIsActiveChanged(EventArgs e)
        {
            if (this.IsActiveChanged != null)
            {
                this.IsActiveChanged(this, e);
            }
        }

    }
}