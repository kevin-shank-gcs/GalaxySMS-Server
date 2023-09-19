using GalaxySMS.Admin.Properties;
using GalaxySMS.Admin.Support;
using GalaxySMS.Client.Entities;
using GalaxySMS.Client.SDK;
using GalaxySMS.Client.SDK.Managers;
using GalaxySMS.Common.Constants;
using GCS.Core.Common;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;
using GCS.Core.Common.UI.Core;
using PDSA.MessageBroker;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;

namespace GalaxySMS.Admin.ViewModels
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class MaintainEntitiesViewModel : ViewModelBase
    {
        [ImportingConstructor]
        public MaintainEntitiesViewModel(IServiceFactory serviceFactory)
        {
            _ServiceFactory = serviceFactory;

            EditCommand = new DelegateCommand<gcsEntity>(OnEditCommand, OnEditCommandCanExecute);
            DeleteCommand = new DelegateCommand<gcsEntity>(OnDeleteCommand, OnDeleteCommandCanExecute);
            AddNewCommand = new DelegateCommand<object>(OnAddNewCommand, OnAddNewCommandCanExecute);
            AddNewChildCommand = new DelegateCommand<gcsEntity>(OnAddNewChildCommand, OnAddNewChildCommandCanExecute);
            AddNewSiblingCommand = new DelegateCommand<gcsEntity>(OnAddNewSiblingCommand, OnAddNewSiblingCommandCanExecute);

            _EntityManager = new EntityManager(Globals.Instance.ServerConnections[0]);
            _EntityManager.GetAllEntitesCompletedEvent += _EntityManager_GetAllEntitesCompletedEvent;
            _EntityManager.DeleteEntityCompletedEvent += _EntityManager_DeleteEntityCompletedEvent;
            _EntityManager.ErrorsOccurredEvent += _EntityManager_ErrorsOccurredEvent;

            Globals.Instance.MessageBroker.MessageReceived += MessageBroker_MessageReceived;
        }

        private void MessageBroker_MessageReceived(object sender, PDSAMessageBrokerEventArgs e)
        {
            // Use this event to receive all messages
            switch (e.MessageName)
            {
                case MessageNames.UserSessionTokenChanged:
                    if (e.MessageObject.MessageBody != null)
                    {
                        _EntityManager.ClientUserSessionData.SessionGuid =
                            ((UserSessionToken)(e.MessageObject.MessageBody)).SessionId;
                    }
                    else
                    {
                        _EntityManager.ClientUserSessionData.SessionGuid = Guid.Empty;
                    }
                    break;

                default:
                    break;
            }
        }

        void _EntityManager_ErrorsOccurredEvent(object sender, ErrorsOccurredEventArgs e)
        {
            App.Current.Dispatcher.Invoke((Action)delegate
           {
               foreach (CustomError error in e.Errors)
               {
                   AddCustomError(error);
               }
               Globals.Instance.IsBusy = false;
           });
        }

        void _EntityManager_DeleteEntityCompletedEvent(object sender, DeleteEntityCompletedEventArgs e)
        {
            App.Current.Dispatcher.Invoke((Action)delegate
           {
               _Entities.Remove(e.Entity);
               Globals.Instance.RefreshEntities();
           });
        }

        private void _EntityManager_GetAllEntitesCompletedEvent(object sender, GetAllEntitiesCompletedEventArgs e)
        {
            App.Current.Dispatcher.Invoke((Action)delegate
            {
                _Entities = new ObservableCollection<gcsEntity>();
                foreach (gcsEntity entity in e.Entities.Items)
                {
                    _Entities.Add(entity);
                }
                OnPropertyChanged(() => Entities, false);
                Globals.Instance.IsBusy = false;
            });
        }

        IServiceFactory _ServiceFactory;

        EditEntityViewModel _CurrentEntityViewModel;

        EntityManager _EntityManager;

        public DelegateCommand<gcsEntity> EditCommand { get; private set; }
        public DelegateCommand<gcsEntity> DeleteCommand { get; private set; }
        public DelegateCommand<object> AddNewCommand { get; private set; }
        public DelegateCommand<gcsEntity> AddNewChildCommand { get; private set; }
        public DelegateCommand<gcsEntity> AddNewSiblingCommand { get; private set; }

        public override string ViewTitle
        {
            get { return Properties.Resources.MaintainEntities_Title; }
        }

        public event CancelMessageEventHandler ConfirmDelete;
        public event EventHandler<ErrorMessageEventArgs> ErrorOccurred;

        public EditEntityViewModel CurrentEntityViewModel
        {
            get { return _CurrentEntityViewModel; }
            set
            {
                if (_CurrentEntityViewModel != value)
                {
                    _CurrentEntityViewModel = value;
                    OnPropertyChanged(() => CurrentEntityViewModel, false);
                }
            }
        }

        ObservableCollection<gcsEntity> _Entities;

        public ObservableCollection<gcsEntity> Entities
        {
            get { return _Entities; }
            set
            {
                if (_Entities != value)
                {
                    _Entities = value;
                    OnPropertyChanged(() => Entities, false);
                }
            }
        }

        private gcsEntity _selectedEntity;

        public gcsEntity SelectedEntity
        {
            get { return _selectedEntity; }
            set
            {
                if (_selectedEntity != value)
                {
                    _selectedEntity = value;
                    OnPropertyChanged(() => SelectedEntity, false);
                }
            }
        }

        protected override async void OnViewLoaded()
        {
            await RefreshEntities();
        }

        private async Task RefreshEntities()
        {
            Globals.Instance.IsBusy = true;
            _Entities = new ObservableCollection<gcsEntity>();

            var parameters = new GetParametersWithPhoto() { PhotoPixelWidth = Settings.Default.ThumbnailWidth };
            parameters.IncludeMemberCollections = true;

            //parameters.ExcludeMemberCollectionSettings.Add(new KeyValuePair<string, bool>(nameof(gcsEntity.UserRequirements), true));
            //parameters.ExcludeMemberCollectionSettings.Add(new KeyValuePair<string, bool>(nameof(gcsEntity.gcsEntityApplications), true));
            //parameters.ExcludeMemberCollectionSettings.Add(new KeyValuePair<string, bool>(nameof(gcsEntity.AllApplications), true));
            //parameters.ExcludeMemberCollectionSettings.Add(new KeyValuePair<string, bool>(nameof(gcsEntity.ParentEntity), true));
            parameters.ExcludeMemberCollectionSettings.Add(nameof(gcsEntity.UserRequirements));
            //parameters.ExcludeMemberCollectionSettings.Add(nameof(gcsEntity.gcsEntityApplications));
            //parameters.ExcludeMemberCollectionSettings.Add(nameof(gcsEntity.AllApplications));
            parameters.ExcludeMemberCollectionSettings.Add(nameof(gcsEntity.ParentEntity));

            parameters.Options.Add(new KeyValuePair<string, bool>(GalaxySMS.Common.Constants.GetOptions.BuildTreeStructure, true));

            if (UseAsyncServiceCalls == false)
            {
                var entities = _EntityManager.GetAllEntities(parameters);
                foreach (var entity in entities.Items)
                    _Entities.Add(entity);
                OnPropertyChanged(() => Entities, false);
                Globals.Instance.IsBusy = false;
            }
            else
            {
                var entities = await _EntityManager.GetAllEntitiesAsync(parameters);

                if (entities != null)
                {
                    foreach (var e in entities.Items.Where(o => o.EntityId != GalaxySMS.Common.Constants.EntityIds.GalaxySMS_SystemEntity_Id).OrderBy(o => o.EntityName))
                    {
                        _Entities.Add(e);
                    }
                }
                OnPropertyChanged(() => Entities, false);
                Globals.Instance.IsBusy = false;
            }
        }

        private bool OnEditCommandCanExecute(gcsEntity obj)
        {
            if (obj == null || CurrentEntityViewModel != null || obj.EntityId == GalaxySMS.Common.Constants.EntityIds.GalaxySMS_SystemEntity_Id)
                return false;

            return true;
        }

        async void OnEditCommand(gcsEntity entity)
        {
            ClearCustomErrors();
            if (entity != null)
            {
                Globals.Instance.IsBusy = true;
                var parameters = new GetParametersWithPhoto() { UniqueId = entity.EntityId };
                parameters.IncludeMemberCollections = true;
                //                parameters.ExcludeMemberCollectionSettings.Add(new System.Collections.Generic.KeyValuePair<string, bool>(nameof(gcsEntity.ChildEntities), true));
                parameters.ExcludeMemberCollectionSettings.Add(nameof(gcsEntity.ChildEntities));

                var fullEntity = await _EntityManager.GetEntityAsync(parameters);
                if (fullEntity != null)
                {
                    CurrentEntityViewModel = new EditEntityViewModel(_ServiceFactory, fullEntity, Globals.Instance.Entities);
                    CurrentEntityViewModel.EntityUpdated += CurrentEntityViewModel_EntityUpdated;
                    CurrentEntityViewModel.CancelEditEntity += CurrentEntityViewModel_CancelEvent;
                }
                Globals.Instance.IsBusy = false;
                if (_EntityManager.HasErrors)
                {
                    AddCustomErrors(_EntityManager.Errors, true);
                }
            }
        }
        private bool OnAddNewCommandCanExecute(object obj)
        {
            return CurrentEntityViewModel == null;
        }


        void OnAddNewCommand(object arg)
        {
            ClearCustomErrors();
            gcsEntity entity = new gcsEntity();
            entity.Settings.Add(new gcsSetting()
            {
                SettingGroup = gcsSettingGroup.gcsEntity,
                SettingSubGroup = gcsSettingSubGroup.AccessProfile,
                SettingKey = gcsSettingKey.ControlsAccessGroup1,
                Value = true.ToString()
            });

            entity.Settings.Add(new gcsSetting()
            {
                SettingGroup = gcsSettingGroup.gcsEntity,
                SettingSubGroup = gcsSettingSubGroup.AccessProfile,
                SettingKey = gcsSettingKey.ControlsAccessGroup2,
                Value = true.ToString()
            });

            entity.Settings.Add(new gcsSetting()
            {
                SettingGroup = gcsSettingGroup.gcsEntity,
                SettingSubGroup = gcsSettingSubGroup.AccessProfile,
                SettingKey = gcsSettingKey.ControlsAccessGroup3,
                Value = false.ToString()
            });

            entity.Settings.Add(new gcsSetting()
            {
                SettingGroup = gcsSettingGroup.gcsEntity,
                SettingSubGroup = gcsSettingSubGroup.AccessProfile,
                SettingKey = gcsSettingKey.ControlsAccessGroup4,
                Value = false.ToString()
            });

            entity.Settings.Add(new gcsSetting()
            {
                SettingGroup = gcsSettingGroup.gcsEntity,
                SettingSubGroup = gcsSettingSubGroup.AccessProfile,
                SettingKey = gcsSettingKey.ControlsIOGroup1,
                Value = false.ToString()
            });

            entity.Settings.Add(new gcsSetting()
            {
                SettingGroup = gcsSettingGroup.gcsEntity,
                SettingSubGroup = gcsSettingSubGroup.AccessProfile,
                SettingKey = gcsSettingKey.ControlsIOGroup2,
                Value = false.ToString()
            });

            entity.Settings.Add(new gcsSetting()
            {
                SettingGroup = gcsSettingGroup.gcsEntity,
                SettingSubGroup = gcsSettingSubGroup.AccessProfile,
                SettingKey = gcsSettingKey.ControlsIOGroup3,
                Value = false.ToString()
            });

            entity.Settings.Add(new gcsSetting()
            {
                SettingGroup = gcsSettingGroup.gcsEntity,
                SettingSubGroup = gcsSettingSubGroup.AccessProfile,
                SettingKey = gcsSettingKey.ControlsIOGroup4,
                Value = false.ToString()
            });

            CurrentEntityViewModel = new EditEntityViewModel(_ServiceFactory, entity, Globals.Instance.Entities);
            CurrentEntityViewModel.EntityUpdated += CurrentEntityViewModel_EntityUpdated;
            CurrentEntityViewModel.CancelEditEntity += CurrentEntityViewModel_CancelEvent;
        }


        private bool OnAddNewChildCommandCanExecute(gcsEntity obj)
        {
            return CurrentEntityViewModel == null;
        }

        void OnAddNewChildCommand(gcsEntity arg)
        {
            ClearCustomErrors();

            gcsEntity entity = new gcsEntity();
            entity.ParentEntityId = arg.EntityId;
            CurrentEntityViewModel = new EditEntityViewModel(_ServiceFactory, entity, Globals.Instance.Entities);
            CurrentEntityViewModel.EntityUpdated += CurrentEntityViewModel_EntityUpdated;
            CurrentEntityViewModel.CancelEditEntity += CurrentEntityViewModel_CancelEvent;
        }


        private bool OnAddNewSiblingCommandCanExecute(gcsEntity obj)
        {
            return CurrentEntityViewModel == null;
        }

        void OnAddNewSiblingCommand(gcsEntity arg)
        {
            ClearCustomErrors();
            gcsEntity entity = new gcsEntity();
            entity.ParentEntityId = arg.ParentEntityId;
            CurrentEntityViewModel = new EditEntityViewModel(_ServiceFactory, entity, Entities);
            CurrentEntityViewModel.EntityUpdated += CurrentEntityViewModel_EntityUpdated;
            CurrentEntityViewModel.CancelEditEntity += CurrentEntityViewModel_CancelEvent;
        }

        //void CurrentEntityViewModel_EntityUpdated(object sender, EntityEventArgs e)
        //{
        //    App.Current.Dispatcher.Invoke((Action) delegate
        //     {
        //         if (!e.IsNew)
        //         {
        //             gcsEntity entity = _Entities.Where(item => item.EntityId == e.Entity.EntityId).FirstOrDefault();
        //             if (entity != null)
        //             {
        //                 entity.EntityDescription = e.Entity.EntityDescription;
        //                 entity.EntityKey = e.Entity.EntityKey;
        //                 entity.EntityName = e.Entity.EntityName;
        //                 entity.IsActive = e.Entity.IsActive;
        //                 entity.IsDefault = e.Entity.IsDefault;
        //                 entity.UserRequirements = e.Entity.UserRequirements;
        //                 entity.gcsEntityApplications = e.Entity.gcsEntityApplications;
        //                 entity.ConcurrencyValue = e.Entity.ConcurrencyValue;
        //             }
        //         }
        //         else
        //             _Entities.Add(e.Entity);

        //         CurrentEntityViewModel = null;
        //         Globals.Instance.RefreshEntities();
        //     });
        //}
        async void CurrentEntityViewModel_EntityUpdated(object sender, EntityEventArgs e)
        {
            App.Current.Dispatcher.Invoke((Action)async delegate
           {
               await RefreshEntities();
               var allEntities = Entities.Descendants(x => x.ChildEntities);
               SelectedEntity = allEntities.Where(x => x.EntityId == e.Entity.EntityId).FirstOrDefault();
               SelectedEntity.IsExpanded = true;

               var tempE = SelectedEntity;
               while (tempE?.ParentEntityId != null)
               {
                   tempE = allEntities.Where(x => x.EntityId == tempE.ParentEntityId).FirstOrDefault();
                   if (tempE != null)
                       tempE.IsExpanded = true;
               }

               CurrentEntityViewModel = null;
               await Globals.Instance.RefreshEntities();
           });
        }


        void CurrentEntityViewModel_CancelEvent(object sender, EventArgs e)
        {
            CurrentEntityViewModel = null;
        }

        private bool OnDeleteCommandCanExecute(gcsEntity obj)
        {
            return CurrentEntityViewModel == null;
        }

        async void OnDeleteCommand(gcsEntity entity)
        {
            ClearCustomErrors();

            var args = new CancelMessageEventArgs(entity.EntityName);
            if (ConfirmDelete != null)
                ConfirmDelete(this, args);
            if (!args.Cancel)
            {

                if (UseAsyncServiceCalls == false)
                {
                    _EntityManager.DeleteEntityByUniqueId(new DeleteParameters() { UniqueId = entity.EntityId });
                    _Entities.Remove(entity);
                    Globals.Instance.RefreshEntities();
                }
                else
                {
                    await _EntityManager.DeleteEntityByUniqueIdAsync(new DeleteParameters() { UniqueId = entity.EntityId });
                }
                await RefreshEntities();
            }
        }
    }
}
