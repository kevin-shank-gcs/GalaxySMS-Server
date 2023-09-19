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
    public class ClusterEditingData : DtoObjectBase
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ClusterEditingData()
        {
            ClusterTypes = new List<ClusterType>();
            CredentialDataLengths = new List<CredentialDataLength>();
            TimeScheduleTypes = new List<TimeScheduleType>();
            AccessRuleOverrideTimeoutValues = new List<StringIntPair>();
            UnlimitedCredentialTimeoutValues = new List<StringIntPair>();
            TimeZones = new List<TimeZoneListItem>();
            LedBehaviorModes = new List<ClusterLedBehaviorMode>();
            AccessPortalTypes = new List<AccessPortalType>();
            Entities = new List<gcsEntityListItem>();

        }

        /// <summary>   List of types of the clusters. </summary>
        private IList<ClusterType> _clusterTypes;
        /// <summary>   List of lengths of the credential data. </summary>
        private IList<CredentialDataLength> _credentialDataLengths;
        /// <summary>   List of types of the time schedules. </summary>
        private IList<TimeScheduleType> _timeScheduleTypes;
        /// <summary>   The access rule override timeout values. </summary>
        private IList<StringIntPair> _accessRuleOverrideTimeoutValues;
        /// <summary>   The unlimited credential timeout values. </summary>
        private IList<StringIntPair> _unlimitedCredentialTimeoutValues;
        /// <summary>   The time zones. </summary>
        private IList<TimeZoneListItem> _timeZones;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the LED behavior modes. </summary>
        ///
        /// <value> The LED behavior modes. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private IList<ClusterLedBehaviorMode> _ledBehaviorModes;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a list of types of the access portals. </summary>
        ///
        /// <value> A list of types of the access portals. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private IList<AccessPortalType> _accessPortalTypes;

        private IList<gcsEntityListItem> _entityListItems;
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a list of types of the clusters. </summary>
        ///
        /// <value> A list of types of the clusters. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public IList<ClusterType> ClusterTypes
        {
            get { return _clusterTypes; }
            set
            {
                if (_clusterTypes != value)
                {
                    _clusterTypes = value;
                    OnPropertyChanged(() => ClusterTypes, false);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a list of lengths of the credential data. </summary>
        ///
        /// <value> A list of lengths of the credential data. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public IList<CredentialDataLength> CredentialDataLengths
        {
            get { return _credentialDataLengths; }
            set
            {
                if (_credentialDataLengths != value)
                {
                    _credentialDataLengths = value;
                    OnPropertyChanged(() => CredentialDataLengths, false);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a list of types of the time schedules. </summary>
        ///
        /// <value> A list of types of the time schedules. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public IList<TimeScheduleType> TimeScheduleTypes
        {
            get { return _timeScheduleTypes; }
            set
            {
                if (_timeScheduleTypes != value)
                {
                    _timeScheduleTypes = value;
                    OnPropertyChanged(() => TimeScheduleTypes, false);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the access rule override timeout values. </summary>
        ///
        /// <value> The access rule override timeout values. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public IList<StringIntPair> AccessRuleOverrideTimeoutValues
        {
            get { return _accessRuleOverrideTimeoutValues; }
            set
            {
                if (_accessRuleOverrideTimeoutValues != value)
                {
                    _accessRuleOverrideTimeoutValues = value;
                    OnPropertyChanged(() => AccessRuleOverrideTimeoutValues, false);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the unlimited credential timeout values. </summary>
        ///
        /// <value> The unlimited credential timeout values. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public IList<StringIntPair> UnlimitedCredentialTimeoutValues
        {
            get { return _unlimitedCredentialTimeoutValues; }
            set
            {
                if (_unlimitedCredentialTimeoutValues != value)
                {
                    _unlimitedCredentialTimeoutValues = value;
                    OnPropertyChanged(() => UnlimitedCredentialTimeoutValues, false);
                }
            }
        }

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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the LED behavior modes. </summary>
        ///
        /// <value> The LED behavior modes. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public IList<ClusterLedBehaviorMode> LedBehaviorModes
        {
            get { return _ledBehaviorModes; }
            set
            {
                if (_ledBehaviorModes != value)
                {
                    _ledBehaviorModes = value;
                    OnPropertyChanged(() => LedBehaviorModes, false);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a list of types of the access portals. </summary>
        ///
        /// <value> A list of types of the access portals. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public IList<AccessPortalType> AccessPortalTypes
        {
            get { return _accessPortalTypes; }
            set
            {
                if (_accessPortalTypes != value)
                {
                    _accessPortalTypes = value;
                    OnPropertyChanged(() => AccessPortalTypes, false);
                }
            }
        }

        [DataMember]
        public IList<gcsEntityListItem> Entities
        {
            get { return _entityListItems; }
            set
            {
                if (_entityListItems != value)
                {
                    _entityListItems = value;
                    OnPropertyChanged(() => Entities, false);
                }
            }
        }


    }
}
