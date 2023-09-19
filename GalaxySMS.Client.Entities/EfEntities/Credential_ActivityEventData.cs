////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	EfEntities\Credential_ActivityEventData.cs
//
// summary:	Implements the credential activity event data class
////////////////////////////////////////////////////////////////////////////////////////////////////

using GCS.Core.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Utils;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A credential activity event data. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class Credential_ActivityEventData : ObjectBase
    {
        #region Private Variables
        /// <summary>   The credential UID. </summary>
        private Guid _CredentialUid = Guid.Empty;
        /// <summary>   The person UID. </summary>
        private Guid _PersonUid = Guid.Empty;
        /// <summary>   The person credential UID. </summary>
        private Guid _PersonCredentialUid = Guid.Empty;
        /// <summary>   Identifier for the entity. </summary>
        private Guid _EntityId = Guid.Empty;
        /// <summary>   The activity event text. </summary>
        private string _ActivityEventText = string.Empty;
        /// <summary>   The person's first name. </summary>
        private string _FirstName = string.Empty;
        /// <summary>   The person's middle name. </summary>
        private string _MiddleName = string.Empty;
        /// <summary>   The person's last name. </summary>
        private string _LastName = string.Empty;
        /// <summary>   Name of the full. </summary>
        private string _FullName = string.Empty;
        /// <summary>   Name of the preferred. </summary>
        private string _PreferredName = string.Empty;
        /// <summary>   Name of the legal. </summary>
        private string _LegalName = string.Empty;
        /// <summary>   Name of the nick. </summary>
        private string _NickName = string.Empty;
        /// <summary>   The card number. </summary>
        private string _CardNumber = string.Empty;
        /// <summary>   Information describing the card binary. </summary>
        private byte[] _CardBinaryData = null;
        /// <summary>   True to person trace. </summary>
        private bool _PersonTrace = false;
        /// <summary>   The company. </summary>
        private string _Company = string.Empty;
        /// <summary>   Name of the entity. </summary>
        private string _EntityName = string.Empty;
        /// <summary>   The department UID. </summary>
        private Guid _DepartmentUid = Guid.Empty;
        /// <summary>   Name of the department. </summary>
        private string _DepartmentName = string.Empty;
        /// <summary>   The person record type UID. </summary>
        private Guid _PersonRecordTypeUid = Guid.Empty;
        /// <summary>   Type of the record. </summary>
        private string _RecordType = string.Empty;
        /// <summary>   Information describing the credential. </summary>
        private string _CredentialDescription = string.Empty;
        /// <summary>   True to enable, false to disable the credential trace. </summary>
        private bool _CredentialTraceEnabled = false;
        private Guid _PersonExpirationModeUid;
        private bool _IsActive;
        private short _UsageCount;
        #endregion

        #region Public Properties

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Credential Uid value. </summary>
        ///
        /// <value> The credential UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public Guid CredentialUid
        {
            get { return _CredentialUid; }
            set
            {
                if (_CredentialUid != value)
                {
                    _CredentialUid = value;
                    OnPropertyChanged(() => CredentialUid);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Person Uid value. </summary>
        ///
        /// <value> The person UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public Guid PersonUid
        {
            get { return _PersonUid; }
            set
            {
                if (_PersonUid != value)
                {
                    _PersonUid = value;
                    OnPropertyChanged(() => PersonUid);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Person Credential Uid value. </summary>
        ///
        /// <value> The person credential UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public Guid PersonCredentialUid
        {
            get { return _PersonCredentialUid; }
            set
            {
                if (_PersonCredentialUid != value)
                {
                    _PersonCredentialUid = value;
                    OnPropertyChanged(() => PersonCredentialUid);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Entity Id value. </summary>
        ///
        /// <value> The identifier of the entity. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public Guid EntityId
        {
            get { return _EntityId; }
            set
            {
                if (_EntityId != value)
                {
                    _EntityId = value;
                    OnPropertyChanged(() => EntityId);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Activity Event Text value. </summary>
        ///
        /// <value> The activity event text. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public string ActivityEventText
        {
            get { return _ActivityEventText; }
            set
            {
                if (_ActivityEventText != value)
                {
                    _ActivityEventText = value;
                    OnPropertyChanged(() => ActivityEventText);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the First Name value. </summary>
        ///
        /// <value> The name of the first. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public string FirstName
        {
            get { return _FirstName; }
            set
            {
                if (_FirstName != value)
                {
                    _FirstName = value;
                    OnPropertyChanged(() => FirstName);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Middle Name value. </summary>
        ///
        /// <value> The name of the middle. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public string MiddleName
        {
            get { return _MiddleName; }
            set
            {
                if (_MiddleName != value)
                {
                    _MiddleName = value;
                    OnPropertyChanged(() => MiddleName);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Last Name value. </summary>
        ///
        /// <value> The name of the last. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public string LastName
        {
            get { return _LastName; }
            set
            {
                if (_LastName != value)
                {
                    _LastName = value;
                    OnPropertyChanged(() => LastName);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Full Name value. </summary>
        ///
        /// <value> The name of the full. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public string FullName
        {
            get { return _FullName; }
            set
            {
                if (_FullName != value)
                {
                    _FullName = value;
                    OnPropertyChanged(() => FullName);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Preferred Name value. </summary>
        ///
        /// <value> The name of the preferred. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public string PreferredName
        {
            get { return _PreferredName; }
            set
            {
                if (_PreferredName != value)
                {
                    _PreferredName = value;
                    OnPropertyChanged(() => PreferredName);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Legal Name value. </summary>
        ///
        /// <value> The name of the legal. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public string LegalName
        {
            get { return _LegalName; }
            set
            {
                if (_LegalName != value)
                {
                    _LegalName = value;
                    OnPropertyChanged(() => LegalName);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Nick Name value. </summary>
        ///
        /// <value> The name of the nick. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public string NickName
        {
            get { return _NickName; }
            set
            {
                if (_NickName != value)
                {
                    _NickName = value;
                    OnPropertyChanged(() => NickName);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Card Number value. </summary>
        ///
        /// <value> The card number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public string CardNumber
        {
            get { return _CardNumber; }
            set
            {
                if (_CardNumber != value)
                {
                    _CardNumber = value;
                    OnPropertyChanged(() => CardNumber);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Card Binary Data value. </summary>
        ///
        /// <value> Information describing the card binary. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public byte[] CardBinaryData
        {
            get { return _CardBinaryData; }
            set
            {
                if (_CardBinaryData != value)
                {
                    _CardBinaryData = value;
                    OnPropertyChanged(() => CardBinaryData);
                }
            }
        }

        public string CardBinaryDataAsHexString
        {
            get
            {
                return HexEncoding.ToString(CardBinaryData, true, "0x", false, 32);
                return string.Empty;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Person Trace value. </summary>
        ///
        /// <value> True if person trace, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public bool PersonTrace
        {
            get { return _PersonTrace; }
            set
            {
                if (_PersonTrace != value)
                {
                    _PersonTrace = value;
                    OnPropertyChanged(() => PersonTrace);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Company value. </summary>
        ///
        /// <value> The company. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public string Company
        {
            get { return _Company; }
            set
            {
                if (_Company != value)
                {
                    _Company = value;
                    OnPropertyChanged(() => Company);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Entity Name value. </summary>
        ///
        /// <value> The name of the entity. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public string EntityName
        {
            get { return _EntityName; }
            set
            {
                if (_EntityName != value)
                {
                    _EntityName = value;
                    OnPropertyChanged(() => EntityName);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Department Uid value. </summary>
        ///
        /// <value> The department UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public Guid DepartmentUid
        {
            get { return _DepartmentUid; }
            set
            {
                if (_DepartmentUid != value)
                {
                    _DepartmentUid = value;
                    OnPropertyChanged(() => DepartmentUid);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Department Name value. </summary>
        ///
        /// <value> The name of the department. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public string DepartmentName
        {
            get { return _DepartmentName; }
            set
            {
                if (_DepartmentName != value)
                {
                    _DepartmentName = value;
                    OnPropertyChanged(() => DepartmentName);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Person Record Type Uid value. </summary>
        ///
        /// <value> The person record type UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public Guid PersonRecordTypeUid
        {
            get { return _PersonRecordTypeUid; }
            set
            {
                if (_PersonRecordTypeUid != value)
                {
                    _PersonRecordTypeUid = value;
                    OnPropertyChanged(() => PersonRecordTypeUid);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Record Type value. </summary>
        ///
        /// <value> The type of the record. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public string RecordType
        {
            get { return _RecordType; }
            set
            {
                if (_RecordType != value)
                {
                    _RecordType = value;
                    OnPropertyChanged(() => RecordType);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Credential Description value. </summary>
        ///
        /// <value> Information describing the credential. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public string CredentialDescription
        {
            get { return _CredentialDescription; }
            set
            {
                if (_CredentialDescription != value)
                {
                    _CredentialDescription = value;
                    OnPropertyChanged(() => CredentialDescription);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the Credential Trace Enabled value. </summary>
        ///
        /// <value> True if credential trace enabled, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public bool CredentialTraceEnabled
        {
            get { return _CredentialTraceEnabled; }
            set
            {
                if (_CredentialTraceEnabled != value)
                {
                    _CredentialTraceEnabled = value;
                    OnPropertyChanged(() => CredentialTraceEnabled);
                }
            }
        }

        [DataMember]

        public Guid PersonExpirationModeUid
        {
            get { return _PersonExpirationModeUid; }
            set
            {
                if (_PersonExpirationModeUid != value)
                {
                    _PersonExpirationModeUid = value;
                    OnPropertyChanged(() => PersonExpirationModeUid);
                }
            }
        }


        [DataMember]

        public short UsageCount
        {
            get { return _UsageCount; }
            set
            {
                if (_UsageCount != value)
                {
                    _UsageCount = value;
                    OnPropertyChanged(() => UsageCount);
                }
            }
        }

        [DataMember]

        public bool IsActive
        {
            get { return _IsActive; }
            set
            {
                if (_IsActive != value)
                {
                    _IsActive = value;
                    OnPropertyChanged(() => IsActive);
                }
            }
        }

        #endregion
    }
}
