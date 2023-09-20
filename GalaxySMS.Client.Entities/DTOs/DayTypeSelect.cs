////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	DTOs\DayTypeSelect.cs
//
// summary:	Implements the day type select class
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
    /// <summary>   A day type select. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class DayTypeSelect : DayType
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DayTypeSelect() : base()
        {
            Initialize();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="o">    The DayTypeSelect to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DayTypeSelect(DayType o) : base(o)
        {
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="o">    The DayTypeSelect to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DayTypeSelect(DayTypeSelect o) :base(o)
        {
            Initialize(o);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this DayTypeSelect. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void Initialize()
        {
            base.Initialize();
            this.ClusterDayTypeMap = new GalaxyClusterDayTypeMap();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this DayTypeSelect. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="o">    The DayTypeSelect to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void Initialize(DayTypeSelect o)
        {
            base.Initialize(o);
            this.Selected = o.Selected;
            this.ClusterDayTypeMap = o.ClusterDayTypeMap;
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

        /// <summary>   The cluster day type map. </summary>
        private GalaxyClusterDayTypeMap _clusterDayTypeMap;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the cluster day type map. </summary>
        ///
        /// <value> The cluster day type map. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public GalaxyClusterDayTypeMap ClusterDayTypeMap
        {
            get { return _clusterDayTypeMap; }
            set
            {
                if (_clusterDayTypeMap != value)
                {
                    _clusterDayTypeMap = value;
                    OnPropertyChanged(() => ClusterDayTypeMap);
                }
            }
        }


    }
}
