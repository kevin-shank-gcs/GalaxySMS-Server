////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	DTOs\TimeScheduleSelect.cs
//
// summary:	Implements the time schedule select class
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
    /// <summary>   A time schedule select. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class TimeScheduleSelect : TimeSchedule
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public TimeScheduleSelect() : base()
        {
            Initialize();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="o">    The TimeScheduleSelect to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public TimeScheduleSelect(TimeSchedule o) : base(o)
        {
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="o">    The TimeScheduleSelect to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public TimeScheduleSelect(TimeScheduleSelect o) :base(o)
        {
            Initialize(o);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this TimeScheduleSelect. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void Initialize()
        {
            base.Initialize();
            this.ClusterScheduleMap = new GalaxyClusterTimeScheduleMap();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this TimeScheduleSelect. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="o">    The TimeScheduleSelect to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void Initialize(TimeScheduleSelect o)
        {
            base.Initialize(o);
            this.Selected = o.Selected;
            this.ClusterScheduleMap = o.ClusterScheduleMap;
        }

        /// <summary>   True if selected. </summary>
        private bool _selected;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether the selected. </summary>
        ///
        /// <value> True if selected, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public bool Selected
        {
            get { return _selected; }
            set
            {
                if (_selected != value)
                {
                    _selected = value;
                    OnPropertyChanged(() => Selected);
                }
            }
        }

        /// <summary>   The cluster schedule map. </summary>
        private GalaxyClusterTimeScheduleMap _clusterScheduleMap;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the cluster schedule map. </summary>
        ///
        /// <value> The cluster schedule map. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public GalaxyClusterTimeScheduleMap ClusterScheduleMap
        {
            get { return _clusterScheduleMap; }
            set
            {
                if (_clusterScheduleMap != value)
                {
                    _clusterScheduleMap = value;
                    OnPropertyChanged(() => ClusterScheduleMap);
                }
            }
        }


    }
}
