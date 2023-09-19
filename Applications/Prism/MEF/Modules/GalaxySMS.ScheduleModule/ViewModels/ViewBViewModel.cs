using System;
using System.ComponentModel.Composition;
using GCS.Core.Common.UI.Core;
using Prism.Events;
using Prism.Regions;
using LocalResources = GalaxySMS.Schedule.Properties;

namespace GalaxySMS.Schedule.ViewModels
{
    [Export(typeof(ViewBViewModel))]
    public class ViewBViewModel : ViewModelBase, IPartImportsSatisfiedNotification, INavigationAware
    {
        #region Private fields
        private readonly IEventAggregator _eventAggregator;
        #endregion

        #region Constructors

        [ImportingConstructor]
        public ViewBViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            ViewTitle = LocalResources.Resources.ViewB_ViewTitle;
        }

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
            throw new NotImplementedException();
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}