using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Globalization;
using GalaxySMS.Prism.Infrastructure;
using GCS.Core.Common.UI.Core;
using Prism.Events;
using Prism.Regions;
using SDK = GalaxySMS.Client.SDK;
using Entities = GalaxySMS.Client.Entities;
using GalaxySMS.Common.Constants;
using GCS.Core.Common.Core;
using GCS.Core.Common;
using System.Linq;
using System.Threading.Tasks;
using GalaxySMS.Prism.Infrastructure.Events;
using GCS.Core.Common.Extensions;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.ScheduleView;
using CommonResources = GalaxySMS.Resources;
using LocalResources = GalaxySMS.Schedule.Properties;
using GalaxySMS.Client.Entities;
using GalaxySMS.Common.Enums;
using GCS.Core.Common.Utils;

namespace GalaxySMS.Schedule.ViewModels
{
    [Export(typeof(DayTypeViewModel))]
    public class DayTypeViewModel : GCS.Core.Common.UI.Core.ViewModelBase, IPartImportsSatisfiedNotification, INavigationAware
    {
        #region Private fields
        private readonly IEventAggregator _eventAggregator;
        private readonly IClientServices _clientServices;
        EditDayTypeViewModel _CurrentItemViewModel;
        private Entities.DayType _deleteThisDayType = null;
        #endregion

        #region Constructors
        [ImportingConstructor]
        public DayTypeViewModel(IEventAggregator eventAggregator, IClientServices clientServices)
        {
            _eventAggregator = eventAggregator;
            _clientServices = clientServices;
            ViewTitle = CommonResources.Resources.DayTypeView_ViewTitle;

            _eventAggregator.GetEvent<PubSubEvent<EntitySavedEventArgs<Entities.DayType>>>().Subscribe(EntitySaved, ThreadOption.UIThread);
            _eventAggregator.GetEvent<PubSubEvent<OperationCanceledEventArgs<Entities.DayType>>>().Subscribe(OperationCanceled, ThreadOption.UIThread);
            _eventAggregator.GetEvent<PubSubEvent<CurrentEntityForSessionChanged>>().Subscribe(OnCurrentEntityForSessionChanged, ThreadOption.UIThread);
            _eventAggregator.GetEvent<PubSubEvent<CurrentSiteForSessionChanged>>().Subscribe(CurrentSiteChanged, ThreadOption.UIThread);
            //_eventAggregator.GetEvent<PubSubEvent<DateDayTypeChanged>>().Subscribe(OnDateDayTypeChanged, ThreadOption.UIThread);

            AddNewCommand = new DelegateCommand<object>(OnAddNewCommand, OnAddNewCommandCanExecute);
            EditCommand = new DelegateCommand<Entities.DayType>(OnEditCommand, OnEditCommandCanExecute);
            DeleteCommand = new DelegateCommand<Entities.DayType>(OnDeleteCommand, OnDeleteCommandCanExecute);
            RefreshCommand = new DelegateCommand<object>(OnRefreshCommand, OnRefreshCommandCanExecute);
            GenerateDefaultDayTypesCommand = new DelegateCommand<object>(OnGenerateDefaultDayTypesCommand, OnGenerateDefaultDayTypesCommandCanExecute);
            SaveDateTypeDefaultsCommand = new DelegateCommand<object>(OnSaveDateTypeDefaultsCommand, OnSaveDateTypeDefaultsCommandCanExecute);

            OneMinuteFormatDateTypeDefaultBehaviors = new DateTypeDefaultBehavior();
            OneMinuteFormatDateTypeDefaultBehaviors.CleanAll();

            SaveCalendarCommand = new DelegateCommand<object>(OnSaveCalendarCommand, OnSaveCalendarCommandCanExecute);
            PreviousMonthCommand = new DelegateCommand<object>(OnPreviousMonthCommand);
            NextMonthCommand = new DelegateCommand<object>(OnNextMonthCommand);

            GridPageSizes = new ObservableCollection<KeyValuePair<int, string>>();

            for (int key = 0; key < 50; key += 10)
            {
                if (key == 0)
                {
                    GridPageSizes.Add(new KeyValuePair<int, string>(key, CommonResources.Resources.PageSize_AllText));
                }
                else
                {
                    GridPageSizes.Add(new KeyValuePair<int, string>(key, key.ToString()));
                }
            }

            foreach (var s in GridPageSizes)
            {
                if (s.Key == 20)
                {
                    GridPageSize = s;
                    break;
                }
            }

            IsAddNewControlVisible = true;
            IsRefreshControlVisible = true;
            IsEditControlVisible = true;
            IsDeleteControlVisible = true;
            IsSaveCalendarControlVisible = true;
            IsGenerateDefaultDayTypesControlVisible = true;
            IsDateTypeDefaultsControlVisible = true;
        }



        private void OnNextMonthCommand(object obj)
        {
            SelectedMonth = SelectedMonth.AddMonths(1);
        }

        private void OnPreviousMonthCommand(object obj)
        {
            SelectedMonth = SelectedMonth.AddMonths(-1);
        }

        //private void OnDateDayTypeChanged(DateDayTypeChanged obj)
        //{
        //    foreach (var d in obj.Dates)
        //    {
        //        var dt = DateTypes.FirstOrDefault(o => o.Date.DateOnly() == d.Date.DateOnly());
        //        if (dt == null)
        //        {
        //            dt = new Entities.DateType()
        //            {
        //                Date = d,
        //                DayTypeUid = obj.DayType.DayTypeUid,
        //                DayType = obj.DayType,
        //            };
        //            DateTypes.Add(dt);
        //        }
        //        else
        //        {
        //            if (obj?.DayType == null)
        //            {
        //                dt.DayType = null;
        //                dt.DayTypeUid = Guid.Empty;
        //            }
        //            else
        //            {
        //                dt.DayType = obj.DayType;
        //                dt.DayTypeUid = obj.DayType.DayTypeUid;
        //            }
        //        }

        //    }
        //    MakeDirty();
        //}

        private bool OnSaveCalendarCommandCanExecute(object obj)
        {
            var dirtyDates = DatesForMonth?.FirstOrDefault(d => d.IsDirty);
            return
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSDataAccessPermission.TimeScheduleCanUpdateId) &&
                dirtyDates != null;
        }

        private async void OnSaveCalendarCommand(object obj)
        {
            base.ClearCustomErrors();


            ValidateModel();

            if (IsValid)
            {
                IsBusy = true;
                UpdateDateTypesCollection();

                var manager = _clientServices.GetManager<SDK.Managers.DateTypeManager>();
                foreach (var dt in DateTypes.Where(d => d.IsAnythingDirty()).ToList())
                {
                    BusyContent = string.Format(CommonResources.Resources.DayTypeCalendarView_PleaseWaitWhileISave, dt.Date.ToShortDateString(), DayTypes?.FirstOrDefault(d => d.DayTypeUid == dt.DayTypeUid));
                    Entities.DateType savedEntity;

                    bool isNew = (dt.DateTypeUid == Guid.Empty);

                    var parameters = new Entities.SaveParameters<Entities.DateType>()
                    {
                        Data = dt,
                        //SessionId = _clientServices.UserSessionToken.SessionId,
                        CurrentEntityId = _clientServices.UserSessionToken.CurrentEntityId
                    };
                    if (UseAsyncServiceCalls == false)
                    {
                        savedEntity = manager.SaveDateType(parameters);
                    }
                    else
                    {
                        savedEntity = await manager.SaveDateTypeAsync(parameters);
                    }

                    if (manager.HasErrors == false)
                    {
                        if (savedEntity != null)
                        {
                            dt.Initialize(savedEntity);
                            dt.CleanAll();
                        }
                        else
                        {
                            DateTypes.Remove(dt);
                            var tempDay = DatesForMonth.FirstOrDefault(d => d.Date == dt.Date);
                            if (tempDay != null)
                            {
                                tempDay.Title = string.Empty;
                                tempDay.CleanAll();
                            }
                        }
                        UpdateDateTypesCollection();
                    }
                    else
                    {
                        AddCustomErrors(manager.Errors, true);
                    }
                    IsBusy = false;
                }
            }
        }

        #endregion

        #region Private Methods

        private bool OnRefreshCommandCanExecute(object obj)
        {
            return
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSDataAccessPermission.TimeScheduleCanViewId);
        }

        private async void OnRefreshCommand(object obj)
        {
            await RefreshFromServer();
        }

        private bool OnGenerateDefaultDayTypesCommandCanExecute(object obj)
        {
            return
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSDataAccessPermission.TimeScheduleCanUpdateId);
        }

        private async void OnGenerateDefaultDayTypesCommand(object obj)
        {
            IsBusy = true;

            base.ClearCustomErrors();
            var manager = _clientServices.GetManager<SDK.Managers.DayTypeManager>();
            var parameters = new SaveParameters<Entities.DayType>()
            {
                //SessionId = _clientServices.UserSessionToken.SessionId,
                CurrentEntityId = _clientServices.UserSessionToken.CurrentEntityId
            };
            if (UseAsyncServiceCalls == false)
            {
                var dayTypes = manager.EnsureDefaultDayTypesExistForEntity(parameters);
            }
            else
            {
                var dayTypes = await manager.EnsureDefaultDayTypesExistForEntityAsync(parameters);
            }

            IsBusy = false;

            if (manager.HasErrors)
            {
                base.AddCustomErrors(manager.Errors, true);
            }
            else
                await RefreshFromServer();
        }

        private async void OnCurrentEntityForSessionChanged(CurrentEntityForSessionChanged obj)
        {
            await RefreshFromServer();
        }

        private async void CurrentSiteChanged(CurrentSiteForSessionChanged obj)
        {
            await RefreshFromServer();
        }

        private void OperationCanceled(OperationCanceledEventArgs<Entities.DayType> obj)
        {
            if (CurrentItemViewModel?.InstanceId == obj.OperationId)
                CurrentItemViewModel = null;
        }

        private void EntitySaved(EntitySavedEventArgs<Entities.DayType> obj)
        {
            if (!obj.IsNew)
            {
                var entity = DayTypes.FirstOrDefault(item => item.DayTypeUid == obj.Entity.DayTypeUid);
                entity?.Initialize(obj.Entity);
            }
            else
                DayTypes.Add(obj.Entity);
            OnPropertyChanged(() => TotalRecordCount, false);

            if (obj.CloseEditor)
                CurrentItemViewModel = null;
        }


        private bool OnSaveDateTypeDefaultsCommandCanExecute(object obj)
        {
            return
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSDataAccessPermission.TimeScheduleCanUpdateId) && OneMinuteFormatDateTypeDefaultBehaviors.IsDirty;
        }

        private async void OnSaveDateTypeDefaultsCommand(object obj)
        {
            var manager = _clientServices.GetManager<SDK.Managers.DateTypeDefaultBehaviorManager>();
            var parameters = new Entities.SaveParameters<DateTypeDefaultBehavior>() { Data = OneMinuteFormatDateTypeDefaultBehaviors, //SessionId = _clientServices.UserSessionToken.SessionId, 
                CurrentEntityId = _clientServices.UserSessionToken.CurrentEntityId };
            DateTypeDefaultBehavior savedDateTypeDefaultBehavior = null;
            if (UseAsyncServiceCalls == false)
            {
                savedDateTypeDefaultBehavior = manager.SaveDateTypeDefaultBehavior(parameters);
            }
            else
            {
                //await Task.Run(() => regionManager.DeleteRegion(parameters));
                savedDateTypeDefaultBehavior = await manager.SaveDateTypeDefaultBehaviorAsync(parameters);
            }
            if (manager.HasErrors)
            {
                base.AddCustomErrors(manager.Errors, true);
            }
            else
            {
                if (savedDateTypeDefaultBehavior != null)
                {
                    OneMinuteFormatDateTypeDefaultBehaviors = savedDateTypeDefaultBehavior;
                    OneMinuteFormatDateTypeDefaultBehaviors.CleanAll();
                }
            }

        }

    private bool OnEditCommandCanExecute(Entities.DayType obj)
        {
            return
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSDataAccessPermission.TimeScheduleCanUpdateId) &&
                obj?.EntityId == _clientServices.CurrentEntityId;
        }

        private void OnEditCommand(Entities.DayType obj)
        {
            ClearCustomErrors();
            if (obj != null)
            {
                CurrentItemViewModel = new EditDayTypeViewModel(_eventAggregator, _clientServices, obj, Guid.Empty);
            }
        }

        private bool OnAddNewCommandCanExecute(object obj)
        {
            return
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSDataAccessPermission.TimeScheduleCanUpdateId);
        }

        private void OnAddNewCommand(object obj)
        {
            ClearCustomErrors();
            var o = new Entities.DayType();
            CurrentItemViewModel = new EditDayTypeViewModel(_eventAggregator, _clientServices, o, Guid.Empty);
        }

        private bool OnDeleteCommandCanExecute(Entities.DayType obj)
        {
            return
                _clientServices.UserSessionToken.HasPermission(
                    PermissionIds.GalaxySMSDataAccessPermission.TimeScheduleCanDeleteId) &&
                obj?.EntityId == _clientServices.CurrentEntityId;
        }


        private void OnDeleteCommand(Entities.DayType entity)
        {
            ClearCustomErrors();
            _deleteThisDayType = entity;
            var dlgParams = new DialogParameters();
            dlgParams.Header = CommonResources.Resources.Common_ConfirmDelete;
            dlgParams.Content = string.Format(CommonResources.Resources.MaintainDayTypes_AreYouSureDeleteDayType,
                _deleteThisDayType.Name);
            dlgParams.OkButtonContent = string.Format(CommonResources.Resources.MaintainDayTypes_YesDeleteDayType, _deleteThisDayType.Name);
            dlgParams.CancelButtonContent = string.Format(CommonResources.Resources.MaintainDayTypes_NoDeleteDayType, _deleteThisDayType.Name);
            dlgParams.Closed += OnConfirmDeleteClosed;
            RadWindow.Confirm(dlgParams);
        }

        private async void OnConfirmDeleteClosed(object sender, WindowClosedEventArgs e)
        {
            if (e.DialogResult == true)
            {
                int numberDeleted = 0;
                var manager = _clientServices.GetManager<SDK.Managers.DayTypeManager>();
                var parameters = new Entities.DeleteParameters<Entities.DayType>() { Data = _deleteThisDayType, SessionId = _clientServices.UserSessionToken.SessionId, CurrentEntityId = _clientServices.UserSessionToken.CurrentEntityId };
                if (UseAsyncServiceCalls == false)
                {
                    numberDeleted = manager.DeleteDayType(parameters);
                }
                else
                {
                    //await Task.Run(() => regionManager.DeleteRegion(parameters));
                    numberDeleted = await manager.DeleteDayTypeAsync(parameters);
                }
                if (manager.HasErrors == false)
                    DayTypes.Remove(_deleteThisDayType);
                else
                {
                    base.AddCustomErrors(manager.Errors, true);
                }
            }
            else
                _deleteThisDayType = null;
        }
        #endregion

        #region Public Properties

        public string SundayTitle => DateTimeFormatInfo.CurrentInfo.GetDayName(DayOfWeek.Sunday);
        public string MondayTitle => DateTimeFormatInfo.CurrentInfo.GetDayName(DayOfWeek.Monday);
        public string TuesdayTitle => DateTimeFormatInfo.CurrentInfo.GetDayName(DayOfWeek.Tuesday);
        public string WednesdayTitle => DateTimeFormatInfo.CurrentInfo.GetDayName(DayOfWeek.Wednesday);
        public string ThursdayTitle => DateTimeFormatInfo.CurrentInfo.GetDayName(DayOfWeek.Thursday);
        public string FridayTitle => DateTimeFormatInfo.CurrentInfo.GetDayName(DayOfWeek.Friday);
        public string SaturdayTitle => DateTimeFormatInfo.CurrentInfo.GetDayName(DayOfWeek.Saturday);


        private DateTime _selectedMonth;

        public DateTime SelectedMonth
        {
            get { return _selectedMonth; }
            set
            {
                if (_selectedMonth != value)
                {
                    _selectedMonth = value;
                    OnPropertyChanged(() => SelectedMonth, false);
                    GetDatesForMonth();
                }
            }
        }


        private KeyValuePair<int, string> _gridPageSize;

        public KeyValuePair<int, string> GridPageSize
        {
            get { return _gridPageSize; }
            set
            {
                _gridPageSize = value;
                OnPropertyChanged(() => GridPageSize, false);
            }
        }

        private ObservableCollection<KeyValuePair<int, string>> _gridPageSizes;

        public ObservableCollection<KeyValuePair<int, string>> GridPageSizes
        {
            get { return _gridPageSizes; }
            set
            {
                if (_gridPageSizes != value)
                {
                    _gridPageSizes = value;
                    OnPropertyChanged(() => GridPageSizes, false);
                }
            }
        }

        public int TotalRecordCount
        {
            get
            {
                if (DayTypes == null)
                    return 0;
                return DayTypes.Count;
            }
            set
            {
                OnPropertyChanged(() => TotalRecordCount, false);
            }
        }

        private void GetDatesForMonth()
        {
            UpdateDateTypesCollection();

            var startOfMonth = SelectedMonth.StartOfMonth();
            var endOfMonth = SelectedMonth.EndOfMonth();

            DatesForMonth = DateTypes?.Where(d => d.Date >= startOfMonth && d.Date <= endOfMonth).ToObservableCollection();
            if (DatesForMonth == null)
                DatesForMonth = new ObservableCollection<Entities.DateType>();

            var daysInMonth = DateTime.DaysInMonth(startOfMonth.Year, startOfMonth.Month);
            for (var day = 1; day <= daysInMonth; day++)
            {
                var currentDate = new DateTime(SelectedMonth.Year, SelectedMonth.Month, day);
                var existingDateType = DateTypes?.FirstOrDefault(d => d.Date.Date == currentDate);
                if (existingDateType == null)
                {
                    var dt = new Entities.DateType()
                    {
                        Date = currentDate,
                        DayTypeUid = Guid.Empty,
                        //DayType = DayTypes.FirstOrDefault(d => d.DayTypeUid == Guid.Empty)
                    };
                    //dt.DayTypeUid = dt.DayType.DayTypeUid;
                    dt.CleanAll();
                    DatesForMonth.Add(dt);
                }
            }
        }

        private void UpdateDateTypesCollection()
        {
            // Start by preserving any Dirty Entries from the current Month into the DateTypes collection, which is the collection that the save operation is based on
            if (DatesForMonth != null)
            {
                var dirtyDates = DatesForMonth.Where(d => d.IsDirty).ToList();
                foreach (var dd in dirtyDates)
                {
                    var existingDate = DateTypes.FirstOrDefault(d => d.Date == dd.Date);
                    if (existingDate == null)
                        DateTypes.Add(dd);
                    else
                        existingDate.Initialize(dd);
                }
            }
        }

        private ObservableCollection<Entities.DateType> _datesForMonth;

        public ObservableCollection<Entities.DateType> DatesForMonth
        {
            get { return _datesForMonth; }
            set
            {
                if (_datesForMonth != value)
                {
                    _datesForMonth = value;
                    OnPropertyChanged(() => DatesForMonth, false);
                }
            }
        }


        private List<Entities.DateType> _dateTypes;

        public List<Entities.DateType> DateTypes
        {
            get { return _dateTypes; }
            set
            {
                if (_dateTypes != value)
                {
                    _dateTypes = value;
                    OnPropertyChanged(() => DateTypes);
                }
            }
        }



        private DateTypeDefaultBehavior _oneMinuteDateTypeDefaultBehavior;

        public DateTypeDefaultBehavior OneMinuteFormatDateTypeDefaultBehaviors
        {
            get { return _oneMinuteDateTypeDefaultBehavior; }
            set
            {
                if (_oneMinuteDateTypeDefaultBehavior != value)
                {
                    _oneMinuteDateTypeDefaultBehavior = value;
                    OnPropertyChanged(() => OneMinuteFormatDateTypeDefaultBehaviors);
                }
            }
        }

        public EditDayTypeViewModel CurrentItemViewModel
        {
            get { return _CurrentItemViewModel; }
            set
            {
                if (_CurrentItemViewModel != value)
                {
                    _CurrentItemViewModel = value;
                    OnPropertyChanged(() => CurrentItemViewModel, false);
                }
            }
        }

        private ObservableCollection<GalaxySMS.Client.Entities.DayType> _dayTypes;

        public ObservableCollection<GalaxySMS.Client.Entities.DayType> DayTypes
        {
            get { return _dayTypes; }
            set
            {
                if (_dayTypes != value)
                {
                    _dayTypes = value;
                    OnPropertyChanged(() => DayTypes, false);
                    OnPropertyChanged(() => TotalRecordCount, false);
                }
            }
        }


        public ObservableCollection<GalaxySMS.Client.Entities.DayType> DayTypeSelectionList
        {
            get
            {
                var newCollection = new ObservableCollection<Entities.DayType>();
                newCollection.Add(new Entities.DayType());
                newCollection.AddRange(DayTypes);
                return newCollection;
            }

        }


        private bool _IsSaveCalendarControlVisible;

        public bool IsSaveCalendarControlVisible
        {
            get { return _IsSaveCalendarControlVisible; }
            set
            {
                if (_IsSaveCalendarControlVisible != value)
                {
                    _IsSaveCalendarControlVisible = value;
                    OnPropertyChanged(() => IsSaveCalendarControlVisible, false);
                }
            }
        }

        private bool _IsGenerateDefaultDayTypesControlVisible;

        public bool IsGenerateDefaultDayTypesControlVisible
        {
            get { return _IsGenerateDefaultDayTypesControlVisible; }
            set
            {
                if (_IsGenerateDefaultDayTypesControlVisible != value)
                {
                    _IsGenerateDefaultDayTypesControlVisible = value;
                    OnPropertyChanged(() => IsGenerateDefaultDayTypesControlVisible, false);
                }
            }
        }


        private bool _IsDateTypeDefaultsControlVisible;

        public bool IsDateTypeDefaultsControlVisible
        {
            get { return _IsDateTypeDefaultsControlVisible; }
            set
            {
                if (_IsDateTypeDefaultsControlVisible != value)
                {
                    _IsDateTypeDefaultsControlVisible = value;
                    OnPropertyChanged(() => IsDateTypeDefaultsControlVisible, false);
                }
            }
        }

        #endregion

        #region Public Events
        public event CancelMessageEventHandler ConfirmDelete;
        public event EventHandler<ErrorMessageEventArgs> ErrorOccured;

        #endregion

        #region Public Commands
        public DelegateCommand<Entities.DayType> EditCommand { get; private set; }
        public DelegateCommand<Entities.DayType> DeleteCommand { get; private set; }
        public DelegateCommand<object> AddNewCommand { get; private set; }
        public DelegateCommand<object> RefreshCommand { get; private set; }
        public DelegateCommand<object> GenerateDefaultDayTypesCommand { get; private set; }
        public DelegateCommand<object> SaveCalendarCommand { get; private set; }
        public DelegateCommand<object> PreviousMonthCommand { get; private set; }
        public DelegateCommand<object> NextMonthCommand { get; private set; }
        public DelegateCommand<object> SaveDateTypeDefaultsCommand { get; private set; }
        #endregion

        #region Protected Methods

        protected override void OnViewLoaded()
        {
            RefreshFromServer();

            SelectedMonth = DateTime.Today.StartOfMonth();
        }

        //private void RefreshFromServer()
        //{
        //    IsBusy = true;
        //    base.ClearCustomErrors();
        //    DayTypes = new ObservableCollection<Client.Entities.DayType>();
        //    var parameters = new Entities.GetParametersWithPhoto {IncludeMemberCollections = true};
        //    //parameters.UniqueId = _clientServices.CurrentSite.SiteUid;
        //    //parameters.IncludePhoto = true;
        //    var dayTypeManager = _clientServices.GetManager<SDK.Managers.DayTypeManager>();
        //    var dayTypes = dayTypeManager.GetDayTypesForEntity(parameters, false);
        //    foreach (var dt in dayTypes)
        //        DayTypes.Add(dt);

        //    var dateTypeManager = _clientServices.GetManager<SDK.Managers.DateTypeManager>();
        //    var dateTypes = dateTypeManager.GetDateTypesForEntity(parameters, false);
        //    foreach (var dt in dateTypes)
        //    {
        //        //dt.DayType = DayTypes.FirstOrDefault(d => d.DayTypeUid == dt.DayTypeUid);
        //        dt.CleanAll();
        //    }
        //    DateTypes = dateTypes.ToList();

        //    OnPropertyChanged(() => TotalRecordCount, false);

        //    if (dayTypeManager.HasErrors)
        //    {
        //        base.AddCustomErrors(dayTypeManager.Errors, true);
        //    }

        //    if (dateTypeManager.HasErrors)
        //    {
        //        base.AddCustomErrors(dateTypeManager.Errors, true);
        //    }
        //    GetDatesForMonth();
        //    IsBusy = false;

        //}
        private async Task RefreshFromServer()
        {
            IsBusy = true;
            base.ClearCustomErrors();
            DayTypes = new ObservableCollection<Client.Entities.DayType>();
            var parameters = new Entities.GetParametersWithPhoto { IncludeMemberCollections = true };
            //parameters.UniqueId = _clientServices.CurrentSite.SiteUid;
            //parameters.IncludePhoto = true;
            var dayTypeManager = _clientServices.GetManager<SDK.Managers.DayTypeManager>();
            var dateTypeManager = _clientServices.GetManager<SDK.Managers.DateTypeManager>();
            var dateTypeDefaultBehaviorManager = _clientServices.GetManager<SDK.Managers.DateTypeDefaultBehaviorManager>();

            var dayTypes = await dayTypeManager.GetDayTypesForEntityAsync(parameters);
            var dateTypes = await dateTypeManager.GetDateTypesForEntityAsync(parameters);
            OneMinuteFormatDateTypeDefaultBehaviors = await dateTypeDefaultBehaviorManager.GetDateTypeDefaultBehaviorForEntityAsync(parameters);

            foreach (var dt in dayTypes.Items)
            {
                //if (dt.HighlightColor != 0)
                //{
                //    dt.HighlightColor = ByteFlipper.RotateBytesLeft(dt.HighlightColor);
                //}
                DayTypes.Add(dt);
            }

            if (OneMinuteFormatDateTypeDefaultBehaviors == null)
            {
                OneMinuteFormatDateTypeDefaultBehaviors = new DateTypeDefaultBehavior();
                var firstOrDefault = DayTypes.FirstOrDefault(d => d.DayTypeCode == DayTypeCode.Sunday);
                if (firstOrDefault != null)
                    OneMinuteFormatDateTypeDefaultBehaviors.SundayDayTypeUid = firstOrDefault.DayTypeUid;

                firstOrDefault = DayTypes.FirstOrDefault(d => d.DayTypeCode == DayTypeCode.Monday);
                if (firstOrDefault != null)
                    OneMinuteFormatDateTypeDefaultBehaviors.MondayDayTypeUid = firstOrDefault.DayTypeUid;

                firstOrDefault = DayTypes.FirstOrDefault(d => d.DayTypeCode == DayTypeCode.Tuesday);
                if (firstOrDefault != null)
                    OneMinuteFormatDateTypeDefaultBehaviors.TuesdayDayTypeUid = firstOrDefault.DayTypeUid;

                firstOrDefault = DayTypes.FirstOrDefault(d => d.DayTypeCode == DayTypeCode.Wednesday);
                if (firstOrDefault != null)
                    OneMinuteFormatDateTypeDefaultBehaviors.WednesdayDayTypeUid = firstOrDefault.DayTypeUid;

                firstOrDefault = DayTypes.FirstOrDefault(d => d.DayTypeCode == DayTypeCode.Thursday);
                if (firstOrDefault != null)
                    OneMinuteFormatDateTypeDefaultBehaviors.ThursdayDayTypeUid = firstOrDefault.DayTypeUid;

                firstOrDefault = DayTypes.FirstOrDefault(d => d.DayTypeCode == DayTypeCode.Friday);
                if (firstOrDefault != null)
                    OneMinuteFormatDateTypeDefaultBehaviors.FridayDayTypeUid = firstOrDefault.DayTypeUid;

                firstOrDefault = DayTypes.FirstOrDefault(d => d.DayTypeCode == DayTypeCode.Saturday);
                if (firstOrDefault != null)
                    OneMinuteFormatDateTypeDefaultBehaviors.SaturdayDayTypeUid = firstOrDefault.DayTypeUid;

            }
            OneMinuteFormatDateTypeDefaultBehaviors.CleanAll();

            foreach (var dt in dateTypes.Items)
            {
                //dt.DayType = DayTypes.FirstOrDefault(d => d.DayTypeUid == dt.DayTypeUid);
                dt.CleanAll();
            }
            DateTypes = dateTypes.Items.ToList();

            OnPropertyChanged(() => TotalRecordCount, false);

            if (dayTypeManager.HasErrors)
            {
                base.AddCustomErrors(dayTypeManager.Errors, true);
            }

            if (dateTypeManager.HasErrors)
            {
                base.AddCustomErrors(dateTypeManager.Errors, true);
            }

            if (dateTypeDefaultBehaviorManager.HasErrors)
                base.AddCustomErrors(dateTypeDefaultBehaviorManager.Errors, true);

            GetDatesForMonth();
            IsBusy = false;

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
            //throw new NotImplementedException();
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            //throw new NotImplementedException();
        }

        #endregion
    }
}