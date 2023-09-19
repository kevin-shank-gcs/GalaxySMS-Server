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
    /// <summary>   A access profile editing data. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class AccessProfileEditingData : DtoObjectBase
    {
        /// <summary>   The sites. </summary>
        private IList<Site> _sites;
        /// <summary>   The access profiles. </summary>
        private IList<AccessProfile> _accessProfiles;
        /// <summary>   Information describing the access and alarm control permissions editing. </summary>
        private AccessAndAlarmControlPermissionsEditingData _accessAndAlarmControlPermissionsEditingData;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public AccessProfileEditingData()
        {
            AccessProfiles = new List<AccessProfile>();
            Sites = new List<Site>();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the sites. </summary>
        ///
        /// <value> The sites. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public IList<Site> Sites
        {
            get { return _sites; }
            set
            {
                if (_sites != value)
                {
                    _sites = value;
                    OnPropertyChanged(() => Sites, false);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the access profiles. </summary>
        ///
        /// <value> The access profiles. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public IList<AccessProfile> AccessProfiles
        {
            get { return _accessProfiles; }
            set
            {
                if (_accessProfiles != value)
                {
                    _accessProfiles = value;
                    OnPropertyChanged(() => AccessProfiles, false);
                }
            }
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets or sets information describing the access and alarm control permissions editing.
        /// </summary>
        ///
        /// <value> Information describing the access and alarm control permissions editing. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public AccessAndAlarmControlPermissionsEditingData AccessAndAlarmControlPermissionsEditingData
        {
            get { return _accessAndAlarmControlPermissionsEditingData; }
            set
            {
                if (_accessAndAlarmControlPermissionsEditingData != value)
                {
                    _accessAndAlarmControlPermissionsEditingData = value;
                    OnPropertyChanged(() => AccessAndAlarmControlPermissionsEditingData, false);
                }
            }
        }


    }
}