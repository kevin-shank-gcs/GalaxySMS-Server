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
	public partial class ClusterTypeClusterCommand : DbObjectBase, ITableEntityBase
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
        public partial class ClusterTypeClusterCommand
        {
        	public ClusterTypeClusterCommand() : base()
        	{
        		Initialize();
        	}
        
        	public ClusterTypeClusterCommand(ClusterTypeClusterCommand e) : base(e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        		base.Initialize();
        }
        
        	public void Initialize(ClusterTypeClusterCommand e)
        	{
        		Initialize();
        		base.Initialize(e);
        
        		if( e == null )
        			return;
        		this.ClusterTypeClusterCommandUid = e.ClusterTypeClusterCommandUid;
        		this.ClusterTypeUid = e.ClusterTypeUid;
        		this.ClusterCommandUid = e.ClusterCommandUid;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		
        	}
        
        	public ClusterTypeClusterCommand Clone(ClusterTypeClusterCommand e)
        	{
        		return new ClusterTypeClusterCommand(e);
        	}
        
        	public bool Equals(ClusterTypeClusterCommand other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(ClusterTypeClusterCommand other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.ClusterTypeClusterCommandUid != this.ClusterTypeClusterCommandUid )
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
    
    	
    	private System.Guid _clusterTypeClusterCommandUid;
    
    	[DataMember]
    	public System.Guid ClusterTypeClusterCommandUid
    	{ 
    		get { return _clusterTypeClusterCommandUid; }
    		set
    		{
    			if (_clusterTypeClusterCommandUid != value )
    			{
    				_clusterTypeClusterCommandUid = value;
    				OnPropertyChanged(() => ClusterTypeClusterCommandUid);
    			}
    		}
    	}
    	
    	private System.Guid _clusterTypeUid;
    
    	[DataMember]
    	public System.Guid ClusterTypeUid
    	{ 
    		get { return _clusterTypeUid; }
    		set
    		{
    			if (_clusterTypeUid != value )
    			{
    				_clusterTypeUid = value;
    				OnPropertyChanged(() => ClusterTypeUid);
    			}
    		}
    	}
    	
    	private System.Guid _clusterCommandUid;
    
    	[DataMember]
    	public System.Guid ClusterCommandUid
    	{ 
    		get { return _clusterCommandUid; }
    		set
    		{
    			if (_clusterCommandUid != value )
    			{
    				_clusterCommandUid = value;
    				OnPropertyChanged(() => ClusterCommandUid);
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
    
    	
    	private ClusterCommand _clusterCommand;
    
    	[DataMember]
    	public virtual ClusterCommand ClusterCommand
    	{ 
    		get { return _clusterCommand; }
    		set
    		{
    			if (_clusterCommand != value )
    			{
    				_clusterCommand = value;
    				OnPropertyChanged(() => ClusterCommand);
    			}
    		}
    	}
    	
    	private ClusterType _clusterType;
    
    	[DataMember]
    	public virtual ClusterType ClusterType
    	{ 
    		get { return _clusterType; }
    		set
    		{
    			if (_clusterType != value )
    			{
    				_clusterType = value;
    				OnPropertyChanged(() => ClusterType);
    			}
    		}
    	}
    }
    
}
