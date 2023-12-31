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
	public partial class AccessPortalTypeFeatureMap : DbObjectBase, ITableEntityBase
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
        public partial class AccessPortalTypeFeatureMap
        {
        	public AccessPortalTypeFeatureMap() : base()
        	{
        		Initialize();
        	}
        
        	public AccessPortalTypeFeatureMap(AccessPortalTypeFeatureMap e) : base(e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        		base.Initialize();
        }
        
        	public void Initialize(AccessPortalTypeFeatureMap e)
        	{
        		Initialize();
        		base.Initialize(e);
        
        		if( e == null )
        			return;
        		this.AccessPortalTypeFeatureMapUid = e.AccessPortalTypeFeatureMapUid;
        		this.AccessPortalTypeUid = e.AccessPortalTypeUid;
        		this.FeatureUid = e.FeatureUid;
        		this.IsSupported = e.IsSupported;
        		this.IsActive = e.IsActive;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		
        	}
        
        	public AccessPortalTypeFeatureMap Clone(AccessPortalTypeFeatureMap e)
        	{
        		return new AccessPortalTypeFeatureMap(e);
        	}
        
        	public bool Equals(AccessPortalTypeFeatureMap other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(AccessPortalTypeFeatureMap other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.AccessPortalTypeFeatureMapUid != this.AccessPortalTypeFeatureMapUid )
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
    
    	
    	private System.Guid _accessPortalTypeFeatureMapUid;
    
    	[DataMember]
    	public System.Guid AccessPortalTypeFeatureMapUid
    	{ 
    		get { return _accessPortalTypeFeatureMapUid; }
    		set
    		{
    			if (_accessPortalTypeFeatureMapUid != value )
    			{
    				_accessPortalTypeFeatureMapUid = value;
    				OnPropertyChanged(() => AccessPortalTypeFeatureMapUid);
    			}
    		}
    	}
    	
    	private System.Guid _accessPortalTypeUid;
    
    	[DataMember]
    	public System.Guid AccessPortalTypeUid
    	{ 
    		get { return _accessPortalTypeUid; }
    		set
    		{
    			if (_accessPortalTypeUid != value )
    			{
    				_accessPortalTypeUid = value;
    				OnPropertyChanged(() => AccessPortalTypeUid);
    			}
    		}
    	}
    	
    	private System.Guid _featureUid;
    
    	[DataMember]
    	public System.Guid FeatureUid
    	{ 
    		get { return _featureUid; }
    		set
    		{
    			if (_featureUid != value )
    			{
    				_featureUid = value;
    				OnPropertyChanged(() => FeatureUid);
    			}
    		}
    	}
    	
    	private bool _isSupported;
    
    	[DataMember]
    	public bool IsSupported
    	{ 
    		get { return _isSupported; }
    		set
    		{
    			if (_isSupported != value )
    			{
    				_isSupported = value;
    				OnPropertyChanged(() => IsSupported);
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
    
    	
    	private Feature _feature;
    
    	[DataMember]
    	public virtual Feature Feature
    	{ 
    		get { return _feature; }
    		set
    		{
    			if (_feature != value )
    			{
    				_feature = value;
    				OnPropertyChanged(() => Feature);
    			}
    		}
    	}
    }
    
}
