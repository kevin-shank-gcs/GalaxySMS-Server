//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using GalaxySMS.Common.Interfaces;

namespace GalaxySMS.Client.Entities
{
	using System;
	using System.Collections.Generic;
	using System.Runtime.Serialization;
	using GCS.Core.Common.Core;
	using GCS.Core.Common.Contracts;
	using FluentValidation;
	using GalaxySMS.Common.Enums;

	////////////////////////////////////////////////////////////////////////////////////////////////////
	/// <summary>   A credential format. </summary>
	///
	/// <remarks>   Kevin, 12/26/2018. </remarks>
	////////////////////////////////////////////////////////////////////////////////////////////////////

	[DataContract]
	[KnownType(typeof(CredentialFormatDataField))]
	[KnownType(typeof(CredentialFormatParity))]
	public partial class CredentialFormat : DbObjectBase, ITableEntityBase, IHasEntityMappingList, ICredentialFormatDefinition
	{
		
		/// <summary>   The credential format UID. </summary>
		private System.Guid _credentialFormatUid;

		////////////////////////////////////////////////////////////////////////////////////////////////////
		/// <summary>   Gets or sets the credential format UID. </summary>
		///
		/// <value> The credential format UID. </value>
		////////////////////////////////////////////////////////////////////////////////////////////////////

		[DataMember]
		public System.Guid CredentialFormatUid
		{ 
			get { return _credentialFormatUid; }
			set
			{
				if (_credentialFormatUid != value )
				{
					_credentialFormatUid = value;
					OnPropertyChanged(() => CredentialFormatUid);
				}
			}
		}
		
		/// <summary>   The display resource key. </summary>
		private Nullable<System.Guid> _displayResourceKey;

		////////////////////////////////////////////////////////////////////////////////////////////////////
		/// <summary>   Gets or sets the display resource key. </summary>
		///
		/// <value> The display resource key. </value>
		////////////////////////////////////////////////////////////////////////////////////////////////////

		[DataMember]
		public Nullable<System.Guid> DisplayResourceKey
		{ 
			get { return _displayResourceKey; }
			set
			{
				if (_displayResourceKey != value )
				{
					_displayResourceKey = value;
					OnPropertyChanged(() => DisplayResourceKey);
				}
			}
		}
		
		/// <summary>   The description resource key. </summary>
		private Nullable<System.Guid> _descriptionResourceKey;

		////////////////////////////////////////////////////////////////////////////////////////////////////
		/// <summary>   Gets or sets the description resource key. </summary>
		///
		/// <value> The description resource key. </value>
		////////////////////////////////////////////////////////////////////////////////////////////////////

		[DataMember]
		public Nullable<System.Guid> DescriptionResourceKey
		{ 
			get { return _descriptionResourceKey; }
			set
			{
				if (_descriptionResourceKey != value )
				{
					_descriptionResourceKey = value;
					OnPropertyChanged(() => DescriptionResourceKey);
				}
			}
		}
		
		/// <summary>   The display. </summary>
		private string _display;

		////////////////////////////////////////////////////////////////////////////////////////////////////
		/// <summary>   Gets or sets the display. </summary>
		///
		/// <value> The display. </value>
		////////////////////////////////////////////////////////////////////////////////////////////////////

		[DataMember]
		public string Display
		{ 
			get { return _display; }
			set
			{
				if (_display != value )
				{
					_display = value;
					OnPropertyChanged(() => Display);
				}
			}
		}
		
		/// <summary>   The description. </summary>
		private string _description;

		////////////////////////////////////////////////////////////////////////////////////////////////////
		/// <summary>   Gets or sets the description. </summary>
		///
		/// <value> The description. </value>
		////////////////////////////////////////////////////////////////////////////////////////////////////

		[DataMember]
		public string Description
		{ 
			get { return _description; }
			set
			{
				if (_description != value )
				{
					_description = value;
					OnPropertyChanged(() => Description);
				}
			}
		}
		
		/// <summary>   The credential format code. </summary>
		private CredentialFormatCodes _credentialFormatCode;

		////////////////////////////////////////////////////////////////////////////////////////////////////
		/// <summary>   Gets or sets the credential format code. </summary>
		///
		/// <value> The credential format code. </value>
		////////////////////////////////////////////////////////////////////////////////////////////////////

		[DataMember]
		public CredentialFormatCodes CredentialFormatCode
		{ 
			get { return _credentialFormatCode; }
			set
			{
				if (_credentialFormatCode != value )
				{
					_credentialFormatCode = value;
					OnPropertyChanged(() => CredentialFormatCode);
				}
			}
		}
		
		/// <summary>   Length of the bit. </summary>
		private short _bitLength;

		////////////////////////////////////////////////////////////////////////////////////////////////////
		/// <summary>   Gets or sets the length of the bit. </summary>
		///
		/// <value> The length of the bit. </value>
		////////////////////////////////////////////////////////////////////////////////////////////////////

		[DataMember]
		public short BitLength
		{ 
			get { return _bitLength; }
			set
			{
				if (_bitLength != value )
				{
					_bitLength = value;
					OnPropertyChanged(() => BitLength);
				}
			}
		}
		
		/// <summary>   True if this CredentialFormat is enabled. </summary>
		private bool _isEnabled;

		////////////////////////////////////////////////////////////////////////////////////////////////////
		/// <summary>   Gets or sets a value indicating whether this CredentialFormat is enabled. </summary>
		///
		/// <value> True if this CredentialFormat is enabled, false if not. </value>
		////////////////////////////////////////////////////////////////////////////////////////////////////

		[DataMember]
		public bool IsEnabled
		{ 
			get { return _isEnabled; }
			set
			{
				if (_isEnabled != value )
				{
					_isEnabled = value;
					OnPropertyChanged(() => IsEnabled);
				}
			}
		}
		
		/// <summary>   True if biometric enrollment supported. </summary>
		private bool _biometricEnrollmentSupported;

		////////////////////////////////////////////////////////////////////////////////////////////////////
		/// <summary>
		/// Gets or sets a value indicating whether the biometric enrollment supported.
		/// </summary>
		///
		/// <value> True if biometric enrollment supported, false if not. </value>
		////////////////////////////////////////////////////////////////////////////////////////////////////

		[DataMember]
		public bool BiometricEnrollmentSupported
		{ 
			get { return _biometricEnrollmentSupported; }
			set
			{
				if (_biometricEnrollmentSupported != value )
				{
					_biometricEnrollmentSupported = value;
					OnPropertyChanged(() => BiometricEnrollmentSupported);
				}
			}
		}
		
		/// <summary>   The biometric identifier field. </summary>
		private short _biometricIdField;

		////////////////////////////////////////////////////////////////////////////////////////////////////
		/// <summary>   Gets or sets the biometric identifier field. </summary>
		///
		/// <value> The biometric identifier field. </value>
		////////////////////////////////////////////////////////////////////////////////////////////////////

		[DataMember]
		public short BiometricIdField
		{ 
			get { return _biometricIdField; }
			set
			{
				if (_biometricIdField != value )
				{
					_biometricIdField = value;
					OnPropertyChanged(() => BiometricIdField);
				}
			}
		}
		
		/// <summary>   True to use full card code. </summary>
		private bool _useCardNumber;

		////////////////////////////////////////////////////////////////////////////////////////////////////
		/// <summary>
		/// Gets or sets a value indicating whether this CredentialFormat use full card code.
		/// </summary>
		///
		/// <value> True if use full card code, false if not. </value>
		////////////////////////////////////////////////////////////////////////////////////////////////////

		[DataMember]
		public bool UseCardNumber
		{ 
			get { return _useCardNumber; }
			set
			{
				if (_useCardNumber != value )
				{
					_useCardNumber = value;
					OnPropertyChanged(() => UseCardNumber);
				}
			}
		}
		
		/// <summary>   True if batch load supported. </summary>
		private bool _batchLoadSupported;

		////////////////////////////////////////////////////////////////////////////////////////////////////
		/// <summary>   Gets or sets a value indicating whether the batch load supported. </summary>
		///
		/// <value> True if batch load supported, false if not. </value>
		////////////////////////////////////////////////////////////////////////////////////////////////////

		[DataMember]
		public bool BatchLoadSupported
		{ 
			get { return _batchLoadSupported; }
			set
			{
				if (_batchLoadSupported != value )
				{
					_batchLoadSupported = value;
					OnPropertyChanged(() => BatchLoadSupported);
				}
			}
		}
		
		/// <summary>   The batch load increment field. </summary>
		private short _batchLoadIncrementField;

		////////////////////////////////////////////////////////////////////////////////////////////////////
		/// <summary>   Gets or sets the batch load increment field. </summary>
		///
		/// <value> The batch load increment field. </value>
		////////////////////////////////////////////////////////////////////////////////////////////////////

		[DataMember]
		public short BatchLoadIncrementField
		{ 
			get { return _batchLoadIncrementField; }
			set
			{
				if (_batchLoadIncrementField != value )
				{
					_batchLoadIncrementField = value;
					OnPropertyChanged(() => BatchLoadIncrementField);
				}
			}
		}
		
		/// <summary>   Name of the insert. </summary>
		private string _insertName;

		////////////////////////////////////////////////////////////////////////////////////////////////////
		/// <summary>   Gets or sets the name of the insert. </summary>
		///
		/// <value> The name of the insert. </value>
		////////////////////////////////////////////////////////////////////////////////////////////////////

		[DataMember]
		public string InsertName
		{ 
			get { return _insertName; }
			set
			{
				if (_insertName != value )
				{
					_insertName = value;
					OnPropertyChanged(() => InsertName);
				}
			}
		}
		
		/// <summary>   The insert date. </summary>
		private System.DateTimeOffset _insertDate;

		////////////////////////////////////////////////////////////////////////////////////////////////////
		/// <summary>   Gets or sets the insert date. </summary>
		///
		/// <value> The insert date. </value>
		////////////////////////////////////////////////////////////////////////////////////////////////////

		[DataMember]
		public System.DateTimeOffset InsertDate
		{ 
			get { return _insertDate; }
			set
			{
				if (_insertDate != value )
				{
					_insertDate = value;
					OnPropertyChanged(() => InsertDate);
				}
			}
		}
		
		/// <summary>   Name of the update. </summary>
		private string _updateName;

		////////////////////////////////////////////////////////////////////////////////////////////////////
		/// <summary>   Gets or sets the name of the update. </summary>
		///
		/// <value> The name of the update. </value>
		////////////////////////////////////////////////////////////////////////////////////////////////////

		[DataMember]
		public string UpdateName
		{ 
			get { return _updateName; }
			set
			{
				if (_updateName != value )
				{
					_updateName = value;
					OnPropertyChanged(() => UpdateName);
				}
			}
		}
		
		/// <summary>   The update. </summary>
		private Nullable<System.DateTimeOffset> _updateDate;

		////////////////////////////////////////////////////////////////////////////////////////////////////
		/// <summary>   Gets or sets the update. </summary>
		///
		/// <value> The update date. </value>
		////////////////////////////////////////////////////////////////////////////////////////////////////

		[DataMember]
		public Nullable<System.DateTimeOffset> UpdateDate
		{ 
			get { return _updateDate; }
			set
			{
				if (_updateDate != value )
				{
					_updateDate = value;
					OnPropertyChanged(() => UpdateDate);
				}
			}
		}
		
		/// <summary>   The concurrency value. </summary>
		private Nullable<short> _concurrencyValue;

		////////////////////////////////////////////////////////////////////////////////////////////////////
		/// <summary>   Gets or sets the concurrency value. </summary>
		///
		/// <value> The concurrency value. </value>
		////////////////////////////////////////////////////////////////////////////////////////////////////

		[DataMember]
		public Nullable<short> ConcurrencyValue
		{ 
			get { return _concurrencyValue; }
			set
			{
				if (_concurrencyValue != value )
				{
					_concurrencyValue = value;
					OnPropertyChanged(() => ConcurrencyValue);
				}
			}
		}
	
		
	 //   /// <summary>   The credentials. </summary>
		//private ICollection<Credential> _credentials;

	 //   ////////////////////////////////////////////////////////////////////////////////////////////////////
	 //   /// <summary>   Gets or sets the credentials. </summary>
	 //   ///
	 //   /// <value> The credentials. </value>
	 //   ////////////////////////////////////////////////////////////////////////////////////////////////////

		//[DataMember]
		//public virtual ICollection<Credential> Credentials
		//{ 
		//	get { return _credentials; }
		//	set
		//	{
		//		if (_credentials != value )
		//		{
		//			_credentials = value;
		//			OnPropertyChanged(() => Credentials);
		//		}
		//	}
		//}
		
		/// <summary>   The credential format data fields. </summary>
		private ICollection<ICredentialFormatDataField> _credentialFormatDataFields;

		////////////////////////////////////////////////////////////////////////////////////////////////////
		/// <summary>   Gets or sets the credential format data fields. </summary>
		///
		/// <value> The credential format data fields. </value>
		////////////////////////////////////////////////////////////////////////////////////////////////////

		[DataMember]
		public virtual ICollection<ICredentialFormatDataField> CredentialFormatDataFields
		{ 
			get { return _credentialFormatDataFields; }
			set
			{
				if (_credentialFormatDataFields != value )
				{
					_credentialFormatDataFields = value;
					OnPropertyChanged(() => CredentialFormatDataFields);
				}
			}
		}
		
		/// <summary>   The gcs resource string. </summary>
		private gcsResourceString _gcsResourceString;

		////////////////////////////////////////////////////////////////////////////////////////////////////
		/// <summary>   Gets or sets the gcs resource string. </summary>
		///
		/// <value> The gcs resource string. </value>
		////////////////////////////////////////////////////////////////////////////////////////////////////

		[DataMember]
		public virtual gcsResourceString gcsResourceString
		{ 
			get { return _gcsResourceString; }
			set
			{
				if (_gcsResourceString != value )
				{
					_gcsResourceString = value;
					OnPropertyChanged(() => gcsResourceString);
				}
			}
		}
		
		/// <summary>   The credential format parities. </summary>
		private ICollection<ICredentialFormatParity> _credentialFormatParities;

		////////////////////////////////////////////////////////////////////////////////////////////////////
		/// <summary>   Gets or sets the credential format parities. </summary>
		///
		/// <value> The credential format parities. </value>
		////////////////////////////////////////////////////////////////////////////////////////////////////

		[DataMember]
		public virtual ICollection<ICredentialFormatParity> CredentialFormatParities
		{ 
			get { return _credentialFormatParities; }
			set
			{
				if (_credentialFormatParities != value )
				{
					_credentialFormatParities = value;
					OnPropertyChanged(() => CredentialFormatParities);
				}
			}
		}

		/// <summary>   List of identifiers for the entities. </summary>
		private ICollection<Guid> _entityIds;

		////////////////////////////////////////////////////////////////////////////////////////////////////
		/// <summary>   Gets or sets a list of identifiers of the entities. </summary>
		///
		/// <value> A list of identifiers of the entities. </value>
		////////////////////////////////////////////////////////////////////////////////////////////////////

		[DataMember]
		public virtual ICollection<Guid> EntityIds
		{
			get { return _entityIds; }
			set
			{
				if (_entityIds != value)
				{
					_entityIds = value;
					OnPropertyChanged(() => EntityIds);
				}
			}
		}

		/// <summary>   The mapped entities permission levels. </summary>
		private ICollection<EntityIdEntityMapPermissionLevel> _MappedEntitiesPermissionLevels;

		////////////////////////////////////////////////////////////////////////////////////////////////////
		/// <summary>   Gets or sets the mapped entities permission levels. </summary>
		///
		/// <value> The mapped entities permission levels. </value>
		////////////////////////////////////////////////////////////////////////////////////////////////////

		[DataMember]
		public virtual ICollection<EntityIdEntityMapPermissionLevel> MappedEntitiesPermissionLevels
		{
			get { return _MappedEntitiesPermissionLevels; }
			set
			{
				if (_MappedEntitiesPermissionLevels != value)
				{
					_MappedEntitiesPermissionLevels = value;
					OnPropertyChanged(() => MappedEntitiesPermissionLevels);
				}
			}
		}

	}

}
