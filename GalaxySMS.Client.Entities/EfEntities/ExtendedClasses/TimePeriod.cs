////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	EfEntities\ExtendedClasses\TimePeriod.cs
//
// summary:	Implements the time period class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using GCS.Core.Common.Core;
using FluentValidation;
using System.Collections.ObjectModel;
using GCS.Core.Common.Extensions;
using System.Data.SqlTypes;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A time period. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class TimePeriod
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public TimePeriod()
        {
            Initialize();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The TimePeriod to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public TimePeriod(TimePeriod e)
        {
            Initialize(e);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this TimePeriod. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Initialize()
        {
            base.Initialize();
            this.EntityIds = new HashSet<Guid>();
            this.MappedEntitiesPermissionLevels = new HashSet<EntityIdEntityMapPermissionLevel>();
            this.StartTime = new TimeSpan(0,0,0);
            this.EndTime = new TimeSpan(0, 23,59,59, 999);
            this.DayStart = DateTimeOffset.Now.Today();
            this.DayEnd = DateTimeOffset.Now.Today().AddHours(24);
            this.TimelineItems = new ObservableCollection<RadTimelineDataItem>();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this TimePeriod. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The TimePeriod to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Initialize(TimePeriod e)
        {
            Initialize();
            if (e == null)
                return;
            this.TimePeriodUid = e.TimePeriodUid;
            this.GalaxyTimePeriodUid = e.GalaxyTimePeriodUid;
            this.EntityId = e.EntityId;
            this.Name = e.Name;
            this.StartTime = e.StartTime;
            this.EndTime = e.EndTime;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            if (e.EntityIds != null)
                this.EntityIds = e.EntityIds.ToCollection();
            if (e.MappedEntitiesPermissionLevels != null)
                this.MappedEntitiesPermissionLevels = e.MappedEntitiesPermissionLevels.ToCollection();
            // The TimelineItems collection is built within the StartTime and EndTime setters, so the source collection does not need to be copied
            //this.TimelineItems = e.TimelineItems.ToObservableCollection();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Makes a deep copy of this TimePeriod. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The TimePeriod to process. </param>
        ///
        /// <returns>   A copy of this TimePeriod. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public TimePeriod Clone()
        {
            return new TimePeriod(this);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Tests if this TimePeriod is considered equal to another. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="other">    The other. </param>
        ///
        /// <returns>   True if the objects are considered equal, false if they are not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool Equals(TimePeriod other)
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

        public bool IsPrimaryKeyEqual(TimePeriod other)
        {
            if (other == null)
                return false;

            if (other.TimePeriodUid != this.TimePeriodUid)
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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Generates a default name. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void GenerateDefaultName()
        {
            //if (Name.IsNullWhiteSpaceOrEmpty())
            //{
            if (StartTime != null && EndTime != null)
                Name = string.Format("{0:t} - {1:t}", StartTime, EndTime);
            //}
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Updates the radians time line data. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void UpdateRadTimeLineData()
        {
            this.TimelineItems = new ObservableCollection<RadTimelineDataItem>();
            var startDate = new DateTimeOffset(DateTimeOffset.Now.Today().Year, DateTimeOffset.Now.Today().Month, DateTimeOffset.Now.Today().Day, StartTime.Hours, StartTime.Minutes, StartTime.Seconds, TimeSpan.Zero);
            var endDate = new DateTimeOffset(DateTimeOffset.Now.Today().Year, DateTimeOffset.Now.Today().Month, DateTimeOffset.Now.Today().Day, EndTime.Hours, EndTime.Minutes, EndTime.Seconds, TimeSpan.Zero);
            if( EndTime >= StartTime)
                TimelineItems.Add(new RadTimelineDataItem() { StartDate = startDate, Duration = EndTime - StartTime });
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the Date/Time of the day start. </summary>
        ///
        /// <value> The day start. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DateTimeOffset DayStart { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the Date/Time of the day end. </summary>
        ///
        /// <value> The day end. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DateTimeOffset DayEnd { get; set; }

        /// <summary>   The time line items. </summary>
        private ObservableCollection<RadTimelineDataItem> _timeLineItems;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the timeline items. </summary>
        ///
        /// <value> The timeline items. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ObservableCollection<RadTimelineDataItem> TimelineItems
        {
            get { return _timeLineItems; }
            set
            {
                if (_timeLineItems != value)
                {
                    _timeLineItems = value;
                    OnPropertyChanged(() => TimelineItems, false);
                }
            }
        }

    }
}
