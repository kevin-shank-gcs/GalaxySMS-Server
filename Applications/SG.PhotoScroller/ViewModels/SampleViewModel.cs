using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.UI.Interfaces;
using SG.PhotoScroller.Properties;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.UI.Core;
using SG.PhotoScroller.Views;

namespace SG.PhotoScroller.ViewModels
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class SampleViewModel : ViewModelBase
    {
        #region Private fields
        #endregion

        #region Constructor
        [ImportingConstructor]
        public SampleViewModel()
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
                return Resources.SampleView_Title;
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
            IDialogService dlgService = new DialogService();
            dlgService.ShowDialog()

           
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
