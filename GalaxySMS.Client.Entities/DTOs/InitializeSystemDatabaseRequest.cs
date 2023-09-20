////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	DTOs\InitializeSystemDatabaseRequest.cs
//
// summary:	Implements the initialize system database request class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using GCS.Core.Common.Core;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   An initialize system database request. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class InitializeSystemDatabaseRequest : DtoObjectBase
    {
        /// <summary>   List of types of the application audits. </summary>
        private IList<gcsApplicationAuditType> _applicationAuditTypes;

        /// <summary>   The applications. </summary>
        private IList<gcsApplication> _applications;

        /// <summary>   The entities. </summary>
        private IList<gcsEntity> _entities;

        /// <summary>   The languages. </summary>
        private IList<gcsLanguage> _languages;

        /// <summary>   The users. </summary>
        private IList<gcsUser> _users;

        /// <summary>   Information describing the system. </summary>
        private gcsSystem _systemData;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public InitializeSystemDatabaseRequest()
        {
            Init();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the entities. </summary>
        ///
        /// <value> The entities. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public IList<gcsEntity> Entities
        {
            get { return _entities; }
            set
            {
                if (_entities != value)
                {
                    _entities = value;
                    OnPropertyChanged(() => Entities, false);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the languages. </summary>
        ///
        /// <value> The languages. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public IList<gcsLanguage> Languages
        {
            get { return _languages; }
            set
            {
                if (_languages != value)
                {
                    _languages = value;
                    OnPropertyChanged(() => Languages, false);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the applications. </summary>
        ///
        /// <value> The applications. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public IList<gcsApplication> Applications
        {
            get { return _applications; }
            set
            {
                if (_applications != value)
                {
                    _applications = value;
                    OnPropertyChanged(() => Applications, false);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the users. </summary>
        ///
        /// <value> The users. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public IList<gcsUser> Users
        {
            get { return _users; }
            set
            {
                if (_users != value)
                {
                    _users = value;
                    OnPropertyChanged(() => Users, false);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a list of types of the application audits. </summary>
        ///
        /// <value> A list of types of the application audits. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public IList<gcsApplicationAuditType> ApplicationAuditTypes
        {
            get { return _applicationAuditTypes; }
            set
            {
                if (_applicationAuditTypes != value)
                {
                    _applicationAuditTypes = value;
                    OnPropertyChanged(() => ApplicationAuditTypes, false);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets information describing the system. </summary>
        ///
        /// <value> Information describing the system. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public gcsSystem SystemData
        {
            get { return _systemData; }
            set
            {
                if (_systemData != value)
                {
                    _systemData = value;
                    OnPropertyChanged(() => SystemData, false);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initialises this InitializeSystemDatabaseRequest. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void Init()
        {
            Entities = new List<gcsEntity>();
            Languages = new List<gcsLanguage>();
            Applications = new List<gcsApplication>();
            Users = new List<gcsUser>();
            ApplicationAuditTypes = new List<gcsApplicationAuditType>();
            SystemData = new gcsSystem();
        }

        private bool _InitializeSystemTables;

        [DataMember]
        public bool InitializeSystemTables
        {
            get { return _InitializeSystemTables; }
            set
            {
                if (_InitializeSystemTables != value)
                {
                    _InitializeSystemTables = value;
                    OnPropertyChanged(() => InitializeSystemTables, false);
                }
            }
        }

    }
}