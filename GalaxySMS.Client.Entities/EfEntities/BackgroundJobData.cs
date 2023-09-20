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
	public partial class BackgroundJobData : DbObjectBase
    {
        
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
    	
    	private string _data;
    
    	[DataMember]
    	public string Data
    	{ 
    		get { return _data; }
    		set
    		{
    			if (_data != value )
    			{
    				_data = value;
    				OnPropertyChanged(() => Data);
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
