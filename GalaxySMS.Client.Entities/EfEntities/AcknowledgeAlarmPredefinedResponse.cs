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
	public partial class AcknowledgeAlarmPredefinedResponse : DbObjectBase, ITableEntityBase
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
        public partial class AcknowledgeAlarmPredefinedResponse
        {
        	public AcknowledgeAlarmPredefinedResponse() : base()
        	{
        		Initialize();
        	}
        
        	public AcknowledgeAlarmPredefinedResponse(AcknowledgeAlarmPredefinedResponse e) : base(e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        		base.Initialize();
        }
        
        	public void Initialize(AcknowledgeAlarmPredefinedResponse e)
        	{
        		Initialize();
        		base.Initialize(e);
        
        		if( e == null )
        			return;
        		this.AcknowledgeAlarmPredefinedResponseUid = e.AcknowledgeAlarmPredefinedResponseUid;
        		this.EntityId = e.EntityId;
        		this.Response = e.Response;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		
        	}
        
        	public AcknowledgeAlarmPredefinedResponse Clone(AcknowledgeAlarmPredefinedResponse e)
        	{
        		return new AcknowledgeAlarmPredefinedResponse(e);
        	}
        
        	public bool Equals(AcknowledgeAlarmPredefinedResponse other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(AcknowledgeAlarmPredefinedResponse other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.AcknowledgeAlarmPredefinedResponseUid != this.AcknowledgeAlarmPredefinedResponseUid )
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
    
    	
    	private System.Guid _acknowledgeAlarmPredefinedResponseUid;
    
    	[DataMember]
    	public System.Guid AcknowledgeAlarmPredefinedResponseUid
    	{ 
    		get { return _acknowledgeAlarmPredefinedResponseUid; }
    		set
    		{
    			if (_acknowledgeAlarmPredefinedResponseUid != value )
    			{
    				_acknowledgeAlarmPredefinedResponseUid = value;
    				OnPropertyChanged(() => AcknowledgeAlarmPredefinedResponseUid);
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
    			if (_entityId != value )
    			{
    				_entityId = value;
    				OnPropertyChanged(() => EntityId);
    			}
    		}
    	}
    	
    	private string _response;
    
    	[DataMember]
    	public string Response
    	{ 
    		get { return _response; }
    		set
    		{
    			if (_response != value )
    			{
    				_response = value;
    				OnPropertyChanged(() => Response);
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
    
    	
    	private gcsEntity _gcsEntity;
    
    	[DataMember]
    	public virtual gcsEntity gcsEntity
    	{ 
    		get { return _gcsEntity; }
    		set
    		{
    			if (_gcsEntity != value )
    			{
    				_gcsEntity = value;
    				OnPropertyChanged(() => gcsEntity);
    			}
    		}
    	}
    }
    
}
