////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	PanelMessages\ScheduleNumber.cs
//
// summary:	Implements the schedule number class
////////////////////////////////////////////////////////////////////////////////////////////////////

using GCS.Core.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent system schedules. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public enum SystemSchedule { Never = 0, Always = 255 }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A schedule number. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class ScheduleNumber : ObjectBase
    {
        /// <summary>   The schedule number. </summary>
        private Int32 _scheduleNumber;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Values that represent schedule number limits. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public enum ScheduleNumberLimits { MinimumScheduleNumber = 0, MaximumScheduleNumber = 255 }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets a unique identifier. </summary>
        ///
        /// <value> The identifier of the unique. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public String UniqueId { get { return string.Format("{0:D3}", Number); } }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the number of.  </summary>
        ///
        /// <exception cref="ArgumentOutOfRangeException">  Thrown when one or more arguments are outside
        ///                                                 the required range. </exception>
        ///
        /// <value> The number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Int32 Number
        {
            get { return _scheduleNumber; }
            set
            {
                if (value >= (Int32)ScheduleNumberLimits.MinimumScheduleNumber && value <= (Int32)ScheduleNumberLimits.MaximumScheduleNumber)
                {
                    _scheduleNumber = value;
                    if (_scheduleNumber != value)
                    {
                        _scheduleNumber = value;
                        OnPropertyChanged(() => Number);
                    }
                }
                else
                    throw new ArgumentOutOfRangeException("ScheduleNumber.Number", value, string.Format("The ScheduleNumber.Number value must be between {0} and {1}",
                        ScheduleNumberLimits.MinimumScheduleNumber, ScheduleNumberLimits.MaximumScheduleNumber));
            }
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
            return UniqueId;
        }
    }
}
