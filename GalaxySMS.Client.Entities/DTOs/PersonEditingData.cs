////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	DTOs\PersonEditingData.cs
//
// summary:	Implements the person editing data class
////////////////////////////////////////////////////////////////////////////////////////////////////

using GCS.Core.Common.Core;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A person editing data. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class PersonEditingData : DtoObjectBase
    {
        /// <summary>   The countries. </summary>
        private IList<Country> _countries;
        /// <summary>   List of types of the person active status. </summary>
        private IList<PersonActiveStatusType> _personActiveStatusTypes;
        /// <summary>   The genders. </summary>
        private IList<Gender> _genders;
        /// <summary>   The departments. </summary>
        private IList<Department> _departments;
        /// <summary>   List of types of the person records. </summary>
        private IList<PersonRecordType> _personRecordTypes;
        ///// <summary>   The sites. </summary>
        //private IList<Site> _sites;
        /// <summary>   The access profiles. </summary>
        private IList<AccessProfile> _accessProfiles;
        /// <summary>   The badge templates. </summary>
        private IList<BadgeTemplate> _badgeTemplates;
        /// <summary>   The cell carriers. </summary>
        private IList<CellCarrier> _cellCarriers;
        /// <summary>   The command scripts. </summary>
        private IList<CommandScript> _commandScripts;
        /// <summary>   The person activation modes. </summary>
        private IList<PersonActivationMode> _personActivationModes;
        /// <summary>   The person expiration modes. </summary>
        private IList<PersonExpirationMode> _personExpirationModes;
        /// <summary>   The credential formats. </summary>
        private IList<CredentialFormat> _credentialFormats;
        /// <summary>   The person credential roles. </summary>
        private IList<PersonCredentialRole> _personCredentialRoles;
        /// <summary>   The access portal no server reply behaviors. </summary>
        private IList<AccessPortalNoServerReplyBehavior> _accessPortalNoServerReplyBehaviors;
        /// <summary>   The access portal defer to server behaviors. </summary>
        private IList<AccessPortalDeferToServerBehavior> _accessPortalDeferToServerBehaviors;
        /// <summary>   Information describing the access and alarm control permissions editing. </summary>
        private AccessAndAlarmControlPermissionsEditingData _accessAndAlarmControlPermissionsEditingData;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public PersonEditingData()
        {
            Countries = new List<Country>();
            PersonActiveStatusTypes = new List<PersonActiveStatusType>();
            Genders = new List<Gender>();
            Departments = new List<Department>();
            PersonRecordTypes = new List<PersonRecordType>();

            AccessProfiles = new List<AccessProfile>();
            //Sites = new List<Site>();
            BadgeTemplates = new List<BadgeTemplate>();
            CellCarriers = new List<CellCarrier>();
            CommandScripts = new List<CommandScript>();
            PersonActivationModes = new List<PersonActivationMode>();
            PersonExpirationModes = new List<PersonExpirationMode>();

            CredentialFormats = new List<CredentialFormat>();
            PersonCredentialRoles = new List<PersonCredentialRole>();

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the countries. </summary>
        ///
        /// <value> The countries. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public IList<Country> Countries
        {
            get { return _countries; }
            set
            {
                if (_countries != value)
                {
                    _countries = value;
                    OnPropertyChanged(() => Countries, false);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a list of types of the person active status. </summary>
        ///
        /// <value> A list of types of the person active status. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public IList<PersonActiveStatusType> PersonActiveStatusTypes
        {
            get { return _personActiveStatusTypes; }
            set
            {
                if (_personActiveStatusTypes != value)
                {
                    _personActiveStatusTypes = value;
                    OnPropertyChanged(() => PersonActiveStatusTypes, false);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the genders. </summary>
        ///
        /// <value> The genders. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public IList<Gender> Genders
        {
            get { return _genders; }
            set
            {
                if (_genders != value)
                {
                    _genders = value;
                    OnPropertyChanged(() => Genders, false);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the departments. </summary>
        ///
        /// <value> The departments. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public IList<Department> Departments
        {
            get { return _departments; }
            set
            {
                if (_departments != value)
                {
                    _departments = value;
                    OnPropertyChanged(() => Departments, false);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a list of types of the person records. </summary>
        ///
        /// <value> A list of types of the person records. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public IList<PersonRecordType> PersonRecordTypes
        {
            get { return _personRecordTypes; }
            set
            {
                if (_personRecordTypes != value)
                {
                    _personRecordTypes = value;
                    OnPropertyChanged(() => PersonRecordTypes, false);
                }
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Gets or sets the sites. </summary>
        /////
        ///// <value> The sites. </value>
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        //[DataMember]
        //public IList<Site> Sites
        //{
        //    get { return _sites; }
        //    set
        //    {
        //        if (_sites != value)
        //        {
        //            _sites = value;
        //            OnPropertyChanged(() => Sites, false);
        //        }
        //    }
        //}

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
        /// <summary>   Gets or sets the badge templates. </summary>
        ///
        /// <value> The badge templates. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public IList<BadgeTemplate> BadgeTemplates
        {
            get { return _badgeTemplates; }
            set
            {
                if (_badgeTemplates != value)
                {
                    _badgeTemplates = value;
                    OnPropertyChanged(() => BadgeTemplates, false);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the cell carriers. </summary>
        ///
        /// <value> The cell carriers. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public IList<CellCarrier> CellCarriers
        {
            get { return _cellCarriers; }
            set
            {
                if (_cellCarriers != value)
                {
                    _cellCarriers = value;
                    OnPropertyChanged(() => CellCarriers, false);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the command scripts. </summary>
        ///
        /// <value> The command scripts. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public IList<CommandScript> CommandScripts
        {
            get { return _commandScripts; }
            set
            {
                if (_commandScripts != value)
                {
                    _commandScripts = value;
                    OnPropertyChanged(() => CommandScripts, false);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the person activation modes. </summary>
        ///
        /// <value> The person activation modes. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public IList<PersonActivationMode> PersonActivationModes
        {
            get { return _personActivationModes; }
            set
            {
                if (_personActivationModes != value)
                {
                    _personActivationModes = value;
                    OnPropertyChanged(() => PersonActivationModes, false);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the person expiration modes. </summary>
        ///
        /// <value> The person expiration modes. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public IList<PersonExpirationMode> PersonExpirationModes
        {
            get { return _personExpirationModes; }
            set
            {
                if (_personExpirationModes != value)
                {
                    _personExpirationModes = value;
                    OnPropertyChanged(() => PersonExpirationModes, false);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the credential formats. </summary>
        ///
        /// <value> The credential formats. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public IList<CredentialFormat> CredentialFormats
        {
            get { return _credentialFormats; }
            set
            {
                if (_credentialFormats != value)
                {
                    _credentialFormats = value;
                    OnPropertyChanged(() => CredentialFormats, false);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the person credential roles. </summary>
        ///
        /// <value> The person credential roles. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public IList<PersonCredentialRole> PersonCredentialRoles
        {
            get { return _personCredentialRoles; }
            set
            {
                if (_personCredentialRoles != value)
                {
                    _personCredentialRoles = value;
                    OnPropertyChanged(() => PersonCredentialRoles, false);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the access portal no server reply behaviors. </summary>
        ///
        /// <value> The access portal no server reply behaviors. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public IList<AccessPortalNoServerReplyBehavior> AccessPortalNoServerReplyBehaviors
        {
            get { return _accessPortalNoServerReplyBehaviors; }
            set
            {
                if (_accessPortalNoServerReplyBehaviors != value)
                {
                    _accessPortalNoServerReplyBehaviors = value;
                    OnPropertyChanged(() => AccessPortalNoServerReplyBehaviors, false);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the access portal defer to server behaviors. </summary>
        ///
        /// <value> The access portal defer to server behaviors. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public IList<AccessPortalDeferToServerBehavior> AccessPortalDeferToServerBehaviors
        {
            get { return _accessPortalDeferToServerBehaviors; }
            set
            {
                if (_accessPortalDeferToServerBehaviors != value)
                {
                    _accessPortalDeferToServerBehaviors = value;
                    OnPropertyChanged(() => AccessPortalDeferToServerBehaviors, false);
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