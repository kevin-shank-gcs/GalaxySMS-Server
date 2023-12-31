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
	public partial class GalaxyInterfaceBoardSection : DbObjectBase, ITableEntityBase
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
        public partial class GalaxyInterfaceBoardSection
        {
        	public GalaxyInterfaceBoardSection() : base()
        	{
        		Initialize();
        	}
        
        	public GalaxyInterfaceBoardSection(GalaxyInterfaceBoardSection e) : base(e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        		base.Initialize();
        		this.GalaxyHardwareModules = new HashSet<GalaxyHardwareModule>();
        		this.AccessPortalProperties = new HashSet<AccessPortalProperty>();
        		this.GalaxyInterfaceBoardSectionCommandAudits = new HashSet<GalaxyInterfaceBoardSectionCommandAudit>();
        }
        
        	public void Initialize(GalaxyInterfaceBoardSection e)
        	{
        		Initialize();
        		base.Initialize(e);
        
        		if( e == null )
        			return;
        		this.GalaxyInterfaceBoardSectionUid = e.GalaxyInterfaceBoardSectionUid;
        		this.GalaxyInterfaceBoardUid = e.GalaxyInterfaceBoardUid;
        		this.InterfaceBoardSectionModeUid = e.InterfaceBoardSectionModeUid;
        		this.SectionNumber = e.SectionNumber;
        		this.IsSectionActive = e.IsSectionActive;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		this.GalaxyHardwareModules = e.GalaxyHardwareModules.ToCollection();
        		this.AccessPortalProperties = e.AccessPortalProperties.ToCollection();
        		this.GalaxyInterfaceBoardSectionCommandAudits = e.GalaxyInterfaceBoardSectionCommandAudits.ToCollection();
        		
        	}
        
        	public GalaxyInterfaceBoardSection Clone(GalaxyInterfaceBoardSection e)
        	{
        		return new GalaxyInterfaceBoardSection(e);
        	}
        
        	public bool Equals(GalaxyInterfaceBoardSection other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(GalaxyInterfaceBoardSection other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.GalaxyInterfaceBoardSectionUid != this.GalaxyInterfaceBoardSectionUid )
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
    
    	
    	private System.Guid _galaxyInterfaceBoardSectionUid;
    
    	[DataMember]
    	public System.Guid GalaxyInterfaceBoardSectionUid
    	{ 
    		get { return _galaxyInterfaceBoardSectionUid; }
    		set
    		{
    			if (_galaxyInterfaceBoardSectionUid != value )
    			{
    				_galaxyInterfaceBoardSectionUid = value;
    				OnPropertyChanged(() => GalaxyInterfaceBoardSectionUid);
    			}
    		}
    	}
    	
    	private System.Guid _galaxyInterfaceBoardUid;
    
    	[DataMember]
    	public System.Guid GalaxyInterfaceBoardUid
    	{ 
    		get { return _galaxyInterfaceBoardUid; }
    		set
    		{
    			if (_galaxyInterfaceBoardUid != value )
    			{
    				_galaxyInterfaceBoardUid = value;
    				OnPropertyChanged(() => GalaxyInterfaceBoardUid);
    			}
    		}
    	}
    	
    	private System.Guid _interfaceBoardSectionModeUid;
    
    	[DataMember]
    	public System.Guid InterfaceBoardSectionModeUid
    	{ 
    		get { return _interfaceBoardSectionModeUid; }
    		set
    		{
    			if (_interfaceBoardSectionModeUid != value )
    			{
    				_interfaceBoardSectionModeUid = value;
    				OnPropertyChanged(() => InterfaceBoardSectionModeUid);
    			}
    		}
    	}
    	
    	private short _sectionNumber;
    
    	[DataMember]
    	public short SectionNumber
    	{ 
    		get { return _sectionNumber; }
    		set
    		{
    			if (_sectionNumber != value )
    			{
    				_sectionNumber = value;
    				OnPropertyChanged(() => SectionNumber);
    			}
    		}
    	}
    	
    	private bool _isSectionActive;
    
    	[DataMember]
    	public bool IsSectionActive
    	{ 
    		get { return _isSectionActive; }
    		set
    		{
    			if (_isSectionActive != value )
    			{
    				_isSectionActive = value;
    				OnPropertyChanged(() => IsSectionActive);
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
    	
    	private ICollection<AccessPortalProperty> _accessPortalProperties;
    
    	[DataMember]
    	public virtual ICollection<AccessPortalProperty> AccessPortalProperties
    	{ 
    		get { return _accessPortalProperties; }
    		set
    		{
    			if (_accessPortalProperties != value )
    			{
    				_accessPortalProperties = value;
    				OnPropertyChanged(() => AccessPortalProperties);
    			}
    		}
    	}
    	
    	private ICollection<GalaxyInterfaceBoardSectionCommandAudit> _galaxyInterfaceBoardSectionCommandAudits;
    
    	[DataMember]
    	public virtual ICollection<GalaxyInterfaceBoardSectionCommandAudit> GalaxyInterfaceBoardSectionCommandAudits
    	{ 
    		get { return _galaxyInterfaceBoardSectionCommandAudits; }
    		set
    		{
    			if (_galaxyInterfaceBoardSectionCommandAudits != value )
    			{
    				_galaxyInterfaceBoardSectionCommandAudits = value;
    				OnPropertyChanged(() => GalaxyInterfaceBoardSectionCommandAudits);
    			}
    		}
    	}
    }
    
}
