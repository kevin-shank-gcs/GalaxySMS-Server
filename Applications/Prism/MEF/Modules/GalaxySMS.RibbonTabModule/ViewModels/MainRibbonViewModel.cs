using System;
using System.ComponentModel.Composition;
using GalaxySMS.RibbonTabModule.Properties;
using GCS.Core.Common.UI.Core;
using Prism.Events;
using Prism.Regions;

namespace GalaxySMS.RibbonTabModule.ViewModels
{
    [Export(typeof(MainRibbonViewModel))]
    public class MainRibbonViewModel : ViewModelBase, IPartImportsSatisfiedNotification, INavigationAware
    {
        #region Private fields
        private readonly IEventAggregator _eventAggregator;
        private string _viewTitle = Resources.MainRibbonView_ViewTitle;
        #endregion

        #region Constructors
        //public FirstViewModel()
        //{

        //}

        [ImportingConstructor]
        public MainRibbonViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }

        #endregion

        #region Public Properties

        public string ViewTitle
        {
            get { return _viewTitle; }
            set
            {
                if (_viewTitle != value)
                {
                    _viewTitle = value;
                    OnPropertyChanged(() => ViewTitle, false);
                }
            }
        }

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