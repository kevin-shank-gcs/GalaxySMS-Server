////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	DTOs\DayTypeTimePeriods.cs
//
// summary:	Implements the day type time periods class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Security;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Core;
using GCS.Framework.Security;
using FluentValidation;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A day type time periods. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class DayTypeTimePeriods : DayType
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DayTypeTimePeriods() : base()
        {
            Initialize();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="o">    The DayTypeTimePeriods to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DayTypeTimePeriods(DayType o) : base(o)
        {
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="o">    The DayTypeTimePeriods to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DayTypeTimePeriods(DayTypeTimePeriods o) :base(o)
        {
            Initialize(o);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this DayTypeTimePeriods. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void Initialize()
        {
            base.Initialize();
            //this.TimePeriods = new ObservableCollection<TimePeriod>();
            this.FifteenMinuteTimePeriods = new ObservableCollection<TimePeriod>();

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this DayTypeTimePeriods. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="o">    The DayTypeTimePeriods to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void Initialize(DayTypeTimePeriods o)
        {
            base.Initialize(o);
            //this.TimePeriods = o.TimePeriods;
            this.FifteenMinuteTimePeriods = o.FifteenMinuteTimePeriods;
            GalaxyTimePeriodUid = o.GalaxyTimePeriodUid;
        }


        //private ObservableCollection<TimePeriod> _TimePeriods;

        //[DataMember]
        //public ObservableCollection<TimePeriod> TimePeriods
        //{
        //    get { return _TimePeriods; }
        //    set
        //    {
        //        if (_TimePeriods != value)
        //        {
        //            _TimePeriods = value;
        //            OnPropertyChanged(() => TimePeriods);
        //        }
        //    }
        //}

        /// <summary>   The fifteen minute time periods. </summary>
        private ObservableCollection<TimePeriod> _FifteenMinuteTimePeriods;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the fifteen minute time periods. </summary>
        ///
        /// <value> The fifteen minute time periods. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public ObservableCollection<TimePeriod> FifteenMinuteTimePeriods
        {
            get { return _FifteenMinuteTimePeriods; }
            set
            {
                if (_FifteenMinuteTimePeriods != value)
                {
                    _FifteenMinuteTimePeriods = value;
                    OnPropertyChanged(() => FifteenMinuteTimePeriods);
                }
            }
        }

        /// <summary>   The galaxy time period UID. </summary>
        private Guid _galaxyTimePeriodUid;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the galaxy time period UID. </summary>
        ///
        /// <value> The galaxy time period UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Guid GalaxyTimePeriodUid
        {
            get { return _galaxyTimePeriodUid; }
            set
            {
                if (_galaxyTimePeriodUid != value)
                {
                    _galaxyTimePeriodUid = value;
                    OnPropertyChanged(() => GalaxyTimePeriodUid, true, true);
                }
            }
        }

        //private ObservableCollection<TimePeriod> _OneMinuteTimePeriods;

        //[DataMember]
        //public ObservableCollection<TimePeriod> OneMinuteTimePeriods
        //{
        //    get { return _OneMinuteTimePeriods; }
        //    set
        //    {
        //        if (_OneMinuteTimePeriods != value)
        //        {
        //            _OneMinuteTimePeriods = value;
        //            OnPropertyChanged(() => OneMinuteTimePeriods);
        //        }
        //    }
        //}
    }
}
