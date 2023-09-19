using GalaSoft.MvvmLight.CommandWpf;
using GalaxySMS.Client.SDK.Managers;
using System;
using System.Diagnostics;
using GCS.Core.Common.Logger;
using System.Linq;
using GCS.Core.Common.UI.Core;
using GalaSoft.MvvmLight.Messaging;
using GalaxySMS.Client.Entities;
using System.Reflection;
using System.Collections.ObjectModel;
using GCS.Core.Common.Extensions;
using GalaxySMS.Common.Enums;
using System.Threading.Tasks;

namespace GalaxySMS.ClientAPI.Sample.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class ClusterPanelViewModel : ViewModelBase
    {
        #region Private fields
        private RelayCommand _refreshClustersForSiteCommand;
        private RelayCommand _refreshClustersForEntityCommand;
        private ObservableCollection<Cluster> _clusters;
        private ObservableCollection<ClusterCommand> _clusterPanelCommands;

        private RelayCommand<Cluster> _clusterCommand;

        #endregion

        #region Public Properties
        public Globals Globals { get { return Globals.Instance; } }

        public ObservableCollection<Cluster> Clusters
        {
            get { return _clusters; }
            set
            {
                if (_clusters != value)
                {
                    _clusters = value;
                    OnPropertyChanged(() => Clusters, false);
                }
            }
        }

        #endregion

        #region Commands
        public RelayCommand RefreshClustersForSiteCommand
        {
            get
            {
                return _refreshClustersForSiteCommand
                    ?? (_refreshClustersForSiteCommand = new RelayCommand(
                    async () =>
                    {
                        try
                        {
                            Globals.IsBusy = true;
                            Globals.BusyContent = "Please wait while the server retrieves the requested data...";

                            // Use the Globals.GetManager<T> helper method to get a usable ClusterManager object
                            var mgr = Globals.GetManager<ClusterManager>();
                            // Call the GetAccessPortalsForSiteAsync method and save the result.
                            var getParams = new GetParametersWithPhoto()
                            {
                                UniqueId = Globals.CurrentSite.SiteUid,
                                IncludePhoto = false,
                                IncludeMemberCollections = true,
                            };
                            getParams.ExcludeMemberCollectionSettings.Add(nameof(Cluster.AccessGroups));
                            getParams.ExcludeMemberCollectionSettings.Add(nameof(Cluster.Areas));
                            getParams.ExcludeMemberCollectionSettings.Add(nameof(Cluster.ClusterEntityMaps));
                            getParams.ExcludeMemberCollectionSettings.Add(nameof(Cluster.ClusterInputOutputGroups));
                            //getParams.ExcludeMemberCollectionSettings.Add(nameof(Cluster.DayTypes));
                            getParams.ExcludeMemberCollectionSettings.Add(nameof(Cluster.EntityIds));
                            getParams.ExcludeMemberCollectionSettings.Add(nameof(Cluster.InputOutputGroups));
                            getParams.ExcludeMemberCollectionSettings.Add(nameof(Cluster.MappedEntitiesPermissionLevels));
                            getParams.ExcludeMemberCollectionSettings.Add(nameof(Cluster.RoleIds));
                            getParams.ExcludeMemberCollectionSettings.Add(nameof(Cluster.ClusterFlashingCommands));
                            var clusters = await mgr.GetClustersForSiteAsync(getParams);

                            if (mgr.HasErrors == false)
                            {
                                if (clusters != null)
                                    Clusters = clusters.ToObservableCollection();
                            }
                            else
                                base.AddCustomErrors(mgr.Errors, true);

                        }
                        catch (Exception e)
                        {
                            this.Log().ErrorFormat($"{MethodBase.GetCurrentMethod().DeclaringType?.FullName}=>{MethodBase.GetCurrentMethod().Name} exception", e);
                        }
                        Globals.IsBusy = false;

                    }));
            }
        }

        public RelayCommand RefreshClustersForEntityCommand
        {
            get
            {
                return _refreshClustersForEntityCommand
                    ?? (_refreshClustersForEntityCommand = new RelayCommand(
                    async () =>
                    {
                        try
                        {
                            Globals.IsBusy = true;
                            Globals.BusyContent = "Please wait while the server retrieves the requested data...";

                            // Use the Globals.GetManager<T> helper method to get a usable ClusterManager object
                            var mgr = Globals.GetManager<ClusterManager>();
                            // Call the GetAccessPortalsForSiteAsync method and save the result.
                            var getParams = new GetParametersWithPhoto()
                            {
                                UniqueId = Globals.CurrentUserEntity.EntityId,
                                IncludePhoto = false,
                                IncludeMemberCollections = true,
                            };
                            getParams.ExcludeMemberCollectionSettings.Add(nameof(Cluster.AccessGroups));
                            getParams.ExcludeMemberCollectionSettings.Add(nameof(Cluster.Areas));
                            getParams.ExcludeMemberCollectionSettings.Add(nameof(Cluster.ClusterEntityMaps));
                            getParams.ExcludeMemberCollectionSettings.Add(nameof(Cluster.ClusterInputOutputGroups));
                            //getParams.ExcludeMemberCollectionSettings.Add(nameof(Cluster.DayTypes));
                            getParams.ExcludeMemberCollectionSettings.Add(nameof(Cluster.EntityIds));
                            getParams.ExcludeMemberCollectionSettings.Add(nameof(Cluster.InputOutputGroups));
                            getParams.ExcludeMemberCollectionSettings.Add(nameof(Cluster.MappedEntitiesPermissionLevels));
                            getParams.ExcludeMemberCollectionSettings.Add(nameof(Cluster.RoleIds));
                            getParams.ExcludeMemberCollectionSettings.Add(nameof(Cluster.ClusterFlashingCommands));

                            var clusters = await mgr.GetAllClustersForEntityAsync(getParams);

                            if (mgr.HasErrors == false)
                            {
                                if (clusters != null)
                                    Clusters = clusters.ToObservableCollection();
                            }
                            else
                                base.AddCustomErrors(mgr.Errors, true);

                        }
                        catch (Exception e)
                        {
                            this.Log().ErrorFormat($"{MethodBase.GetCurrentMethod().DeclaringType?.FullName}=>{MethodBase.GetCurrentMethod().Name} exception", e);
                        }
                        Globals.IsBusy = false;

                    }));
            }
        }


        public RelayCommand<Cluster> ClusterCommand
        {
            get { return _clusterCommand; }
            set
            {
                if (_clusterCommand != value)
                {
                    _clusterCommand = value;
                    OnPropertyChanged(() => ClusterCommand, false);
                }
            }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public ClusterPanelViewModel()
        {
            Globals.Messenger.Register<NotificationMessage<UserEntity>>(this, OnUserEntityChanged);
            Globals.Messenger.Register<NotificationMessage<Site>>(this, OnSiteChanged);
            Globals.Messenger.Register<NotificationMessage<PanelInqueryReply>>(this, OnPanelInqueryReply);
            Globals.Messenger.Register<NotificationMessage<CredentialCountReply>>(this, OnCredentialCountReply);
            Globals.Messenger.Register<NotificationMessage<LoggingStatusReply>>(this, OnLoggingStatusReply);
            Globals.Messenger.Register<NotificationMessage<FlashProgressMessage>>(this, OnFlashProgressMessage);
            

            ClusterCommand = new RelayCommand<Cluster>(OnClusterCommand, CanClusterCommand);
        }



        private async void OnClusterCommand(Cluster c)
        {
            await ExecuteClusterCommand(c);
        }

        bool CanClusterCommand(Cluster arg)
        {
            if( arg?.SelectedClusterCommand == null)
                return false;
            return Globals.UserSessionToken.HasPermission(GalaxySMS.Common.Constants.PermissionIds.GalaxySMSAccessPortalCommandPermission.UnlockMomentarily);
        }

        private void OnUserEntityChanged(NotificationMessage<UserEntity> obj)
        {
            Trace.WriteLine($"{MethodBase.GetCurrentMethod().DeclaringType?.FullName}=>{MethodBase.GetCurrentMethod().Name}({obj?.Content?.EntityName})");
        }

        private void OnSiteChanged(NotificationMessage<Site> obj)
        {
            Trace.WriteLine($"{MethodBase.GetCurrentMethod().DeclaringType?.FullName}=>{MethodBase.GetCurrentMethod().Name}({obj?.Content?.SiteName})");
        }

        private void OnPanelInqueryReply(NotificationMessage<PanelInqueryReply> obj)
        {
            if( Clusters == null)
                return;

            var c = Clusters.FirstOrDefault(o => o.ClusterUid == obj.Content.ClusterUid);
            if (c != null)
            {
                var p = c.GalaxyPanels.FirstOrDefault(o => o.GalaxyPanelUid == obj.Content.PanelUid);
                if (p != null)
                {
                    p.PanelInqueryReply = obj.Content;
                    p.PanelInqueryReply.CreatedDateTime = obj.Content.CreatedDateTime;
                }
            }

            Trace.WriteLine($"{MethodBase.GetCurrentMethod().DeclaringType?.FullName}=>{MethodBase.GetCurrentMethod().Name}=>({obj?.Content.CrisisModeActive})");
        }


        private void OnLoggingStatusReply(NotificationMessage<LoggingStatusReply> obj)
        {
            if( Clusters == null)
                return;

            var c = Clusters.FirstOrDefault(o => o.ClusterUid == obj.Content.ClusterUid);
            if (c != null)
            {
                var p = c.GalaxyPanels.FirstOrDefault(o => o.GalaxyPanelUid == obj.Content.PanelUid);
                if (p != null)
                {
                    p.LoggingStatusReply = obj.Content;
                    p.LoggingStatusReply.CreatedDateTime = obj.Content.CreatedDateTime;
                }
            }

            Trace.WriteLine($"{MethodBase.GetCurrentMethod().DeclaringType?.FullName}=>{MethodBase.GetCurrentMethod().Name}=>({obj?.Content.EnabledState})");
        }

        private void OnCredentialCountReply(NotificationMessage<CredentialCountReply> obj)
        {
            if( Clusters == null)
                return;

            var c = Clusters.FirstOrDefault(o => o.ClusterUid == obj.Content.ClusterUid);
            if (c != null)
            {
                var p = c.GalaxyPanels.FirstOrDefault(o => o.GalaxyPanelUid == obj.Content.PanelUid);
                if (p != null)
                {
                    p.CredentialCountReply = obj.Content;
                    p.CredentialCountReply.CreatedDateTime = obj.Content.CreatedDateTime;
                }
            }

            Trace.WriteLine($"{MethodBase.GetCurrentMethod().DeclaringType?.FullName}=>{MethodBase.GetCurrentMethod().Name}=>({obj?.Content.Value})");
        }

        private void OnFlashProgressMessage(NotificationMessage<FlashProgressMessage> obj)
        {
            Trace.WriteLine($"OnFlashProgressMessage {obj.Content.ProgressMessage}, {obj.Content.UniqueCpuId}");
        }

        private async Task ExecuteClusterCommand(Cluster c)
        {
            Globals.BusyContent = $"Please wait. Sending {c.SelectedClusterCommand?.Display} to {c.ClusterName}";
            Globals.IsBusy = true;
            var mgr = Globals.GetManager<ClusterManager>();

            var parameters = new CommandParameters<GalaxyCpuCommandAction>()
            {
                Data = new GalaxyCpuCommandAction()
                {
                    CommandAction = (GalaxyCpuCommandActionCode)c.SelectedClusterCommand.CommandCode,
                    ClusterUid = c.ClusterUid
                },
                SessionId = Globals.UserSessionToken.SessionId,
                CurrentEntityId = Globals.UserSessionToken.CurrentEntityId,
            };

            CommandResponse<GalaxyCpuCommandAction> bResult = await mgr.ExecuteClusterCommandAsync(parameters);

            if (bResult != null && mgr.HasErrors == false)
            {

            }
            else if (mgr.HasErrors)
            {
                AddCustomErrors(mgr.Errors, true);
            }
            Globals.IsBusy = false;

        }
    }
}