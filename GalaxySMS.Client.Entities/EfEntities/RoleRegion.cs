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
	public partial class RoleRegion : DbObjectBase, ITableEntityBase
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
        public partial class RoleRegion
        {
        	public RoleRegion() : base()
        	{
        		Initialize();
        	}
        
        	public RoleRegion(RoleRegion e) : base(e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        		base.Initialize();
        		this.RoleRegionPermissions = new HashSet<RoleRegionPermission>();
        }
        
        	public void Initialize(RoleRegion e)
        	{
        		Initialize();
        		base.Initialize(e);
        
        		if( e == null )
        			return;
        		this.RoleRegionUid = e.RoleRegionUid;
        		this.RoleId = e.RoleId;
        		this.RegionUid = e.RegionUid;
        		this.IncludeAllSites = e.IncludeAllSites;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		this.RoleRegionPermissions = e.RoleRegionPermissions.ToCollection();
        		
        	}
        
        	public RoleRegion Clone(RoleRegion e)
        	{
        		return new RoleRegion(e);
        	}
        
        	public bool Equals(RoleRegion other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(RoleRegion other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.RoleRegionUid != this.RoleRegionUid )
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
    
    	
    	private System.Guid _roleRegionUid;
    
    	[DataMember]
    	public System.Guid RoleRegionUid
    	{ 
    		get { return _roleRegionUid; }
    		set
    		{
    			if (_roleRegionUid != value )
    			{
    				_roleRegionUid = value;
    				OnPropertyChanged(() => RoleRegionUid);
    			}
    		}
    	}
    	
    	private System.Guid _roleId;
    
    	[DataMember]
    	public System.Guid RoleId
    	{ 
    		get { return _roleId; }
    		set
    		{
    			if (_roleId != value )
    			{
    				_roleId = value;
    				OnPropertyChanged(() => RoleId);
    			}
    		}
    	}
    	
    	private System.Guid _regionUid;
    
    	[DataMember]
    	public System.Guid RegionUid
    	{ 
    		get { return _regionUid; }
    		set
    		{
    			if (_regionUid != value )
    			{
    				_regionUid = value;
    				OnPropertyChanged(() => RegionUid);
    			}
    		}
    	}
    	
    	private bool _includeAllSites;
    
    	[DataMember]
    	public bool IncludeAllSites
    	{ 
    		get { return _includeAllSites; }
    		set
    		{
    			if (_includeAllSites != value )
    			{
    				_includeAllSites = value;
    				OnPropertyChanged(() => IncludeAllSites);
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
    
    	
    	//private gcsRole _gcsRole;
    
    	//[DataMember]
    	//public virtual gcsRole gcsRole
    	//{ 
    	//	get { return _gcsRole; }
    	//	set
    	//	{
    	//		if (_gcsRole != value )
    	//		{
    	//			_gcsRole = value;
    	//			OnPropertyChanged(() => gcsRole);
    	//		}
    	//	}
    	//}
    	
    	//private Region _region;
    
    	//[DataMember]
    	//public virtual Region Region
    	//{ 
    	//	get { return _region; }
    	//	set
    	//	{
    	//		if (_region != value )
    	//		{
    	//			_region = value;
    	//			OnPropertyChanged(() => Region);
    	//		}
    	//	}
    	//}


        private ICollection<RoleSite> _sites;

        [DataMember]
        public ICollection<RoleSite> Sites
        {
            get { return _sites; }
            set
            {
                if (_sites != value)
                {
                    _sites = value;
                    OnPropertyChanged(() => Sites);
                }
            }
        }

        private ICollection<RoleRegionPermission> _roleRegionPermissions;
    
    	[DataMember]
    	public virtual ICollection<RoleRegionPermission> RoleRegionPermissions
    	{ 
    		get { return _roleRegionPermissions; }
    		set
    		{
    			if (_roleRegionPermissions != value )
    			{
    				_roleRegionPermissions = value;
    				OnPropertyChanged(() => RoleRegionPermissions);
    			}
    		}
    	}
    }
    
}
