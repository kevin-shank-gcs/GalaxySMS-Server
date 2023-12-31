using System;
using System.ComponentModel;
using System.Runtime.Serialization;

using PDSA.Validation;

namespace GalaxySMS.EntityLayer
{
    /// <summary>
    /// This class contains properties for each data value returned, or parameter to be input/output from the Credential_GetActivityEventDataPDSA stored procedure.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>

    public partial class Credential_GetActivityEventDataPDSA : PDSAEntityBase
    {
        #region Private Variables
        private Guid _CredentialUid = Guid.Empty;
        private Guid _PersonUid = Guid.Empty;
        private Guid _PersonCredentialUid = Guid.Empty;
        private Guid _EntityId = Guid.Empty;
        private string _ActivityEventText = string.Empty;
        private string _FirstName = string.Empty;
        private string _MiddleName = string.Empty;
        private string _LastName = string.Empty;
        private string _FullName = string.Empty;
        private string _PreferredName = string.Empty;
        private string _LegalName = string.Empty;
        private string _NickName = string.Empty;
        private string _CardNumber = string.Empty;
        private byte[] _CardBinaryData = null;
        private bool _PersonTrace = false;
        private string _Company = string.Empty;
        private string _EntityName = string.Empty;
        private Guid _DepartmentUid = Guid.Empty;
        private string _DepartmentName = string.Empty;
        private Guid _PersonRecordTypeUid = Guid.Empty;
        private string _RecordType = string.Empty;
        private string _CredentialDescription = string.Empty;
        private bool _CredentialTraceEnabled = false;
        private Guid _PersonExpirationModeUid = Guid.Empty;
        private short _UsageCount = 0;
        private bool _IsActive = false;
        private int _RETURNVALUE = 0;
        #endregion

        #region Public Properties
        /// <summary>
        /// Get/Set the Credential Uid value
        /// </summary>

        [DataMember]

        public Guid CredentialUid
        {
            get { return _CredentialUid; }
            set
            {
                if (HasValueChanged(_CredentialUid, value, "CredentialUid"))
                {
                    _CredentialUid = value;
                    RaisePropertyChanged("CredentialUid");
                }
            }
        }

        /// <summary>
        /// Get/Set the Person Uid value
        /// </summary>

        [DataMember]

        public Guid PersonUid
        {
            get { return _PersonUid; }
            set
            {
                if (HasValueChanged(_PersonUid, value, "PersonUid"))
                {
                    _PersonUid = value;
                    RaisePropertyChanged("PersonUid");
                }
            }
        }

        /// <summary>
        /// Get/Set the Person Credential Uid value
        /// </summary>

        [DataMember]

        public Guid PersonCredentialUid
        {
            get { return _PersonCredentialUid; }
            set
            {
                if (HasValueChanged(_PersonCredentialUid, value, "PersonCredentialUid"))
                {
                    _PersonCredentialUid = value;
                    RaisePropertyChanged("PersonCredentialUid");
                }
            }
        }

        /// <summary>
        /// Get/Set the Entity Id value
        /// </summary>

        [DataMember]

        public Guid EntityId
        {
            get { return _EntityId; }
            set
            {
                if (HasValueChanged(_EntityId, value, "EntityId"))
                {
                    _EntityId = value;
                    RaisePropertyChanged("EntityId");
                }
            }
        }

        /// <summary>
        /// Get/Set the Activity Event Text value
        /// </summary>

        [DataMember]

        public string ActivityEventText
        {
            get { return _ActivityEventText; }
            set
            {
                if (HasValueChanged(_ActivityEventText, value, "ActivityEventText"))
                {
                    _ActivityEventText = value;
                    RaisePropertyChanged("ActivityEventText");
                }
            }
        }

        /// <summary>
        /// Get/Set the First Name value
        /// </summary>

        [DataMember]

        public string FirstName
        {
            get { return _FirstName; }
            set
            {
                if (HasValueChanged(_FirstName, value, "FirstName"))
                {
                    _FirstName = value;
                    RaisePropertyChanged("FirstName");
                }
            }
        }

        /// <summary>
        /// Get/Set the Middle Name value
        /// </summary>

        [DataMember]

        public string MiddleName
        {
            get { return _MiddleName; }
            set
            {
                if (HasValueChanged(_MiddleName, value, "MiddleName"))
                {
                    _MiddleName = value;
                    RaisePropertyChanged("MiddleName");
                }
            }
        }

        /// <summary>
        /// Get/Set the Last Name value
        /// </summary>

        [DataMember]

        public string LastName
        {
            get { return _LastName; }
            set
            {
                if (HasValueChanged(_LastName, value, "LastName"))
                {
                    _LastName = value;
                    RaisePropertyChanged("LastName");
                }
            }
        }

        /// <summary>
        /// Get/Set the Full Name value
        /// </summary>

        [DataMember]

        public string FullName
        {
            get { return _FullName; }
            set
            {
                if (HasValueChanged(_FullName, value, "FullName"))
                {
                    _FullName = value;
                    RaisePropertyChanged("FullName");
                }
            }
        }

        /// <summary>
        /// Get/Set the Preferred Name value
        /// </summary>

        [DataMember]

        public string PreferredName
        {
            get { return _PreferredName; }
            set
            {
                if (HasValueChanged(_PreferredName, value, "PreferredName"))
                {
                    _PreferredName = value;
                    RaisePropertyChanged("PreferredName");
                }
            }
        }

        /// <summary>
        /// Get/Set the Legal Name value
        /// </summary>

        [DataMember]

        public string LegalName
        {
            get { return _LegalName; }
            set
            {
                if (HasValueChanged(_LegalName, value, "LegalName"))
                {
                    _LegalName = value;
                    RaisePropertyChanged("LegalName");
                }
            }
        }

        /// <summary>
        /// Get/Set the Nick Name value
        /// </summary>

        [DataMember]

        public string NickName
        {
            get { return _NickName; }
            set
            {
                if (HasValueChanged(_NickName, value, "NickName"))
                {
                    _NickName = value;
                    RaisePropertyChanged("NickName");
                }
            }
        }

        /// <summary>
        /// Get/Set the Card Number value
        /// </summary>

        [DataMember]

        public string CardNumber
        {
            get { return _CardNumber; }
            set
            {
                if (HasValueChanged(_CardNumber, value, "CardNumber"))
                {
                    _CardNumber = value;
                    RaisePropertyChanged("CardNumber");
                }
            }
        }

        /// <summary>
        /// Get/Set the Card Binary Data value
        /// </summary>

        [DataMember]

        public byte[] CardBinaryData
        {
            get { return _CardBinaryData; }
            set
            {
                if (HasValueChanged(_CardBinaryData, value, "CardBinaryData"))
                {
                    _CardBinaryData = value;
                    RaisePropertyChanged("CardBinaryData");
                }
            }
        }

        /// <summary>
        /// Get/Set the Person Trace value
        /// </summary>

        [DataMember]

        public bool PersonTrace
        {
            get { return _PersonTrace; }
            set
            {
                if (HasValueChanged(_PersonTrace, value, "PersonTrace"))
                {
                    _PersonTrace = value;
                    RaisePropertyChanged("PersonTrace");
                }
            }
        }

        /// <summary>
        /// Get/Set the Company value
        /// </summary>

        [DataMember]

        public string Company
        {
            get { return _Company; }
            set
            {
                if (HasValueChanged(_Company, value, "Company"))
                {
                    _Company = value;
                    RaisePropertyChanged("Company");
                }
            }
        }

        /// <summary>
        /// Get/Set the Entity Name value
        /// </summary>

        [DataMember]

        public string EntityName
        {
            get { return _EntityName; }
            set
            {
                if (HasValueChanged(_EntityName, value, "EntityName"))
                {
                    _EntityName = value;
                    RaisePropertyChanged("EntityName");
                }
            }
        }

        /// <summary>
        /// Get/Set the Department Uid value
        /// </summary>

        [DataMember]

        public Guid DepartmentUid
        {
            get { return _DepartmentUid; }
            set
            {
                if (HasValueChanged(_DepartmentUid, value, "DepartmentUid"))
                {
                    _DepartmentUid = value;
                    RaisePropertyChanged("DepartmentUid");
                }
            }
        }

        /// <summary>
        /// Get/Set the Department Name value
        /// </summary>

        [DataMember]

        public string DepartmentName
        {
            get { return _DepartmentName; }
            set
            {
                if (HasValueChanged(_DepartmentName, value, "DepartmentName"))
                {
                    _DepartmentName = value;
                    RaisePropertyChanged("DepartmentName");
                }
            }
        }

        /// <summary>
        /// Get/Set the Person Record Type Uid value
        /// </summary>

        [DataMember]

        public Guid PersonRecordTypeUid
        {
            get { return _PersonRecordTypeUid; }
            set
            {
                if (HasValueChanged(_PersonRecordTypeUid, value, "PersonRecordTypeUid"))
                {
                    _PersonRecordTypeUid = value;
                    RaisePropertyChanged("PersonRecordTypeUid");
                }
            }
        }

        /// <summary>
        /// Get/Set the Record Type value
        /// </summary>

        [DataMember]

        public string RecordType
        {
            get { return _RecordType; }
            set
            {
                if (HasValueChanged(_RecordType, value, "RecordType"))
                {
                    _RecordType = value;
                    RaisePropertyChanged("RecordType");
                }
            }
        }

        /// <summary>
        /// Get/Set the Credential Description value
        /// </summary>

        [DataMember]

        public string CredentialDescription
        {
            get { return _CredentialDescription; }
            set
            {
                if (HasValueChanged(_CredentialDescription, value, "CredentialDescription"))
                {
                    _CredentialDescription = value;
                    RaisePropertyChanged("CredentialDescription");
                }
            }
        }

        /// <summary>
        /// Get/Set the Credential Trace Enabled value
        /// </summary>

        [DataMember]

        public bool CredentialTraceEnabled
        {
            get { return _CredentialTraceEnabled; }
            set
            {
                if (HasValueChanged(_CredentialTraceEnabled, value, "CredentialTraceEnabled"))
                {
                    _CredentialTraceEnabled = value;
                    RaisePropertyChanged("CredentialTraceEnabled");
                }
            }
        }

        /// <summary>
        /// Get/Set the return value value
        /// </summary>

        [DataMember]

        public int RETURNVALUE
        {
            get { return _RETURNVALUE; }
            set
            {
                if (HasValueChanged(_RETURNVALUE, value, "@RETURN_VALUE"))
                {
                    _RETURNVALUE = value;
                    RaisePropertyChanged("RETURNVALUE");
                }
            }
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the person expiration mode UID. </summary>
        ///
        /// <value> The person expiration mode UID. </value>
        ///=================================================================================================
        [DataMember]
        public Guid PersonExpirationModeUid
        {
            get { return _PersonExpirationModeUid; }
            set
            {
                if (HasValueChanged(_PersonExpirationModeUid, value, "PersonExpirationModeUid"))
                {
                    _PersonExpirationModeUid = value;
                    RaisePropertyChanged("PersonExpirationModeUid");
                }
            }
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the number of usages. </summary>
        ///
        /// <value> The number of usages. </value>
        ///=================================================================================================
        [DataMember]
        public short UsageCount
        {
            get { return _UsageCount; }
            set
            {
                if (HasValueChanged(_UsageCount, value, "UsageCount"))
                {
                    _UsageCount = value;
                    RaisePropertyChanged("UsageCount");
                }
            }
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets or sets a value indicating whether this Credential_GetActivityEventDataPDSA is
        /// active.
        /// </summary>
        ///
        /// <value> True if this Credential_GetActivityEventDataPDSA is active, false if not. </value>
        ///=================================================================================================
        [DataMember]
        public bool IsActive
        {
            get { return _IsActive; }
            set
            {
                if (HasValueChanged(_IsActive, value, "IsActive"))
                {
                    _IsActive = value;
                    RaisePropertyChanged("IsActive");
                }
            }
        }


        #endregion
    }
}
