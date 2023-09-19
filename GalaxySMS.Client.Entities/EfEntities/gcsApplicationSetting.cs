
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
    /// <summary>   The gcs application setting. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

	[DataContract]
	public partial class gcsApplicationSetting : DbObjectBase
    {
       
        /// <summary>   Identifier for the application setting. </summary>
    	private System.Guid _applicationSettingId;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of the application setting. </summary>
        ///
        /// <value> The identifier of the application setting. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public System.Guid ApplicationSettingId
    	{ 
    		get { return _applicationSettingId; }
    		set
    		{
    			if (_applicationSettingId != value )
    			{
    				_applicationSettingId = value;
    				OnPropertyChanged(() => ApplicationSettingId);
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
        
        /// <summary>   The setting key. </summary>
    	private string _settingKey;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the setting key. </summary>
        ///
        /// <value> The setting key. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public string SettingKey
    	{ 
    		get { return _settingKey; }
    		set
    		{
    			if (_settingKey != value )
    			{
    				_settingKey = value;
    				OnPropertyChanged(() => SettingKey);
    			}
    		}
    	}
        
        /// <summary>   The setting value. </summary>
    	private string _settingValue;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the setting value. </summary>
        ///
        /// <value> The setting value. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public string SettingValue
    	{ 
    		get { return _settingValue; }
    		set
    		{
    			if (_settingValue != value )
    			{
    				_settingValue = value;
    				OnPropertyChanged(() => SettingValue);
    			}
    		}
    	}
        
        /// <summary>   Information describing the setting. </summary>
    	private string _settingDescription;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets information describing the setting. </summary>
        ///
        /// <value> Information describing the setting. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public string SettingDescription
    	{ 
    		get { return _settingDescription; }
    		set
    		{
    			if (_settingDescription != value )
    			{
    				_settingDescription = value;
    				OnPropertyChanged(() => SettingDescription);
    			}
    		}
    	}
        
        /// <summary>   True if this gcsApplicationSetting is active. </summary>
    	private bool _isActive;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets or sets a value indicating whether this gcsApplicationSetting is active.
        /// </summary>
        ///
        /// <value> True if this gcsApplicationSetting is active, false if not. </value>
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
        
        /// <summary>   The category. </summary>
    	private string _category;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the category. </summary>
        ///
        /// <value> The category. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public string Category
    	{ 
    		get { return _category; }
    		set
    		{
    			if (_category != value )
    			{
    				_category = value;
    				OnPropertyChanged(() => Category);
    			}
    		}
    	}
    }
    
}
