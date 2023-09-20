using System;
using System.ComponentModel.Composition;
using GalaxySMSModule_MEF_TelerikRibbonTabs_Template.Properties;
using GCS.Core.Common.UI.Core;
using Prism.Events;
using Prism.Regions;

namespace GalaxySMSModule_MEF_TelerikRibbonTabs_Template.ViewModels
{
    [Export(typeof(ViewAViewModel))]
    public class ViewAViewModel : ViewModelBase, IPartImportsSatisfiedNotification, INavigationAware
    {
        #region Private fields
        private readonly IEventAggregator _eventAggregator;
        
        #endregion

        #region Constructors
        [ImportingConstructor]
        public ViewAViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            ViewTitle = Resources.ViewA_ViewTitle;
        }

        #endregion

        #region Commands
        public DelegateCommand<object> UpdateCommand { get; set; }
        #endregion

        #region Public Properties

        #endregion

        #region IPartImportsSatisfiedNotification Implementation

        public void OnImportsSatisfied()
        {
        }

        #endregion

        #region INavigationAware Implementation

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }
        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            //throw new NotImplementedException();
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            //throw new NotImplementedException();
        }

        #endregion
    }
}