////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	EfEntities\ExtendedClasses\TimeScheduleDayTypeTimePeriod.cs
//
// summary:	Implements the time schedule day type time period class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using GCS.Core.Common.Core;
using FluentValidation;
using System.Collections.ObjectModel;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A time schedule day type time period. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class TimeScheduleDayTypeTimePeriod
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public TimeScheduleDayTypeTimePeriod()
        {
            Initialize();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The TimeScheduleDayTypeTimePeriod to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public TimeScheduleDayTypeTimePeriod(TimeScheduleDayTypeTimePeriod e)
        {
            Initialize(e);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this TimeScheduleDayTypeTimePeriod. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Initialize()
        {
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this TimeScheduleDayTypeTimePeriod. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The TimeScheduleDayTypeTimePeriod to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Initialize(TimeScheduleDayTypeTimePeriod e)
        {
            Initialize();
            if (e == null)
                return;
            this.TimeScheduleDayTypeTimePeriodUid = e.TimeScheduleDayTypeTimePeriodUid;
            this.DayTypeUid = e.DayTypeUid;
            this.TimePeriodUid = e.TimePeriodUid;
            this.TimeScheduleUid = e.TimeScheduleUid;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

            this.DayType = e.DayType;
            this.TimePeriod = e.TimePeriod;

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Makes a deep copy of this TimeScheduleDayTypeTimePeriod. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The TimeScheduleDayTypeTimePeriod to process. </param>
        ///
        /// <returns>   A copy of this TimeScheduleDayTypeTimePeriod. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public TimeScheduleDayTypeTimePeriod Clone(TimeScheduleDayTypeTimePeriod e)
        {
            return new TimeScheduleDayTypeTimePeriod(e);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Tests if this TimeScheduleDayTypeTimePeriod is considered equal to another.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="other">    The other. </param>
        ///
        /// <returns>   True if the objects are considered equal, false if they are not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool Equals(TimeScheduleDayTypeTimePeriod other)
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

        public bool IsPrimaryKeyEqual(TimeScheduleDayTypeTimePeriod other)
        {
            if (other == null)
                return false;

            if (other.TimeScheduleDayTypeTimePeriodUid != this.TimeScheduleDayTypeTimePeriodUid)
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
    }
}
