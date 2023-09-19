using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using GalaxySMS.Client.Contracts.ViewModelContracts;
using GalaxySMS.Client.Entities;
using GalaxySMS.Client.SDK.Managers;
using GalaxySMS.Prism.Infrastructure;
using GCS.Core.Common;
using GCS.Core.Common.Core;
using GCS.Core.Common.UI.Core;
using GCS.Core.Common.Utils;
using Prism.Events;
using Telerik.Windows.Controls;
using Entities = GalaxySMS.Client.Entities;
using CommonResources = GalaxySMS.Resources;
using ViewModelBase = GCS.Core.Common.UI.Core.ViewModelBase;

namespace GalaxySMS.Schedule.ViewModels
{
    [Export(typeof(EditDayTypeViewModel))]
    public class EditDayTypeViewModel : ViewModelBase, ISupportsUserEntitySelection
    {
        #region Private Fields
        private readonly IEventAggregator _eventAggregator;
        private readonly IClientServices _clientServices;
        private Entities.DayType _DayType;
        #endregion

        #region Constructors
        [ImportingConstructor]
        public EditDayTypeViewModel(IEventAggregator eventAggregator, IClientServices clientServices, Entities.DayType entity, Guid instanceId)
        {
            if (instanceId == Guid.Empty)
                InstanceId = Guid.NewGuid();
            else
                InstanceId = instanceId;

            _eventAggregator = eventAggregator;
            _clientServices = clientServices;

            _DayType = new Entities.DayType(entity);
            _DayType.CleanAll();

            SaveCommand = new DelegateCommand<object>(OnSaveCommandExecute, OnSaveCommandCanExecute);
            CancelCommand = new DelegateCommand<object>(OnCancelCommandExecute);
            EntityMapChecked = new DelegateCommand<UserEntitySelect>(OnEntityMapChecked);
            BusyContent = CommonResources.Resources.Common_PleaseWait;
            ViewTitle = CommonResources.Resources.EditDayTypeView_ViewTitle;

            if (UserSessionToken != null)
            {
                UserEntitiesSelectionList = UserSessionToken.GetUserEntitySelectCollection();
                foreach (var ue in UserEntitiesSelectionList)
                {
                    if (_DayType.EntityIds.Contains(ue.EntityId))
                        ue.Selected = true;
                }
            }
            PaletteColorPresets = new ObservableCollection<ColorPreset>();
            PaletteColorPresets.AddRange(Enum.GetValues(typeof(ColorPreset)));
            PaletteColorPreset = ColorPreset.Office;
        }

        #endregion

        #region Public Commands
        public DelegateCommand<object> SaveCommand { get; private set; }

        public DelegateCommand<object> CancelCommand { get; private set; }
        public DelegateCommand<UserEntitySelect> EntityMapChecked { get; set; }

        #endregion

        #region Public Properties
        public Entities.DayType DayType
        {
            get { return _DayType; }
        }

        private ColorPreset _paletteColorPreset;

        public ColorPreset PaletteColorPreset
        {
            get { return _paletteColorPreset; }
            set
            {
                if (_paletteColorPreset != value)
                {
                    _paletteColorPreset = value;
                    OnPropertyChanged(() => PaletteColorPreset, false);
                }
            }
        }

        private ObservableCollection<ColorPreset> _paletteColorPresets;

        public ObservableCollection<ColorPreset> PaletteColorPresets
        {
            get { return _paletteColorPresets; }
            set
            {
                if (_paletteColorPresets != value)
                {
                    _paletteColorPresets = value;
                    OnPropertyChanged(() => PaletteColorPresets, false);
                }
            }
        }

        public Guid InstanceId { get; }
        #region Implementation of ISupportsUserEntitySelection

        public void OnEntityMapChecked(UserEntitySelect obj)
        {
            _DayType.MakeDirty();
        }
        public UserSessionToken UserSessionToken
        {
            get { return _clientServices?.UserSessionToken; }
        }

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

        private ICollection<UserEntitySelect> _userEntitiesSelectionList;
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

        #endregion

        #region Protected Methods
        protected override void AddModels(List<ObjectBase> models)
        {
            models.Add(DayType);
        }
        #endregion

        #region Private Methods


        private async void OnSaveCommandExecute(object arg)
        {
            ValidateModel();

            if (IsValid)
            {
                BusyContent = string.Format(CommonResources.Resources.EditDayTypeView_PleaseWaitWhileISave, DayType.Name);

                DayType.EntityIds.Clear();
                foreach (var ue in UserEntitiesSelectionList)
                {
                    if (ue.Selected || ue.EntityId == DayType.EntityId)
                        DayType.EntityIds.Add(ue.EntityId);
                }
                
                //var rotatedForeColor = ByteFlipper.RotateBytesRight(DayType.HighlightColor);
                //DayType.HighlightColor = rotatedForeColor;
                IsBusy = true;
                var manager = _clientServices.GetManager<DayTypeManager>();
                bool isNew = (DayType.DayTypeUid == Guid.Empty);
                Entities.DayType savedEntity;
                var parameters = new SaveParameters<Entities.DayType>()
                {
                    Data = DayType,
                    //SessionId = _clientServices.UserSessionToken.SessionId,
                    CurrentEntityId = _clientServices.UserSessionToken.CurrentEntityId
                };
                if (UseAsyncServiceCalls == false)
                {
                    savedEntity = manager.SaveDayType(parameters);
                }
                else
                {
                    savedEntity = await manager.SaveDayTypeAsync(parameters);
                }

                if (savedEntity != null && manager.HasErrors == false)
                {
                    _eventAggregator.GetEvent<PubSubEvent<EntitySavedEventArgs<Entities.DayType>>>()
                        .Publish(new EntitySavedEventArgs<Entities.DayType>()
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
            return _DayType.IsDirty;
        }

        private void OnCancelCommandExecute(object arg)
        {
            _eventAggregator.GetEvent<PubSubEvent<OperationCanceledEventArgs<Entities.DayType>>>().Publish(new OperationCanceledEventArgs<Entities.DayType>()
            {
                Entity = DayType,
                OperationId = InstanceId
            });
        }
       #endregion
    }

}