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
	public partial class GalaxyClusterTimeScheduleMap : DbObjectBase, ITableEntityBase
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
        public partial class GalaxyClusterTimeScheduleMap
        {
        	public GalaxyClusterTimeScheduleMap() : base()
        	{
        		Initialize();
        	}
        
        	public GalaxyClusterTimeScheduleMap(GalaxyClusterTimeScheduleMap e) : base(e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        		base.Initialize();
        }
        
        	public void Initialize(GalaxyClusterTimeScheduleMap e)
        	{
        		Initialize();
        		base.Initialize(e);
        
        		if( e == null )
        			return;
        		this.GalaxyClusterTimeScheduleMapUid = e.GalaxyClusterTimeScheduleMapUid;
        		this.TimeScheduleUid = e.TimeScheduleUid;
        		this.ClusterUid = e.ClusterUid;
        		this.PanelScheduleNumber = e.PanelScheduleNumber;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		
        	}
        
        	public GalaxyClusterTimeScheduleMap Clone(GalaxyClusterTimeScheduleMap e)
        	{
        		return new GalaxyClusterTimeScheduleMap(e);
        	}
        
        	public bool Equals(GalaxyClusterTimeScheduleMap other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(GalaxyClusterTimeScheduleMap other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.GalaxyClusterTimeScheduleMapUid != this.GalaxyClusterTimeScheduleMapUid )
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
    
    	
    	private System.Guid _galaxyClusterTimeScheduleMapUid;
    
    	[DataMember]
    	public System.Guid GalaxyClusterTimeScheduleMapUid
    	{ 
    		get { return _galaxyClusterTimeScheduleMapUid; }
    		set
    		{
    			if (_galaxyClusterTimeScheduleMapUid != value )
    			{
    				_galaxyClusterTimeScheduleMapUid = value;
    				OnPropertyChanged(() => GalaxyClusterTimeScheduleMapUid);
    			}
    		}
    	}
    	
    	private System.Guid _timeScheduleUid;
    
    	[DataMember]
    	public System.Guid TimeScheduleUid
    	{ 
    		get { return _timeScheduleUid; }
    		set
    		{
    			if (_timeScheduleUid != value )
    			{
    				_timeScheduleUid = value;
    				OnPropertyChanged(() => TimeScheduleUid);
    			}
    		}
    	}
    	
    	private System.Guid _clusterUid;
    
    	[DataMember]
    	public System.Guid ClusterUid
    	{ 
    		get { return _clusterUid; }
    		set
    		{
    			if (_clusterUid != value )
    			{
    				_clusterUid = value;
    				OnPropertyChanged(() => ClusterUid);
    			}
    		}
    	}
    	
    	private int _panelScheduleNumber;
    
    	[DataMember]
    	public int PanelScheduleNumber
    	{ 
    		get { return _panelScheduleNumber; }
    		set
    		{
    			if (_panelScheduleNumber != value )
    			{
    				_panelScheduleNumber = value;
    				OnPropertyChanged(() => PanelScheduleNumber);
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
    	
    	private System.DateTime _insertDate;
    
    	[DataMember]
    	public System.DateTime InsertDate
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
    
    	
    	private Cluster _cluster;
    
    	[DataMember]
    	public virtual Cluster Cluster
    	{ 
    		get { return _cluster; }
    		set
    		{
    			if (_cluster != value )
    			{
    				_cluster = value;
    				OnPropertyChanged(() => Cluster);
    			}
    		}
    	}
    }
    
}
