////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	DTOs\ClusterEditingData.cs
//
// summary:	Implements the cluster editing data class
////////////////////////////////////////////////////////////////////////////////////////////////////

using GCS.Core.Common.Core;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A cluster editing data. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class EntityEditingData : DtoObjectBase
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public EntityEditingData()
        {
            TimeZones = new List<TimeZoneListItem>();
        }

        /// <summary>   The time zones. </summary>
        private IList<TimeZoneListItem> _timeZones;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the time zones. </summary>
        ///
        /// <value> The time zones. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public IList<TimeZoneListItem> TimeZones
        {
            get { return _timeZones; }
            set
            {
                if (_timeZones != value)
                {
                    _timeZones = value;
                    OnPropertyChanged(() => TimeZones, false);
                }
            }
        }


    }
}
