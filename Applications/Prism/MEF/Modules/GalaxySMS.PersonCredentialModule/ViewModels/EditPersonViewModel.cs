using GalaxySMS.Client.Contracts.ViewModelContracts;
using GalaxySMS.Client.Entities;
using GalaxySMS.Client.SDK.Managers;
using GalaxySMS.Common.Constants;
using GalaxySMS.Common.Enums;
using GalaxySMS.PersonCredential.UserControls;
using GalaxySMS.Prism.Infrastructure;
using GCS.Core.Common;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;
using GCS.Core.Common.Logger;
using GCS.Core.Common.UI.Core;
using GCS.Core.Common.UI.Interfaces;
using GCS.Framework.CredentialProcessor;
using GCS.Framework.Imaging;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Telerik.Windows.Controls;
using AccessPortalDeferToServerBehavior = GalaxySMS.Common.Enums.AccessPortalDeferToServerBehavior;
using AccessPortalNoServerReplyBehavior = GalaxySMS.Common.Enums.AccessPortalNoServerReplyBehavior;
using CommonResources = GalaxySMS.Resources;
using Entities = GalaxySMS.Client.Entities;
using ViewModelBase = GCS.Core.Common.UI.Core.ViewModelBase;

namespace GalaxySMS.PersonCredential.ViewModels
{
    [Export(typeof(EditPersonViewModel))]
    public class EditPersonViewModel : ViewModelBase, ISupportsUserEntitySelection
    {

        #region Private Fields
        private readonly IEventAggregator _eventAggregator;
        private readonly IClientServices _clientServices;
        private Entities.Person _Person;
        private bool _isBasicInfoExpanded = true;
        private ICollection<UserEntitySelect> _userEntitiesSelectionList;
        private Entities.PersonCredential _deleteThisPersonCredential;
        private Entities.PersonClusterPermission _deleteThisPersonClusterPermission;
        private gcsEntity _theEntity;
        private ObservableCollection<Printer> _printers;
        private ObservableCollection<PrintDispatcher> _printDispatchers;
        private BadgePreviewData _badgePreviewData;

        private bool _IsAddNewCredentialControlVisible;
        private bool _isDeleteCredentialControlVisible;
        private bool _IsAddNewPersonClusterPermissionControlVisible;
        private bool _IsPrintPreviewBadgeControlVisible;

        #endregion

        #region Constructors
        [ImportingConstructor]
        public EditPersonViewModel(IEventAggregator eventAggregator, IClientServices clientServices, Entities.Person entity, Guid instanceId, PersonEditingData personEditingData, UserInterfacePageControlData uiPageControlData)
        {
            if (instanceId == Guid.Empty)
                InstanceId = Guid.NewGuid();
            else
                InstanceId = instanceId;

            _eventAggregator = eventAggregator;
            _clientServices = clientServices;

            PersonEditingData = personEditingData;
            UserInterfacePageControlData = uiPageControlData;

            Person.PersonPropertyRules = UserInterfacePageControlData.ControlProperties;
            BuildRequiredProperties();

            foreach (var pcp in entity.PersonClusterPermissions)
            {
                var c = PersonEditingData.AccessAndAlarmControlPermissionsEditingData.GetClusterSelectionItem(pcp.ClusterUid);
                var s = PersonEditingData.AccessAndAlarmControlPermissionsEditingData.GetSiteSelectionItem(c.SiteUid);
                RegionSelectionItemBasic r = null;
                if (s != null)
                    r = PersonEditingData.AccessAndAlarmControlPermissionsEditingData.GetRegionSelectionItem(s.RegionUid);
                pcp.Initialize(c, s, r);
            }

            Task.Run(async () =>
            {
                _theEntity = await _clientServices.GetEntity(entity.EntityId);
            }).Wait();

            _Person = new Entities.Person(entity);
            _Person.CleanAll();

            SaveCommand = new DelegateCommand<object>(OnSaveCommandExecute, OnSaveCommandCanExecute);
            CancelCommand = new DelegateCommand<object>(OnCancelCommandExecute);
            SelectImageCommand = new DelegateCommand<object>(OnSelectImageCommandExecute);
            EntityMapChecked = new DelegateCommand<UserEntitySelect>(OnEntityMapChecked);
            AddNewCredentialCommand = new DelegateCommand<object>(OnAddNewCredentialCommandExecute, OnAddNewCredentialCommandCanExecute);
            SearchForCredentialByValuesCommand = new DelegateCommand<Credential>(OnSearchForCredentialByValuesCommandExecute, OnSearchForCredentialByValuesCommandCanExecute);
            DeletePersonCredentialCommand = new DelegateCommand<Entities.PersonCredential>(OnDeletePersonCredentialCommandExecute, OnDeletePersonCredentialCommandCanExecute);
            SelectPersonCredentialCommand = new DelegateCommand<Entities.PersonCredential>(OnSelectPersonCredentialCommandExecute, OnSelectPersonCredentialCommandCanExecute);
            AddNewPersonClusterPermissionCommand = new DelegateCommand<ClusterSelectionItemBasic>(OnAddNewPersonClusterPermissionCommandExecute, OnAddNewPersonClusterPermissionCommandCanExecute);
            DeletePersonClusterPermissionCommand = new DelegateCommand<Entities.PersonClusterPermission>(OnDeletePersonClusterPermissionCommandExecute, OnDeletePersonClusterPermissionCommandCanExecute);

            PersonalAccessPortalToAuthorizedCommand = new DelegateCommand<ObservableCollection<object>>(OnPersonalAccessPortalToAuthorizedCommandExecute, OnPersonalAccessPortalToAuthorizedCommandCanExecute);
            PersonalAccessPortalToNotAuthorizedCommand = new DelegateCommand<ObservableCollection<object>>(OnPersonalAccessPortalToNotAuthorizedCommandExecute, OnPersonalAccessPortalToNotAuthorizedCommandCanExecute);
            PersonalDynamicAccessGroupToAuthorizedCommand = new DelegateCommand<ObservableCollection<object>>(OnPersonalDynamicAccessGroupToAuthorizedCommandExecute, OnPersonalDynamicAccessGroupToAuthorizedCommandCanExecute);
            PersonalDynamicAccessGroupToNotAuthorizedCommand = new DelegateCommand<ObservableCollection<object>>(OnPersonalDynamicAccessGroupToNotAuthorizedCommandExecute, OnPersonalDynamicAccessGroupToNotAuthorizedCommandCanExecute);

            AccessProfileSelectionChanged = new DelegateCommand<AccessProfile>(OnAccessProfileSelectionChangedCommandExecute);
            PrintPreviewBadgeCommand = new DelegateCommand<Entities.PersonCredential>(OnPrintPreviewBadgeCommandExecute, OnPrintPreviewBadgeCommandCanExecute);
            SendToPrinterCommand = new DelegateCommand<Entities.PersonCredential>(OnSendToPrinterCommandExecute, OnSendToPrinterCommandCanExecute);
            SendToPrintDispatcherCommand = new DelegateCommand<Entities.PersonCredential>(OnSendToPrintDispatcherCommandExecute, OnSendToPrintDispatcherCommandCanExecute);


            IsAddNewCredentialControlVisible = true;
            IsDeleteCredentialControlVisible = true;
            IsAddNewPersonClusterPermissionControlVisible = true;
            IsPrintPreviewBadgeControlVisible = _clientServices.MyLicense.GetFeatureValue<bool>(LicenseFeatureKey.BadgingSystemIdProducer.ToString());
            BusyContent = CommonResources.Resources.Common_PleaseWait;
            ViewTitle = CommonResources.Resources.EditPersonView_ViewTitle;

            Printers = new ObservableCollection<Printer>();
            PrintDispatchers = new ObservableCollection<PrintDispatcher>();

            if (UserSessionToken != null)
            {
                UserEntitiesSelectionList = UserSessionToken.GetUserEntitySelectCollection();
                foreach (var ue in UserEntitiesSelectionList)
                {
                    if (_Person.EntityIds.Contains(ue.EntityId))
                        ue.Selected = true;
                }
            }

            this.SelectEntityHeaderText = string.Format(
                CommonResources.Resources.EditPersonView_EntityMappingTabHeader, EntityAlias);

            this.SelectEntityHeaderToolTip = string.Format(
                CommonResources.Resources.EditPersonView_EntityMappingTabHeaderToolTip, EntityAliasPlural);

            _eventAggregator.GetEvent<PubSubEvent<PanelCredentialActivityLogMessage>>().Subscribe(HandlePanelCredentialActivityLogMessage, ThreadOption.PublisherThread, true, IsNotInMemoryEvent);

        }

        private bool OnSendToPrintDispatcherCommandCanExecute(Entities.PersonCredential obj)
        {
            return obj?.SelectedPrintDispatcher != null;
        }

        private async void OnSendToPrintDispatcherCommandExecute(Entities.PersonCredential obj)
        {
            if (obj?.SelectedPrintDispatcher == null)
                return;

            var manager = _clientServices.GetManager<BadgePrintManager>();

            var createPrintRequestParams = new GetParametersWithPhoto<IdProducerPrintRequestParameters>()
            {
                Data = { PersonCredentialUid = obj.PersonCredentialUid, Dossier = false, DispatcherId = obj.SelectedPrintDispatcher.ID }
            };

            var printRequests = await manager.CreatePrintRequestForCredentialAsync(createPrintRequestParams);
        }

        private bool OnSendToPrinterCommandCanExecute(Entities.PersonCredential obj)
        {
            return obj?.SelectedPrinter != null;
        }

        private async void OnSendToPrinterCommandExecute(Entities.PersonCredential obj)
        {
            if (obj?.SelectedPrinter == null)
                return;

            var manager = _clientServices.GetManager<BadgePrintManager>();

            var createPrintRequestParams = new GetParametersWithPhoto<IdProducerPrintRequestParameters>()
            {
                Data = { PersonCredentialUid = obj.PersonCredentialUid, Dossier = false, PrinterId = obj.SelectedPrinter.ID }
            };

            var printRequests = await manager.CreatePrintRequestForCredentialAsync(createPrintRequestParams);
        }

        private bool OnPrintPreviewBadgeCommandCanExecute(Entities.PersonCredential obj)
        {
            return obj?.BadgeTemplateUid != GalaxySMS.Common.Constants.BadgeTemplateIds.BadgeTemplateUid_None;
        }

        private async void OnPrintPreviewBadgeCommandExecute(Entities.PersonCredential obj)
        {
            var manager = _clientServices.GetManager<BadgePrintManager>();

            var previewParams = new GetParametersWithPhoto<IdProducerPrintPreviewRequestParameters>()
            {
                Data = { PersonCredentialUid = obj.PersonCredentialUid, Dossier = false }
            };

            var previewData = await manager.GetPreviewImagesForCredentialAsync(previewParams);
            if (previewData != null)
            {
                obj.BadgePreviewData = new BadgePreviewData(previewData);
                //var imgBytes = Convert.FromBase64String(previewData.FrontPreviewImage);
                //System.IO.File.WriteAllBytes("R:\\Users\\Kevin\\AppData\\Local\\Temp\\badgeFrontImage.jpg", imgBytes);
                //var printControl = new idProducerPrintWindow();
                //printControl.Owner = Application.Current.MainWindow;
                //printControl.BadgePreviewData = previewData;
                //printControl.ShowDialog();
            }
            else
                obj.BadgePreviewData = null;
        }


        private async void OnAccessProfileSelectionChangedCommandExecute(AccessProfile obj)
        {
            if (obj != null && obj.AccessProfileUid != GalaxySMS.Common.Constants.AccessProfileIds.AccessProfileId_None)
            {
                var manager = _clientServices.GetManager<AccessProfileManager>();
                var ap = await manager.GetAccessProfileAsync(new GetParametersWithPhoto()
                {
                    UniqueId = obj.AccessProfileUid,
                    IncludeMemberCollections = true,
                });

                if (ap != null)
                {   // Now sync up the person cluster settings
                    var deleteTheseClustersFromPerson = Person.PersonClusterPermissions.Where(c => ap.AccessProfileClusters.All(c2 => c2.ClusterUid != c.ClusterUid)).ToList();
                    foreach (var c in deleteTheseClustersFromPerson)
                    {
                        Person.PersonClusterPermissions.Remove(c);
                    }

                    var addTheseClusters = ap.AccessProfileClusters.Where(c => Person.PersonClusterPermissions.All(c2 => c2.ClusterUid != c.ClusterUid)).ToList();
                    foreach (var c in addTheseClusters)
                    {
                        var csi = PersonEditingData.AccessAndAlarmControlPermissionsEditingData.GetClusterSelectionItem(c.ClusterUid);
                        if (csi != null)
                            OnAddNewPersonClusterPermissionCommandExecute(csi);
                    }

                    var updateTheseClusters = ap.AccessProfileClusters.Where(c => Person.PersonClusterPermissions.Any(c2 => c2.ClusterUid == c.ClusterUid)).ToList();
                    foreach (var c in updateTheseClusters)
                    {
                        var pcp = Person.PersonClusterPermissions.FirstOrDefault(p => p.ClusterUid == c.ClusterUid);
                        if (pcp != null)
                        {
                            if (_theEntity.AccessProfileControlsAG1)
                                pcp.AccessGroup1.AccessGroupUid = c.AccessGroup1.AccessGroupUid;
                            if (_theEntity.AccessProfileControlsAG2)
                                pcp.AccessGroup2.AccessGroupUid = c.AccessGroup2.AccessGroupUid;
                            if (_theEntity.AccessProfileControlsAG3)
                                pcp.AccessGroup3.AccessGroupUid = c.AccessGroup3.AccessGroupUid;
                            if (_theEntity.AccessProfileControlsAG4)
                                pcp.AccessGroup4.AccessGroupUid = c.AccessGroup4.AccessGroupUid;

                            if (_theEntity.AccessProfileControlsIO1)
                                pcp.InputOutputGroup1.InputOutputGroupUid = c.InputOutputGroup1.InputOutputGroupUid;
                            if (_theEntity.AccessProfileControlsIO2)
                                pcp.InputOutputGroup2.InputOutputGroupUid = c.InputOutputGroup2.InputOutputGroupUid;
                            if (_theEntity.AccessProfileControlsIO3)
                                pcp.InputOutputGroup3.InputOutputGroupUid = c.InputOutputGroup3.InputOutputGroupUid;
                            if (_theEntity.AccessProfileControlsIO4)
                                pcp.InputOutputGroup4.InputOutputGroupUid = c.InputOutputGroup4.InputOutputGroupUid;
                        }
                    }
                }
            }

            OnPropertyChanged(() => IsAccessGroup1SelectorEnabled, false);
            OnPropertyChanged(() => IsAccessGroup2SelectorEnabled, false);
            OnPropertyChanged(() => IsAccessGroup3SelectorEnabled, false);
            OnPropertyChanged(() => IsAccessGroup4SelectorEnabled, false);
            OnPropertyChanged(() => IsInputOutputGroup1SelectorEnabled, false);
            OnPropertyChanged(() => IsInputOutputGroup2SelectorEnabled, false);
            OnPropertyChanged(() => IsInputOutputGroup3SelectorEnabled, false);
            OnPropertyChanged(() => IsInputOutputGroup4SelectorEnabled, false);
        }

        private async void HandlePanelCredentialActivityLogMessage(PanelCredentialActivityLogMessage obj)
        {
            var selectedCredential = Person.PersonCredentials.FirstOrDefault(o => o.IsSelected);
            if (selectedCredential != null)
            {
                var df = PersonEditingData.CredentialFormats.FirstOrDefault(o => o.CredentialFormatCode == CredentialFormatCodes.NumericCardCode);
                var mgr = _clientServices.GetManager<CredentialManager>();
                var decodedCred = await mgr.DecodeCredentialNumberAsync(new DecodeCredentialNumberParameters()
                {
                    BitCount = (short)obj.BitCount,
                    CredentialNumber = obj.CredentialNumber,
                    DeviceUid = obj.DeviceUid
                });
                if (decodedCred != null && decodedCred.Count > 0)
                {
                    var dc = decodedCred.FirstOrDefault();
                    if (dc != null)
                    {
                        var rawCred = new RawCredentialData(dc.CredentialFormatCode, obj.CredentialNumber, obj.CredentialBytes, dc.CredentialParts.Select(o => o.Value).ToList());

                        await ProcessCredentialDataEventArgs(new CredentialDataEventArgs(rawCred));
                    }
                }
                else
                {
                    selectedCredential.Credential.CredentialFormatUid = df.CredentialFormatUid;
                    selectedCredential.Credential.CardNumber = obj.CredentialNumber;
                    selectedCredential.Credential.BitCount = (short)obj.BitCount;
                }
            }
        }

        private bool IsNotInMemoryEvent(PanelCredentialActivityLogMessage eventMessage)
        {
            return eventMessage.IsNotInPanelMemoryEvent;
        }
        private bool OnPersonalAccessPortalToAuthorizedCommandCanExecute(ObservableCollection<object> obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (obj.Count == 0)
                return false;
            return true;
        }

        private void OnPersonalAccessPortalToAuthorizedCommandExecute(ObservableCollection<object> obj)
        {
            foreach (var o in obj)
            {
                if (o is AccessPortalSelectionItemBasic ap)
                {
                    ap.Selected = true;
                    // Must Remove then add to get the grid to refresh
                    // http://www.telerik.com/forums/gridview-items-not-refreshing-when-the-gridview-is-sorted-or-filtered
                    foreach (var pcp in Person.PersonClusterPermissions)
                    {
                        foreach (var accessPortal in pcp.AccessPortalsNotAuthorized)
                        {
                            if (ap.AccessPortalUid == accessPortal.AccessPortalUid)
                            {
                                pcp.AccessPortalsNotAuthorized.Remove(ap);
                                pcp.AccessPortalsAuthorized.Add(ap);
                                pcp.MakeDirty();
                                if (pcp.PersonPersonalAccessGroup?.AccessPortals != null)
                                {
                                    var x = pcp.PersonPersonalAccessGroup.AccessPortals.FirstOrDefault(z =>
                                        z.AccessPortalUid == ap.AccessPortalUid);
                                    if (x == null)
                                    {
                                        pcp.PersonPersonalAccessGroup.AccessPortals =
                                            pcp.PersonPersonalAccessGroup.AccessPortals.ToList();
                                        pcp.PersonPersonalAccessGroup.AccessPortals.Add(new AccessPortalUidItem()
                                            {AccessPortalUid = ap.AccessPortalUid, PortalName = ap.AccessPortalName});
                                    }
                                }

                                return;
                            }
                        }
                    }

                }
            }
        }

        private bool OnPersonalAccessPortalToNotAuthorizedCommandCanExecute(ObservableCollection<object> obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (obj.Count == 0)
                return false;
            return true;
        }

        private void OnPersonalAccessPortalToNotAuthorizedCommandExecute(ObservableCollection<object> obj)
        {
            foreach (var o in obj)
            {
                if (o is AccessPortalSelectionItemBasic ap)
                {
                    ap.Selected = false;
                    // Must Remove then add to get the grid to refresh
                    // http://www.telerik.com/forums/gridview-items-not-refreshing-when-the-gridview-is-sorted-or-filtered
                    foreach (var pcp in Person.PersonClusterPermissions)
                    {
                        foreach (var accessPortal in pcp.AccessPortalsAuthorized)
                        {
                            if (ap.AccessPortalUid == accessPortal.AccessPortalUid)
                            {
                                pcp.AccessPortalsAuthorized.Remove(ap);
                                pcp.AccessPortalsNotAuthorized.Add(ap);
                                pcp.MakeDirty();

                                if (pcp.PersonPersonalAccessGroup?.AccessPortals != null)
                                {
                                    pcp.PersonPersonalAccessGroup.AccessPortals =
                                        pcp.PersonPersonalAccessGroup.AccessPortals.ToList();

                                    var x = pcp.PersonPersonalAccessGroup.AccessPortals.FirstOrDefault(z =>
                                        z.AccessPortalUid == ap.AccessPortalUid);
                                    if (x != null)
                                        pcp.PersonPersonalAccessGroup.AccessPortals.Remove(x);
                                }

                                return;
                            }
                        }
                    }

                }
            }
        }

        private bool OnPersonalDynamicAccessGroupToAuthorizedCommandCanExecute(ObservableCollection<object> obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (obj.Count == 0)
                return false;
            return true;
        }

        private void OnPersonalDynamicAccessGroupToAuthorizedCommandExecute(ObservableCollection<object> obj)
        {
            foreach (var o in obj)
            {
                if (o is AccessGroupSelectionItemBasic ag)
                {
                    ag.Selected = true;
                    // Must Remove then add to get the grid to refresh
                    // http://www.telerik.com/forums/gridview-items-not-refreshing-when-the-gridview-is-sorted-or-filtered
                    foreach (var pcp in Person.PersonClusterPermissions)
                    {
                        foreach (var accessGroup in pcp.AccessGroupsNotAuthorized)
                        {
                            if (ag.AccessGroupUid == accessGroup.AccessGroupUid)
                            {
                                pcp.AccessGroupsNotAuthorized.Remove(ag);
                                pcp.AccessGroupsAuthorized.Add(ag);
                                pcp.MakeDirty();

                                if (pcp.PersonPersonalAccessGroup?.DynamicAccessGroups != null)
                                {
                                    pcp.PersonPersonalAccessGroup.DynamicAccessGroups =
                                        pcp.PersonPersonalAccessGroup.DynamicAccessGroups.ToList();
                                    var x = pcp.PersonPersonalAccessGroup.DynamicAccessGroups.FirstOrDefault(z =>
                                        z.AccessGroupUid == ag.AccessGroupUid);
                                    if (x == null)
                                        pcp.PersonPersonalAccessGroup.DynamicAccessGroups.Add(new AccessGroupUidItem(){AccessGroupUid = ag.AccessGroupUid, AccessGroupName = ag.AccessGroupName});
                                }


                                return;
                            }
                        }
                    }

                }
            }
        }

        private bool OnPersonalDynamicAccessGroupToNotAuthorizedCommandCanExecute(ObservableCollection<object> obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (obj.Count == 0)
                return false;
            return true;
        }

        private void OnPersonalDynamicAccessGroupToNotAuthorizedCommandExecute(ObservableCollection<object> obj)
        {
            foreach (var o in obj)
            {
                if (o is AccessGroupSelectionItemBasic ag)
                {
                    ag.Selected = false;
                    // Must Remove then add to get the grid to refresh
                    // http://www.telerik.com/forums/gridview-items-not-refreshing-when-the-gridview-is-sorted-or-filtered
                    foreach (var pcp in Person.PersonClusterPermissions)
                    {
                        foreach (var accessGroup in pcp.AccessGroupsAuthorized)
                        {
                            if (ag.AccessGroupUid == accessGroup.AccessGroupUid)
                            {
                                pcp.AccessGroupsAuthorized.Remove(ag);
                                pcp.AccessGroupsNotAuthorized.Add(ag);
                                pcp.MakeDirty();

                                if (pcp.PersonPersonalAccessGroup?.DynamicAccessGroups != null)
                                {
                                    pcp.PersonPersonalAccessGroup.DynamicAccessGroups =
                                        pcp.PersonPersonalAccessGroup.DynamicAccessGroups.ToList();
                                    var x = pcp.PersonPersonalAccessGroup.DynamicAccessGroups.FirstOrDefault(z =>
                                        z.AccessGroupUid == ag.AccessGroupUid);
                                    if (x != null)
                                        pcp.PersonPersonalAccessGroup.DynamicAccessGroups.Remove(x);
                                }

                                return;
                            }
                        }
                    }

                }
            }
        }

        private void OnDeletePersonClusterPermissionCommandExecute(PersonClusterPermission obj)
        {
            ClearCustomErrors();
            _deleteThisPersonClusterPermission = obj;
            var dlgParams = new DialogParameters();
            dlgParams.Header = CommonResources.Resources.Common_ConfirmDelete;
            dlgParams.Content = string.Format(CommonResources.Resources.MaintainPersons_AreYouSureDeletePersonClusterPermission,
                _deleteThisPersonClusterPermission.ClusterName);
            dlgParams.OkButtonContent = string.Format(CommonResources.Resources.MaintainPersons_YesDeletePersonClusterPermission, _deleteThisPersonClusterPermission);
            dlgParams.CancelButtonContent = string.Format(CommonResources.Resources.MaintainPersons_NoDeletePersonClusterPermission, _deleteThisPersonClusterPermission);
            dlgParams.Closed += OnConfirmDeletePersonClusterPermissionClosed;
            RadWindow.Confirm(dlgParams);
        }

        private async void OnConfirmDeletePersonClusterPermissionClosed(object sender, WindowClosedEventArgs e)
        {
            if (e.DialogResult == true)
            {
                Person.PersonClusterPermissions.Remove(_deleteThisPersonClusterPermission);
            }
            _deleteThisPersonClusterPermission = null;
        }
        private bool OnDeletePersonClusterPermissionCommandCanExecute(PersonClusterPermission obj)
        {
            return
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSDataAccessPermission.CredentialCanDeleteId) &&
                Person.EntityId == _clientServices.CurrentEntityId;
        }

        private void OnAddNewPersonClusterPermissionCommandExecute(ClusterSelectionItemBasic obj)
        {
            var existingPersonClusterPermission = Person.PersonClusterPermissions.FirstOrDefault(p => p.ClusterUid == obj.ClusterUid);
            if (existingPersonClusterPermission == null)
            {
                var pcp = new PersonClusterPermission();
                var s = PersonEditingData.AccessAndAlarmControlPermissionsEditingData.GetSiteSelectionItem(obj.SiteUid);
                RegionSelectionItemBasic r = null;
                if (s != null)
                    r = PersonEditingData.AccessAndAlarmControlPermissionsEditingData.GetRegionSelectionItem(s.RegionUid);
                pcp.Initialize(obj, s, r);

                Person.PersonClusterPermissions.Add(pcp);
            }

        }

        private bool OnAddNewPersonClusterPermissionCommandCanExecute(ClusterSelectionItemBasic obj)
        {
            return
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSDataAccessPermission.CredentialCanAddId) &&
                Person.EntityId == _clientServices.CurrentEntityId &&
                Person.PersonClusterPermissions.FirstOrDefault(o => o.ClusterUid == obj.ClusterUid) == null;
        }

        private bool OnDeletePersonCredentialCommandCanExecute(Entities.PersonCredential obj)
        {
            return
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSDataAccessPermission.CredentialCanDeleteId) &&
                Person.EntityId == _clientServices.CurrentEntityId;
        }

        private void OnDeletePersonCredentialCommandExecute(Entities.PersonCredential obj)
        {
            ClearCustomErrors();
            _deleteThisPersonCredential = obj;
            var dlgParams = new DialogParameters();
            dlgParams.Header = CommonResources.Resources.Common_ConfirmDelete;
            dlgParams.Content = string.Format(CommonResources.Resources.MaintainPersons_AreYouSureDeletePersonCredential,
                _deleteThisPersonCredential.CredentialDescription);
            dlgParams.OkButtonContent = string.Format(CommonResources.Resources.MaintainPersons_YesDeletePersonCredential, _deleteThisPersonCredential);
            dlgParams.CancelButtonContent = string.Format(CommonResources.Resources.MaintainPersons_NoDeletePersonCredential, _deleteThisPersonCredential);
            dlgParams.Closed += OnConfirmDeletePersonCredentialClosed;
            RadWindow.Confirm(dlgParams);
        }

        private void OnConfirmDeletePersonCredentialClosed(object sender, WindowClosedEventArgs e)
        {
            if (e.DialogResult == true)
            {
                Person.PersonCredentials.Remove(_deleteThisPersonCredential);
            }
            _deleteThisPersonCredential = null;
        }

        private bool OnSelectPersonCredentialCommandCanExecute(Entities.PersonCredential obj)
        {
            return true;
        }

        private void OnSelectPersonCredentialCommandExecute(Entities.PersonCredential obj)
        {
            foreach (var c in Person.PersonCredentials.Where(o => o != obj))
            {
                c.IsSelected = false;
            }
            obj.IsSelected = true;
        }

        private bool OnSearchForCredentialByValuesCommandCanExecute(object obj)
        {
            return true;
        }

        private async void OnSearchForCredentialByValuesCommandExecute(Credential obj)
        {
            IsBusy = true;
            base.ClearCustomErrors();
            var parameters = new Entities.PersonSummarySearchParameters();
            parameters.UniqueId = _clientServices.CurrentSite.SiteUid;
            parameters.IncludeMemberCollections = false;
            parameters.IncludePhoto = true;
            parameters.PhotoPixelWidth = _clientServices.ThumbnailPixelWidth;
            parameters.SearchType = PersonSearchType.ByCredentialFieldValues;
            parameters.SearchCredential = obj;

            var mgr = _clientServices.GetManager<PersonManager>();
            var searchResults = await mgr.SearchAsync(parameters);

            if (mgr.HasErrors)
            {
                base.AddCustomErrors(mgr.Errors, true);
            }
            else
            {
                if (searchResults != null && searchResults.Count > 0)
                {
                    var p = searchResults.FirstOrDefault();
                    if (p != null)
                    {
                        if (p.PersonUid != this.Person.PersonUid)
                        {
                            IsBusy = false;
                            Application.Current.Dispatcher.Invoke(() =>
                            {
                                var content = new ucDuplicateCredentialPersonSummary();
                                content.DataContext = p;
                                RadWindow.Alert(new DialogParameters()
                                {
                                    Header = GalaxySMS.Resources.Resources.PersonEditor_DuplicateCredentialAlertHeader,
                                    Content = content
                                });
                            });
                            return;
                        }
                    }

                }

            }
            IsBusy = false;

        }

        private bool OnAddNewCredentialCommandCanExecute(object obj)
        {
            return
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSDataAccessPermission.CredentialCanUpdateId);
        }

        private void OnAddNewCredentialCommandExecute(object obj)
        {
            var pc = new Entities.PersonCredential()
            {
                IsActive = true,
            };

            var pcr = PersonEditingData.PersonCredentialRoles.FirstOrDefault(o => o.Code == PersonCredentialRoles.AccessControl);
            if (pcr != null)
                pc.PersonCredentialRoleUid = pcr.PersonCredentialRoleUid;

            var pam = PersonEditingData.PersonActivationModes.FirstOrDefault(o => o.Code == PersonActivationModes.ImmediatelyActive);
            if (pam != null)
                pc.PersonActivationModeUid = pam.PersonActivationModeUid;

            var pem = PersonEditingData.PersonExpirationModes.FirstOrDefault(o => o.Code == PersonExpirationModes.NeverExpires);
            if (pem != null)
                pc.PersonExpirationModeUid = pem.PersonExpirationModeUid;

            var apdsb = PersonEditingData.AccessPortalDeferToServerBehaviors.FirstOrDefault(o => o.Code == AccessPortalDeferToServerBehavior.Never);
            if (apdsb != null)
                pc.AccessPortalDeferToServerBehaviorUid = apdsb.AccessPortalDeferToServerBehaviorUid;

            var apnsrd = PersonEditingData.AccessPortalNoServerReplyBehaviors.FirstOrDefault(o => o.Code == AccessPortalNoServerReplyBehavior.FollowPanelDecision);
            if (apnsrd != null)
                pc.AccessPortalNoServerReplyBehaviorUid = apnsrd.AccessPortalNoServerReplyBehaviorUid;

            var bt = PersonEditingData.BadgeTemplates.FirstOrDefault();
            if (bt != null)
            {
                pc.BadgeTemplateUid = bt.BadgeTemplateUid;
                pc.DossierBadgeTemplateUid = bt.BadgeTemplateUid;
            }
            pc.Credential.CredentialFormat = PersonEditingData.CredentialFormats.FirstOrDefault(o => o.CredentialFormatCode == CredentialFormatCodes.Standard26Bit);
            if (pc.Credential.CredentialFormat != null)
                pc.Credential.CredentialFormatUid = pc.Credential.CredentialFormat.CredentialFormatUid;
            Person.PersonCredentials.Add(pc);
            OnSelectPersonCredentialCommandExecute(pc);
        }

        private void BuildRequiredProperties()
        {
            RequiredProperties = UserInterfacePageControlData.ControlProperties.Where(p => p.IsRequired &&
            p.IsActive &&
            p.PropertyName != PersonStandardPropertyNames.InsertDate.ToString() &&
            p.PropertyName != PersonStandardPropertyNames.InsertName.ToString() &&
            p.PropertyName != PersonStandardPropertyNames.UpdateDate.ToString() &&
            p.PropertyName != PersonStandardPropertyNames.UpdateName.ToString() &&
            p.PropertyName != PersonStandardPropertyNames.EntityId.ToString() &&
            p.PropertyName != PersonStandardPropertyNames.PersonUid.ToString()).OrderBy(o => o.Display).ToObservableCollection();

            //RequiredPropertyControls = new ObservableCollection<FrameworkElement>();
            //foreach (var rp in RequiredProperties)
            //{
            //    var rpc = GetControlForProperty(rp.PropertyName);
            //    if( rpc != null)
            //        RequiredPropertyControls.Add(rpc);
            //    else
            //        this.Log().DebugFormat("BuildRequiredProperties: {0} property null", rp.PropertyName);
            //}
        }



        #endregion

        #region Public Commands
        public DelegateCommand<object> SaveCommand { get; private set; }

        public DelegateCommand<object> CancelCommand { get; private set; }

        public DelegateCommand<object> SelectImageCommand { get; private set; }

        public DelegateCommand<UserEntitySelect> EntityMapChecked { get; set; }

        public DelegateCommand<object> AddNewCredentialCommand { get; private set; }
        public DelegateCommand<Credential> SearchForCredentialByValuesCommand { get; private set; }
        public DelegateCommand<Entities.PersonCredential> DeletePersonCredentialCommand { get; private set; }

        public DelegateCommand<Entities.PersonCredential> SelectPersonCredentialCommand { get; private set; }

        public DelegateCommand<ClusterSelectionItemBasic> AddNewPersonClusterPermissionCommand { get; private set; }
        public DelegateCommand<PersonClusterPermission> DeletePersonClusterPermissionCommand { get; private set; }

        public DelegateCommand<ObservableCollection<object>> PersonalAccessPortalToAuthorizedCommand { get; private set; }
        public DelegateCommand<ObservableCollection<object>> PersonalAccessPortalToNotAuthorizedCommand { get; private set; }
        public DelegateCommand<ObservableCollection<object>> PersonalDynamicAccessGroupToAuthorizedCommand { get; private set; }
        public DelegateCommand<ObservableCollection<object>> PersonalDynamicAccessGroupToNotAuthorizedCommand { get; private set; }
        public DelegateCommand<AccessProfile> AccessProfileSelectionChanged { get; set; }
        public DelegateCommand<Entities.PersonCredential> PrintPreviewBadgeCommand { get; private set; }

        public DelegateCommand<Entities.PersonCredential> SendToPrinterCommand { get; private set; }
        public DelegateCommand<Entities.PersonCredential> SendToPrintDispatcherCommand { get; private set; }
        #endregion

        #region Public Properties
        public Entities.Person Person
        {
            get { return _Person; }
        }
        public bool IsBasicInfoExpanded
        {
            get { return _isBasicInfoExpanded; }
            set
            {
                if (_isBasicInfoExpanded != value)
                {
                    _isBasicInfoExpanded = value;
                    OnPropertyChanged(() => IsBasicInfoExpanded, false);
                }
            }
        }

        public Guid InstanceId { get; }

        private Entities.PersonEditingData _personEditingData;

        public Entities.PersonEditingData PersonEditingData
        {
            get { return _personEditingData; }
            set
            {
                if (_personEditingData != value)
                {
                    _personEditingData = value;
                    OnPropertyChanged(() => PersonEditingData, false);
                }
            }
        }


        private Entities.UserInterfacePageControlData _uiPageControlData;

        public Entities.UserInterfacePageControlData UserInterfacePageControlData
        {
            get { return _uiPageControlData; }
            set
            {
                if (_uiPageControlData != value)
                {
                    _uiPageControlData = value;
                    OnPropertyChanged(() => UserInterfacePageControlData, false);
                }
            }
        }

        private ObservableCollection<UserDefinedProperty> _requiredProperties;

        public ObservableCollection<UserDefinedProperty> RequiredProperties
        {
            get { return _requiredProperties; }
            set
            {
                if (_requiredProperties != value)
                {
                    _requiredProperties = value;
                    OnPropertyChanged(() => RequiredProperties, false);
                }
            }
        }

        //private ObservableCollection<FrameworkElement> _requiredPropertyControls;

        //public ObservableCollection<FrameworkElement> RequiredPropertyControls
        //{
        //    get { return _requiredPropertyControls; }
        //    set
        //    {
        //        if (_requiredPropertyControls != value)
        //        {
        //            _requiredPropertyControls = value;
        //            OnPropertyChanged(() => RequiredPropertyControls, false);
        //        }
        //    }
        //}
        public ObservableCollection<Printer> Printers
        {
            get { return _printers; }
            set
            {
                if (_printers != value)
                {
                    _printers = value;
                    OnPropertyChanged(() => Printers, false);
                }
            }
        }


        public ObservableCollection<PrintDispatcher> PrintDispatchers
        {
            get { return _printDispatchers; }
            set
            {
                if (_printDispatchers != value)
                {
                    _printDispatchers = value;
                    OnPropertyChanged(() => PrintDispatchers, false);
                }
            }
        }

        //private Printer _selectedPrinter;

        //public Printer SelectedPrinter
        //{
        //    get { return _selectedPrinter; }
        //    set
        //    {
        //        if (_selectedPrinter != value)
        //        {
        //            _selectedPrinter = value;
        //            OnPropertyChanged(() => SelectedPrinter, false);
        //        }
        //    }
        //}

        //private PrintDispatcher _selectedPrintDispatcher;

        //public PrintDispatcher SelectedPrintDispatcher
        //{
        //    get { return _selectedPrintDispatcher; }
        //    set
        //    {
        //        if (_selectedPrintDispatcher != value)
        //        {
        //            _selectedPrintDispatcher = value;
        //            OnPropertyChanged(() => SelectedPrintDispatcher, false);
        //        }
        //    }
        //}

        public bool IsAddNewCredentialControlVisible
        {
            get { return _IsAddNewCredentialControlVisible; }
            set
            {
                if (_IsAddNewCredentialControlVisible != value)
                {
                    _IsAddNewCredentialControlVisible = value;
                    OnPropertyChanged(() => IsAddNewCredentialControlVisible, false);
                }
            }
        }

        public bool IsDeleteCredentialControlVisible
        {
            get { return _isDeleteCredentialControlVisible; }
            set
            {
                if (_isDeleteCredentialControlVisible != value)
                {
                    _isDeleteCredentialControlVisible = value;
                    OnPropertyChanged(() => IsDeleteCredentialControlVisible, false);
                }
            }
        }
        public bool IsAddNewPersonClusterPermissionControlVisible
        {
            get { return _IsAddNewPersonClusterPermissionControlVisible; }
            set
            {
                if (_IsAddNewPersonClusterPermissionControlVisible != value)
                {
                    _IsAddNewPersonClusterPermissionControlVisible = value;
                    OnPropertyChanged(() => IsAddNewPersonClusterPermissionControlVisible, false);
                }
            }
        }
        public bool IsPrintPreviewBadgeControlVisible
        {
            get { return _IsPrintPreviewBadgeControlVisible; }
            set
            {
                if (_IsPrintPreviewBadgeControlVisible != value)
                {
                    _IsPrintPreviewBadgeControlVisible = value;
                    OnPropertyChanged(() => IsPrintPreviewBadgeControlVisible, false);
                }
            }
        }
        public UserDefinedProperty PersonIdProperty
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.PersonId.ToString()); } }
        public UserDefinedProperty FirstNameProperty
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.FirstName.ToString()); } }

        public UserDefinedProperty LastNameProperty
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.LastName.ToString()); } }

        public UserDefinedProperty MiddleNameProperty
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.MiddleName.ToString()); } }

        public UserDefinedProperty CountryOfBirthUidProperty
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.CountryOfBirthUid.ToString()); } }

        public UserDefinedProperty PersonActiveStatusTypeUidProperty
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.PersonActiveStatusTypeUid.ToString()); } }

        public UserDefinedProperty GenderUidProperty
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.GenderUid.ToString()); } }

        public UserDefinedProperty DepartmentUidProperty
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.DepartmentUid.ToString()); } }

        public UserDefinedProperty AccessProfileUidProperty
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.AccessProfileUid.ToString()); } }

        public UserDefinedProperty PersonRecordTypeUidProperty
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.PersonRecordTypeUid.ToString()); } }

        public UserDefinedProperty EntityIdProperty
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.EntityId.ToString()); } }

        public UserDefinedProperty PersonUidProperty
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.PersonUid.ToString()); } }

        public UserDefinedProperty RowOriginProperty
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.RowOrigin.ToString()); } }

        public UserDefinedProperty OriginIdProperty
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.OriginId.ToString()); } }

        public UserDefinedProperty InitialsProperty
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.Initials.ToString()); } }

        public UserDefinedProperty NickNameProperty
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.NickName.ToString()); } }

        public UserDefinedProperty LegalNameProperty
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.LegalName.ToString()); } }

        public UserDefinedProperty FullNameProperty
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.FullName.ToString()); } }

        public UserDefinedProperty PreferredNameProperty
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.PreferredName.ToString()); } }

        public UserDefinedProperty CompanyProperty
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.Company.ToString()); } }

        public UserDefinedProperty HomeOfficeLocationProperty
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.HomeOfficeLocation.ToString()); } }

        public UserDefinedProperty JobTitleProperty
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.JobTitle.ToString()); } }

        public UserDefinedProperty RaceProperty
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.Race.ToString()); } }

        public UserDefinedProperty NationalityProperty
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.Nationality.ToString()); } }

        public UserDefinedProperty EthnicityProperty
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.Ethnicity.ToString()); } }

        public UserDefinedProperty PrimaryLanguageProperty
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.PrimaryLanguage.ToString()); } }

        public UserDefinedProperty SecondaryLanguageProperty
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.SecondaryLanguage.ToString()); } }

        public UserDefinedProperty NationalIdentificationNumberProperty
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.NationalIdentificationNumber.ToString()); } }

        public UserDefinedProperty DateOfBirthProperty
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.DateOfBirth.ToString()); } }

        public UserDefinedProperty EmploymentDateProperty
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.EmploymentDate.ToString()); } }

        public UserDefinedProperty TerminationDateProperty
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.TerminationDate.ToString()); } }

        public UserDefinedProperty ActivationDateTimeProperty
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.ActivationDateTime.ToString()); } }

        public UserDefinedProperty ExpirationDateTimeProperty
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.ExpirationDateTime.ToString()); } }

        public UserDefinedProperty TraceProperty
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.Trace.ToString()); } }

        public UserDefinedProperty SysGalEmployeeIdProperty
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.SysGalEmployeeId.ToString()); } }

        public UserDefinedProperty VeryImportantPersonProperty
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.VeryImportantPerson.ToString()); } }

        public UserDefinedProperty HasPhysicalDisabilityProperty
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.HasPhysicalDisability.ToString()); } }

        public UserDefinedProperty HasVertigoProperty
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.HasVertigo.ToString()); } }

        public UserDefinedProperty ActivityEventTextProperty
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.ActivityEventText.ToString()); } }


        public UserDefinedProperty InsertNameProperty
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.InsertName.ToString()); } }

        public UserDefinedProperty InsertDateProperty
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.InsertDate.ToString()); } }

        public UserDefinedProperty UpdateNameProperty
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.UpdateName.ToString()); } }

        public UserDefinedProperty UpdateDateProperty
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.UpdateDate.ToString()); } }

        public UserDefinedProperty TextData1Property
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.TextData1.ToString()); } }

        public UserDefinedProperty TextData2Property
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.TextData2.ToString()); } }

        public UserDefinedProperty TextData3Property
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.TextData3.ToString()); } }

        public UserDefinedProperty TextData4Property
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.TextData4.ToString()); } }

        public UserDefinedProperty TextData5Property
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.TextData5.ToString()); } }

        public UserDefinedProperty TextData6Property
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.TextData6.ToString()); } }

        public UserDefinedProperty TextData7Property
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.TextData7.ToString()); } }

        public UserDefinedProperty TextData8Property
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.TextData8.ToString()); } }

        public UserDefinedProperty TextData9Property
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.TextData9.ToString()); } }

        public UserDefinedProperty TextData10Property
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.TextData10.ToString()); } }

        public UserDefinedProperty TextData11Property
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.TextData11.ToString()); } }

        public UserDefinedProperty TextData12Property
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.TextData12.ToString()); } }

        public UserDefinedProperty TextData13Property
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.TextData13.ToString()); } }

        public UserDefinedProperty TextData14Property
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.TextData14.ToString()); } }

        public UserDefinedProperty TextData15Property
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.TextData15.ToString()); } }

        public UserDefinedProperty TextData16Property
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.TextData16.ToString()); } }

        public UserDefinedProperty TextData17Property
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.TextData17.ToString()); } }

        public UserDefinedProperty TextData18Property
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.TextData18.ToString()); } }

        public UserDefinedProperty TextData19Property
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.TextData19.ToString()); } }

        public UserDefinedProperty TextData20Property
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.TextData20.ToString()); } }

        public UserDefinedProperty TextData21Property
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.TextData21.ToString()); } }

        public UserDefinedProperty TextData22Property
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.TextData22.ToString()); } }

        public UserDefinedProperty TextData23Property
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.TextData23.ToString()); } }

        public UserDefinedProperty TextData24Property
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.TextData24.ToString()); } }

        public UserDefinedProperty TextData25Property
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.TextData25.ToString()); } }

        public UserDefinedProperty TextData26Property
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.TextData26.ToString()); } }

        public UserDefinedProperty TextData27Property
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.TextData27.ToString()); } }

        public UserDefinedProperty TextData28Property
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.TextData28.ToString()); } }

        public UserDefinedProperty TextData29Property
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.TextData29.ToString()); } }

        public UserDefinedProperty TextData30Property
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.TextData30.ToString()); } }

        public UserDefinedProperty TextData31Property
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.TextData31.ToString()); } }

        public UserDefinedProperty TextData32Property
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.TextData32.ToString()); } }

        public UserDefinedProperty TextData33Property
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.TextData33.ToString()); } }

        public UserDefinedProperty TextData34Property
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.TextData34.ToString()); } }

        public UserDefinedProperty TextData35Property
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.TextData35.ToString()); } }

        public UserDefinedProperty TextData36Property
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.TextData36.ToString()); } }

        public UserDefinedProperty TextData37Property
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.TextData37.ToString()); } }

        public UserDefinedProperty TextData38Property
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.TextData38.ToString()); } }

        public UserDefinedProperty TextData39Property
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.TextData39.ToString()); } }

        public UserDefinedProperty TextData40Property
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.TextData40.ToString()); } }

        public UserDefinedProperty TextData41Property
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.TextData41.ToString()); } }

        public UserDefinedProperty TextData42Property
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.TextData42.ToString()); } }

        public UserDefinedProperty TextData43Property
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.TextData43.ToString()); } }

        public UserDefinedProperty TextData44Property
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.TextData44.ToString()); } }

        public UserDefinedProperty TextData45Property
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.TextData45.ToString()); } }

        public UserDefinedProperty TextData46Property
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.TextData46.ToString()); } }

        public UserDefinedProperty TextData47Property
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.TextData47.ToString()); } }

        public UserDefinedProperty TextData48Property
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.TextData48.ToString()); } }

        public UserDefinedProperty TextData49Property
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.TextData49.ToString()); } }

        public UserDefinedProperty TextData50Property
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.TextData50.ToString()); } }

        public UserDefinedProperty CountryOfBirthProperty
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.CountryOfBirthUid.ToString()); } }

        public UserDefinedProperty GenderProperty
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.GenderUid.ToString()); } }

        public UserDefinedProperty PersonActiveStatusTypeProperty
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.PersonActiveStatusTypeUid.ToString()); } }

        public UserDefinedProperty DepartmentProperty
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.DepartmentUid.ToString()); } }

        public UserDefinedProperty AccessProfileProperty
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.AccessProfileUid.ToString()); } }

        public UserDefinedProperty PersonRecordTypeProperty
        { get { return GetUserDefinedProperty(PersonStandardPropertyNames.PersonRecordTypeUid.ToString()); } }

        public bool IsAccessGroup1SelectorEnabled
        {
            get
            {
                return Person.PersonAccessControlProperty.AccessProfileUid == GalaxySMS.Common.Constants.AccessProfileIds.AccessProfileId_None || !_theEntity.AccessProfileControlsAG1;
            }
            set
            {
                OnPropertyChanged(() => IsAccessGroup1SelectorEnabled, false);
            }
        }

        public bool IsAccessGroup2SelectorEnabled
        {
            get
            {
                return Person.PersonAccessControlProperty.AccessProfileUid == GalaxySMS.Common.Constants.AccessProfileIds.AccessProfileId_None || !_theEntity.AccessProfileControlsAG2;
            }
            set
            {
                OnPropertyChanged(() => IsAccessGroup2SelectorEnabled, false);
            }
        }

        public bool IsAccessGroup3SelectorEnabled
        {
            get
            {
                return Person.PersonAccessControlProperty.AccessProfileUid == GalaxySMS.Common.Constants.AccessProfileIds.AccessProfileId_None || !_theEntity.AccessProfileControlsAG3;
            }
            set
            {
                OnPropertyChanged(() => IsAccessGroup3SelectorEnabled, false);
            }
        }

        public bool IsAccessGroup4SelectorEnabled
        {
            get
            {
                return Person.PersonAccessControlProperty.AccessProfileUid == GalaxySMS.Common.Constants.AccessProfileIds.AccessProfileId_None || !_theEntity.AccessProfileControlsAG4;
            }
            set
            {
                OnPropertyChanged(() => IsAccessGroup4SelectorEnabled, false);
            }
        }


        public bool IsInputOutputGroup1SelectorEnabled
        {
            get
            {
                return Person.PersonAccessControlProperty.AccessProfileUid == GalaxySMS.Common.Constants.AccessProfileIds.AccessProfileId_None || !_theEntity.AccessProfileControlsIO1;
            }
            set
            {
                OnPropertyChanged(() => IsInputOutputGroup1SelectorEnabled, false);
            }
        }


        public bool IsInputOutputGroup2SelectorEnabled
        {
            get
            {
                return Person.PersonAccessControlProperty.AccessProfileUid == GalaxySMS.Common.Constants.AccessProfileIds.AccessProfileId_None || !_theEntity.AccessProfileControlsIO2;
            }
            set
            {
                OnPropertyChanged(() => IsInputOutputGroup2SelectorEnabled, false);
            }
        }

        public bool IsInputOutputGroup3SelectorEnabled
        {
            get
            {
                return Person.PersonAccessControlProperty.AccessProfileUid == GalaxySMS.Common.Constants.AccessProfileIds.AccessProfileId_None || !_theEntity.AccessProfileControlsIO3;
            }
            set
            {
                OnPropertyChanged(() => IsInputOutputGroup3SelectorEnabled, false);
            }
        }

        public bool IsInputOutputGroup4SelectorEnabled
        {
            get
            {
                return Person.PersonAccessControlProperty.AccessProfileUid == GalaxySMS.Common.Constants.AccessProfileIds.AccessProfileId_None || !_theEntity.AccessProfileControlsIO4;
            }
            set
            {
                OnPropertyChanged(() => IsInputOutputGroup4SelectorEnabled, false);
            }
        }

        #endregion

        #region Protected Methods
        protected override void AddModels(List<ObjectBase> models)
        {
            models.Add(Person);
        }

        protected override void OnViewLoaded()
        {
            var isIdProducerLicensed = _clientServices.MyLicense.GetFeatureValue<bool>(LicenseFeatureKey.BadgingSystemIdProducer.ToString());
            if (isIdProducerLicensed)
            {
                Task.Run(async () =>
                {
                    var parameters = new GetParametersWithPhoto<IdProducerRequestParameters>
                    {
                        Data = { PersonUid = Person.PersonUid }
                    };
                    var manager = _clientServices.GetManager<BadgePrintManager>();
                    var printers = await manager.GetAllPrintersAsync(parameters);
                    var printDispatchers = await manager.GetAllPrintDispatchersAsync(parameters);
                    Printers = printers.ToObservableCollection();
                    PrintDispatchers = printDispatchers.ToObservableCollection();

                }).Wait();
            }

            base.OnViewLoaded();
        }
        #endregion

        #region Private Methods

        private UserDefinedProperty GetUserDefinedProperty(string propertyName)
        {
            return UserInterfacePageControlData.ControlProperties.FirstOrDefault(o => o.PropertyName == propertyName);
        }

        private async void OnSaveCommandExecute(object arg)
        {
            ValidateModel();

            if (IsValid)
            {
                BusyContent = string.Format(CommonResources.Resources.EditPersonView_PleaseWaitWhileISave, Person);

                Person.EntityIds.Clear();
                foreach (var ue in UserEntitiesSelectionList)
                {
                    if (ue.Selected || ue.EntityId == Person.EntityId)
                        Person.EntityIds.Add(ue.EntityId);
                }

                //foreach (var pcp in Person.PersonClusterPermissions)
                //{
                    //pcp.PersonPersonalAccessGroup.AccessPortalUids = pcp.AccessPortalsAuthorized.Select(o => o.AccessPortalUid).ToCollection();
                    //pcp.PersonPersonalAccessGroup.DynamicAccessGroupUids = pcp.AccessGroupsAuthorized.Select(o => o.AccessGroupUid).ToCollection();
                    //var apIds = pcp.AccessPortalsAuthorized.Select(o => o.AccessPortalUid).ToCollection();
                    //var dagIds = pcp.AccessGroupsAuthorized.Select(o => o.AccessGroupUid).ToCollection();
                    //foreach( var apid in apIds)
                    //    pcp.PersonPersonalAccessGroup.AccessPortals.Add(new AccessPortalUidItem(){AccessPortalUid = apid});
                    //foreach (var dagid in dagIds)
                    //    pcp.PersonPersonalAccessGroup.DynamicAccessGroups.Add(new AccessGroupUidItem() { AccessGroupUid = dagid });
                //}

                IsBusy = true;
                var manager = _clientServices.GetManager<PersonManager>();
                bool isNew = (Person.PersonUid == Guid.Empty);
                Entities.Person savedEntity;
                //if (Person.IsPanelDataDirty == false)
                //{
                //    if (Person.PersonAccessControlProperty.IsPanelDataDirty)
                //        Person.IsPanelDataDirty = Person.PersonAccessControlProperty.IsPanelDataDirty;
                //    else
                //        Person.IsPanelDataDirty = Person.IsAnyPanelDataDirty();
                //}
                var parameters = new SaveParameters<Entities.Person>()
                {
                    SavePhoto = true,
                    Data = Person,
                    //SessionId = _clientServices.UserSessionToken.SessionId,
                    CurrentEntityId = _clientServices.UserSessionToken.CurrentEntityId
                };
                parameters.AddOption(nameof(GalaxySMS.Common.Enums.SavePersonClusterPermissionOption).ToString(), SavePersonClusterPermissionOption.DeleteMissingItems.ToString());
                if (UseAsyncServiceCalls == false)
                {
                    savedEntity = manager.SavePerson(parameters);
                }
                else
                {
                    savedEntity = await manager.SavePersonAsync(parameters);
                }

                if (savedEntity != null && manager.HasErrors == false)
                {
                    _eventAggregator.GetEvent<PubSubEvent<EntitySavedEventArgs<Entities.Person>>>()
                        .Publish(new EntitySavedEventArgs<Entities.Person>()
                        {
                            Entity = savedEntity,
                            IsNew = isNew
                        });
                }
                else if (manager.HasErrors)
                {
                    AddCustomErrors(manager.Errors, true);
                }
                IsBusy = false;
            }
        }

        private bool OnSaveCommandCanExecute(object arg)
        {
            if (Person.PersonUid == Guid.Empty)
                return _Person.IsDirty || _Person.IsAnythingDirty() &&
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSDataAccessPermission.PersonnelCanAddId) &&
                Person.EntityId == _clientServices.CurrentEntityId;

            return _Person.IsDirty || _Person.IsAnythingDirty() &&
                   _clientServices.UserSessionToken.HasPermission(
                       PermissionIds.GalaxySMSDataAccessPermission.PersonnelCanUpdateId) &&
                   Person.EntityId == _clientServices.CurrentEntityId;
        }

        private void OnCancelCommandExecute(object arg)
        {
            _eventAggregator.GetEvent<PubSubEvent<OperationCanceledEventArgs<Entities.Person>>>().Publish(new OperationCanceledEventArgs<Entities.Person>()
            {
                Entity = Person,
                OperationId = InstanceId
            });
        }
        private void OnSelectImageCommandExecute(object obj)
        {
            try
            {
                IDialogService dlgService = new DialogService();
                ImageCaptureControl captureControl = new ImageCaptureControl
                {
                    Image = ByteArrayToFromImage.ByteArrayToImage(_Person.Photo.PhotoImage),
                    AutomaticallyScaleDownImage = true,
                    ScaleToMaximumHeight = 600,
                    AspectRatio = ImageAspectRatio.Square1X1
                    //Image = ByteArrayToFromImage.ByteArrayToImage(_Person.Photo.PhotoImage),
                    ////AutomaticallyScaleDownImage = false,
                    ////ScaleToMaximumHeight = 600,
                    //AspectRatio = ImageAspectRatio.Square1X1
                };
                SetBackgroundSubdued();
                dlgService.ShowRadDialog(captureControl, null, CommonResources.Resources.Dialog_SelectPersonPhotoTitle);
                ClearBackgroundSubdued();
                if (captureControl.DialogResult == true && captureControl.ImageCroppedAndScaled != null)
                {
                    if (_Person.PersonPhotos.FirstOrDefault() == null)
                        _Person.PersonPhotos.Add(new PersonPhoto()
                        {
                            IsDefault = true,
                        });
                    _Person.Photo.PhotoImage =
                        ByteArrayToFromImage.ImageToByteArray(captureControl.ImageCroppedAndScaled);
                    _Person.MakeDirty();
                }
            }
            catch (Exception ex)
            {
                this.Log().DebugFormat("OnSelectImageCommandExecute: {0}", ex.Message);
            }
        }

        public async Task ProcessCredentialDataEventArgs(CredentialDataEventArgs e)
        {
            var selectedCredential = Person.PersonCredentials.FirstOrDefault(o => o.IsSelected);
            if (selectedCredential == null)
                return;

            var df = EnumExtensions.GetOne<CredentialFormatCodes>(e.Data.DataFormat);

            var f = PersonEditingData?.CredentialFormats.FirstOrDefault(o => o.CredentialFormatCode == df);
            if (f == null)
                return;

            // Search the database for the credential to see if it is already in the database
            IsBusy = true;
            base.ClearCustomErrors();
            var parameters = new Entities.PersonSummarySearchParameters();
            parameters.UniqueId = _clientServices.CurrentSite.SiteUid;
            parameters.IncludeMemberCollections = false;
            parameters.IncludePhoto = true;
            parameters.PhotoPixelWidth = _clientServices.ThumbnailPixelWidth;
            parameters.SearchType = PersonSearchType.ByCredentialNumber;
            parameters.SearchCredential = new Credential() { CredentialFormat = f };

            if (parameters.SearchCredential.CredentialFormat != null)
            {
                switch (parameters.SearchCredential.CredentialFormat.CredentialFormatCode)
                {
                    case CredentialFormatCodes.NumericCardCode:
                    case CredentialFormatCodes.MagneticStripeBarcodeAba:
                    case CredentialFormatCodes.GalaxyKeypad:
                    case CredentialFormatCodes.BasIpQr:
                    case CredentialFormatCodes.BtFarpointeConektMobile:
                    case CredentialFormatCodes.BtHidMobileAccess:
                    case CredentialFormatCodes.BtStidMobileId:
                    case CredentialFormatCodes.BtAllegion:
                    case CredentialFormatCodes.BtBasIp:
                        parameters.SearchCredential.CardNumber = e.Data.FullCardCode;
                        break;

                    case CredentialFormatCodes.Standard26Bit:
                        parameters.SearchCredential.CardNumber = e.Data.Wiegand26Data.FCC;
                        parameters.SearchCredential.Standard26Bit.FacilityCode =
                            (short)e.Data.Wiegand26Data.FacilityCode;
                        parameters.SearchCredential.Standard26Bit.IdCode = e.Data.Wiegand26Data.IDCode;
                        break;

                    case CredentialFormatCodes.Corporate1K35Bit:
                        parameters.SearchCredential.CardNumber = e.Data.Wiegand35HIDCorporate1000Data.FCC;
                        parameters.SearchCredential.Corporate1K35Bit.CompanyCode =
                            (int)e.Data.Wiegand35HIDCorporate1000Data.CompanyCode;
                        parameters.SearchCredential.Corporate1K35Bit.IdCode =
                            (int)e.Data.Wiegand35HIDCorporate1000Data.IDCode;
                        break;

                    case CredentialFormatCodes.Corporate1K48Bit:
                        parameters.SearchCredential.CardNumber = e.Data.Wiegand48HIDCorporate1000Data.FCC;
                        parameters.SearchCredential.Corporate1K48Bit.CompanyCode =
                            (int)e.Data.Wiegand48HIDCorporate1000Data.CompanyCode;
                        parameters.SearchCredential.Corporate1K48Bit.IdCode =
                            (int)e.Data.Wiegand48HIDCorporate1000Data.IDCode;
                        break;

                    case CredentialFormatCodes.USGovernmentID:
                        selectedCredential.Credential.CardNumber = e.Data.RawData;
                        break;

                    case CredentialFormatCodes.XceedId40Bit:
                        parameters.SearchCredential.CardNumber = e.Data.XceedId40BitData.FCC;
                        parameters.SearchCredential.XceedId40Bit.SiteCode = e.Data.XceedId40BitData.SiteCode;
                        parameters.SearchCredential.XceedId40Bit.IdCode =
                            (int)e.Data.XceedId40BitData.IDCode;
                        break;

                    case CredentialFormatCodes.Cypress37Bit:
                        parameters.SearchCredential.CardNumber = e.Data.Cypress37BitData.FCC;
                        parameters.SearchCredential.Cypress37Bit.FacilityCode =
                            e.Data.Cypress37BitData.FacilityCode;
                        parameters.SearchCredential.Cypress37Bit.IdCode =
                            (int)e.Data.Cypress37BitData.IDCode;
                        break;

                    case CredentialFormatCodes.H1030437Bit:
                        parameters.SearchCredential.CardNumber = e.Data.HIDH1030437BitData.FCC;
                        parameters.SearchCredential.H1030437Bit.FacilityCode =
                            (int)e.Data.HIDH1030437BitData.FacilityCode;
                        parameters.SearchCredential.H1030437Bit.IdCode =
                            (int)e.Data.HIDH1030437BitData.IDCode;
                        break;

                    case CredentialFormatCodes.H1030237Bit:
                        parameters.SearchCredential.CardNumber = e.Data.HIDH1030237BitData.FCC;
                        parameters.SearchCredential.H1030237Bit.IdCode = e.Data.HIDH1030237BitData.IdCode;
                        break;

                    case CredentialFormatCodes.SoftwareHouse37Bit:
                        parameters.SearchCredential.CardNumber = e.Data.SoftwareHouse37BitData.FCC;
                        parameters.SearchCredential.SoftwareHouse37Bit.FacilityCode = e.Data.SoftwareHouse37BitData.FacilityCode;
                        parameters.SearchCredential.SoftwareHouse37Bit.SiteCode = e.Data.SoftwareHouse37BitData.SiteCode;
                        parameters.SearchCredential.SoftwareHouse37Bit.IdCode = e.Data.SoftwareHouse37BitData.IdCode;
                        break;

                    case CredentialFormatCodes.PIV75Bit:
                        parameters.SearchCredential.CardNumber = e.Data.PIV75Data.FCC;
                        parameters.SearchCredential.PIV75Bit.AgencyCode = (int)e.Data.PIV75Data.AgencyCode;
                        parameters.SearchCredential.PIV75Bit.SiteCode = (int)e.Data.PIV75Data.SiteCode;
                        parameters.SearchCredential.PIV75Bit.CredentialCode =
                            (int)e.Data.PIV75Data.Credential;
                        break;

                    case CredentialFormatCodes.Bqt36Bit:
                        parameters.SearchCredential.CardNumber = e.Data.BQT36Data.FCC;
                        parameters.SearchCredential.Bqt36Bit.FacilityCode =
                            (short)e.Data.BQT36Data.FacilityCode;
                        parameters.SearchCredential.Bqt36Bit.IdCode = (int)e.Data.BQT36Data.IDCode;
                        parameters.SearchCredential.Bqt36Bit.IssueCode = (short)e.Data.BQT36Data.IssueNumber;
                        break;

                    case CredentialFormatCodes.None:
                        break;
                }

            }

            var mgr = _clientServices.GetManager<PersonManager>();
            var searchResults = await mgr.SearchAsync(parameters);

            if (mgr.HasErrors)
            {
                base.AddCustomErrors(mgr.Errors, true);
            }
            else
            {
                if (searchResults != null && searchResults.Count > 0)
                {
                    var p = searchResults.FirstOrDefault();
                    if (p != null)
                    {
                        if (p.PersonUid != this.Person.PersonUid)
                        {
                            IsBusy = false;
                            Application.Current.Dispatcher.Invoke(() =>
                            {
                                var content = new ucDuplicateCredentialPersonSummary();
                                content.DataContext = p;
                                RadWindow.Alert(new DialogParameters()
                                {
                                    Header = GalaxySMS.Resources.Resources.PersonEditor_DuplicateCredentialAlertHeader,
                                    Content = content
                                });
                            });
                            return;
                        }
                    }

                }

            }
            IsBusy = false;

            selectedCredential.Credential.CredentialFormat = f;
            selectedCredential.Credential.CredentialFormatUid = f.CredentialFormatUid;
            var desc = selectedCredential.CredentialDescription;

            switch (e.Data.DataFormat)
            {
                case CredentialFormatCodes.NumericCardCode:
                case CredentialFormatCodes.MagneticStripeBarcodeAba:
                case CredentialFormatCodes.GalaxyKeypad:
                case CredentialFormatCodes.BasIpQr:
                case CredentialFormatCodes.BtFarpointeConektMobile:
                case CredentialFormatCodes.BtHidMobileAccess:
                case CredentialFormatCodes.BtStidMobileId:
                case CredentialFormatCodes.BtAllegion:
                case CredentialFormatCodes.BtBasIp:
                    selectedCredential.Credential.CardNumber = e.Data.FullCardCode;
                    if (string.IsNullOrEmpty(desc))
                        selectedCredential.CredentialDescription = selectedCredential.Credential.CardNumber;
                    break;

                case CredentialFormatCodes.Standard26Bit:
                    selectedCredential.Credential.Standard26Bit.FacilityCode = (short)e.Data.Wiegand26Data.FacilityCode;
                    selectedCredential.Credential.Standard26Bit.IdCode = e.Data.Wiegand26Data.IDCode;
                    if (string.IsNullOrEmpty(desc))
                        selectedCredential.CredentialDescription = selectedCredential.Credential.Standard26Bit.IdCode.ToString();
                    break;

                case CredentialFormatCodes.Corporate1K35Bit:
                    selectedCredential.Credential.Corporate1K35Bit.CompanyCode = (int)e.Data.Wiegand35HIDCorporate1000Data.CompanyCode;
                    selectedCredential.Credential.Corporate1K35Bit.IdCode = (int)e.Data.Wiegand35HIDCorporate1000Data.IDCode;
                    if (string.IsNullOrEmpty(desc))
                        selectedCredential.CredentialDescription = selectedCredential.Credential.Corporate1K35Bit.IdCode.ToString();
                    break;

                case CredentialFormatCodes.Corporate1K48Bit:
                    selectedCredential.Credential.Corporate1K48Bit.CompanyCode = (int)e.Data.Wiegand48HIDCorporate1000Data.CompanyCode;
                    selectedCredential.Credential.Corporate1K48Bit.IdCode = (int)e.Data.Wiegand48HIDCorporate1000Data.IDCode;
                    if (string.IsNullOrEmpty(desc))
                        selectedCredential.CredentialDescription = selectedCredential.Credential.Corporate1K48Bit.IdCode.ToString();
                    break;

                case CredentialFormatCodes.USGovernmentID:
                    selectedCredential.Credential.CardNumber = e.Data.RawData;
                    if (string.IsNullOrEmpty(desc))
                        selectedCredential.CredentialDescription = CredentialFormatCodes.USGovernmentID.ToString();
                    break;

                case CredentialFormatCodes.XceedId40Bit:
                    //selectedCredential.Credential.CredentialXceedId40Bit.SiteCode = (int)e.Data.CustomData.Value1;
                    //selectedCredential.Credential.CredentialXceedId40Bit.IdCode = (int)e.Data.CustomData.Value2;
                    //if (string.IsNullOrEmpty(desc))
                    //    selectedCredential.CredentialDescription = selectedCredential.Credential.CredentialXceedId40Bit.IdCode.ToString();
                    selectedCredential.Credential.XceedId40Bit.SiteCode = (int)e.Data.XceedId40BitData.SiteCode;
                    selectedCredential.Credential.XceedId40Bit.IdCode = (int)e.Data.XceedId40BitData.IDCode;
                    if (string.IsNullOrEmpty(desc))
                        selectedCredential.CredentialDescription = selectedCredential.Credential.XceedId40Bit.IdCode.ToString();
                    break;

                case CredentialFormatCodes.Cypress37Bit:
                    //selectedCredential.Credential.CredentialCypress37Bit.FacilityCode = (int)e.Data.CustomData.Value1;
                    //selectedCredential.Credential.CredentialCypress37Bit.IdCode = (int)e.Data.CustomData.Value2;
                    //if (string.IsNullOrEmpty(desc))
                    //    selectedCredential.CredentialDescription = selectedCredential.Credential.CredentialCypress37Bit.IdCode.ToString();
                    selectedCredential.Credential.Cypress37Bit.FacilityCode = (int)e.Data.Cypress37BitData.FacilityCode;
                    selectedCredential.Credential.Cypress37Bit.IdCode = (int)e.Data.Cypress37BitData.IDCode;
                    if (string.IsNullOrEmpty(desc))
                        selectedCredential.CredentialDescription = selectedCredential.Credential.Cypress37Bit.IdCode.ToString();
                    break;

                case CredentialFormatCodes.H1030437Bit:
                    selectedCredential.Credential.H1030437Bit.FacilityCode = (int)e.Data.HIDH1030437BitData.FacilityCode;
                    selectedCredential.Credential.H1030437Bit.IdCode = (int)e.Data.HIDH1030437BitData.IDCode;
                    if (string.IsNullOrEmpty(desc))
                        selectedCredential.CredentialDescription = selectedCredential.Credential.H1030437Bit.IdCode.ToString();
                    break;

                case CredentialFormatCodes.H1030237Bit:
                    selectedCredential.Credential.H1030237Bit.IdCode = e.Data.HIDH1030237BitData.IdCode;
                    if (string.IsNullOrEmpty(desc))
                        selectedCredential.CredentialDescription = selectedCredential.Credential.H1030237Bit.IdCode.ToString();
                    break;

                case CredentialFormatCodes.SoftwareHouse37Bit:
                    selectedCredential.Credential.SoftwareHouse37Bit.FacilityCode = e.Data.SoftwareHouse37BitData.FacilityCode;
                    selectedCredential.Credential.SoftwareHouse37Bit.SiteCode = e.Data.SoftwareHouse37BitData.SiteCode;
                    selectedCredential.Credential.SoftwareHouse37Bit.IdCode = e.Data.SoftwareHouse37BitData.IdCode;
                    if (string.IsNullOrEmpty(desc))
                        selectedCredential.CredentialDescription = selectedCredential.Credential.SoftwareHouse37Bit.IdCode.ToString();
                    break;

                case CredentialFormatCodes.PIV75Bit:
                    selectedCredential.Credential.PIV75Bit.AgencyCode = (int)e.Data.PIV75Data.AgencyCode;
                    selectedCredential.Credential.PIV75Bit.SiteCode = (int)e.Data.PIV75Data.SiteCode;
                    selectedCredential.Credential.PIV75Bit.CredentialCode = (int)e.Data.PIV75Data.Credential;
                    if (string.IsNullOrEmpty(desc))
                        selectedCredential.CredentialDescription = selectedCredential.Credential.PIV75Bit.CredentialCode.ToString();
                    break;

                case CredentialFormatCodes.Bqt36Bit:
                    selectedCredential.Credential.Bqt36Bit.FacilityCode = (short)e.Data.BQT36Data.FacilityCode;
                    selectedCredential.Credential.Bqt36Bit.IdCode = (int)e.Data.BQT36Data.IDCode;
                    selectedCredential.Credential.Bqt36Bit.IssueCode = (short)e.Data.BQT36Data.IssueNumber;
                    if (string.IsNullOrEmpty(desc))
                        selectedCredential.CredentialDescription = selectedCredential.Credential.Bqt36Bit.IdCode.ToString();
                    break;

                case CredentialFormatCodes.None:
                    break;
            }
        }

        #endregion

        public void OnEntityMapChecked(UserEntitySelect obj)
        {
            _Person.MakeDirty();
        }
        #region Implementation of ISupportsUserEntitySelection

        public string EntityAlias
        {
            get { return _clientServices.EntityAlias; }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                    value = CommonResources.Resources.DefaultEntityAlias;
                if (_clientServices.EntityAlias != value)
                {
                    _clientServices.EntityAlias = value;
                    OnPropertyChanged(() => EntityAlias, false);
                }
            }
        }

        public string EntityAliasPlural
        {
            get { return _clientServices.EntityAliasPlural; }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                    value = CommonResources.Resources.DefaultEntityAliasPlural;
                if (_clientServices.EntityAliasPlural != value)
                {
                    _clientServices.EntityAliasPlural = value;
                    OnPropertyChanged(() => EntityAliasPlural, false);
                }
            }
        }

        private string _selectEntityHeaderText;

        public string SelectEntityHeaderText
        {
            get { return _selectEntityHeaderText; }
            set
            {
                if (_selectEntityHeaderText != value)
                {
                    _selectEntityHeaderText = value;
                    OnPropertyChanged(() => SelectEntityHeaderText, false);
                }
            }
        }

        private string _selectEntityHeaderToolTip;

        public string SelectEntityHeaderToolTip
        {
            get { return _selectEntityHeaderToolTip; }
            set
            {
                if (_selectEntityHeaderToolTip != value)
                {
                    _selectEntityHeaderToolTip = value;
                    OnPropertyChanged(() => SelectEntityHeaderToolTip, false);
                }
            }
        }

        public UserSessionToken UserSessionToken
        {
            get { return _clientServices?.UserSessionToken; }
        }


        public ICollection<UserEntitySelect> UserEntitiesSelectionList
        {
            get { return _userEntitiesSelectionList; }
            internal set
            {
                _userEntitiesSelectionList = value;
                OnPropertyChanged(() => UserEntitiesSelectionList, false);
            }
        }

        #endregion

    }

}