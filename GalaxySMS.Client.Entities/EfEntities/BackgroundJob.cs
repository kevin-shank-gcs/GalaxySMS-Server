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
	public partial class BackgroundJob : DbObjectBase, ITableEntityBase
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
    	
    	private System.Guid _userId;
    
    	[DataMember]
    	public System.Guid UserId
    	{ 
    		get { return _userId; }
    		set
    		{
    			if (_userId != value )
    			{
    				_userId = value;
    				OnPropertyChanged(() => UserId);
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
    	
    	private string _jobType;
    
    	[DataMember]
    	public string JobType
    	{ 
    		get { return _jobType; }
    		set
    		{
    			if (_jobType != value )
    			{
    				_jobType = value;
    				OnPropertyChanged(() => JobType);
    			}
    		}
    	}
    	
    	private string _dataType;
    
    	[DataMember]
    	public string DataType
    	{ 
    		get { return _dataType; }
    		set
    		{
    			if (_dataType != value )
    			{
    				_dataType = value;
    				OnPropertyChanged(() => DataType);
    			}
    		}
    	}
    	
    	private System.Guid _dataItemUid;
    
    	[DataMember]
    	public System.Guid DataItemUid
    	{ 
    		get { return _dataItemUid; }
    		set
    		{
    			if (_dataItemUid != value )
    			{
    				_dataItemUid = value;
    				OnPropertyChanged(() => DataItemUid);
    			}
    		}
    	}

        private string _itemName;

        [DataMember]
        public string ItemName
        {
            get { return _itemName; }
            set
            {
                if (_itemName != value)
                {
                    _itemName = value;
                    OnPropertyChanged(() => ItemName);
                }
            }
        }

        private System.Guid _entityId;

        [DataMember]
        public System.Guid EntityId
        {
            get { return _entityId; }
            set
            {
                if (_entityId != value)
                {
                    _entityId = value;
                    OnPropertyChanged(() => EntityId);
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
    
    	
    	private BackgroundJobData _backgroundJobData;
    
    	[DataMember]
    	public virtual BackgroundJobData BackgroundJobData
    	{ 
    		get { return _backgroundJobData; }
    		set
    		{
    			if (_backgroundJobData != value )
    			{
    				_backgroundJobData = value;
    				OnPropertyChanged(() => BackgroundJobData);
    			}
    		}
    	}
    	
    	private ICollection<BackgroundJobStateChange> _backgroundJobStateChanges;
    
    	[DataMember]
    	public virtual ICollection<BackgroundJobStateChange> BackgroundJobStateChanges
    	{ 
    		get { return _backgroundJobStateChanges; }
    		set
    		{
    			if (_backgroundJobStateChanges != value )
    			{
    				_backgroundJobStateChanges = value;
    				OnPropertyChanged(() => BackgroundJobStateChanges);
    			}
    		}
    	}
    }
    
}
