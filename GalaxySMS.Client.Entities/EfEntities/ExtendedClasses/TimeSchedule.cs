////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	EfEntities\ExtendedClasses\TimeSchedule.cs
//
// summary:	Implements the time schedule class
////////////////////////////////////////////////////////////////////////////////////////////////////

using FluentValidation;
using GCS.Core.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A time schedule. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class TimeSchedule
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public TimeSchedule()
        {
            Initialize();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The TimeSchedule to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public TimeSchedule(TimeSchedule e)
        {
            Initialize(e);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this TimeSchedule. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Initialize()
        {
            this.EntityIds = new HashSet<Guid>();
            this.MappedEntitiesPermissionLevels = new HashSet<EntityIdEntityMapPermissionLevel>();
            this.TimeScheduleDayTypesTimePeriods = new HashSet<TimeScheduleDayTypeTimePeriod>();
            this.TimeScheduleDayTypesGalaxyTimePeriods = new HashSet<TimeScheduleDayTypeGalaxyTimePeriod>();
            this.DayTypesTimePeriods = new ObservableCollection<DayTypeTimePeriods>();
            this.Clusters = new ObservableCollection<ClusterTimeScheduleItem>();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this TimeSchedule. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The TimeSchedule to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Initialize(TimeSchedule e)
        {
            Initialize();
            base.Initialize(e);

            if (e == null)
                return;
            this.TimeScheduleUid = e.TimeScheduleUid;
            this.EntityId = e.EntityId;
            this.Display = e.Display;
            this.Description = e.Description;
            this.DisplayResourceKey = e.DisplayResourceKey;
            this.DescriptionResourceKey = e.DescriptionResourceKey;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            if (e.EntityIds != null)
                this.EntityIds = e.EntityIds.ToCollection();
            if (e.MappedEntitiesPermissionLevels != null)
                this.MappedEntitiesPermissionLevels = e.MappedEntitiesPermissionLevels.ToCollection();
            if (e.TimeScheduleDayTypesTimePeriods != null)
                this.TimeScheduleDayTypesTimePeriods = e.TimeScheduleDayTypesTimePeriods.ToCollection();
            if (e.TimeScheduleDayTypesGalaxyTimePeriods != null)
                this.TimeScheduleDayTypesGalaxyTimePeriods = e.TimeScheduleDayTypesGalaxyTimePeriods.ToCollection();
            if (e.DayTypesTimePeriods != null)
                this.DayTypesTimePeriods = e.DayTypesTimePeriods.ToObservableCollection();
            if (e.Clusters != null)
                this.Clusters = e.Clusters.ToObservableCollection();
            this.TotalRowCount = e.TotalRowCount;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Makes a deep copy of this TimeSchedule. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The TimeSchedule to process. </param>
        ///
        /// <returns>   A copy of this TimeSchedule. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public TimeSchedule Clone(TimeSchedule e)
        {
            return new TimeSchedule(e);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Tests if this TimeSchedule is considered equal to another. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="other">    The other. </param>
        ///
        /// <returns>   True if the objects are considered equal, false if they are not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool Equals(TimeSchedule other)
        {
            return base.Equals(other);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Query if 'other' is primary key equal. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="other">    The other. </param>
        ///
        /// <returns>   True if primary key equal, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool IsPrimaryKeyEqual(TimeSchedule other)
        {
            if (other == null)
                return false;

            if (other.TimeScheduleUid != this.TimeScheduleUid)
                return false;
            return true;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Serves as the default hash function. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <returns>   A hash code for the current object. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets information describing the fifteen minute format. </summary>
        ///
        /// <value> Information describing the fifteen minute format. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ObservableCollection<DayTypeTimePeriods> FifteenMinuteFormatData
        {
            get { return this.DayTypesTimePeriods.Where(i => i.IsFifteenMinuteFormatHolidayType || i.IsFifteenMinuteFormatStandardDayType).ToObservableCollection(); }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets information describing the fifteen minute format standard day. </summary>
        ///
        /// <value> Information describing the fifteen minute format standard day. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ObservableCollection<DayTypeTimePeriods> FifteenMinuteFormatStandardDayData
        {
            get { return this.DayTypesTimePeriods.Where(i => i.IsFifteenMinuteFormatStandardDayType).ToObservableCollection(); }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets information describing the fifteen minute format holiday. </summary>
        ///
        /// <value> Information describing the fifteen minute format holiday. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ObservableCollection<DayTypeTimePeriods> FifteenMinuteFormatHolidayData
        {
            get { return this.DayTypesTimePeriods.Where(i => i.IsFifteenMinuteFormatHolidayType).ToObservableCollection(); }
        }

        //public ObservableCollection<TimeScheduleDayTypeTimePeriod> FifteenMinuteFormatData
        //{
        //    get { return this.TimeScheduleDayTypesTimePeriods.Where(i => i.DayType.IsFifteenMinuteFormatHolidayType || i.DayType.IsFifteenMinuteFormatStandardDayType).ToObservableCollection(); }
        //}

        //public ObservableCollection<TimeScheduleDayTypeTimePeriod> FifteenMinuteFormatStandardDayData
        //{
        //    get { return this.TimeScheduleDayTypesTimePeriods.Where(i => i.DayType.IsFifteenMinuteFormatStandardDayType).ToObservableCollection(); }
        //}

        //public ObservableCollection<TimeScheduleDayTypeTimePeriod> FifteenMinuteFormatHolidayData
        //{
        //    get { return this.TimeScheduleDayTypesTimePeriods.Where(i => i.DayType.IsFifteenMinuteFormatHolidayType).ToObservableCollection(); }
        //}

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Returns a string that represents the current object. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <returns>   A string that represents the current object. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public override string ToString()
        {
            return base.ToString();
        }


        private int _TotalRowCount;

        [DataMember]
        public int TotalRowCount
        {
            get => _TotalRowCount;
            set
            {
                if (_TotalRowCount != value)
                {
                    _TotalRowCount = value;
                    OnPropertyChanged(() => TotalRowCount, false);
                }
            }
        }

        private ICollection<ClusterTimeScheduleItem> _clusters;

        [DataMember]
        public ICollection<ClusterTimeScheduleItem> Clusters
        {
            get { return _clusters; }
            set
            {
                if (_clusters != value)
                {
                    _clusters = value;
                    OnPropertyChanged(() => Clusters);
                }
            }
        }


    }
}
