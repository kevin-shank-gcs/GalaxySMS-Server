////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	PanelMessages\GalaxyRegion.cs
//
// summary:	Implements the galaxy region class
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
    /// <summary>   A galaxy region. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class GalaxyRegion : ObjectBase
    {
        /// <summary>   Identifier for the region. </summary>
        private string _regionId;
        /// <summary>   Name of the region. </summary>
        private string _regionName;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxyRegion()
            : base()
        {
            RegionId = string.Empty;
            RegionName = string.Empty;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="regionId">     The identifier of the region. </param>
        /// <param name="regionName">   The name of the region. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxyRegion(String regionId, String regionName)
            : base()
        {
            RegionId = regionId;
            RegionName = regionName;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="o">    The GalaxyRegion to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxyRegion(GalaxyRegion o)
            : base()
        {
            RegionId = o.RegionId;
            RegionName = o.RegionName;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets a unique identifier. </summary>
        ///
        /// <value> The identifier of the unique. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public String UniqueId { get { return RegionId; } }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of the region. </summary>
        ///
        /// <value> The identifier of the region. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public String RegionId
        {
            get { return _regionId; }
            set
            {
                if (_regionId != value)
                {
                    _regionId = value;
                    OnPropertyChanged(() => RegionId);
                }

            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the region. </summary>
        ///
        /// <value> The name of the region. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public String RegionName
        {
            get { return _regionName; }
            set
            {
                if (_regionName != value)
                {
                    _regionName = value;
                    OnPropertyChanged(() => RegionName);
                }

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
