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

            CanChangeApplication = true;
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

        private bool _CanChangeApplication;
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

        public gcsApplication CurrentApplication
        {
            get
            {
                return (from a in Globals.Instance.Applications
                        where a.ApplicationId == Role.EntityId
                        select a).FirstOrDefault();
            }
        }


        private ObservableCollection<gcsPermissionCategory> _Permissions;

        public ObservableCollection<gcsPermissionCategory> Permissions
        {
            get
            {
                return _Permissions;
            }
            set
            {
                if (_Permissions != value)
                {
                    _Permissions = value;
                    OnPropertyChanged(() => Permissions);
                }
            }
        }

        async Task InitializePermissionCollections()
        {
            Globals.Instance.IsBusy = true;
            Permissions = CurrentApplication.gcsPermissionCategories.OrderBy(category => category.CategoryName).ToObservableCollection();
            var permissionIds = Role.RolePermissions.Select(item => item.PermissionId).ToList();
            foreach (var permissionCategory in Permissions)
            {
                foreach (var permission in permissionCategory.gcsPermissions)
                {
                    permission.RoleHasPermission = permissionIds.Contains(permission.PermissionId);
                    permission.CleanAll();
                }
                permissionCategory.CleanAll();
            }

            EditingData = await _RoleManager.GetRoleEditingDataAsync(new GetParametersWithPhoto() { UniqueId = this.Role.RoleId, IncludePhoto = true, PhotoPixelWidth = 200, IncludeMemberCollections = true });

            foreach (var ef in EditingData.FilterData.EntityFilters)
            {
                foreach (var r in ef.Regions)
                {
                    foreach (var s in r.Sites)
                    {
                        foreach (var c in s.Clusters)
                        {
                            var roleCluster = Role.Clusters.FirstOrDefault(o => o.ClusterUid == c.ClusterUid);
                            if (roleCluster != null)
                            {
                                c.RoleIncludesItem = true;
                            }

                            foreach (var ap in c.AccessPortals)
                            {
                                var roleAp = Role.AccessPortals.FirstOrDefault(o => o.AccessPortalUid == ap.AccessPortalUid);
                                if (roleAp != null)
                                {
                                    ap.RoleIncludesItem = true;
                                }
                            }
                            foreach (var id in c.InputDevices)
                            {
                                var roleId = Role.InputDevices.FirstOrDefault(o => o.InputDeviceUid == id.InputDeviceUid);
                                if (roleId != null)
                                {
                                    id.RoleIncludesItem = true;
                                }
                            }
                            foreach (var od in c.OutputDevices)
                            {
                                var roleOd = Role.OutputDevices.FirstOrDefault(o => o.OutputDeviceUid == od.OutputDeviceUid);
                                if (roleOd != null)
                                {
                                    od.RoleIncludesItem = true;
                                }
                            }
                            foreach (var iog in c.InputOutputGroups)
                            {
                                var roleIog = Role.InputOutputGroups.FirstOrDefault(o => o.InputOutputGroupUid == iog.InputOutputGroupUid);
                                if (roleIog != null)
                                {
                                    iog.RoleIncludesItem = true;
                                }
                            }
                        }
                    }
                }
            }

            Globals.Instance.IsBusy = false;
        }

        private ApplicationRoleEditingData _EditingData;

        public ApplicationRoleEditingData EditingData
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

        public bool CanChangeApplication
        {
            get
            {
                return _CanChangeApplication;
            }
            set
            {
                if (_CanChangeApplication != value)
                {
                    _CanChangeApplication = value;
                    OnPropertyChanged(() => CanChangeApplication);
                }
            }
        }
        public ObservableCollection<gcsApplication> Applications
        { get { return Globals.Instance.Applications; } }

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

            foreach (var permissionCategory in Permissions)
            {
                foreach (var permission in permissionCategory.gcsPermissions)
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

        private void OnAccessPortalChecked(AccessPortalSelectionItemBasic ap)
        {
            if (ap != null)
            {
                _Role.MakeDirty();

                var roleAp = Role.AccessPortals.FirstOrDefault(o => o.AccessPortalUid == ap.AccessPortalUid);
                if (ap.RoleIncludesItem)
                {

                    if (roleAp == null)
                    {
                        roleAp = new RoleAccessPortal() { AccessPortalUid = ap.AccessPortalUid };
                        Role.AccessPortals.Add(roleAp);
                    }
                }
                else
                {
                    if (roleAp != null)
                    {
                        Role.AccessPortals.Remove(roleAp);
                    }
                }
            }
        }

        private void OnInputDeviceChecked(InputDeviceSelectionItemBasic id)
        {
            if (id != null)
            {
                _Role.MakeDirty();

                var roleId = Role.InputDevices.FirstOrDefault(o => o.InputDeviceUid == id.InputDeviceUid);
                if (id.RoleIncludesItem)
                {

                    if (roleId == null)
                    {
                        roleId = new RoleInputDevice() { InputDeviceUid = id.InputDeviceUid };
                        Role.InputDevices.Add(roleId);
                    }
                }
                else
                {
                    if (roleId != null)
                    {
                        Role.InputDevices.Remove(roleId);
                    }
                }
            }
        }

        private void OnOutputDeviceChecked(OutputDeviceSelectionItemBasic od)
        {
            if (od != null)
            {
                _Role.MakeDirty();

                var roleOd = Role.OutputDevices.FirstOrDefault(o => o.OutputDeviceUid == od.OutputDeviceUid);
                if (od.RoleIncludesItem)
                {

                    if (roleOd == null)
                    {
                        roleOd = new RoleOutputDevice() { OutputDeviceUid = od.OutputDeviceUid };
                        Role.OutputDevices.Add(roleOd);
                    }
                }
                else
                {
                    if (roleOd != null)
                    {
                        Role.OutputDevices.Remove(roleOd);
                    }
                }
            }
        }

        private void OnInputOutputGroupChecked(InputOutputGroupSelectionItemBasic iog)
        {
            if (iog != null)
            {
                _Role.MakeDirty();

                var roleIog = Role.InputOutputGroups.FirstOrDefault(o => o.InputOutputGroupUid == iog.InputOutputGroupUid);
                if (iog.RoleIncludesItem)
                {
                    if (roleIog == null)
                    {
                        roleIog = new RoleInputOutputGroup() { InputOutputGroupUid = iog.InputOutputGroupUid };
                        Role.InputOutputGroups.Add(roleIog);
                    }
                }
                else
                {
                    if (roleIog != null)
                    {
                        Role.InputOutputGroups.Remove(roleIog);
                    }
                }
            }
        }

        private void OnClusterChecked(ClusterSelectionItemBasic c)
        {
            if (c != null)
            {
                _Role.MakeDirty();

                var roleC = Role.Clusters.FirstOrDefault(o => o.ClusterUid == c.ClusterUid);
                if (c.RoleIncludesItem)
                {

                    if (roleC == null)
                    {
                        roleC = new RoleCluster() { ClusterUid = c.ClusterUid };
                        Role.Clusters.Add(roleC);
                    }
                }
                else
                {
                    if (roleC != null)
                    {
                        Role.Clusters.Remove(roleC);
                    }
                }
            }
        }



    }
}
