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
	using GCS.Core.Common.Contracts;	using FluentValidation;
    
	[DataContract]
	public partial class GalaxyInputDelayType : DbObjectBase, ITableEntityBase
    {
    
    /*	// Move to partial class
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
	using GCS.Core.Common.Core;
	using GCS.Core.Common.Contracts;	using FluentValidation;
    using System.Collections.ObjectModel;
    using GCS.Core.Common.Extensions;
    
    namespace GalaxySMS.Client.Entities
    {
        public partial class GalaxyInputDelayType
        {
        	public GalaxyInputDelayType() : base()
        	{
        		Initialize();
        	}
        
        	public GalaxyInputDelayType(GalaxyInputDelayType e) : base(e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        		base.Initialize();
        }
        
        	public void Initialize(GalaxyInputDelayType e)
        	{
        		Initialize();
        		base.Initialize(e);
        
        		if( e == null )
        			return;
        		this.GalaxyInputDelayTypeUid = e.GalaxyInputDelayTypeUid;
        		this.Display = e.Display;
        		this.DisplayResourceKey = e.DisplayResourceKey;
        		this.Description = e.Description;
        		this.DescriptionResourceKey = e.DescriptionResourceKey;
        		this.Code = e.Code;
        		this.DisplayOrder = e.DisplayOrder;
        		this.IsDefault = e.IsDefault;
        		this.IsActive = e.IsActive;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		
        	}
        
        	public GalaxyInputDelayType Clone(GalaxyInputDelayType e)
        	{
        		return new GalaxyInputDelayType(e);
        	}
        
        	public bool Equals(GalaxyInputDelayType other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(GalaxyInputDelayType other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.GalaxyInputDelayTypeUid != this.GalaxyInputDelayTypeUid )
        			return false;
        		return true;
        	}
        
        	public override int GetHashCode()
        	{
        		return base.GetHashCode();
        	}
        
        	public override string ToString()
        	{
        		return base.ToString();
        	}
        }
    }
    */
    
    	
    	private System.Guid _galaxyInputDelayTypeUid;
    
    	[DataMember]
    	public System.Guid GalaxyInputDelayTypeUid
    	{ 
    		get { return _galaxyInputDelayTypeUid; }
    		set
    		{
    			if (_galaxyInputDelayTypeUid != value )
    			{
    				_galaxyInputDelayTypeUid = value;
    				OnPropertyChanged(() => GalaxyInputDelayTypeUid);
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
    	
    	private short _code;
    
    	[DataMember]
    	public short Code
    	{ 
    		get { return _code; }
    		set
    		{
    			if (_code != value )
    			{
    				_code = value;
    				OnPropertyChanged(() => Code);
    			}
    		}
    	}
    	
    	private Nullable<int> _displayOrder;
    
    	[DataMember]
    	public Nullable<int> DisplayOrder
    	{ 
    		get { return _displayOrder; }
    		set
    		{
    			if (_displayOrder != value )
    			{
    				_displayOrder = value;
    				OnPropertyChanged(() => DisplayOrder);
    			}
    		}
    	}
    	
    	private Nullable<bool> _isDefault;
    
    	[DataMember]
    	public Nullable<bool> IsDefault
    	{ 
    		get { return _isDefault; }
    		set
    		{
    			if (_isDefault != value )
    			{
    				_isDefault = value;
    				OnPropertyChanged(() => IsDefault);
    			}
    		}
    	}
    	
    	private Nullable<bool> _isActive;
    
    	[DataMember]
    	public Nullable<bool> IsActive
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
    	
    	private Nullable<System.DateTime> _insertDate;
    
    	[DataMember]
    	public Nullable<System.DateTime> InsertDate
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
    	
    	private Nullable<System.DateTime> _updateDate;
    
    	[DataMember]
    	public Nullable<System.DateTime> UpdateDate
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
    
    	
    	private gcsResourceString _gcsResourceString;
    
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
    }
    
}
