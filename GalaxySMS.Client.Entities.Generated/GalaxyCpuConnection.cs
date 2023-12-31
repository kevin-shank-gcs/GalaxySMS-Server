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
	public partial class GalaxyCpuConnection : DbObjectBase, ITableEntityBase
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
        public partial class GalaxyCpuConnection
        {
        	public GalaxyCpuConnection() : base()
        	{
        		Initialize();
        	}
        
        	public GalaxyCpuConnection(GalaxyCpuConnection e) : base(e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        		base.Initialize();
        }
        
        	public void Initialize(GalaxyCpuConnection e)
        	{
        		Initialize();
        		base.Initialize(e);
        
        		if( e == null )
        			return;
        		this.CpuUid = e.CpuUid;
        		this.IsConnected = e.IsConnected;
        		this.ServerAddress = e.ServerAddress;
        		this.LastConnectedTime = e.LastConnectedTime;
        		this.LastDisconnectedTime = e.LastDisconnectedTime;
        		
        	}
        
        	public GalaxyCpuConnection Clone(GalaxyCpuConnection e)
        	{
        		return new GalaxyCpuConnection(e);
        	}
        
        	public bool Equals(GalaxyCpuConnection other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(GalaxyCpuConnection other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.CpuUid != this.CpuUid )
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
    
    	
    	private System.Guid _cpuUid;
    
    	[DataMember]
    	public System.Guid CpuUid
    	{ 
    		get { return _cpuUid; }
    		set
    		{
    			if (_cpuUid != value )
    			{
    				_cpuUid = value;
    				OnPropertyChanged(() => CpuUid);
    			}
    		}
    	}
    	
    	private bool _isConnected;
    
    	[DataMember]
    	public bool IsConnected
    	{ 
    		get { return _isConnected; }
    		set
    		{
    			if (_isConnected != value )
    			{
    				_isConnected = value;
    				OnPropertyChanged(() => IsConnected);
    			}
    		}
    	}
    	
    	private string _serverAddress;
    
    	[DataMember]
    	public string ServerAddress
    	{ 
    		get { return _serverAddress; }
    		set
    		{
    			if (_serverAddress != value )
    			{
    				_serverAddress = value;
    				OnPropertyChanged(() => ServerAddress);
    			}
    		}
    	}
    	
    	private Nullable<System.DateTime> _lastConnectedTime;
    
    	[DataMember]
    	public Nullable<System.DateTime> LastConnectedTime
    	{ 
    		get { return _lastConnectedTime; }
    		set
    		{
    			if (_lastConnectedTime != value )
    			{
    				_lastConnectedTime = value;
    				OnPropertyChanged(() => LastConnectedTime);
    			}
    		}
    	}
    	
    	private Nullable<System.DateTime> _lastDisconnectedTime;
    
    	[DataMember]
    	public Nullable<System.DateTime> LastDisconnectedTime
    	{ 
    		get { return _lastDisconnectedTime; }
    		set
    		{
    			if (_lastDisconnectedTime != value )
    			{
    				_lastDisconnectedTime = value;
    				OnPropertyChanged(() => LastDisconnectedTime);
    			}
    		}
    	}
    
    	
    	private GalaxyCpu _galaxyCpu;
    
    	[DataMember]
    	public virtual GalaxyCpu GalaxyCpu
    	{ 
    		get { return _galaxyCpu; }
    		set
    		{
    			if (_galaxyCpu != value )
    			{
    				_galaxyCpu = value;
    				OnPropertyChanged(() => GalaxyCpu);
    			}
    		}
    	}
    }
    
}
