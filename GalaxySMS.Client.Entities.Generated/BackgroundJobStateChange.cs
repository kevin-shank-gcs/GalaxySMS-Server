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
	public partial class BackgroundJobStateChange : DbObjectBase, ITableEntityBase
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
        public partial class BackgroundJobStateChange
        {
        	public BackgroundJobStateChange() : base()
        	{
        		Initialize();
        	}
        
        	public BackgroundJobStateChange(BackgroundJobStateChange e) : base(e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        		base.Initialize();
        }
        
        	public void Initialize(BackgroundJobStateChange e)
        	{
        		Initialize();
        		base.Initialize(e);
        
        		if( e == null )
        			return;
        		this.BackgroundJobStateChangeUid = e.BackgroundJobStateChangeUid;
        		this.BackgroundJobUid = e.BackgroundJobUid;
        		this.ChangeDateTime = e.ChangeDateTime;
        		this.State = e.State;
        		this.Info = e.Info;
        		
        	}
        
        	public BackgroundJobStateChange Clone(BackgroundJobStateChange e)
        	{
        		return new BackgroundJobStateChange(e);
        	}
        
        	public bool Equals(BackgroundJobStateChange other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(BackgroundJobStateChange other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.BackgroundJobStateChangeUid != this.BackgroundJobStateChangeUid )
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
    
    	
    	private System.Guid _backgroundJobStateChangeUid;
    
    	[DataMember]
    	public System.Guid BackgroundJobStateChangeUid
    	{ 
    		get { return _backgroundJobStateChangeUid; }
    		set
    		{
    			if (_backgroundJobStateChangeUid != value )
    			{
    				_backgroundJobStateChangeUid = value;
    				OnPropertyChanged(() => BackgroundJobStateChangeUid);
    			}
    		}
    	}
    	
    	private System.Guid _backgroundJobUid;
    
    	[DataMember]
    	public System.Guid BackgroundJobUid
    	{ 
    		get { return _backgroundJobUid; }
    		set
    		{
    			if (_backgroundJobUid != value )
    			{
    				_backgroundJobUid = value;
    				OnPropertyChanged(() => BackgroundJobUid);
    			}
    		}
    	}
    	
    	private System.DateTime _changeDateTime;
    
    	[DataMember]
    	public System.DateTime ChangeDateTime
    	{ 
    		get { return _changeDateTime; }
    		set
    		{
    			if (_changeDateTime != value )
    			{
    				_changeDateTime = value;
    				OnPropertyChanged(() => ChangeDateTime);
    			}
    		}
    	}
    	
    	private string _state;
    
    	[DataMember]
    	public string State
    	{ 
    		get { return _state; }
    		set
    		{
    			if (_state != value )
    			{
    				_state = value;
    				OnPropertyChanged(() => State);
    			}
    		}
    	}
    	
    	private string _info;
    
    	[DataMember]
    	public string Info
    	{ 
    		get { return _info; }
    		set
    		{
    			if (_info != value )
    			{
    				_info = value;
    				OnPropertyChanged(() => Info);
    			}
    		}
    	}
    
    	
    	private BackgroundJob _backgroundJob;
    
    	[DataMember]
    	public virtual BackgroundJob BackgroundJob
    	{ 
    		get { return _backgroundJob; }
    		set
    		{
    			if (_backgroundJob != value )
    			{
    				_backgroundJob = value;
    				OnPropertyChanged(() => BackgroundJob);
    			}
    		}
    	}
    }
    
}
