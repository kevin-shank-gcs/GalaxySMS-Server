//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GalaxySMS.Client.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
	using GCS.Core.Common.Core;
	using GCS.Core.Common.Contracts;
    using GalaxySMS.Common.Interfaces;
    using FluentValidation;

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A credential format data field. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

	[DataContract]
	public partial class CredentialFormatDataField : DbObjectBase, ITableEntityBase, ICredentialFormatDataField
    {
   	
        /// <summary>   The credential format data field UID. </summary>
    	private System.Guid _credentialFormatDataFieldUid;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the credential format data field UID. </summary>
        ///
        /// <value> The credential format data field UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public System.Guid CredentialFormatDataFieldUid
    	{ 
    		get { return _credentialFormatDataFieldUid; }
    		set
    		{
    			if (_credentialFormatDataFieldUid != value )
    			{
    				_credentialFormatDataFieldUid = value;
    				OnPropertyChanged(() => CredentialFormatDataFieldUid);
    			}
    		}
    	}
    	
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
    	
        /// <summary>   Name of the field. </summary>
    	private string _fieldName;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the field. </summary>
        ///
        /// <value> The name of the field. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public string FieldName
    	{ 
    		get { return _fieldName; }
    		set
    		{
    			if (_fieldName != value )
    			{
    				_fieldName = value;
    				OnPropertyChanged(() => FieldName);
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
    	
        /// <summary>   The starts at. </summary>
    	private short _startsAt;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the starts at. </summary>
        ///
        /// <value> The starts at. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public short StartsAt
    	{ 
    		get { return _startsAt; }
    		set
    		{
    			if (_startsAt != value )
    			{
    				_startsAt = value;
    				OnPropertyChanged(() => StartsAt);
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
    	
        /// <summary>   The minimum value. </summary>
    	private ulong _minimumValue;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the minimum value. </summary>
        ///
        /// <value> The minimum value. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public ulong MinimumValue
    	{ 
    		get { return _minimumValue; }
    		set
    		{
    			if (_minimumValue != value )
    			{
    				_minimumValue = value;
    				OnPropertyChanged(() => MinimumValue);
    			}
    		}
    	}
    	
        /// <summary>   The maximum value. </summary>
    	private ulong _maximumValue;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the maximum value. </summary>
        ///
        /// <value> The maximum value. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public ulong MaximumValue
    	{ 
    		get { return _maximumValue; }
    		set
    		{
    			if (_maximumValue != value )
    			{
    				_maximumValue = value;
    				OnPropertyChanged(() => MaximumValue);
    			}
    		}
    	}
    	
        /// <summary>   The field number. </summary>
    	private short _fieldNumber;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the field number. </summary>
        ///
        /// <value> The field number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public short FieldNumber
    	{ 
    		get { return _fieldNumber; }
    		set
    		{
    			if (_fieldNumber != value )
    			{
    				_fieldNumber = value;
    				OnPropertyChanged(() => FieldNumber);
    			}
    		}
    	}
    	
        /// <summary>   True if this CredentialFormatDataField is read only. </summary>
    	private bool _isReadOnly;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets or sets a value indicating whether this CredentialFormatDataField is read only.
        /// </summary>
        ///
        /// <value> True if this CredentialFormatDataField is read only, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public bool IsReadOnly
    	{ 
    		get { return _isReadOnly; }
    		set
    		{
    			if (_isReadOnly != value )
    			{
    				_isReadOnly = value;
    				OnPropertyChanged(() => IsReadOnly);
    			}
    		}
    	}
    	
        /// <summary>   True if this CredentialFormatDataField is visible. </summary>
    	private bool _isVisible;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets or sets a value indicating whether this CredentialFormatDataField is visible.
        /// </summary>
        ///
        /// <value> True if this CredentialFormatDataField is visible, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public bool IsVisible
    	{ 
    		get { return _isVisible; }
    		set
    		{
    			if (_isVisible != value )
    			{
    				_isVisible = value;
    				OnPropertyChanged(() => IsVisible);
    			}
    		}
    	}
    	
        /// <summary>   The default value. </summary>
    	private ulong _defaultValue;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the default value. </summary>
        ///
        /// <value> The default value. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public ulong DefaultValue
    	{ 
    		get { return _defaultValue; }
    		set
    		{
    			if (_defaultValue != value )
    			{
    				_defaultValue = value;
    				OnPropertyChanged(() => DefaultValue);
    			}
    		}
    	}

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets or sets a value indicating whether this CredentialFormatDataField is dirty.
        /// </summary>
        ///
        /// <value> True if this CredentialFormatDataField is dirty, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public bool IsDirty
        {
            get
            { return base.IsDirty; }
            set
            {
                base.IsDirty = value;
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
    
    	
        /// <summary>   The credential format. </summary>
    	private CredentialFormat _credentialFormat;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the credential format. </summary>
        ///
        /// <value> The credential format. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public virtual CredentialFormat CredentialFormat
    	{ 
    		get { return _credentialFormat; }
    		set
    		{
    			if (_credentialFormat != value )
    			{
    				_credentialFormat = value;
    				OnPropertyChanged(() => CredentialFormat);
    			}
    		}
    	}
    }
    
}
