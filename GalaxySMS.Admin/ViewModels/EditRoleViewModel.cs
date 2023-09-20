using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using GalaxySMS.Admin.Support;
using GalaxySMS.Client.Entities;
using GalaxySMS.Client.SDK;
using GalaxySMS.Client.SDK.Managers;
using GCS.Core.Common;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;
using GCS.Core.Common.Logger;
using GCS.Core.Common.UI.Core;

namespace GalaxySMS.Admin.ViewModels
{
    public class EditRoleViewModel : ViewModelBase
    {
        public EditRoleViewModel(IServiceFactory serviceFactory, gcsRole role)
        {
            _ServiceFactory = serviceFactory;
            _Role = new gcsRole(role);
            _Role.CleanAll();

            CanChangeEntity = true;
            SaveCommand = new DelegateCommand<object>(OnSaveCommandExecute, OnSaveCommandCanExecute);
            CancelCommand = new DelegateCommand<object>(OnCancelCommandExecute);
            PermissionChecked = new DelegateCommand<object>(OnPermissionChecked);
            AccessPortalChecked = new DelegateCommand<AccessPortalSelectionItemBasic>(OnAccessPortalChecked);
            InputDeviceChecked = new DelegateCommand<InputDeviceSelectionItemBasic>(OnInputDeviceChecked);
            OutputDeviceChecked = new DelegateCommand<OutputDeviceSelectionItemBasic>(OnOutputDeviceChecked);
            InputOutputGroupChecked = new DelegateCommand<InputOutputGroupSelectionItemBasic>(OnInputOutputGroupChecked);
            ClusterChecked = new DelegateCommand<ClusterSelectionItemBasic>(OnClusterChecked);

            _RoleManager = new RoleManager(Globals.Instance.ServerConnections[0]);
            _RoleManager.SaveRoleCompletedEvent += RoleManager_OnSaveRoleCompletedEvent;
            _RoleManager.ErrorsOccurredEvent += RoleManager_OnErrorsOccurredEvent;

            InitializePermissionCollections();
        }


        private void RoleManager_OnErrorsOccurredEvent(object sender, ErrorsOccurredEventArgs e)
        {
            foreach (CustomError error in e.Errors)
            {
                AddCustomError(error);
            }
        }

        private void RoleManager_OnSaveRoleCompletedEvent(object sender, SaveRoleCompletedEventArgs e)
        {
            App.Current.Dispatcher.Invoke((Action)delegate
            {
                if (e.Role != null)
                {
                    if (RoleUpdated != null)
                    {
                        Role = e.Role;
                        RoleUpdated(this, new RoleEventArgs(e.Role, e.IsNew));
                    }
                }
            });
        }

        private bool _CanChangeEntity;
        IServiceFactory _ServiceFactory;
        gcsRole _Role;
        RoleManager _RoleManager;

        public DelegateCommand<object> SaveCommand { get; private set; }
        public DelegateCommand<object> CancelCommand { get; private set; }
        public DelegateCommand<object> PermissionChecked { get; private set; }
        public DelegateCommand<AccessPortalSelectionItemBasic> AccessPortalChecked { get; private set; }
        public DelegateCommand<InputDeviceSelectionItemBasic> InputDeviceChecked { get; private set; }
        public DelegateCommand<OutputDeviceSelectionItemBasic> OutputDeviceChecked { get; private set; }
        public DelegateCommand<InputOutputGroupSelectionItemBasic> InputOutputGroupChecked { get; private set; }
        public DelegateCommand<ClusterSelectionItemBasic> ClusterChecked { get; private set; }

        public event EventHandler CancelEditRole;
        public event EventHandler<RoleEventArgs> RoleUpdated;

        public gcsRole Role
        {
            get { return _Role; }
            internal set
            {
                if (_Role != value)
                {
                    _Role = value;
                    OnPropertyChanged(() => Role);
                }
            }
        }

        public gcsEntityEx CurrentEntity
        {
            get
            {
                return (from a in Globals.Instance.Entities
                        where a.EntityId == Role.EntityId
                        select a).FirstOrDefault();
            }
        }


        private ObservableCollection<gcsApplicationPermissionsMinimal> _ApplicationPermissions;

        public ObservableCollection<gcsApplicationPermissionsMinimal> ApplicationPermissions
        {
            get
            {
                return _ApplicationPermissions;
            }
            set
            {
                if (_ApplicationPermissions != value)
                {
                    _ApplicationPermissions = value;
                    OnPropertyChanged(() => ApplicationPermissions);
                }
            }
        }

        async Task InitializePermissionCollections()
        {
            Globals.Instance.IsBusy = true;
            try
            {

            var getParams = new GetParametersWithPhoto()
            {
                UniqueId = this.Role.EntityId, IncludePhoto = true, PhotoPixelWidth = 200,
                RefreshCache = true,
                IncludeMemberCollections = true
            };
            getParams.ExcludeMemberCollectionSettings.Add(nameof(ClusterSelectionItemBasic.AccessGroups));
            getParams.ExcludeMemberCollectionSettings.Add(nameof(ClusterSelectionItemBasic.TimeSchedules));
            EditingData = await _RoleManager.GetRoleEditingDataAsync(getParams);
            if (EditingData?.ApplicationPermissions == null)
            {
                Globals.Instance.IsBusy = false;
                return;
            }

            ApplicationPermissions = EditingData.ApplicationPermissions.OrderBy(category => category.ApplicationName).ToObservableCollection();
            var permissionIds = Role.RolePermissions.Select(item => item.PermissionId).ToList();

            var canRunFacMgr = permissionIds.FirstOrDefault(o =>
                o == GalaxySMS.Common.Constants.PermissionIds.CanExecuteIds.GalaxySMS_FacilityManager_CanExecuteId);
            var canRunAdminMgr = permissionIds.FirstOrDefault(o =>
                o == GalaxySMS.Common.Constants.PermissionIds.CanExecuteIds.GalaxySMS_Admin_CanExecuteId);
            var personEditingPerm = permissionIds.FirstOrDefault(o =>
                o == GalaxySMS.Common.Constants.PermissionIds.GalaxySMSDataAccessPermission.PersonnelCanAddId);

                foreach (var applicationPermissionCategory in ApplicationPermissions)
            {
                foreach (var permissionCategory in applicationPermissionCategory.PermissionCategories)
                {
                    foreach (var permission in permissionCategory.Permissions)
                    {
                        permission.RoleHasPermission = permissionIds.Contains(permission.PermissionId);
                        permission.CleanAll();
                    }
                    permissionCategory.CleanAll();
                }
            }


            //foreach (var ef in EditingData.FilterData)
            //{
            //    foreach (var r in ef.Regions)
            //    {
            //        foreach (var s in r.Sites)
            //        {
            //            foreach (var c in s.Clusters)
            //            {
            //                var roleCluster = Role.DeviceFilters.Clusters.FirstOrDefault(o => o.ClusterUid == c.ClusterUid);
            //                if (roleCluster != null)
            //                {
            //                    c.RoleIncludesItem = true;

            //                    foreach (var ap in c.AccessPortals)
            //                    {
            //                        var roleAp = roleCluster.AccessPortals.FirstOrDefault(o => o.AccessPortalUid == ap.AccessPortalUid);
            //                        if (roleAp != null)
            //                        {
            //                            ap.RoleIncludesItem = true;
            //                        }
            //                    }
            //                    foreach (var id in c.InputDevices)
            //                    {
            //                        var roleId = roleCluster.InputDevices.FirstOrDefault(o => o.InputDeviceUid == id.InputDeviceUid);
            //                        if (roleId != null)
            //                        {
            //                            id.RoleIncludesItem = true;
            //                        }
            //                    }
            //                    foreach (var od in c.OutputDevices)
            //                    {
            //                        var roleOd = roleCluster.OutputDevices.FirstOrDefault(o => o.OutputDeviceUid == od.OutputDeviceUid);
            //                        if (roleOd != null)
            //                        {
            //                            od.RoleIncludesItem = true;
            //                        }
            //                    }
            //                    foreach (var iog in c.InputOutputGroups)
            //                    {
            //                        var roleIog = roleCluster.InputOutputGroups.FirstOrDefault(o => o.InputOutputGroupUid == iog.InputOutputGroupUid);
            //                        if (roleIog != null)
            //                        {
            //                            iog.RoleIncludesItem = true;
            //                        }
            //                    }
            //                }

            //            }
            //        }
            //    }
            //}

            foreach (var r in EditingData.FilterData.Regions)
            {
                this.Log().Info($"{r.RegionName}");
                var roleRegion = Role.DeviceFilters.Regions.FirstOrDefault(o => o.RegionUid == r.RegionUid);
                if (roleRegion == null)
                {
                    roleRegion = new RoleRegion()
                    {
                        RegionUid = r.RegionUid,
                        IncludeAllSites = false
                    };
                    Role.DeviceFilters.Regions = Role.DeviceFilters.Regions.ToCollection();
                    Role.DeviceFilters.Regions.Add(roleRegion);
                }

                foreach (var s in r.Sites)
                {
                    this.Log().Info($"{s.SiteName}");
                    var roleSite = roleRegion.Sites.FirstOrDefault(o => o.SiteUid == s.SiteUid);
                    if (roleSite == null)
                    {
                        roleSite = new RoleSite() { SiteUid = s.SiteUid, IncludeAllClusters = false };
                        roleRegion.Sites = roleRegion.Sites.ToCollection();
                        roleRegion.Sites.Add(roleSite);
                    }

                    foreach (var c in s.Clusters)
                    {
                        this.Log().Info($"{c.ClusterName}");

                        var roleCluster = roleSite.Clusters.FirstOrDefault(o => o.ClusterUid == c.ClusterUid);
                        if (roleCluster == null)
                        {
                            roleCluster = new RoleCluster()
                            {
                                ClusterUid = c.ClusterUid,
                            };
                            roleSite.Clusters = roleSite.Clusters.ToCollection();
                            roleSite.Clusters.Add(roleCluster);

                        }

                        r.RoleIncludesItem = true;
                        s.RoleIncludesItem = true;
                        c.RoleIncludesItem = true;

                        foreach (var ap in c.AccessPortals)
                        {
                            this.Log().Info($"{ap.AccessPortalName}");

                            var roleAp = roleCluster.AccessPortals.FirstOrDefault(o => o.AccessPortalUid == ap.AccessPortalUid);
                            if (roleAp != null)
                            {
                                r.RoleIncludesItem = true;
                                s.RoleIncludesItem = true;
                                c.RoleIncludesItem = true;
                                ap.RoleIncludesItem = true;
                            }
                        }
                        foreach (var id in c.InputDevices)
                        {
                            this.Log().Info($"{id.InputName}");
                            var roleId = roleCluster.InputDevices.FirstOrDefault(o => o.InputDeviceUid == id.InputDeviceUid);
                            if (roleId != null)
                            {
                                r.RoleIncludesItem = true;
                                s.RoleIncludesItem = true;
                                c.RoleIncludesItem = true;
                                id.RoleIncludesItem = true;
                            }
                        }
                        foreach (var od in c.OutputDevices)
                        {
                            this.Log().Info($"{od.OutputName}");
                            var roleOd = roleCluster.OutputDevices.FirstOrDefault(o => o.OutputDeviceUid == od.OutputDeviceUid);
                            if (roleOd != null)
                            {
                                r.RoleIncludesItem = true;
                                s.RoleIncludesItem = true;
                                c.RoleIncludesItem = true;
                                od.RoleIncludesItem = true;
                            }
                        }
                        foreach (var iog in c.InputOutputGroups)
                        {
                            this.Log().Info($"{iog.InputOutputGroupName}");
                            var roleIog = roleCluster.InputOutputGroups.FirstOrDefault(o => o.InputOutputGroupUid == iog.InputOutputGroupUid);
                            if (roleIog != null)
                            {
                                r.RoleIncludesItem = true;
                                s.RoleIncludesItem = true;
                                c.RoleIncludesItem = true;
                                iog.RoleIncludesItem = true;
                            }
                        }
                    }
                }
            }
            }
            catch (Exception e)
            {
                AddCustomError(new CustomError(e));
                this.Log().Error(e.ToString());
            }

            Globals.Instance.IsBusy = false;
        }

        private EntityRoleEditingData _EditingData;

        public EntityRoleEditingData EditingData
        {
            get { return _EditingData; }
            set
            {
                if (_EditingData != value)
                {
                    _EditingData = value;
                    OnPropertyChanged(() => EditingData, true);
                }
            }
        }

        public bool CanChangeEntity
        {
            get
            {
                return _CanChangeEntity;
            }
            set
            {
                if (_CanChangeEntity != value)
                {
                    _CanChangeEntity = value;
                    OnPropertyChanged(() => CanChangeEntity);
                }
            }
        }
        public ObservableCollection<gcsEntityEx> Entities
        { get { return Globals.Instance.Entities; } }

        protected override void AddModels(List<ObjectBase> models)
        {
            models.Add(Role);
        }

        void OnSaveCommandExecute(object arg)
        {
            ValidateModel();

            if (IsValid)
            {
                UpdateRolePermissions();
                bool isNew = (_Role.RoleId == Guid.Empty);
                var saveParams = new SaveParameters<gcsRole>(_Role);
                if (UseAsyncServiceCalls == false)
                {
                    var savedRole = _RoleManager.SaveRole(saveParams);
                    if (savedRole != null)
                    {
                        RoleUpdated?.Invoke(this, new RoleEventArgs(savedRole, isNew));
                    }
                }
                else
                {
                    _RoleManager.SaveRoleAsync(saveParams);
                }

            }
        }

        private void UpdateRolePermissions()
        {
            var rolePermissions = Role.RolePermissions.ToList();

            foreach (var applicationPermissions in ApplicationPermissions)
            {
                foreach (var permissionCategory in applicationPermissions.PermissionCategories)
                {
                    foreach (var permission in permissionCategory.Permissions)
                    {
                        if (permission.IsDirty)
                        {
                            //rolePermissions.Select(item => item.PermissionId == permission.PermissionId);
                            var rolePermission = (from rp in rolePermissions
                                                  where rp.PermissionId == permission.PermissionId
                                                  select rp).FirstOrDefault();
                            if (permission.RoleHasPermission)
                            {
                                if (rolePermission == null)
                                {
                                    rolePermissions.Add(new gcsRolePermission()
                                    {
                                        PermissionId = permission.PermissionId
                                    });
                                }
                            }
                            else
                            {
                                if (rolePermission != null)
                                {
                                    rolePermissions.Remove(rolePermission);
                                }
                            }
                        }
                    }
                }
            }

            Role.RolePermissions = rolePermissions.ToCollection();
        }

        bool OnSaveCommandCanExecute(object arg)
        {
            return _Role.IsDirty;
        }

        void OnCancelCommandExecute(object arg)
        {
            if (CancelEditRole != null)
                CancelEditRole(this, EventArgs.Empty);
        }

        private void OnPermissionChecked(object obj)
        {
            _Role.MakeDirty();
        }

        private RoleCluster GetRoleFiltersRoleCluster(Guid clusterUid)
        {
            foreach (var region in Role?.DeviceFilters?.Regions)
            {
                foreach (var site in region?.Sites)
                {
                    var roleCluster = site?.Clusters.FirstOrDefault(o => o.ClusterUid == clusterUid);
                    if (roleCluster != null)
                        return roleCluster;
                }
            }

            return null;
        }

        private RoleSite GetRoleFiltersRoleSite(Guid siteUid)
        {
            foreach (var region in Role?.DeviceFilters?.Regions)
            {
                    var roleSite = region?.Sites.FirstOrDefault(o => o.SiteUid == siteUid);
                    if (roleSite != null)
                        return roleSite;
            }

            return null;
        }

        private void OnAccessPortalChecked(AccessPortalSelectionItemBasic ap)
        {
            if (ap != null)
            {
                _Role.MakeDirty();
                var roleCluster = GetRoleFiltersRoleCluster( ap.ClusterUid);
                if (roleCluster != null)
                {
                    var roleAp = roleCluster.AccessPortals.FirstOrDefault(o => o.AccessPortalUid == ap.AccessPortalUid);
                    if (ap.RoleIncludesItem)
                    {

                        if (roleAp == null)
                        {
                            roleAp = new RoleAccessPortal() { AccessPortalUid = ap.AccessPortalUid };
                            roleCluster.AccessPortals.Add(roleAp);
                        }
                    }
                    else
                    {
                        if (roleAp != null)
                        {
                            roleCluster.AccessPortals.Remove(roleAp);
                        }
                    }
                }
            }
        }

        private void OnInputDeviceChecked(InputDeviceSelectionItemBasic id)
        {
            if (id != null)
            {
                _Role.MakeDirty();
                var roleCluster = GetRoleFiltersRoleCluster(id.ClusterUid);
                if (roleCluster != null)
                {
                    var roleId = roleCluster.InputDevices.FirstOrDefault(o => o.InputDeviceUid == id.InputDeviceUid);
                    if (id.RoleIncludesItem)
                    {

                        if (roleId == null)
                        {
                            roleId = new RoleInputDevice() { InputDeviceUid = id.InputDeviceUid };
                            roleCluster.InputDevices.Add(roleId);
                        }
                    }
                    else
                    {
                        if (roleId != null)
                        {
                            roleCluster.InputDevices.Remove(roleId);
                        }
                    }
                }
            }
        }

        private void OnOutputDeviceChecked(OutputDeviceSelectionItemBasic od)
        {
            if (od != null)
            {
                _Role.MakeDirty();
                var roleCluster = GetRoleFiltersRoleCluster(od.ClusterUid);
                if (roleCluster != null)
                {
                    var roleOd = roleCluster.OutputDevices.FirstOrDefault(o => o.OutputDeviceUid == od.OutputDeviceUid);
                    if (od.RoleIncludesItem)
                    {

                        if (roleOd == null)
                        {
                            roleOd = new RoleOutputDevice() { OutputDeviceUid = od.OutputDeviceUid };
                            roleCluster.OutputDevices.Add(roleOd);
                        }
                    }
                    else
                    {
                        if (roleOd != null)
                        {
                            roleCluster.OutputDevices.Remove(roleOd);
                        }
                    }
                }
            }
        }

        private void OnInputOutputGroupChecked(InputOutputGroupSelectionItemBasic iog)
        {
            if (iog != null)
            {
                _Role.MakeDirty();
                var roleCluster = GetRoleFiltersRoleCluster(iog.ClusterUid);
                if (roleCluster != null)
                {
                    var roleIog =
                        roleCluster.InputOutputGroups.FirstOrDefault(o => o.InputOutputGroupUid == iog.InputOutputGroupUid);
                    if (iog.RoleIncludesItem)
                    {
                        if (roleIog == null)
                        {
                            roleIog = new RoleInputOutputGroup() { InputOutputGroupUid = iog.InputOutputGroupUid };
                            roleCluster.InputOutputGroups.Add(roleIog);
                        }
                    }
                    else
                    {
                        if (roleIog != null)
                        {
                            roleCluster.InputOutputGroups.Remove(roleIog);
                        }
                    }
                }
            }
        }

        private void OnClusterChecked(ClusterSelectionItemBasic c)
        {
            if (c != null)
            {
                _Role.MakeDirty();

                var roleCluster = GetRoleFiltersRoleCluster(c.ClusterUid);
                var roleSite = GetRoleFiltersRoleSite(c.SiteUid);
                if (roleSite != null)
                {
                    if (c.RoleIncludesItem)
                    {
                        if (roleCluster == null)
                        {
                            roleCluster = new RoleCluster() {ClusterUid = c.ClusterUid};
                            roleSite.Clusters.Add(roleCluster);
                        }
                    }
                    else
                    {
                        if (roleCluster != null)
                        {
                            roleSite.Clusters.Remove(roleCluster);
                        }
                    }
                }
                else
                {
                    
                }
            }
        }



    }
}
