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
    using FluentValidation;
    
	[DataContract]
	public partial class GalaxyInterfaceBoardSectionCommand : DbObjectBase, ITableEntityBase
    {
        	
    	private System.Guid _galaxyInterfaceBoardSectionCommandUid;
    
    	[DataMember]
    	public System.Guid GalaxyInterfaceBoardSectionCommandUid
    	{ 
    		get { return _galaxyInterfaceBoardSectionCommandUid; }
    		set
    		{
    			if (_galaxyInterfaceBoardSectionCommandUid != value )
    			{
    				_galaxyInterfaceBoardSectionCommandUid = value;
    				OnPropertyChanged(() => GalaxyInterfaceBoardSectionCommandUid);
    			}
    		}
    	}
    	
    	private string _display;
    
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
    	
    	private Nullable<System.Guid> _displayResourceKey;
    
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
    	
    	private string _description;
    
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
    	
    	private Nullable<System.Guid> _descriptionResourceKey;
    
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
    	
    	private short _commandCode;
    
    	[DataMember]
    	public short CommandCode
    	{ 
    		get { return _commandCode; }
    		set
    		{
    			if (_commandCode != value )
    			{
    				_commandCode = value;
    				OnPropertyChanged(() => CommandCode);
    			}
    		}
    	}
    	
    	private bool _isActive;
    
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
    	
    	private string _insertName;
    
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
    	
    	private System.DateTimeOffset _insertDate;
    
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
    	
    	private string _updateName;
    
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
    	
    	private Nullable<System.DateTimeOffset> _updateDate;
    
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
    	
    	private Nullable<short> _concurrencyValue;
    
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
