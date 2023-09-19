/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocatorTemplate xmlns:vm="clr-namespace:GalaxySMS.ClientAPI.Sample.ViewModel"
                                   x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace GalaxySMS.ClientAPI.Sample.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<AccessPortalViewModel>();
            SimpleIoc.Default.Register<InputDeviceViewModel>();
            SimpleIoc.Default.Register<InputOutputGroupViewModel>();
            SimpleIoc.Default.Register<ClusterPanelViewModel>();
            SimpleIoc.Default.Register<ActivityEventsViewModel>();
            SimpleIoc.Default.Register<AlarmEventsViewModel>();
        }

        /// <summary>
        /// Gets the Main property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public AccessPortalViewModel AccessPortals
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AccessPortalViewModel>();
            }
        }
        
        public InputDeviceViewModel InputDevices
        {
            get
            {
                return ServiceLocator.Current.GetInstance<InputDeviceViewModel>();
            }
        }
        
        public InputOutputGroupViewModel InputOutputGroups
        {
            get
            {
                return ServiceLocator.Current.GetInstance<InputOutputGroupViewModel>();
            }
        }
        public ClusterPanelViewModel Clusters
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ClusterPanelViewModel>();
            }
        }

        public ActivityEventsViewModel ActivityEvents
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ActivityEventsViewModel>();
            }
        }

        public AlarmEventsViewModel AlarmEvents
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AlarmEventsViewModel>();
            }
        }

        /// <summary>
        /// Cleans up all the resources.
        /// </summary>
        public static void Cleanup()
        {
        }
    }
}