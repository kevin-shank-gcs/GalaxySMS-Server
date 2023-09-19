////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	EfEntities\ExtendedClasses\AssaDayPeriod.cs
//
// summary:	Implements the assa day period class
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
    /// <summary>   An assa day period. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class AssaDayPeriod
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public AssaDayPeriod()
        {
            Initialize();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The AssaDayPeriod to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public AssaDayPeriod(AssaDayPeriod e)
        {
            Initialize(e);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this AssaDayPeriod. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Initialize()
        {
            this.AssaDayPeriodTimePeriods = new HashSet<AssaDayPeriodTimePeriod>();
            this.AssaTimeScheduleDayPeriods = new HashSet<AssaTimeScheduleDayPeriod>();
            this.EntityIds = new HashSet<Guid>();
            this.MappedEntitiesPermissionLevels = new HashSet<EntityIdEntityMapPermissionLevel>();
            this.TimePeriods = new ObservableCollection<TimePeriod>();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this AssaDayPeriod. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The AssaDayPeriod to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Initialize(AssaDayPeriod e)
        {
            Initialize();
            if (e == null)
                return;
            this.AssaDayPeriodUid = e.AssaDayPeriodUid;
            this.EntityId = e.EntityId;
            this.Name = e.Name;
            this.Sunday = e.Sunday;
            this.Monday = e.Monday;
            this.Tuesday = e.Tuesday;
            this.Wednesday = e.Wednesday;
            this.Thursday = e.Thursday;
            this.Friday = e.Friday;
            this.Saturday = e.Saturday;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.AssaDsrDayPeriodId = e.AssaDsrDayPeriodId;
            this.AssaDayPeriodTimePeriods = e.AssaDayPeriodTimePeriods.ToCollection();
            this.AssaTimeScheduleDayPeriods = e.AssaTimeScheduleDayPeriods.ToCollection();
            if (e.EntityIds != null)
                this.EntityIds = e.EntityIds.ToCollection();
            if (e.MappedEntitiesPermissionLevels != null)
                this.MappedEntitiesPermissionLevels = e.MappedEntitiesPermissionLevels.ToCollection();
            if (e.TimePeriods != null)
            {
                //                this.TimePeriods = e.TimePeriods.ToObservableCollection();
                foreach (var tp in e.TimePeriods)
                    this.TimePeriods.Add(new TimePeriod(tp));
            }

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Makes a deep copy of this AssaDayPeriod. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The AssaDayPeriod to process. </param>
        ///
        /// <returns>   A copy of this AssaDayPeriod. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public AssaDayPeriod Clone(AssaDayPeriod e)
        {
            return new AssaDayPeriod(e);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Tests if this AssaDayPeriod is considered equal to another. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="other">    The other. </param>
        ///
        /// <returns>   True if the objects are considered equal, false if they are not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool Equals(AssaDayPeriod other)
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

        public bool IsPrimaryKeyEqual(AssaDayPeriod other)
        {
            if (other == null)
                return false;

            if (other.AssaDayPeriodUid != this.AssaDayPeriodUid)
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
