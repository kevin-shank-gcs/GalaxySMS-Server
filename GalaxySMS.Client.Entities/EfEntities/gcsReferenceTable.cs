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
	using FluentValidation;

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   The gcs reference table. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

	[DataContract]
	public partial class gcsReferenceTable : DbObjectBase
    {
        /// <summary>   Identifier for the reference table. </summary>
    	private System.Guid _referenceTableId;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of the reference table. </summary>
        ///
        /// <value> The identifier of the reference table. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public System.Guid ReferenceTableId
    	{ 
    		get { return _referenceTableId; }
    		set
    		{
    			if (_referenceTableId != value )
    			{
    				_referenceTableId = value;
    				OnPropertyChanged(() => ReferenceTableId);
    			}
    		}
    	}
        
        /// <summary>   Identifier for the application. </summary>
    	private System.Guid _applicationId;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of the application. </summary>
        ///
        /// <value> The identifier of the application. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public System.Guid ApplicationId
    	{ 
    		get { return _applicationId; }
    		set
    		{
    			if (_applicationId != value )
    			{
    				_applicationId = value;
    				OnPropertyChanged(() => ApplicationId);
    			}
    		}
    	}
        
        /// <summary>   Identifier for the language. </summary>
    	private System.Guid _languageId;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of the language. </summary>
        ///
        /// <value> The identifier of the language. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public System.Guid LanguageId
    	{ 
    		get { return _languageId; }
    		set
    		{
    			if (_languageId != value )
    			{
    				_languageId = value;
    				OnPropertyChanged(() => LanguageId);
    			}
    		}
    	}
        
        /// <summary>   Name of the table. </summary>
    	private string _tableName;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the table. </summary>
        ///
        /// <value> The name of the table. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public string TableName
    	{ 
    		get { return _tableName; }
    		set
    		{
    			if (_tableName != value )
    			{
    				_tableName = value;
    				OnPropertyChanged(() => TableName);
    			}
    		}
    	}
        
        /// <summary>   Name of the table display. </summary>
    	private string _tableDisplayName;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the table display. </summary>
        ///
        /// <value> The name of the table display. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public string TableDisplayName
    	{ 
    		get { return _tableDisplayName; }
    		set
    		{
    			if (_tableDisplayName != value )
    			{
    				_tableDisplayName = value;
    				OnPropertyChanged(() => TableDisplayName);
    			}
    		}
    	}
        
        /// <summary>   The table display name resource key. </summary>
    	private Nullable<System.Guid> _tableDisplayNameResourceKey;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the table display name resource key. </summary>
        ///
        /// <value> The table display name resource key. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public Nullable<System.Guid> TableDisplayNameResourceKey
    	{ 
    		get { return _tableDisplayNameResourceKey; }
    		set
    		{
    			if (_tableDisplayNameResourceKey != value )
    			{
    				_tableDisplayNameResourceKey = value;
    				OnPropertyChanged(() => TableDisplayNameResourceKey);
    			}
    		}
    	}
        
        /// <summary>   Name of the primary key column. </summary>
    	private string _primaryKeyColumnName;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the primary key column. </summary>
        ///
        /// <value> The name of the primary key column. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public string PrimaryKeyColumnName
    	{ 
    		get { return _primaryKeyColumnName; }
    		set
    		{
    			if (_primaryKeyColumnName != value )
    			{
    				_primaryKeyColumnName = value;
    				OnPropertyChanged(() => PrimaryKeyColumnName);
    			}
    		}
    	}
        
        /// <summary>   True if this gcsReferenceTable is active. </summary>
    	private bool _isActive;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether this gcsReferenceTable is active. </summary>
        ///
        /// <value> True if this gcsReferenceTable is active, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public bool IsActive
    	{ 
    		get { return _isActive; }
    		set
    		{
    			if (_isActive != value )
    			{
    				_isActive = value;
    				OnPropertyChanged(() => IsActive);
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
    }
    
}
