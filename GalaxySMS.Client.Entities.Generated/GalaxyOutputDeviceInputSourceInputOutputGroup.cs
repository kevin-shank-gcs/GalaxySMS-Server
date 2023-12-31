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
	public partial class GalaxyOutputDeviceInputSourceInputOutputGroup : DbObjectBase, ITableEntityBase
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
        public partial class GalaxyOutputDeviceInputSourceInputOutputGroup
        {
        	public GalaxyOutputDeviceInputSourceInputOutputGroup() : base()
        	{
        		Initialize();
        	}
        
        	public GalaxyOutputDeviceInputSourceInputOutputGroup(GalaxyOutputDeviceInputSourceInputOutputGroup e) : base(e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        		base.Initialize();
        }
        
        	public void Initialize(GalaxyOutputDeviceInputSourceInputOutputGroup e)
        	{
        		Initialize();
        		base.Initialize(e);
        
        		if( e == null )
        			return;
        		this.GalaxyOutputDeviceInputSourceInputOutputGroupUid = e.GalaxyOutputDeviceInputSourceInputOutputGroupUid;
        		this.GalaxyOutputDeviceInputSourceUid = e.GalaxyOutputDeviceInputSourceUid;
        		this.InputOutputGroupUid = e.InputOutputGroupUid;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		
        	}
        
        	public GalaxyOutputDeviceInputSourceInputOutputGroup Clone(GalaxyOutputDeviceInputSourceInputOutputGroup e)
        	{
        		return new GalaxyOutputDeviceInputSourceInputOutputGroup(e);
        	}
        
        	public bool Equals(GalaxyOutputDeviceInputSourceInputOutputGroup other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(GalaxyOutputDeviceInputSourceInputOutputGroup other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.GalaxyOutputDeviceInputSourceInputOutputGroupUid != this.GalaxyOutputDeviceInputSourceInputOutputGroupUid )
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
    
    	
    	private System.Guid _galaxyOutputDeviceInputSourceInputOutputGroupUid;
    
    	[DataMember]
    	public System.Guid GalaxyOutputDeviceInputSourceInputOutputGroupUid
    	{ 
    		get { return _galaxyOutputDeviceInputSourceInputOutputGroupUid; }
    		set
    		{
    			if (_galaxyOutputDeviceInputSourceInputOutputGroupUid != value )
    			{
    				_galaxyOutputDeviceInputSourceInputOutputGroupUid = value;
    				OnPropertyChanged(() => GalaxyOutputDeviceInputSourceInputOutputGroupUid);
    			}
    		}
    	}
    	
    	private System.Guid _galaxyOutputDeviceInputSourceUid;
    
    	[DataMember]
    	public System.Guid GalaxyOutputDeviceInputSourceUid
    	{ 
    		get { return _galaxyOutputDeviceInputSourceUid; }
    		set
    		{
    			if (_galaxyOutputDeviceInputSourceUid != value )
    			{
    				_galaxyOutputDeviceInputSourceUid = value;
    				OnPropertyChanged(() => GalaxyOutputDeviceInputSourceUid);
    			}
    		}
    	}
    	
    	private System.Guid _inputOutputGroupUid;
    
    	[DataMember]
    	public System.Guid InputOutputGroupUid
    	{ 
    		get { return _inputOutputGroupUid; }
    		set
    		{
    			if (_inputOutputGroupUid != value )
    			{
    				_inputOutputGroupUid = value;
    				OnPropertyChanged(() => InputOutputGroupUid);
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
    
    	
    	private GalaxyOutputDeviceInputSource _galaxyOutputDeviceInputSource;
    
    	[DataMember]
    	public virtual GalaxyOutputDeviceInputSource GalaxyOutputDeviceInputSource
    	{ 
    		get { return _galaxyOutputDeviceInputSource; }
    		set
    		{
    			if (_galaxyOutputDeviceInputSource != value )
    			{
    				_galaxyOutputDeviceInputSource = value;
    				OnPropertyChanged(() => GalaxyOutputDeviceInputSource);
    			}
    		}
    	}
    }
    
}
