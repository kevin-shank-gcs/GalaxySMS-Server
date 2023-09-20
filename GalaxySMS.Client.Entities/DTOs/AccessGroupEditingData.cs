////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	DTOs\AccessProfileEditingData.cs
//
// summary:	Implements the access profile editing data class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Core;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   The access group editing data. </summary>
    ///
    /// <seealso cref="T:GCS.Core.Common.Core.DtoObjectBase"/>
    ///=================================================================================================

    [DataContract]
    public class AccessGroupEditingData : DtoObjectBase
    {
        /// <summary>   The time schedules. </summary>
        private IList<TimeSchedule> _timeSchedules;
        /// <summary>   The access portals. </summary>
        private IList<AccessPortalListItem> _accessPortals;
        /// <summary>   The cluster UID. </summary>
        private Guid _clusterUid;
        
        
        /// <summary>   Default constructor. </summary>
        public AccessGroupEditingData()
        {
            AccessPortals = new List<AccessPortalListItem>();
            TimeSchedules = new List<TimeSchedule>();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the cluster UID. </summary>
        ///
        /// <value> The cluster UID. </value>
        ///=================================================================================================

        [DataMember]
        public Guid ClusterUid
        {
            get { return _clusterUid; }
            set
            {
                if (_clusterUid != value)
                {
                    _clusterUid = value;
                    OnPropertyChanged(() => ClusterUid, false);
                }
            }
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the access portals. </summary>
        ///
        /// <value> The access portals. </value>
        ///=================================================================================================

        [DataMember]
        public IList<AccessPortalListItem> AccessPortals
        {
            get { return _accessPortals; }
            set
            {
                if (_accessPortals != value)
                {
                    _accessPortals = value;
                    OnPropertyChanged(() => AccessPortals, false);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the time schedules. </summary>
        ///
        /// <value> The time schedules. </value>
        ///=================================================================================================

        [DataMember]
        public IList<TimeSchedule> TimeSchedules
        {
            get { return _timeSchedules; }
            set
            {
                if (_timeSchedules != value)
                {
                    _timeSchedules = value;
                    OnPropertyChanged(() => TimeSchedules, false);
                }
            }
        }


    }
}