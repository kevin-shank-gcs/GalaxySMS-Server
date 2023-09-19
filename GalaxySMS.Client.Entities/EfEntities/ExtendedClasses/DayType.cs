////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	EfEntities\ExtendedClasses\DayType.cs
//
// summary:	Implements the day type class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using GalaxySMS.Common.Enums;
using GCS.Core.Common.Extensions;
using GCS.Core.Common.Utils;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A day type. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class DayType
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DayType()
        {
            Initialize();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The DayType to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DayType(DayType e)
        {
            Initialize(e);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this DayType. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Initialize()
        {
            DateTypes = new HashSet<DateType>();
            DayTypeFifteenMinuteTimePeriods = new HashSet<TimeScheduleDayTypeTimePeriod>();
            //DayTypeOneMinuteTimePeriods = new HashSet<TimeScheduleDayTypeTimePeriod>();

            EntityIds = new HashSet<Guid>();
            MappedEntitiesPermissionLevels = new HashSet<EntityIdEntityMapPermissionLevel>();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this DayType. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The DayType to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Initialize(DayType e)
        {
            Initialize();
            if (e == null)
                return;
            DayTypeUid = e.DayTypeUid;
            EntityId = e.EntityId;
            Name = e.Name;
            Notes = e.Notes;
            HighlightColor = e.HighlightColor;
            DayTypeCode = e.DayTypeCode;
            IsActive = e.IsActive;
            InsertName = e.InsertName;
            InsertDate = e.InsertDate;
            UpdateName = e.UpdateName;
            UpdateDate = e.UpdateDate;
            ConcurrencyValue = e.ConcurrencyValue;
            DateTypes = e.DateTypes.ToCollection();
            DayTypeFifteenMinuteTimePeriods = e.DayTypeFifteenMinuteTimePeriods.ToCollection();
            //DayTypeOneMinuteTimePeriods = e.DayTypeOneMinuteTimePeriods.ToCollection();
            if (e.EntityIds != null)
                EntityIds = e.EntityIds.ToCollection();
            if (e.MappedEntitiesPermissionLevels != null)
                this.MappedEntitiesPermissionLevels = e.MappedEntitiesPermissionLevels.ToCollection();
            this.TotalRowCount = e.TotalRowCount;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Makes a deep copy of this DayType. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The DayType to process. </param>
        ///
        /// <returns>   A copy of this DayType. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DayType Clone(DayType e)
        {
            return new DayType(e);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Tests if this DayType is considered equal to another. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="other">    The other. </param>
        ///
        /// <returns>   True if the objects are considered equal, false if they are not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool Equals(DayType other)
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

        public bool IsPrimaryKeyEqual(DayType other)
        {
            if (other == null)
                return false;

            if (other.DayTypeUid != DayTypeUid)
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
        /// <summary>
        /// Gets or sets a value indicating whether this DayType is fifteen minute format holiday type.
        /// </summary>
        ///
        /// <value> True if this DayType is fifteen minute format holiday type, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        //[DataMember]
        public bool IsFifteenMinuteFormatHolidayType
        {
            //get; set;
            get
            {
                switch (DayTypeCode)
                {
                    case DayTypeCode.DayType1:
                    case DayTypeCode.DayType2:
                    case DayTypeCode.DayType3:
                    case DayTypeCode.DayType4:
                    case DayTypeCode.DayType5:
                    case DayTypeCode.DayType6:
                    case DayTypeCode.DayType7:
                    case DayTypeCode.DayType8:
                    case DayTypeCode.DayType9:
                        return true;
                }

                return false;
            }
            //set { }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets or sets a value indicating whether this DayType is fifteen minute format standard day
        /// type.
        /// </summary>
        ///
        /// <value> True if this DayType is fifteen minute format standard day type, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        //[DataMember]
        public bool IsFifteenMinuteFormatStandardDayType
        {
            //get; set;
            get
            {
                switch (DayTypeCode)
                {
                    case DayTypeCode.Sunday:
                    case DayTypeCode.Monday:
                    case DayTypeCode.Tuesday:
                    case DayTypeCode.Wednesday:
                    case DayTypeCode.Thursday:
                    case DayTypeCode.Friday:
                    case DayTypeCode.Saturday:
                        return true;
                }

                return false;
            }
            //set {}
        }

        public string HighlightColorRGBA
        {
            get
            {
                return HighlightColor.ToRGBA();
            }
            set
            {
                HighlightColor = value.RGBAToInt();
            }
        }


        public int TelerikHighlightColor
        {
            get { return ByteFlipper.RotateBytesLeft(HighlightColor); }
            set
            {
                HighlightColor = ByteFlipper.RotateBytesRight(value);
                OnPropertyChanged(() => TelerikHighlightColor, true);
            }
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


    }
}
