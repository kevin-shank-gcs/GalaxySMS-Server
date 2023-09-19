using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GalaxySMS.Client.Entities;
using GalaxySMS.Client.UI;
using GalaxySMS.Schedule.Support;
using GCS.Core.Common.Extensions;
using GCS.Core.Common.UI.Core;
using Telerik.Windows.Controls;

namespace GalaxySMS.Schedule.UserControls
{
    /// <summary>
    /// Interaction logic for DailyMinuteBasedTimePeriodEditor.xaml
    /// </summary>
    public partial class DailyMinuteBasedTimePeriodEditor : UserControlViewBase
    {
        private ushort _alternatingCount;
        List<TimePeriod> _internalTimePeriods = null;

        public DailyMinuteBasedTimePeriodEditor()
        {
            InitializeComponent();
            SetTimesCommand = new DelegateCommand<object>(OnSetTimesCommand, OnSetTimesCommandCanExecute);
            ClearAllIntervalsCommand = new DelegateCommand<object>(OnClearAllIntervalsCommand, OnClearAllIntervalsCommandCanExecute);
            ToggleAllIntervalsCommand = new DelegateCommand<object>(OnToggleAllIntervalsCommand, OnToggleAllIntervalsCommandCanExecute);
            InvertAllIntervalsCommand = new DelegateCommand<object>(OnInvertAllIntervalsCommand, OnInvertAllIntervalsCommandCanExecute);
            AlternateAllIntervalsCommand = new DelegateCommand<object>(OnAlternateAllIntervalsCommand, OnAlternateAllIntervalsCommandCanExecute);
            AlternatingCount = 2;

            TimeIntervals = new ObservableCollection<TimeInterval>();
            _internalTimePeriods = new List<TimePeriod>();
            this.Loaded += DailyMinuteBasedTimePeriodEditor_Loaded;

        }

        private void DailyMinuteBasedTimePeriodEditor_Loaded(object sender, RoutedEventArgs e)
        {
            Loaded -= DailyMinuteBasedTimePeriodEditor_Loaded;
            TimeIntervalResolutionUpdated();
            lb1.SelectionChanged -= lb1_OnSelectionChanged;
            if (this.TimePeriods == null || TimePeriods.Count == 0)
                lb1.SelectedItems.Clear();
            else
            {
                //foreach (var tp in TimePeriods)
                //{
                //    foreach (var i in TimeIntervals.Where(ti=>ti.Time >= tp.StartTime))
                //    {
                //        if (IsTimeIntervalInRange(i, tp))
                //        {
                //            lb1.SelectedItems.Add(i);
                //            break;
                //        }
                //    }
                //}
                foreach (var i in TimeIntervals)
                {
                    if( i.Time.Hours == 8)
                        Trace.WriteLine($"8am");
                    foreach (var tp in TimePeriods.Where(p => i.Time >= p.StartTime && i.Time + i.Duration <= p.EndTime ))
                    {
                        if (IsTimeIntervalInRange(i, tp))
                        {
                            lb1.SelectedItems.Add(i);
                            break;
                        }
                    }
                }

            }

            if (TimePeriods != null)
                _internalTimePeriods = TimePeriods.ToList();

            lb1.SelectionChanged += lb1_OnSelectionChanged;
        }

        private bool IsTimeIntervalInRange(TimeInterval i, TimePeriod tp)
        {
            var endTime = i.Time + i.Duration;
            if (endTime.Days > 0)
                i.Duration = i.Duration.Subtract(new TimeSpan(0, 0, 0, 0, 1));
            if (i.Time >= tp.StartTime && (i.Time + i.Duration) <= tp.EndTime)
                return true;
            return false;
        }

        private bool OnAlternateAllIntervalsCommandCanExecute(object obj)
        {
            if (AlternatingCount == 0)
                return false;
            return true;
        }

        private void OnAlternateAllIntervalsCommand(object obj)
        {
            lb1.SelectionChanged -= lb1_OnSelectionChanged;
            lb1.SelectedItems.Clear();
            int x = 0;
            foreach (var i in TimeIntervals)
            {
                if (x++ % AlternatingCount == 0)
                    lb1.SelectedItems.Add(i);
            }
            lb1.SelectionChanged += lb1_OnSelectionChanged;
            lb1_OnSelectionChanged(this, null);
        }

        private bool OnInvertAllIntervalsCommandCanExecute(object obj)
        {
            return true;
        }

        private void OnInvertAllIntervalsCommand(object obj)
        {
            var selected = lb1.SelectedItems;
            var notSelected = lb1.Items.OfType<object>().Where(x => !lb1.SelectedItems.Contains(x)).ToList();//Except(lb1.SelectedItems);
            lb1.SelectedItems.Clear();

            lb1.SelectionChanged -= lb1_OnSelectionChanged;


            foreach (var i in notSelected)
                lb1.SelectedItems.Add(i);

            lb1.SelectionChanged += lb1_OnSelectionChanged;
            lb1_OnSelectionChanged(this, null);

        }

        private bool OnToggleAllIntervalsCommandCanExecute(object obj)
        {
            return true;
        }

        private void OnToggleAllIntervalsCommand(object obj)
        {
            lb1.SelectionChanged -= lb1_OnSelectionChanged;
            if (lb1.SelectedItems.Count == 0)
            {
                foreach (var i in lb1.Items)
                    lb1.SelectedItems.Add(i);
            }
            else
                lb1.SelectedItems.Clear();
            lb1.SelectionChanged += lb1_OnSelectionChanged;
            lb1_OnSelectionChanged(this, null);

        }

        private bool OnClearAllIntervalsCommandCanExecute(object obj)
        {
            return true;
        }

        private void OnClearAllIntervalsCommand(object obj)
        {
            lb1.SelectedItems.Clear();
        }

        private bool OnSetTimesCommandCanExecute(object obj)
        {
            if (tpStartTime.SelectedValue.HasValue && tpEndTime.SelectedValue.HasValue)
                return true;
            return false;
        }

        private void OnSetTimesCommand(object obj)
        {
            lb1.SelectionChanged -= lb1_OnSelectionChanged;
            foreach (var i in TimeIntervals)
            {
                if (i != null && tpStartTime.SelectedValue.HasValue && tpEndTime.SelectedValue.HasValue)
                {
                    if (i.Time >= tpStartTime.SelectedValue.Value.TimeOfDay && i.Time < tpEndTime.SelectedValue.Value.TimeOfDay)
                    {
                        if (!lb1.SelectedItems.Contains(i))
                            lb1.SelectedItems.Add(i);
                    }
                }
            }
            lb1.SelectionChanged += lb1_OnSelectionChanged;
            lb1_OnSelectionChanged(this, null);
        }

        private void EventSetter_OnHandler(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var lbi = sender as RadListBoxItem;
                lbi.IsSelected = true;
                lbi.Focus();
                lb1.SelectedItems.Add(lbi);
            }
        }

        #region TimeIntervals
        public static readonly DependencyProperty TimeIntervalsProperty =
            DependencyProperty.Register(
                "TimeIntervals",
                typeof(ObservableCollection<TimeInterval>),
                typeof(DailyMinuteBasedTimePeriodEditor),
                new UIPropertyMetadata(null));
        public ObservableCollection<TimeInterval> TimeIntervals
        {
            get { return (ObservableCollection<TimeInterval>)GetValue(TimeIntervalsProperty); }
            set { SetValue(TimeIntervalsProperty, value); }
        }

        #endregion

        //#region TimePeriodIntervals
        //public static readonly DependencyProperty TimePeriodIntervalsProperty =
        //    DependencyProperty.Register(
        //        "TimePeriodIntervals",
        //        typeof(ICollection<TimePeriodInterval>),
        //        typeof(DailyTimePeriodIntervalEditor),
        //        new UIPropertyMetadata(null));
        //public ICollection<TimePeriodInterval> TimePeriodIntervals
        //{
        //    get { return (ICollection<TimePeriodInterval>)GetValue(TimePeriodIntervalsProperty); }
        //    set { SetValue(TimePeriodIntervalsProperty, value); }
        //}
        #region TimePeriods
        public static readonly DependencyProperty TimePeriodsProperty =
            DependencyProperty.Register(
                "TimePeriods",
                typeof(ObservableCollection<TimePeriod>),
                typeof(DailyMinuteBasedTimePeriodEditor),
                new UIPropertyMetadata(null));
        public ObservableCollection<TimePeriod> TimePeriods
        {
            get { return (ObservableCollection<TimePeriod>)GetValue(TimePeriodsProperty); }
            set
            {
                SetValue(TimePeriodsProperty, value);
                _internalTimePeriods = TimePeriods.ToList();
                Trace.WriteLine(string.Format("TimePeriods setter. TimePeriods: {0}, _internalTimePeriods:{1}",
                    TimePeriods.Count, _internalTimePeriods.Count));
            }
        }
        #endregion

        #region TimeIntervalResolution
        public static readonly DependencyProperty TimeIntervalResolutionProperty =
            DependencyProperty.Register(
                "TimeIntervalResolution",
                typeof(TimeInterval.Resolution),
                typeof(DailyMinuteBasedTimePeriodEditor));
        public TimeInterval.Resolution TimeIntervalResolution
        {
            get { return (TimeInterval.Resolution)GetValue(TimeIntervalResolutionProperty); }
            set
            {
                SetValue(TimeIntervalResolutionProperty, value);
                Trace.WriteLine(string.Format("TimeIntervalResolutionProperty setter:{0}", value));
                //TimeIntervalResolutionUpdated();
            }
        }

        private void TimeIntervalResolutionUpdated()
        {
            TimeIntervals.Clear();
            switch (TimeIntervalResolution)
            {
                case TimeInterval.Resolution.Minute:
                    break;
                case TimeInterval.Resolution.FifteenMinute:
                    break;
                default:
                    break;
            }
            var dt = DateTime.Today;
            while (dt.Date == DateTime.Today)
            {
                TimeIntervals.Add(new TimeInterval() { Time = new TimeSpan(dt.Hour, dt.Minute, 0), IntervalResolution = TimeIntervalResolution, Duration = new TimeSpan(0, 0, (int)TimeIntervalResolution, 0) });
                dt = dt.AddMinutes((int)TimeIntervalResolution);
            }
        }

        #endregion

        #region ZoomFactor
        public static readonly DependencyProperty ZoomFactorProperty =
            DependencyProperty.Register(
                "ZoomFactor",
                typeof(double),
                typeof(DailyMinuteBasedTimePeriodEditor),
                new UIPropertyMetadata(null));


        public double ZoomFactor
        {
            get { return (double)GetValue(ZoomFactorProperty); }
            set
            {
                Trace.WriteLine(string.Format("ZoomFactor setter:{0}", value));
                SetValue(ZoomFactorProperty, value);
            }
        }

        #endregion

        #region ExpanderHeaderText
        public static readonly DependencyProperty ExpanderHeaderTextProperty =
            DependencyProperty.Register(
                "ExpanderHeaderText",
                typeof(string),
                typeof(DailyMinuteBasedTimePeriodEditor),
                new UIPropertyMetadata(null));


        public string ExpanderHeaderText
        {
            get { return (string)GetValue(ExpanderHeaderTextProperty); }
            set
            {
                Trace.WriteLine(string.Format("ExpanderHeaderText setter:{0}", value));
                SetValue(ExpanderHeaderTextProperty, value);
            }
        }

        #endregion

        #region ItemsPerTimeEditorRow
        public static readonly DependencyProperty ItemsPerTimeEditorRowProperty =
            DependencyProperty.Register(
                "ItemsPerTimeEditorRow",
                typeof(int),
                typeof(DailyMinuteBasedTimePeriodEditor),
                new UIPropertyMetadata(null));


        public int ItemsPerTimeEditorRow
        {
            get { return (int)GetValue(ItemsPerTimeEditorRowProperty); }
            set
            {
                Trace.WriteLine(string.Format("ItemsPerTimeEditorRow setter:{0}", value));
                SetValue(ItemsPerTimeEditorRowProperty, value);
            }
        }

        #endregion

        public DelegateCommand<object> SetTimesCommand { get; private set; }
        public DelegateCommand<object> ClearAllIntervalsCommand { get; private set; }
        public DelegateCommand<object> InvertAllIntervalsCommand { get; private set; }
        public DelegateCommand<object> ToggleAllIntervalsCommand { get; private set; }
        public DelegateCommand<object> AlternateAllIntervalsCommand { get; private set; }

        public ushort AlternatingCount
        {
            get { return _alternatingCount; }
            set
            {
                if (_alternatingCount != value)
                {
                    _alternatingCount = value;
                    OnPropertyChanged(() => AlternatingCount);
                }
            }
        }

        private void lb1_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Trace.WriteLine(string.Format("time bar selection changed. {0} items selected, TimePeriods:{1}",
                lb1.SelectedItems.Count, _internalTimePeriods.Count));
            UpdateTimePeriods();
        }

        private void UpdateTimePeriods()
        {
            if (_internalTimePeriods == null)
                _internalTimePeriods = new List<TimePeriod>();
            _internalTimePeriods.Clear();
            TimePeriod tp = null;
            var selectedItems = new List<TimeInterval>();
            foreach (var i in lb1.SelectedItems)
            {
                var ti = i as TimeInterval;
                if (ti != null)
                    selectedItems.Add(ti);
            }

            selectedItems.Sort((x, y) => TimeSpan.Compare(x.Time, y.Time));
            foreach (var ti in selectedItems)
            {
                if (ti != null)
                {
                    if (tp == null || tp.EndTime < ti.Time)
                    {
                        tp = new TimePeriod() { StartTime = ti.Time, EndTime = ti.Time + ti.Duration };
                        _internalTimePeriods.Add(tp);
                    }
                    else if (tp.EndTime == ti.Time)
                    {
                        tp.EndTime = ti.Time + ti.Duration;
                    }
                }
            }

            //for (int x = 0; x < _internalTimePeriods.Count; x++)
            //{
            //    if (TimePeriods.Count > x)
            //        _internalTimePeriods[x].TimePeriodUid = TimePeriods[x].TimePeriodUid;
            //}
            TimePeriods = _internalTimePeriods.ToObservableCollection();
        }
    }
}
