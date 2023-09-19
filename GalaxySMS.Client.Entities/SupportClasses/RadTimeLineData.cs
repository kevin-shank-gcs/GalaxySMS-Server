////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	SupportClasses\RadTimeLineData.cs
//
// summary:	Implements the radians time line data class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Resources;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   The radians timeline data item. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class RadTimelineDataItem
    {
        /// <summary>   The duration. </summary>
        private TimeSpan duration;
        /// <summary>   The start date. </summary>
        private DateTimeOffset startDate;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the start date. </summary>
        ///
        /// <value> The start date. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DateTimeOffset StartDate
        {
            get
            {
                return this.startDate;
            }

            set
            {
                this.startDate = value;
                EndTime = StartDate + Duration;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the end time. </summary>
        ///
        /// <value> The end time. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DateTimeOffset EndTime { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the duration. </summary>
        ///
        /// <value> The duration. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public TimeSpan Duration
        {
            get
            {
                return this.duration;
            }

            set
            {
                this.duration = value;
                EndTime = StartDate + Duration;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the tool tip. </summary>
        ///
        /// <value> The tool tip. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string ToolTip
        {
            get
            {
                //var s = string.Format("{0} - {1} ({2})", StartDate.ToString("hh:mm tt"), EndTime.ToString("hh:mm tt"),
                //    Duration.ToString());
                //return s;// string.Format("This is a pain");
                return string.Format(Resources.Resources.DayPeriod_TimePeriodTimeBarToolTipFormat, 
                    StartDate.ToString("hh:mm tt"), 
                    EndTime.ToString("hh:mm tt"),
                    Duration.Hours, 
                    Duration.Minutes); 
            }
            //get { return string.Format("{0:tt} - {1:tt} {2:hh:mm})", StartDate, EndTime, Duration); }
            //get { return string.Format(Resources.Resources.DayPeriod_TimePeriodTimeBarToolTipFormat, StartDate, EndTime, Duration); }
        }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   The radians timeline start end item. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class RadTimelineStartEndItem
    {
        /// <summary>   The end time. </summary>
        private DateTimeOffset _endTime;
        /// <summary>   The start time. </summary>
        private DateTimeOffset _startTime;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public RadTimelineStartEndItem()
        {
            _startTime = DateTimeOffset.Now.Today();
            _endTime = DateTimeOffset.Now.Today().AddDays(1);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the start time. </summary>
        ///
        /// <value> The start time. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DateTimeOffset StartTime
        {
            get { return _startTime; }
            set
            {
                if (value <= _endTime)
                    _startTime = value;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the end time. </summary>
        ///
        /// <value> The end time. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DateTimeOffset EndTime
        {
            get { return _endTime; }
            set
            {
                if (value >= _startTime)
                    _endTime = value;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the tool tip. </summary>
        ///
        /// <value> The tool tip. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string ToolTip
        {
            get { return string.Format("{0:t} - {1:t}", StartTime, EndTime); }
        }

    }
}
