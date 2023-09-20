using System.ComponentModel.Composition;
using GalaxySMS.SiteManager.Properties;
using GCS.Core.Common.UI.Core;

namespace GalaxySMS.SiteManager.ViewModels
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class MainWindowViewModel : ViewModelBase
    {
        #region Private fields
        #endregion

        #region Constructor
        [ImportingConstructor]
        public MainWindowViewModel()
        {
            CommandA = new DelegateCommand<object>(ExecuteCommandA, CanExecuteCommandA);
        }
        #endregion

        #region Commands
        public DelegateCommand<object> CommandA { get; private set; }

        #endregion

        #region Public Properties
        public override string ViewTitle
        {
            get
            {
                return string.Format(Resources.MainView_ApplicationTitleFormat, Resources.MainView_ApplicationTitle, Globals.MyAssemblyAtrributes.Version);
            }
        }

        public Globals Globals
        {
            get
            {
                return Globals.Instance;
            }
        }

        #endregion

        #region Private Methods
        private bool CanExecuteCommandA(object obj)
        {   // perform logic to indicate if the command can be executed
            return true;
        }

        private void ExecuteCommandA(object obj)
        {
        }

        #endregion

        #region Protected methods
        protected override void OnViewLoaded()
        {
            ClearCustomErrors();
        }

        #endregion
    }
}
