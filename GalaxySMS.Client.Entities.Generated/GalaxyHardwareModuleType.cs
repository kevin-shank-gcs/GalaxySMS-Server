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
	public partial class GalaxyHardwareModuleType : DbObjectBase, ITableEntityBase
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
        public partial class GalaxyHardwareModuleType
        {
        	public GalaxyHardwareModuleType() : base()
        	{
        		Initialize();
        	}
        
        	public GalaxyHardwareModuleType(GalaxyHardwareModuleType e) : base(e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        		base.Initialize();
        		this.GalaxyHardwareModules = new HashSet<GalaxyHardwareModule>();
        }
        
        	public void Initialize(GalaxyHardwareModuleType e)
        	{
        		Initialize();
        		base.Initialize(e);
        
        		if( e == null )
        			return;
        		this.GalaxyHardwareModuleTypeUid = e.GalaxyHardwareModuleTypeUid;
        		this.ModuleTypeCode = e.ModuleTypeCode;
        		this.Description = e.Description;
        		this.Display = e.Display;
        		this.DisplayResourceKey = e.DisplayResourceKey;
        		this.DescriptionResourceKey = e.DescriptionResourceKey;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		this.NumberOfNodes = e.NumberOfNodes;
        		this.BinaryResourceUid = e.BinaryResourceUid;
        		this.GalaxyHardwareModules = e.GalaxyHardwareModules.ToCollection();
        		
        	}
        
        	public GalaxyHardwareModuleType Clone(GalaxyHardwareModuleType e)
        	{
        		return new GalaxyHardwareModuleType(e);
        	}
        
        	public bool Equals(GalaxyHardwareModuleType other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(GalaxyHardwareModuleType other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.GalaxyHardwareModuleTypeUid != this.GalaxyHardwareModuleTypeUid )
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
    
    	
    	private System.Guid _galaxyHardwareModuleTypeUid;
    
    	[DataMember]
    	public System.Guid GalaxyHardwareModuleTypeUid
    	{ 
    		get { return _galaxyHardwareModuleTypeUid; }
    		set
    		{
    			if (_galaxyHardwareModuleTypeUid != value )
    			{
    				_galaxyHardwareModuleTypeUid = value;
    				OnPropertyChanged(() => GalaxyHardwareModuleTypeUid);
    			}
    		}
    	}
    	
    	private short _moduleTypeCode;
    
    	[DataMember]
    	public short ModuleTypeCode
    	{ 
    		get { return _moduleTypeCode; }
    		set
    		{
    			if (_moduleTypeCode != value )
    			{
    				_moduleTypeCode = value;
    				OnPropertyChanged(() => ModuleTypeCode);
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
    	
    	private string _displayResourceKey;
    
    	[DataMember]
    	public string DisplayResourceKey
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
    	
    	private string _descriptionResourceKey;
    
    	[DataMember]
    	public string DescriptionResourceKey
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
    	
    	private short _numberOfNodes;
    
    	[DataMember]
    	public short NumberOfNodes
    	{ 
    		get { return _numberOfNodes; }
    		set
    		{
    			if (_numberOfNodes != value )
    			{
    				_numberOfNodes = value;
    				OnPropertyChanged(() => NumberOfNodes);
    			}
    		}
    	}
    	
    	private Nullable<System.Guid> _binaryResourceUid;
    
    	[DataMember]
    	public Nullable<System.Guid> BinaryResourceUid
    	{ 
    		get { return _binaryResourceUid; }
    		set
    		{
    			if (_binaryResourceUid != value )
    			{
    				_binaryResourceUid = value;
    				OnPropertyChanged(() => BinaryResourceUid);
    			}
    		}
    	}
    
    	
    	private ICollection<GalaxyHardwareModule> _galaxyHardwareModules;
    
    	[DataMember]
    	public virtual ICollection<GalaxyHardwareModule> GalaxyHardwareModules
    	{ 
    		get { return _galaxyHardwareModules; }
    		set
    		{
    			if (_galaxyHardwareModules != value )
    			{
    				_galaxyHardwareModules = value;
    				OnPropertyChanged(() => GalaxyHardwareModules);
    			}
    		}
    	}
    }
    
}
