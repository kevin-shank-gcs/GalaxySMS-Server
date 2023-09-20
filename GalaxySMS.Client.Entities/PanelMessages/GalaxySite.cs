////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	PanelMessages\GalaxySite.cs
//
// summary:	Implements the galaxy site class
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
    /// <summary>   A galaxy site. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class GalaxySite : ObjectBase
    {
        /// <summary>   Identifier for the site. </summary>
        private string _siteId;
        /// <summary>   Name of the site. </summary>
        private string _siteName;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxySite()
            : base()
        {
            SiteId = string.Empty;
            SiteName = string.Empty;

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="siteId">   The identifier of the site. </param>
        /// <param name="siteName"> The name of the site. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxySite(String siteId, String siteName)
            : base()
        {
            SiteId = siteId;
            SiteName = siteName;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="o">    The GalaxySite to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxySite(GalaxySite o)
            : base()
        {
            SiteId = o.SiteId;
            SiteName = o.SiteName;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets a unique identifier. </summary>
        ///
        /// <value> The identifier of the unique. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public String UniqueId { get { return SiteId; } }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of the site. </summary>
        ///
        /// <value> The identifier of the site. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public String SiteId
        {
            get { return _siteId; }
            set
            {
                if (_siteId != value)
                {
                    _siteId = value;
                    OnPropertyChanged(() => SiteId);
                }

            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the site. </summary>
        ///
        /// <value> The name of the site. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public String SiteName
        {
            get { return _siteName; }
            set
            {
                if (_siteName != value)
                {
                    _siteName = value;
                    OnPropertyChanged(() => SiteName);
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
